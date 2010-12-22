Public Class AddContact
    Dim updating As Boolean = False
    Dim m_contactID As Integer = -1
    Private m_connection As SqlClient.SqlConnection
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim commit As New IcewaterCommit(IcewaterCommit.TableType.Contacts, m_connection)
        Dim params As New Specialized.NameValueCollection()
        If Not (txtFirstName.Text = "") Then
            params.Add("FirstName", txtFirstName.Text)
        End If
        If Not (txtLastName.Text = "") Then
            params.Add("LastName", txtLastName.Text)
        End If
        params.Add("OrganizationName", txtOrganizationName.Text)
        If Not (txtMailingAddress.Text = "") Then
            params.Add("MailingAddress", txtMailingAddress.Text)
        End If
        If Not (txtCity.Text = "") Then
            params.Add("City", txtCity.Text)
        End If
        If Not (txtArea.Text = "") Then
            params.Add("Area", txtArea.Text)
        End If
        If Not (txtCountry.Text = "") Then
            params.Add("Country", txtCountry.Text)
        End If
        If Not (txtPostalCode.Text = "") Then
            params.Add("PostalCode", txtPostalCode.Text)
        End If
        If Not (txtFaxNumber.Text = "") Then
            params.Add("FaxNumber", txtFaxNumber.Text)
        End If
        If Not (txtPhoneNumber.Text = "") Then
            params.Add("PhoneNumber", txtPhoneNumber.Text)
        End If
        If Not (txtEmailAddress.Text = "") Then
            params.Add("EmailAddress", txtEmailAddress.Text)
        End If
        If updating Then
            m_contactID = commit.UpdateRow(m_contactID, params)
        Else
            m_contactID = commit.CommitRow(params)
        End If
        If m_contactID > 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Unable To Add Contact to the Database")
        End If
    End Sub

    Public Sub New(ByVal connection As SqlClient.SqlConnection)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.       
        m_connection = connection
    End Sub
    Public Sub New(ByVal connection As SqlClient.SqlConnection, ByVal contactID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.       
        m_connection = connection
        m_contactID = contactID

        Dim commit As New IcewaterCommit(IcewaterCommit.TableType.Contacts, m_connection)
        Dim params As Specialized.NameValueCollection = commit.GetRowToEdit(contactID)

        txtFirstName.Text = params.Get("FirstName")
        txtLastName.Text = params.Get("LastName")
        txtOrganizationName.Text = params.Get("OrganizationName")
        txtMailingAddress.Text = params.Get("MailingAddress")
        txtCity.Text = params.Get("City")
        txtArea.Text = params.Get("Area")
        txtCountry.Text = params.Get("Country")
        txtPostalCode.Text = params.Get("PostalCode")
        txtFaxNumber.Text = params.Get("FaxNumber")
        txtPhoneNumber.Text = params.Get("PhoneNumber")
        txtEmailAddress.Text = params.Get("EmailAddress")

        updating = True
    End Sub


End Class