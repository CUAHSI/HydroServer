from odmdata.session_factory import SessionFactory
from odmdata.site import Site
from odmdata.variable import Variable
from odmdata.unit import Unit
from odmdata.series import Series
from odmdata.data_value import DataValue
from odmdata.quality_control_level import QualityControlLevel
from odmdata.qualifier import Qualifier


class EditService():

    def __init__(self, cursor=None, connection_string="", debug=False):
        self._session_factory = SessionFactory(connection_string, debug)
        self._edit_session = self._session_factory.get_session()
        self._debug = debug
        self._parent_form = parent_form

        if cursor == None:
            # TODO
            # build it ourselves (series selector init)
            pass
        else:
            self._cursor = cursor

        # [(ID, value, datetime), ...]
        self._cursor.execute("SELECT  ValueID, DataValue, LocalDateTime FROM DataValuesEdit ORDER BY LocalDateTime")
        results = self.editCursor.fetchall()

        self._active_series = results
        self._active_points = results


    # operator is a character, either '<' or '>'
    def filter_value(self, value, operator):
        if operator == '<': # less than
            self._active_points = [x[1] < value for x in self._active_points]
        if operator == '>': # greater than
            self._active_points = [x[1] > value for x in self._active_points]


    def filter_date(self, before, after):
        if before != None:
            self._active_points = [x[2] < after for x in self._active_points]
        if after != None:
            self._active_points = [x[2] > before for x in self._active_points]


    def reset(self):
        self._active_points = self._active_series

    def save(self):
        # Save to sqlite memory DB, not real DB
        pass

    def full_save(self):
        # Save to real DB
        pass

    def get_active_points(self):
        return self._active_points


    def add_point(self, point):
        # add to active_series and _points,
        # save to sqlite DB
        pass


    def reconcile_dates(self, parent_series_id):
        # append new data to this series
        pass