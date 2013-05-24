from odmdata import SessionFactory
from odmdata import Site
from odmdata import Variable
from odmdata import Unit
from odmdata import Series
from odmdata import DataValue
from odmdata import QualityControlLevel
from odmdata import Qualifier
from odmdata import ODMVersion

from sqlalchemy import distinct

class SeriesService():

	# Accepts a string for creating a SessionFactory, default uses odmdata/connection.cfg
	def __init__(self, connection_string="", debug=False):
		self._session_factory = SessionFactory(connection_string, debug)
		self._edit_session = self._session_factory.get_session()
		self._debug = debug

	def get_test_data(self):
		return self._edit_session.query(ODMVersion).first()

	# Sites methods
	def get_sites(self, site_code = ""):
		result = None
		if (site_code):
			result = self._edit_session.query(distinct(Series.site_id), Series.site_code, Series.site_name).filter_by(site_code=site_code).one()
		else:
			result = self._edit_session.query(distinct(Series.site_id), Series.site_code, Series.site_name).order_by(Series.site_code).all()

		return result

	# Variables methods
	def get_variables(self, site_code = ""):	# covers NoDV, VarUnits, TimeUnits
		result = None
		if (site_code):
			result = self._edit_session.query(
				distinct(Series.variable_id), Series.variable_code, Series.variable_name).filter_by(site_code=site_code).order_by(Series.variable_code
			).all()
		else:
			result = self._edit_session.query(distinct(Variable.variable_id), Series.variable_code, Series.variable_name).order_by(Series.variable_code).all()

		return result

	def get_variable_by_id(self, variable_id):
		return self._edit_session.query(Variable).filter_by(id=variable_id).one()
		
	def get_no_data_value(self, variable_id):
		return self._edit_session.query(Variable.no_data_value).filter_by(id = variable_id).one()

	# Unit methods
	def get_unit_by_name(self, unit_name):
		return self._edit_session.query(Unit).filter_by(name=unit_name).one()

	def get_unit_by_id(self, unit_id):
		return self._edit_session.query(Unit).filter_by(id=unit_id).one()

	def get_unit_abbrev_by_name(self, unit_name):
		try:
			result = self._edit_session.query(Unit.abbreviation).filter_by(name=unit_name).one()[0]
		except:
			result = None
		return result

	# Series Catalog methods
	def get_series(self, site_code="", var_code=""):
		result = None
		if (site_code and var_code):
			result = self._edit_session.query(Series).filter_by(site_code=site_code, variable_code=var_code).order_by(Series.id).all()
		elif (site_code):
			result = self._edit_session.query(Series).filter_by(site_code=site_code).order_by(Series.id).all()
		elif (var_code):
			result = self._edit_session.query(Series).filter_by(variable_code=var_code).order_by(Series.id).all()
		else:
			result = self._edit_session.query(Series).order_by(Series.id).all()
		return result
	
	def get_series_by_id(self, series_id):
		return self._edit_session.query(Series).filter_by(id=series_id).order_by(Series.id).one()

	def get_series_test(self):
		return self._edit_session.query(Series.id, Series.site_id, Series.site_code, Series.site_name, Series.variable_id, Series.variable_code,
									Series.variable_name, Series.speciation, Series.variable_units_id, Series.variable_units_name, Series.sample_medium,
									Series.value_type, Series.time_support, Series.time_units_id, Series.time_units_name, Series.data_type, Series.general_category,
									Series.method_id, Series.method_description, Series.source_id, Series.organization, Series.source_description,
									Series.citation, Series.quality_control_level_id, Series.quality_control_level_code, Series.begin_date_time, 
									Series.end_date_time, Series.begin_date_time_utc, Series.end_date_time_utc, Series.value_count
								).order_by(Series.id).all()

	def get_series_from_filter(self):
		# Pass in probably a Series object, match it against the database
		pass

	
	def get_data_values_by_series_id(self, series_id):
		return self.get_data_values_by_series_test(self.get_series_by_id(series_id))#.order_by(DataValue.local_date_time).all()

	# DataValues by Series	
	def get_data_values_by_series(self, series):
		return self._edit_session.query(DataValue).filter_by(
								variable_id=series.variable_id, 
								site_id=series.site_id,
								method_id=series.method_id,
								source_id=series.source_id,
								quality_control_level_id=series.quality_control_level_id).order_by(DataValue.local_date_time).all()

	def get_data_values_by_series_test(self, series):
		return self._edit_session.query(DataValue.id, DataValue.data_value, DataValue.value_accuracy, DataValue.local_date_time,  DataValue.utc_offset,DataValue.date_time_utc,
							   DataValue.site_id, DataValue.variable_id, DataValue.offset_value, DataValue.offset_type_id, DataValue.censor_code,
							   DataValue.qualifier_id, DataValue.method_id, DataValue.source_id, DataValue.sample_id, DataValue.derived_from_id,
							   DataValue.quality_control_level_id).filter_by(
								variable_id=series.variable_id, 
								site_id=series.site_id,
								method_id=series.method_id,
								source_id=series.source_id,
								quality_control_level_id=series.quality_control_level_id).order_by(DataValue.local_date_time).all()

	def get_data_value_by_id(self, id):
		try:
			result = self._edit_session.query(DataValue).filter_by(id=id).one()
		except:
			result = None
		return result

	# Quality Control Level methods
	def get_qcl_definition(self, qcl_id):
		try:
			result = self._edit_session.query(QualityControlLevel.definition).filter_by(id=qcl_id).one()
		except:
			result = None
		return result


	# Edit/delete methods
	def delete_dvs(self, dv_list):
		for dv in dv_list:
			merged_dv = self._edit_session.merge(dv)
			self._edit_session.delete(merged_dv)
		self._edit_session.commit()

	def update_dvs(self, dv_list):
		merged_dv_list = map(self._edit_session.merge, dv_list)
		self._edit_session.add_all(merged_dv_list)
		self._edit_session.commit()

	def create_method(self, method):
		new_method = self._edit_session.merge(method)
		self._edit_session.add(new_method)
		self._edit_session.commit()

	def create_new_series(self, data_values, variable_id, site_id, method_id, source_id, qcl_id):
		self.update_dvs(data_values)
		series = Series()
		series.variable_id = variable_id
		series.site_id = site_id
		series.method_id = method_id
		series.source_id = source_id
		series.quality_control_level_id = qcl_id

		self._edit_session.add(series)
		self._edit_session.commit()

	def create_qualifier(self, code, description):
		qualifier = Qualifier()
		qualifier.code = code
		qualifier.description = description

		self._edit_session.add(qualifier)
		self._edit_session.commit()

	def create_variable(self, code, name, speciation, variable_unit, sample_medium, 
		value_type, is_regular, time_support, time_unit, data_type, general_category, no_data_value):
		var = Variable()
		var.code = code
		var.name = name
		var.speciation = speciation
		var.variable_unit = variable_unit
		var.sample_medium = sample_medium
		var.value_type =  value_type
		var.is_regular = is_regular
		var.time_support = time_support
		var.time_unit = time_unit
		var.data_type = data_type
		var.general_category = general_category
		var.no_data_value = no_data_value

		self._edit_session.add(var)
		self._edit_session.commit()

	def update_series_catalog(self, series):
		merged_series = self._edit_session.merge(series)
		self._edit_session.add(merged_series)
		self._edit_session.commit()

	def create_qcl(self, code, definition, explanation):
		qcl = QualityControlLevel()
		qcl.code = code
		qcl.definition = definition
		qcl.explanation = explanation

		self._edit_session.add(qcl)
		self._edit_session.commit()

	def delete_series(self, series):
		data_values = self.get_data_values_by_series(series)
		self.delete_dvs(data_values)

		delete_series = self._edit_session.merge(series)
		self._edit_session.delete(delete_series)
		self._edit_session.commit()