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
	variable_name              = Column('VariableName', String)
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
	citation				   = Column('Citation', String)
	quality_control_level_id   = Column('QualityControlLevelID', Integer)
	quality_control_level_code = Column('QualityControlLevelCode', String)
	begin_date_time			   = Column('BeginDateTime', DateTime)
	end_date_time			   = Column('EndDateTime', DateTime)
	begin_date_time_utc		   = Column('BeginDateTimeUTC', DateTime)
	end_date_time_utc		   = Column('EndDateTimeUTC', DateTime)
	value_count				   = Column('ValueCount', Integer)

	data_values = relationship("DataValue",
		primaryjoin="and_(DataValue.site_id == Series.site_id, "
			"DataValue.variable_id == Series.variable_id, "
			"DataValue.method_id == Series.method_id, "
			"DataValue.source_id == Series.source_id, "
			"DataValue.quality_control_level_id == Series.quality_control_level_id)",
		foreign_keys="[DataValue.site_id, DataValue.variable_id, DataValue.method_id, DataValue.source_id, DataValue.quality_control_level_id]",
		backref="series")


	# TODO add all to repr
	def __repr__(self):
		return "<Series('%s')>" % (self.id)

		
	def getCols(self):
		return ['SeriesID','SiteID', 'SiteCode', 'SiteName','VariableID', 'VariableCode', 'VariableName',
			'Speciation', 'VariableUnitsID', 'VariableUnitsName', 'SampleMedium', 'ValueType', 'TimeSupport',
			'TimeUnitsID', 'TimeUnitsName', 'DataType', 'GeneralCategory', 'MethodID', 'MethodDescription',
			'SourceID', 'SourceDescription', 'Organization', 'Citation', 'QualityControlLevelID', 'QualityControlLevelCode', 
			'BeginDateTime', 'EndDateTime', 'BeginDateTimeUTC', 'EndDateTimeUTC', 'ValueCount'	]
	def getValues(self):
		return [self.id, self.site_id, self.site_code, self.site_name, self.variable_id, self.variable_code, 
				self.variable_name, self.speciation, self.variable_units_id, self.variable_units_name, 
				self.sample_medium, self.value_type, self.time_support, self.time_units_id, self.time_units_name, 
				self.data_type, self.general_category, self.method_id, self.method_description,
				self.source_id, self.source_description, self.organization, self.citation, 
				self.quality_control_level_id, self.quality_control_level_code, self.begin_date_time, 
				self.end_date_time, self.begin_date_time_utc, self.end_date_time_utc, self.value_count	]


	def getValue(self, element):
		if element == 'SeriesID':
			return str(self.id)
		elif element == 'SiteID':
			return str(self.site_id)
		elif element =='SiteCode':
			return str(self.site_code) 
		elif element =='SiteName':
			return str(self.site_name)
		elif element =='VariableID': 
			return str(self.variable_id)
		elif element =='VariableCode': 
			return str(self.variable_code)
		elif element =='VariableName':
			return str(self.variable_name)
		elif element =='Speciation':
			return str(self.speciation )
		elif element =='VariableUnitsID':
			return str(self.variable_units_id)
		elif element =='VariableUnitsName':
			return str(self.variable_units_name)
		elif element =='SampleMedium':
			return str(self.sample_medium)
		elif element =='ValueType':
			return str(self.value_type)
		elif element =='TimeSupport':
			return str(self.time_support)			
		elif element =='TimeUnitsID':
			return str(self.time_units_id)		
		elif element =='TimeUnitsName':
			return str(self.time_units_name)
		elif element =='DataType':
			return str(self.data_type)
		elif element =='GeneralCategory':
			return str(self.general_category)
		elif element == 'MethodID':
			return str(self.method_id)
		elif element =='MethodDescription':
			return str(self.method_description)
		elif element =='SourceID':
			return str(self.source_id)
		elif element =='SourceDescription':
			return str(self.source_description)
		elif element =='Organization':
			return str(self.organization)
		elif element =='Citation':
			return str(self.citation)
		elif element =='QualityControlLevelID':
			return str(self.quality_control_level_id)
		elif element =='QualityControlLevelCode':
			return str(self.quality_control_level_code)
		elif element =='BeginDateTime':
			return str(self.begin_date_time)
		elif element =='EndDateTime':
			return str(self.end_date_time)
		elif element =='BeginDateTimeUTC':
			return str(self.begin_date_time_utc)
		elif element =='EndDateTimeUTC':
			return str(self.end_date_time_utc)
		elif element =='ValueCount':
			return str(self.value_count)
		else: return None

