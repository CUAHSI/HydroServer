from sqlalchemy import *
from sqlalchemy.orm import relationship
from base import Base

class OffsetType(Base):
	__tablename__ = 'OffsetTypes'

	id 			= Column('OffsetTypeID', Integer, primary_key=True)
	units_id    = Column('OffsetUnitsID', Integer)
	description = Column('OffsetDescription', String)

	def __repr__(self):
		return "<Unit('%s', '%s', '%s')>" % (self.id, self.units_id, self.description)