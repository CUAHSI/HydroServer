from odmdata.site import Site
from odmdata import session_factory

session = session_factory.get_session()

def get_by_id(site_id):
	return session.query(Site).filter_by(id=site_id).one()

def get_by_code(site_code):
	return session.query(Site).filter_by(site_code=site_code).one()

def get_all():
	return session.query(Site).order_by(Site.id).all()

def test():
	from odmdata.unit import Unit
	return session.query(Unit).all()
