from sqlalchemy import *
from sqlalchemy.orm import relationship
from base import Base

class Series(Base):
	__tablename__ = 'SeriesCatalog'

	id 						   = Column('SeriesID', Integer, primary_key=True)
	site_id 		    	   = Column('SiteID', String)
	site_code 		    	   = Column('SiteCode', String, nullable=False)
	site_name 		    	   = Column('SiteName', String)
	variable_id		    	   = Column('VariableID', Integer)
	variable_code			   = Column('VariableCode', String)
	speciation	 	    	   = Column('Speciation', String)
	variable_units_id   	   = Column('VariableUnitsID', Integer)
	variable_units_name 	   = Column('VariableUnitsName', String)
	sample_medium	    	   = Column('SampleMedium', String)
	value_type				   = Column('ValueType', String)
	time_support	    	   = Column('TimeSupport', Float)
	time_units_id	    	   = Column('TimeUnitsID', Integer)
	time_units_name	    	   = Column('TimeUnitsName', String)
	data_type		    	   = Column('DataType', String)
	general_category 		   = Column('GeneralCategory', String)
	method_id		    	   = Column('MethodID', Integer)
	method_description  	   = Column('MethodDescription', String)
	source_id		    	   = Column('SourceID', Integer)
	source_description  	   = Column('SourceDescription', String)
	organization	    	   = Column('Organization', String)
	cititation				   = Column('Citation', String)
	quality_control_level_id   = Column('QualityControlLevelID', Integer)
	quality_control_level_code = Column('QualityControlLevelCode', String)
	begin_date_time			   = Column('BeginDateTime', DateTime)
	end_date_time			   = Column('EndDateTime', DateTime)
	begin_date_time_utc		   = Column('BeginDateTimeUTC', DateTime)
	end_date_time_utc		   = Column('EndDateTimeUTC', DateTime)
	value_count				   = Column('ValueCount', Integer)

	def __repr__(self):
		return "<Series('%s')>" % (self.id)