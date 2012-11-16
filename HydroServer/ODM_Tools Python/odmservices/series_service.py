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
		session_factory = SessionFactory(connection_string, debug)
		self.session = session_factory.get_session()

	# Creates a new session factory with the given connection string
	def change_connection(connection_string):
		session_factory = SessionFactory(connection_string, debug)
		self.session = session_factory.get_session()

	# Sites methods
	def get_sites(self, site_code = ""):
		if (site_code):
			return self.session.query(distinct(Series.site_id), Series.site_code, Series.site_name).filter_by(site_code=site_code).one()
		else:
			return self.session.query(distinct(Series.site_id), Series.site_code, Series.site_name).order_by(Series.site_code).all()

	# Variables methods
	def get_variables(self, site_code = ""):	# covers NoDV, VarUnits, TimeUnits
		if (site_code):
			return self.session.query(distinct(Series.variable_id), Series.variable_code, Series.variable_name).filter_by(site_code=site_code).all()
		else:
			return self.session.query(distinct(Series.variable_id), Series.variable_code, Series.variable_name).order_by(Series.variable_code).all()

	# Unit methods
	def get_unit_by_name(self, unit_name):
		return self.session.query(Unit).filter_by(name=unit_name).one()

	def get_unit_by_id(self, unit_id):
		return self.session.query(Unit).filter_by(id=unit_id).one()

	# Series Catalog methods
	def get_series(self, site_code="", var_code=""):		# NEED 2
		if (site_code):
			return self.session.query(Series).filter_by(site_code=site_code).all()
		else:
			return self.session.query(Series).all()

	def get_series_from_filter(self):
		# Pass in probably a Series object, match it against the database
		pass

	# DataValues by Series
	def get_data_values_by_series(self, series):
		return self.session.query(DataValue).filter_by(
								variable_id=series.variable_id, 
								site_id=series.site_id,
								method_id=series.method_id,
								source_id=series.source_id,
								quality_control_level_id=series.quality_control_level_id).all()

	# Quality Control Level methods
	def get_qcl_definition(self, qcl_id):
		return self.session.query(QualityControlLevel.definition).filter_by(id=qcl_id).one()