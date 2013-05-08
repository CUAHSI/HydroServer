# This class is intended for users to simplify console interaction

from wx.lib.pubsub import pub as Publisher


class ConsoleTools(object):

    def __init__(self, ribbon, record_service=None):
        self._edit_error = "no series selected for editing"
        self._add_point_req_error = "A required field was left empty"

        self._ribbon = ribbon
        self._record_service = record_service
    

    ################
    # Set methods
    ################
    def set_record_service(self, rec_serv):
        self._record_service = rec_serv

    def toggle_recording(self):
        if self._record_service:
            self._record_service.toggle_record()
        else:
            return "Cannot record: %s" % (self._edit_error)

    def toggle_filter_previous(self):
        if self._record_service:
            self._record_service.toggle_filter_previous()

    def restore(self):
        if self._record_service:
            self._record_service.restore()

    ################
    # Filter methods
    ################
    def filter_value(self, value, operator):
        if self._record_service:
            self._record_service.filter_value(value, operator)
            self.refresh_plot()
        else:
            return "Cannot filter: %s" % (self._edit_error)

    def filter_dates(self, before, after):
        if self._record_service:
            self._record_service.filter_dates(before, after)
            self.refresh_plot()
        else:
            return "Cannot filter: %s" % (self._edit_error)

    def data_gaps(self, value, time_period):
        if self._record_service:
            self._record_service.data_gaps(value, time_period)
            self.refresh_plot()

    def value_change_threshold(self, value):
        if self._record_service:
            self._record_service.value_change_threshold(value)
            self.refresh_plot()

    def reset_filter(self):
        if self._record_service:
            self._record_service.reset_filter()
            self.refresh_plot()
    
    ################
    # Edit methods
    ################

    def change_value(self, value, operator):
        if self._record_service:
            self._record_service.change_value(value, operator)
            self.refresh_plot()
            Publisher.sendMessage(("updateValues"), None)

    def add_point(self, data_value, value_accuracy, local_datetime, utc_offset, datetime_utc, offset_value, offset_type, censor_code, qualifier_code, lab_sample_code):
        if (data_value == None or local_datetime == None or utc_offset == None or
            datetime_utc == None or censor_code == None or censor_code == ""):
            return "Error adding point: %s" % (self._add_point_req_error)

        point = (data_value, value_accuracy, local_datetime, utc_offset, datetime_utc, offset_value, offset_type, censor_code, qualifier_code, lab_sample_code)
        point_list = []
        point_list.append(point)
        if self._record_service:
            self._record_service.add_points(point_list)
            self.refresh_plot()
            Publisher().sendMessage(("updateValues"), None)

    def add_points(self, point_list):
        for point in point_list:
            #data_value, local_datetime, utc_offset, datetime_utc, censor_code
            if (point[0] == None or point[2] == None or point[3] == None or
                point[4] == None or point[7] == None or point[7] == ""):
                return "Error adding point: %s" % (self._add_point_req_error)

        if self._record_service:
            self._record_service.add_points(point_list)
            self.refresh_plot()
            Publisher().sendMessage(("updateValues"), None)

    def delete_points(self):
        if self._record_service:
            self._record_service.delete_points()
            self.refresh_plot()
            Publisher.sendMessage(("updateValues"), None)

    def restore(self):
        if self._record_service:
            self._record_service.restore()
            self.refresh_plot()
            Publisher.sendMessage(("updateValues"), None)

    ###############
    # UI methods
    ###############
    def refresh_plot(self):
        Publisher.sendMessage(("changePlotSelection"), self._record_service.get_plot_list())