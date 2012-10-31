from odmdata.data_value import DataValue
from odmdata import session_factory

session = session_factory.get_session()

def get_by_site_id(site_id):
	return session.query(DataValue).filter_by(site_id=site_id).all()

def count_by_site_id(site_id):
	return session.query(DataValue).filter_by(site_id=site_id).count()