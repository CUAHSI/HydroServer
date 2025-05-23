import os
from series_service import SeriesService
from cv_service import CVService
from edit_service import EditService
from record_service import RecordService
from sqlalchemy.exc import SQLAlchemyError

class ServiceManager():
	def __init__(self, debug=False):
		self.debug = debug
		f = self.__get_file('r')
		self._connections = []
		self._connection_format = "%s+%s://%s:%s@%s/%s"

		# Read all lines (connections) in the file 
		while True:
			line = f.readline()
			if not line: 
				break
			else:
				line = line.split()
				line_dict = {}
				line_dict['engine']   = line[0]
				line_dict['user'] 	  = line[1]
				line_dict['password'] = line[2]
				line_dict['address']  = line[3]
				line_dict['db'] 	  = line[4]

				self._connections.append(line_dict)

		if len(self._connections) is not 0:
			# The current connection defaults to the most recent (i.e. the last written to the file)
			self._current_connection = self._connections[-1]
		else:
			self._current_connection = None

		f.close()


	def get_connections(self):
		return self._connections

	def get_current_connection(self):
		return self._current_connection

	def add_connection(self, conn_dict):
		"""conn_dict must be a dictionary with keys: engine, user, password, address, db"""

		# remove earlier connections that are identical to this one
		self.delete_connection(conn_dict)

		self._connections.append(conn_dict)
		self._current_connection = self._connections[-1]

		# write changes to connection file
		self.__save_connections()

	def test_connection(self, conn_dict):
		conn_string = self.__build_connection_string(conn_dict)
		try:
			service = SeriesService(conn_string, True)
			site = service.get_test_data()
			# print site
		except SQLAlchemyError:
			return False

		return True

	def delete_connection(self, conn_dict):
		self._connections[:] = [x for x in self._connections if x != conn_dict]

	# Create and return services based on the currently active connection
	def get_series_service(self):
		conn_string = self.__build_connection_string(self._current_connection)
		return SeriesService(conn_string, self.debug)

	def get_cv_service(self):
		conn_string = self.__build_connection_string(self._current_connection)
		return CVService(conn_string, self.debug)


	def get_edit_service(self, series_id, connection):
		conn_string = self.__build_connection_string(self._current_connection)
		return EditService(series_id, connection=connection, connection_string=conn_string, debug=self.debug)

	def get_record_service(self, script, series_id, connection):
		return RecordService(script, self.get_edit_service(series_id, connection), self.__build_connection_string(self.get_current_connection()))

	# private
	def __get_file(self, mode):
		fn = os.path.join(os.path.dirname(__file__), 'connection.cfg')
		return open(fn, mode)

	def __build_connection_string(self, conn_dict):
		driver = ""
		if conn_dict['engine'] == 'mssql':
			driver = "pyodbc"
		if conn_dict['engine'] == 'mysql':
			driver = "pymysql"

		conn_string = self._connection_format % (conn_dict['engine'], driver, conn_dict['user'], conn_dict['password'], conn_dict['address'], conn_dict['db'])
		# print conn_string
		return conn_string

	def __save_connections(self):
		f = self.__get_file('w')
		for conn in self._connections:
			f.write("%s %s %s %s %s\n" % (conn['engine'], conn['user'], conn['password'], conn['address'], conn['db']) )
		f.close()