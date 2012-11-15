from sqlalchemy import *
from sqlalchemy.orm import relationship
from base import Base

class SampleMedium(Base):
	__tablename__ = 'SampleMedium'

	term   	   = Column('Term', String, primary_key=True)
	definition = Column('Definition', String)

	def __repr__(self):
		return "<SampleMedium('%s', '%s')>" % (self.term, self.definition)