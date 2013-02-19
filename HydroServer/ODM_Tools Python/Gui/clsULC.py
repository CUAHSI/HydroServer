
import wx
import wx.lib.agw.ultimatelistctrl as ULC


class clsULC(ULC.UltimateListCtrl):

	def __init__(self, *args, **kwargs):
		self.modelObjects = []
		self.innerList = []
		self.columns = []
		self.filter = None
		self.useAlternateBackColors = True
		self.evenRowsBackColor = "White" #wx.Colour(240, 248, 255) # ALICE BLUE
		self.oddRowsBackColor = "SlateGray" #wx.Colour(255, 250, 205) # LEMON CHIFFON

		# wx.ListCtrl.__init__(self, *args, **kwargs)
		ULC.UltimateListCtrl.__init__(self, *args, **kwargs )

	

	def SetObjects(self, modelObjects, preserveSelection=False):
		"""
		Set the list of modelObjects to be displayed by the control.
		"""
		if preserveSelection:
			selection = self.GetSelectedOcolumnsbjects()

		if modelObjects is None:
			self.modelObjects = list()
		else:
			self.modelObjects = modelObjects[:]

		self.RepopulateList()

		# for series in self.seriesList:
		#	 ind = self.tableSeries.GetItemCount()
		#	 self.tableSeries.Append([False, series.site_name ,series.variable_name])
		#	 self.tableSeries.SetStringItem(ind, 0,"", it_kind=1)


	def SetColumns(self, columns, repopulate=True):
		# """
		# Set the list of columns that will be displayed.

		# The elements of the list can be either ColumnDefn objects or a tuple holding the values
		# to be given to the ColumnDefn constructor.

		# The first column is the primary column -- this will be shown in the the non-report views.

		
		# """


		# self.InsertColumn(col=colnum, format=wx.LIST_FORMAT_CENTRE, heading=u'',
		# 	 width=25) 
		# for c in self.columnstitle:
		# 	colnum+=1
		# 	self.InsertColumn(col=colnum, format=wx.LIST_FORMAT_LEFT,
		# 		heading=c, width=140)
		
		# ULC.UltimateListCtrl.ClearAll(self)
		# self.columns = []
		# for x in columns:
		# 	if isinstance(x, ColumnDefn):
		# 		self.AddColumnDefn(x)
		# 	else:
		# 		self.AddColumnDefn(ColumnDefn(*x))		
		# if repopulate:
		# 	self.RepopulateList()


		colnum = 0
		self.InsertColumn(col=colnum, format=wx.LIST_FORMAT_CENTRE, heading=u'',
			 width=25) 
		for c in self.columns:
			colnum+=1
			self.InsertColumn(col=colnum, format=wx.LIST_FORMAT_LEFT,
				heading=c, width=140)
		# self.SetColumns(self.columns)


		if repopulate:
			self.RepopulateList()

	# def AddColumnDefn(self, defn):
	# 	# """
	# 	# Append the given ColumnDefn object to our list of active columns.

	# 	# If this method is called directly, you must also call RepopulateList()
	# 	# to populate the new column with data.
	# 	# """
	# 	self.columns.append(defn)

	# 	info = ULC.UltimateListItem()
	# 	info.m_mask = wx.LIST_MASK_TEXT | wx.LIST_MASK_FORMAT
	# 	# if isinstance(defn.headerImage, basestring) and self.smallImageList is not None:
	# 	# 	info.m_image = self.smallImageList.GetImageIndex(defn.headerImage)
	# 	# else:
	# 	# 	info.m_image = defn.headerImage
	# 	# if info.m_image != -1:
	# 	# 	info.m_mask = info.m_mask | wx.LIST_MASK_IMAGE
	# 	# info.m_format = defn.GetAlignment()
	# 	# info.m_text = defn.title
	# 	# info.m_width = defn.width
	# 	self.InsertColumnInfo(len(self.columns)-1, info)

	# 	# Under Linux, the width doesn't take effect without this call
	# 	self.SetColumnWidth(len(self.columns)-1, defn.width)

	# 	# The first checkbox column becomes the check state column for the control
	   

 	def _BuildInnerList(self):
		# """
		# Build the list that will actually populate the control
		# """
		# This is normally just the list of model objects
		if self.filter:
			self.innerList = self.filter(self.modelObjects)
		else:
			self.innerList = self.modelObjects

		# Our map isn't valid after doing this
		self.objectToIndexMap = None

 	def GetFilter(self):
		# """
		# Return the filter that is currently operating on this control.
		# """
		return self.filter

 	def GetFilteredObjects(self):
		# """
		# Return the model objects that are actually displayed in the control.

		# If no filter is in effect, this is the same as GetObjects().
		# """
		return self.innerList

 	def SetFilter(self, filter):
		# """
		# Remember the filter that is currently operating on this control.
		# Set this to None to clear the current filter.

		# A filter is a callable that accepts one parameter: the original list
		# of model objects. The filter chooses which of these model objects should
		# be visible to the user, and returns a collection of only those objects.

		# The Filter module has some useful standard filters.

		# You must call RepopulateList() for changes to the filter to be visible.
		# """
		self.filter = filter

 	def GetObjectAt(self, index):
		# """
		# Return the model object at the given row of the list.
		# """
		# Because of sorting, index can't be used directly, which is
		# why we set the item data to be the real index
		return self.innerList[self.GetItemData(index)]

 	def AddObjects(self, modelObjects):
		# """
		# Add the given collections of objects to our collection of objects.
		# """
		self.modelObjects.extend(modelObjects)
		# We don't want to call RepopulateList() here since that makes the whole
		# control redraw, which flickers slightly, which I *really* hate! So we
		# most of the work of RepopulateList() but only redraw from the first
		# added object down.
		# self._SortObjects()
		self._BuildInnerList()
		self.SetItemCount(len(self.innerList))

		# Find where the first added object appears and make that and everything
		# after it redraw
		first = self.GetItemCount()
		for x in modelObjects:
			# Because of filtering the added objects may not be in the list
			idx = self.GetIndexOf(x)
			if idx != -1:
				first = min(first, idx)
				if first == 0:
					break

		if first < self.GetItemCount():
			self.RefreshItems(first, self.GetItemCount() - 1)


 	def RepopulateList(self):
		# """
		# Completely rebuild the contents of the list control
		# """
		# self._SortObjects()
		self._BuildInnerList()
		self.Freeze()
		try:
			ULC.UltimateListCtrl.DeleteAllItems(self)
			if len(self.innerList) == 0 or len(self.columns) == 0:
				self.Refresh()				
				return

		# 	# self.stEmptyListMsg.Hide()

			# Insert all the rows
			item = ULC.UltimateListItem()
			item.SetColumn(0)
			for (i, x) in enumerate(self.innerList):
				item.Clear()
				self._InsertUpdateItem(item, i, x, True)

		
			# for series in self.innerList:
			# 	ind = self.GetItemCount()
			# 	self.Append([False, series.site_name ,series.variable_name])
			# 	self.SetStringItem(ind, 0,"", it_kind=1)


		# 	# Auto-resize once all the data has been added
			self.AutoSizeColumns()
			# self._FormatAllRows()
		finally:
			self.Thaw()	




			 

 	def SetItemCount(self, count):
		# """
		# Change the number of items visible in the list
		# """
		ULC.UltimateListCtrl.SetItemCount(self, count)
		self.stEmptyListMsg.Show(count == 0)
		self.lastGetObjectIndex = -1


 	def RefreshObject(self, modelObject):
		# """
		# Refresh the display of the given model
		# """
		idx = self.GetIndexOf(modelObject)
		if idx != -1:
			self.RefreshIndex(self._MapModelIndexToListIndex(idx), modelObject)


 	def RefreshObjects(self, aList):
		# """
		# Refresh all the objects in the given list
		# """
		try:
			self.Freeze()
			for x in aList:
				self.RefreshObject(x)
		finally:
			self.Thaw()



	# def _MapModelIndexToListIndex(self, modelIndex):
	# 	# """
	# 	# Return the index in the list where the given model index lives
	# 	# """
	# 	return self.FindItemData(-1, modelIndex)

 	def RefreshIndex(self, index, modelObject):
		# """
		# Refresh the item at the given index with data associated with the given object
		# """
		self._InsertUpdateItem(self.GetItem(index), index, modelObject, False)

 	def _InsertUpdateItem(self, listItem, index, modelObject, isInsert):
		# for series in self.seriesList:
		#	 ind = self.GetItemCount()
			 # self.Append(listItem)
			 # self.SetStringItem(index, 0,"", it_kind=1)

		if isInsert:
			listItem.SetId(index)
			listItem.SetData(index)

		listItem.SetText(False)
		self.SetStringItem(index, 0,"", it_kind=1)
		self._FormatOneItem(listItem, index, modelObject)

		if isInsert:
			self.InsertItem(listItem)
		else:
			self.SetItem(listItem)


		
		for iCol in range(1, len(self.columns)):
			self.SetStringItem(index, iCol, modelObject[iCol])



 	def _FormatAllRows(self):
		# """
		# Set up the required formatting on all rows
		# """
		for i in range(self.GetItemCount()):
			item = self.GetItem(i)
			self._FormatOneItem(item, i, self.GetObjectAt(i))
			self.SetItem(item)


 	def _FormatOneItem(self, item, index, model):
		# """
		# Give the given row it's correct background color
		# """
		if self.useAlternateBackColors: 
			if index & 1:
				item.SetBackgroundColour(self.oddRowsBackColor)
			else:
				item.SetBackgroundColour(self.evenRowsBackColor)
		# if self.rowFormatter is not None:
		# 	self.rowFormatter(item, model)









