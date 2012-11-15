from odmdata.session_factory import SessionFactory
from odmdata.site import Site
from odmdata.variable import Variable
from odmdata.unit import Unit
from odmdata.series import Series
from odmdata.quality_control_level import QualityControlLevel

class SeriesService():

	# Accepts a string for creating a SessionFactory, default uses odmdata/connection.cfg
	def __init__(connection_string="", debug=True):
		session_factory = SessionFactory(connection_string, debug)
		self.session = session_factory.get_session()

	# Creates a new session factory with the given connection string
	def change_connection(connection_string):
		session_factory = SessionFactory(connection_string, debug)
		self.session = session_factory.get_session()

	# Sites methods
	def get_sites(site_code = ""):
		if (site_code):
			return self.session.query(Site).filter_by(site_code=site_code).one()
		else:
			return self.session.query(Site).all()

	# Variables methods
	def get_variable(var_code):	# covers NoDV, VarUnits, TimeUnits
		return self.session.query(Variable).filter_by(code=var_code).all()

	# Unit methods
	def get_unit_by_name(unit_name):
		return self.session.query(Unit).filter_by(name=unit_name).one()

	def get_unit_by_id(unit_id):
		return self.session.query(Unit).filter_by(id=unit_id).one()

	# Series Catalog methods
	def get_series(site_code=""):
		if (site_code):
			return self.session.query(Series.site_id, Series.variable_id).filter_by(site_code=site_code).all()
		else:
			return self.session.query(Series.site_id, Series.variable_id).all()

	def get_series_from_filter():
		# Pass in probably a Series object, match it against the database
		pass

	# Quality Control Level methods
	def get_qcl_definition(qcl_id):
		return self.session.query(QualityControlLevel.definition).filter_by(id=qcl_id).one()