Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class Layout
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Customer") <> "" Then
            hlLogin.Visible = False
            hlLogout.Visible = True
            lblCustomer.Text = Session("Customer")
            lblCustomer.Visible = True
            hrefDestination.InnerText = Session("Email")
        End If
        Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore2").ConnectionString
        Dim connMainCategory As SqlConnection
        Dim cmdMainCategory As SqlCommand
        Dim drMainCategory As SqlDataReader
        Dim strSQL As String = "Select * from MasterCategory Where parent = 0"
        connMainCategory = New SqlConnection(strConn)
        cmdMainCategory = New SqlCommand(strSQL, connMainCategory)
        connMainCategory.Open()
        drMainCategory = cmdMainCategory.ExecuteReader(CommandBehavior.CloseConnection)
        Dim strMainCategory As String = ""
        Do While drMainCategory.Read()
            strMainCategory = strMainCategory + "<li><a href='Category.aspx?MainCategoryID='>" + Trim(drMainCategory("CategoryName")) + "</a></li>"
        Loop
        lblMainCategory2.Text = strMainCategory
    End Sub
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If tbSearch.Text <> "" Then
            Dim strURL As String = "/ProductDetail.aspx?ProductID = " & Trim(tbSearch.Text)
            ' check  the number of words in the textbox
            Dim strCheck As String = " "
            If Not Trim(tbSearch.Text).Contains(strCheck) Then
                'Connect to Database'
                Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore2").ConnectionString
                Dim connProduct As SqlConnection
                Dim cmdProduct As SqlCommand
                Dim drProduct As SqlDataReader
                connProduct = New SqlConnection(strConn)
                Dim strSQL As String = "Select * from Product where ProductID = '" & Trim(tbSearch.Text) & "'"
                cmdProduct = New SqlCommand(strSQL, connProduct)
                connProduct.Open()
                drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)

                'If there is a match, redirect to ProductDetail.aspx?ProductID = " & Trim(tbSearch.Text)
                If tbSearch.Text <> " " Then
                    strURL = "/ProductDetail.aspx?ProductID=" & (tbSearch.Text)
                    Response.Redirect(strURL)
                End If
            Else
                strURL = "/ProductDetail.aspx?ProductID=" & Request.QueryString("ProductID") & "&ProductName=" & Trim(tbSearch.Text)
                Response.Redirect(strURL)
            End If
        End If
    End Sub
End Class