class TextSearch(object):
	"""
	Return only model objects that match a given string. If columns is not empty,
	only those columns will be considered when searching for the string. Otherwise,
	all columns will be searched.

	Example::
		self.olv.SetFilter(Filter.TextSearch(self.olv, text="findthis"))
		self.olv.RepopulateList()
	"""

	def __init__(self, objectListView, columns=(), text=""):
		"""
		Create a filter that includes on modelObject that have 'self.text' somewhere in the given columns.
		"""
		self.objectListView = objectListView
		self.columns = columns
		self.text = text

	def __call__(self, modelObjects):
		"""
		Return the model objects that contain our text in one of the columns to consider
		"""
		if not self.text:
			return modelObjects

		# In non-report views, we can only search the primary column
		# if self.objectListView.InReportView():
		cols = self.columns or self.objectListView.columns
		# else:
		#	 cols = [self.objectListView.columns[0]]

		textToFind = self.text.lower()

		def _containsText(modelObject):
			for col in cols:
				if textToFind in col.GetStringValue(modelObject).lower():
					return True
			return False

		return [x for x in modelObjects if _containsText(x)]

	def SetText(self, text):
		"""
		Set the text that this filter will match. Set this to None or "" to disable the filter.
		"""
		self.text = text


class Chain(object):
	"""
	Return only model objects that match all of the given filters.

	Example::
		# Show at most 100 people whose salary is over 50,000
		salaryFilter = Filter.Predicate(lambda person: person.GetSalary() > 50000)
		self.olv.SetFilter(Filter.Chain(salaryFilter, Filter.Tail(100)))
		self.olv.RepopulateList()
	"""

	def __init__(self, *filters):
		"""
		Create a filter that performs all the given filters.

		The order of the filters is important.
		"""
		self.filters = filters


	def __call__(self, modelObjects):
		"""
		Return the model objects that match all of our filters
		"""
		for filter in self.filters:
			modelObjects = filter(modelObjects)
		return modelObjects
