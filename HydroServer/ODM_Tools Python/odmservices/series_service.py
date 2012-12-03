from odmdata.session_factory import SessionFactory
from odmdata.site import Site
from odmdata.variable import Variable
from odmdata.unit import Unit
from odmdata.series import Series
from odmdata.data_value import DataValue
from odmdata.quality_control_level import QualityControlLevel

from sqlalchemy import distinct

class SeriesService():

	# Accepts a string for creating a SessionFactory, default uses odmdata/connection.cfg
	def __init__(self, connection_string="", debug=False):
		self._session_factory = SessionFactory(connection_string, debug)
		self._edit_session = self._session_factory.get_session()
		self._debug = debug

	# Creates a new session factory with the given connection string
	def change_connection(connection_string):
		self._session_factory = SessionFactory(connection_string, self._debug)
		self._edit_session = self._session_factory.get_session()

	# Sites methods
	def get_sites(self, site_code = ""):
		session = self._session_factory.get_session()
		result = None
		if (site_code):
			result = session.query(distinct(Series.site_id), Series.site_code, Series.site_name).filter_by(site_code=site_code).one()
		else:
			result = session.query(distinct(Series.site_id), Series.site_code, Series.site_name).order_by(Series.site_code).all()

		session.close()
		return result

	# Variables methods
	def get_variables(self, site_code = ""):	# covers NoDV, VarUnits, TimeUnits
		session = self._session_factory.get_session()
		result = None
		if (site_code):
			result = session.query(
				distinct(Series.variable_id), Series.variable_code, Series.variable_name).filter_by(site_code=site_code).order_by(Series.variable_code
			).all()
		else:
			result = session.query(distinct(Series.variable_id), Series.variable_code, Series.variable_name).order_by(Series.variable_code).all()

		session.close()
		return result

	# Unit methods
	def get_unit_by_name(self, unit_name):
		session = self._session_factory.get_session()
		result = session.query(Unit).filter_by(name=unit_name).one()
		session.close()
		return result

	def get_unit_by_id(self, unit_id):
		session = self._session_factory.get_session()
		result = session.query(Unit).filter_by(id=unit_id).one()
		session.close()
		return result

	def get_unit_abbrev_by_name(self, unit_name):
		session = self._session_factory.get_session()
		try:
			result = session.query(Unit.abbreviation).filter_by(name=unit_name).one()[0]
		except:
			result = None
		session.close()
		return result

	# Series Catalog methods
	def get_series(self, site_code="", var_code=""):
		session = self._session_factory.get_session()
		result = None
		if (site_code and var_code):
			result = session.query(Series).filter_by(site_code=site_code, variable_code=var_code).order_by(Series.id).all()
		elif (site_code):
			result = session.query(Series).filter_by(site_code=site_code).order_by(Series.id).all()
		elif (var_code):
			result = session.query(Series).filter_by(variable_code=var_code).order_by(Series.id).all()
		else:
			result = session.query(Series).order_by(Series.id).all()
		session.close()
		return result

	def get_series_from_filter(self):
		# Pass in probably a Series object, match it against the database
		pass

	# DataValues by Series
	def get_data_values_by_series(self, series):
		session = self._session_factory.get_session()
		result = session.query(DataValue).filter_by(
								variable_id=series.variable_id, 
								site_id=series.site_id,
								method_id=series.method_id,
								source_id=series.source_id,
								quality_control_level_id=series.quality_control_level_id).order_by(DataValue.local_date_time).all()
		session.close()
		return result

	def get_data_value_by_id(self, id):
		session = self._session_factory.get_session()
		try:
			result = session.query(DataValue).filter_by(id=id).one()
		except:
			result = None
		session.close()
		return result

	# Quality Control Level methods
	def get_qcl_definition(self, qcl_id):
		session = self._session_factory.get_session()
		try:
			result = session.query(QualityControlLevel.definition).filter_by(id=qcl_id).one()
		except:
			result = None
		session.close()
		return result


	# Edit/delete methods
	def delete_dvs(self, dv_list):
		session = self._session_factory.get_session()
		for dv in dv_list:
			merged_dv = session.merge(dv)
			session.delete(merged_dv)
		session.commit()
		session.close()

	def update_dvs(self, dv_list):
		session = self._session_factory.get_session()

		merged_dv_list = map(session.merge, dv_list)

		session.add_all(merged_dv_list)

		session.commit()
		session.close()

	def create_method(self, method):
		session = self._session_factory.get_session()
		new_method = session.merge(method)
		session.add(new_method)
		session.commit()
		session.close()

