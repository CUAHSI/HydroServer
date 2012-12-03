# CV imports
from odmdata.vertical_datum_cv import VerticalDatumCV
from odmdata.site_type_cv import SiteTypeCV
from odmdata.variable_name_cv import VariableNameCV
from odmdata.speciation_cv import SpeciationCV
from odmdata.sample_medium_cv import SampleMediumCV
from odmdata.value_type_cv import ValueTypeCV
from odmdata.data_type_cv import DataTypeCV
from odmdata.general_category_cv import GeneralCategoryCV
from odmdata.censor_code_cv import CensorCodeCV
from odmdata.topic_category_cv import TopicCategoryCV
from odmdata.sample_type_cv import SampleTypeCV

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


	# Controlled Vocabulary get methods
	def get_vertical_datum_cvs(self):
		session = self._session_factory.get_session()
		result = session.query(VerticalDatumCV).order_by(VerticalDatumCV.term).all()
		session.close()
		return result

	def get_site_type_cvs(self):
		session = self._session_factory.get_session()
		result = session.query(SiteTypeCV).order_by(SiteTypeCV.term).all()
		session.close()
		return result

	def get_variable_name_cvs(self):
		session = self._session_factory.get_session()
		result = session.query(VariableNameCV).order_by(VariableNameCV.term).all()
		session.close()
		return result

	def get_speciation_cvs(self):
		session = self._session_factory.get_session()
		result = session.query(SpeciationCV).order_by(SpeciationCV.term).all()
		session.close()
		return result

	def get_sample_medium_cvs(self):
		session = self._session_factory.get_session()
		result = session.query(SampleMediumCV).order_by(SampleMediumCV.term).all()
		session.close()
		return result

	def get_value_type_cvs(self):
		session = self._session_factory.get_session()
		result = session.query(ValueTypeCV).order_by(ValueTypeCV.term).all()
		session.close()
		return result

	def get_data_type_cvs(self):
		session = self._session_factory.get_session()
		result = session.query(DataTypeCV).order_by(DataTypeCV.term).all()
		session.close()
		return result

	def get_general_category_cvs(self):
		session = self._session_factory.get_session()
		result = session.query(GeneralCategoryCV).order_by(GeneralCategoryCV.term).all()
		session.close()
		return result

	def get_censor_code_cvs(self):
		session = self._session_factory.get_session()
		result = session.query(CensorCodeCV).order_by(CensorCodeCV.term).all()
		session.close()
		return result

	def get_sample_type_cvs(self):		
		session = self._session_factory.get_session()
		result = session.query(SampleTypeCV).order_by(SampleTypeCV.term).all()
		session.close()
		return result