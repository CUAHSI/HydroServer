from edit_service import EditService

class RecordService():

    # Script header (imports etc.) will be set up in Main when record is clicked.
    def __init__(self, script, edit_service, connection_string, record=False):
        self._script = script
        self._edit_service = edit_service
        self._connection_string = connection_string
        self._record = record

    ###################
    # Filters
    ###################
    def filter_value(self, value, operator):
        self._edit_service.filter_value(value, operator)
        if self._record:
            self._script("series.filter_value(%s, '%s')\n" % (value, operator), 'black')

    def change_value(self, value, operator):
        self._edit_service.change_value(value, operator)
        if self._record:
            self._script("series.change_value(%s, '%s'\n" % (value, operator), 'black')

    def filter_date(self, before, after):
        self._edit_service.filter_date(before, after)
        if self._record:
            self._script("series.filter_date(%s, %s)\n" % (repr(before), repr(after)), 'black')

    def data_gaps(self, value, time_period):
        self._edit_service.data_gaps(value, time_period)
        if self._record:
            self._script("series.data_gaps(%s, '%s')\n" % (value, time_period), 'black')

    def value_change_threshold(self, value):
        self._edit_service.value_change_threshold(value)
        if self._record:
            self._script("series.value_change_threshold(%s)\n" % (value), 'black')

    def toggle_filter_previous(self):
        self._edit_service.toggle_filter_previous()

    def  select_points(self, id_list=[], datetime_list=[]):
        self._edit_service.select_points(id_list, datetime_list)
        if self._record:
            self._script("#Lasso selection")


    ###################
    # Editing
    ###################
    def add_points(self, points):
        self._edit_service.add_points(points)
        if self._record:
            self._script("# add points")

    def delete_points(self):
        self._edit_service.delete_points()
        if self._record:
            self._script("series.delete_points()\n", 'black')

    def change_values(self, operator, value):
        self._edit_service.change_values(operator, value)
        if self._record:
            self._script("series.change_values(%s, %s\n" % (operator, value), 'black')

    def reset_filter(self):
        self._edit_service.reset_filter()
        if self._record:
            self._script("series.reset_filter()\n", 'black')

    def restore(self):
        self._edit_service.restore()
        if self._record:
            self._script("series.restore()\n", 'black')

    def save(self):
        self._edit_service.save()
        if self._record:
            self._script("series.save()\n", 'black')

    def write_to_db(self):
        self._edit_service.write_to_db()       
        if self._record:
            self._script("series.write_to_db()\n", 'black')

    def get_active_series(self):
        return self._edit_service.get_active_series()

    def get_active_points(self):
        return self._edit_service.get_active_points()

    def get_plot_list(self):
        return self._edit_service.get_plot_list()

    def toggle_record(self):
        if self._record:
            self._record = False
        else:
            self._record = True

    def write_header(self):
        self._script("from odmservices import EditService\n", 'black')
        self._script("series = EditService(series_id=%s, connection_string='%s')\n" % (self._edit_service._series_id, self._connection_string), 'black')