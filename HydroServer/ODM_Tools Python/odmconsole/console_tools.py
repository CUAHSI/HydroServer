# This class is intended for users to simplify console interaction

import wx.py.crust
from odmservices import RecordService
from wx.lib.pubsub import Publisher


class ConsoleTools(object):

    def __init__(self, ribbon, record_service=None):
        self._edit_error = "no series selected for editing"

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
            Publisher().sendMessage(("updateValues"), None)

    def delete_points(self):
        if self._record_service:
            self._record_service.delete_points()
            self.refresh_plot()
            Publisher().sendMessage(("updateValues"), None)

    def restore(self):
        if self._record_service:
            self._record_service.restore()
            self.refresh_plot()
            Publisher.sendMessage(("updateValues"), None)

    ###############
    # UI methods
    ###############
    def refresh_plot(self):
        Publisher().sendMessage(("changePlotSelection"), self._record_service.get_plot_list())