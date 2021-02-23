Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows

Public Class ProductDetail
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("ProductID") <> "" Then
            Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore2").ConnectionString
            Dim connProduct As SqlConnection
            Dim cmdProduct As SqlCommand
            Dim drProduct As SqlDataReader
            Dim strSQL As String = "Select * From Product Where ProductId = " & CInt(Request.QueryString("ProductId"))
            connProduct = New SqlConnection(strConn)
            cmdProduct = New SqlCommand(strSQL, connProduct)
            connProduct.Open()
            drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
            If drProduct.Read() Then
                lblProductName.Text = drProduct.Item("ProductName")
                lblProductDescription.Text = drProduct.Item("ProductDescription")
                lblPrice.Text = drProduct.Item("UnitPrice")
                lblProductNumber.Text = drProduct.Item("ProductNumber")
                imgProduct.ImageUrl = "/productImages/" + Trim(drProduct.Item("ProductNumber")) + ".jpg"
            End If

            'Calculate 20% Off Discount of UnitPrice
            If Session("Customer") <> "" Then
                lblDiscount.Text = Math.Round((drProduct.Item("UnitPrice") - (drProduct.Item("UnitPrice") * 0.2)), 2)
                lblDiscount.Text = ("User Discount - $" + lblDiscount.Text)
            End If
            Dim strRating As String = ""
            For intRating As Integer = 1 To drProduct.Item("Rating")
                strRating = strRating + "<img src='images/1star.jpg' width='30px' />"
            Next
            lblRating.Text = strRating
            ' imgProduct.ImageUrl = 

            'SEO Tags
            dynamicTitle.InnerHtml = Request.QueryString("ProductName")
            metaKeywords.Attributes.Item("content") = "keyword1, keyword2, keyword3, …"
            metaDescription.Attributes.Item("content") = "Description…”
        End If
    End Sub

    Private Sub BtnAddtoCart_Click(sender As Object, e As EventArgs) Handles btnAddtoCart.Click
        '*** get CartNo
        Dim strCartNo As String
        If HttpContext.Current.Request.Cookies("CartNo") Is Nothing Then
            strCartNo = GetRandomCartNoUsingGUID(10)
            Dim CookieTo As New HttpCookie("CartNo", strCartNo)
            HttpContext.Current.Response.AppendCookie(CookieTo)
        Else
            Dim CookieBack As HttpCookie
            CookieBack = HttpContext.Current.Request.Cookies("CartNo")
            strCartNo = CookieBack.Value
        End If

        ' set up ado objects and variables
        Dim strConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore2").ConnectionString
        Dim conn As New SqlConnection(strConnectionString)
        Dim drCheck As SqlDataReader
        Dim strSQLStatement As String
        Dim cmdSQL As SqlCommand

        ' get product price
        strSQLStatement = "Select * From Product Where ProductNumber = '" & lblProductNumber.Text & "'"
        cmdSQL = New SqlCommand(strSQLStatement, conn)
        conn.Open()
        drCheck = cmdSQL.ExecuteReader()
        Dim sngPrice As Single = 0.00
        If drCheck.Read() Then
            sngPrice = drCheck.Item("UnitPrice")
        End If
        drCheck.Close()

        ' check if this product already exits in the cart
        strSQLStatement = "SELECT * FROM Cart WHERE CartNo = '" & strCartNo & "' and ProductNumber = '" & Trim(lblProductNumber.Text) & "'"
        cmdSQL.CommandText = strSQLStatement
        drCheck = cmdSQL.ExecuteReader()
        If drCheck.Read() Then
            ' update the quantity
            'strSQLStatement = "INSERT INTO Cart (CartNo, ProductNumber, ProductName, Quantity, Price) values('" & strCartNo & "', '" & lblProductNumber.Text & "', '" & lblProductName.Text & "', " & CInt(tbQuantity.Text) & ", " & sngPrice & ")"
            Dim id As Integer
            If Not Int32.TryParse(tbQuantity.Text, id) Then
                Forms.MessageBox.Show("Error, not a valid number")
                Return
            End If
            System.Text.RegularExpressions.Regex.IsMatch(tbQuantity.Text, "[ ^ 0-9]")
            tbQuantity.Text += drCheck.Item("Quantity")
            strSQLStatement = "UPDATE Cart SET Quantity = '" & CInt(tbQuantity.Text) & "' WHERE CartNo = '" & strCartNo & "' AND ProductNumber = '" & lblProductNumber.Text & "'"
            '"UPDATE Cart (CartNo, ProductNumber, Quantity) values('" & strCartNo & "', '" & lblProductNumber.Text & "', " & CInt(tbQuantity.Text) & ")"
        Else
            strSQLStatement = "INSERT INTO Cart (CartNo, ProductNumber, ProductName, Quantity, Price) values('" & strCartNo & "', '" & lblProductNumber.Text & "', '" & lblProductName.Text & "', " & CInt(tbQuantity.Text) & ", " & sngPrice & ")"
        End If
        drCheck.Close() ' When a DataReader is open, its Connection is dedicated to the its associated SQLcommand.
        cmdSQL.CommandText = strSQLStatement
        Dim drCart As SqlDataReader
        drCart = cmdSQL.ExecuteReader(CommandBehavior.CloseConnection)
        'Response.Redirect("ViewCart.aspx")
    End Sub

    Public Function GetRandomCartNoUsingGUID(ByVal length As Integer) As String
        'Get the GUID
        Dim guidResult As String = System.Guid.NewGuid().ToString()
        'Remove the hyphens
        guidResult = guidResult.Replace("-", String.Empty)
        'Make sure length is valid
        If length <= 0 OrElse length > guidResult.Length Then
            Throw New ArgumentException("Length must be between 1 and " & guidResult.Length)
        End If
        'Return the first length bytes
        Return guidResult.Substring(0, length)
    End Function
End Class