Public Class RootView
    Inherits System.Web.UI.Page
    Public SourcePage As RootDefault

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Heading
        ltlSeriesInfo.Text = Session("pSeriesInfo")

        'Data Table
        Dim objDataSet As Data.DataSet = CType(Session("DataSet"), Data.DataSet)
        If (objDataSet.Tables.IndexOf("PlotData") >= 0) Then
            dgODMData.DataSource = objDataSet.Tables("PlotData")
            dgODMData.DataBind()
        End If
    End Sub
End Class
