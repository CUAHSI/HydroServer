
Public Class RootPrint
    Inherits System.Web.UI.Page
    Protected WithEvents lblSite As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim mobjRootDefault As RootDefault = CType(Context.Handler, RootDefault)
        Dim objDataSet As Data.DataSet = CType(Session("DataSet"), Data.DataSet)

        'Heading
        ltlSeriesInfo.Text = Session("SeriesInfo")

        'Graph
        If ((Session("TimeSeries")).Visible) Then
            Session("TimeSeries").Replot(Session("Options"))
            PlaceHolder1.Controls.Add(Session("TimeSeries"))
        ElseIf ((Session("Probability")).Visible) Then
            Session("Probability").Replot(Session("Options"))
            PlaceHolder1.Controls.Add(Session("Probability"))
        ElseIf ((Session("Histogram")).Visible) Then
            Session("Histogram").Replot(Session("Options"))
            PlaceHolder1.Controls.Add(Session("Histogram"))
        ElseIf ((Session("Histogram")).Visible) Then
            Session("BoxWhisker").Replot(Session("Options"))
            PlaceHolder1.Controls.Add(Session("BoxWhisker"))
        End If

        'Summary
        Dim objDataTable As Data.DataTable = objDataSet.Tables.Item(0)
        lblArithmeticMean.Text = Statistics.ArithmeticMean(objDataTable).ToString("G4")
        lblGeometricMean.Text = Statistics.GeometricMean(objDataTable).ToString("G4")
        lblMaximum.Text = Statistics.Maximum(objDataTable).ToString
        lblMinimum.Text = Statistics.Minimum(objDataTable).ToString
        lblStandardDeviation.Text = Statistics.StandardDeviation(objDataTable).ToString("G4")
        lblCoefficientOfVariation.Text = Statistics.CoefficientOfVariation(objDataTable).ToString("###%")
        lbl10Percentile.Text = Statistics.Percentile(objDataTable, 10).ToString("G4")
        lbl25Percentile.Text = Statistics.LowerQuartile(objDataTable).ToString("G4")
        lblMedian.Text = Statistics.Median(objDataTable).ToString("G4")
        lbl75Percentile.Text = Statistics.UpperQuartile(objDataTable).ToString("G4")
        lbl90Percentile.Text = Statistics.Percentile(objDataTable, 90).ToString("G4")
        lblNumberOfObservations.Text = Statistics.Count(objDataTable).ToString
    End Sub

End Class
