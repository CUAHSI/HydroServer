# Declare a mapped class
from sqlalchemy import *
from sqlalchemy.orm import relationship
from base import Base

class DataValue(Base):
	__tablename__ = 'DataValues'

	id 						 = Column('ValueID', Integer, primary_key=True)
	data_value 		    	 = Column('DataValue', Float)
	value_accuracy	    	 = Column('ValueAccuracy', Float)
	local_date_time	    	 = Column('LocalDateTime', DateTime)
	utc_offset		    	 = Column('UTCOffset', Float)
	date_time_utc			 = Column('DateTimeUTC', DateTime)
	site_id		 	    	 = Column('SiteID', Integer)
	variable_id			   	 = Column('VariableID', Integer)
	offset_value	    	 = Column('OffsetValue', Float)
	offset_type_id			 = Column('OffsetTypeID', Integer)
	censor_code		    	 = Column('CensorCode', String)
	qualifier_id	    	 = Column('QualifierID', Integer)
	method_id		    	 = Column('MethodID', Integer)
	source_id		    	 = Column('SourceID', Integer)
	sample_id			  	 = Column('SampleID', Integer)
	derived_from_id	    	 = Column('DerivedFromID', Integer)
	quality_control_level_id = Column('QualityControlLevelID', Integer)

	def __repr__(self):
		return "<DataValue('%s', '%s')>" % (self.data_value, self.local_date_time)