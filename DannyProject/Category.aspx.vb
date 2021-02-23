Imports System.Data
Imports System.Data.SqlClient
Public Class Category
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SqlDSProductListWS.SelectCommand = "Select * From Product Where Featured = 1"
        lblProductList.Text = "Featured Products"

        If Request.QueryString("MainCategoryID") <> "" Then
            SqlDSSubCategory.SelectCommand = "Select * From MasterCategory Where parent = " & CInt(Request.QueryString("MainCategoryID"))
            lblMainCategoryName.Text = Request.QueryString("MainCategoryName")
            lblBreadCrumbMainCategory.Text = Request.QueryString("MainCategoryName")
            SqlDSProductListWS.SelectCommand = "Select * From Product Where maincategoryid = " & CInt(Request.QueryString("MainCategoryID")) & "AND Featured = 1"
            lblProductList.Text = "Featured Products in " & Request.QueryString("MainCategoryName")

            'SEO Tags
            dynamicTitle.InnerHtml = Request.QueryString("MainCategoryName")
            metaKeywords.Attributes.Item("content") = "keyword1, keyword2, keyword3, …"
            metaDescription.Attributes.Item("content") = "Description…”

        End If
        If Request.QueryString("SubCategoryID") <> "" Then
            SqlDSProductListWS.SelectCommand = "Select * From Product Where subcategoryid = " & CInt(Request.QueryString("SubCategoryID"))
            'SqlDSProductListWS2.SelectCommand = "Select * From Product Where maincategoryid = " & CInt(Request.QueryString("MainCategoryID"))
            lblProductList.Text = "Product List for: " + Request.QueryString("SubCategoryName")
            lblBreadCrumbSubCategory.Text = Request.QueryString("SubCategoryName")

            'SEO Tags
            dynamicTitle.InnerHtml = Request.QueryString("SubCategoryName")
            metaKeywords.Attributes.Item("content") = "keyword1, keyword2, keyword3, …"
            metaDescription.Attributes.Item("content") = "Description…”
        End If
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
        End If
    End Sub

    Private Sub rpSubProductListWS_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpSubProductListWS.ItemDataBound
        Dim strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore2").ConnectionString
        Dim connProduct As SqlConnection
        Dim cmdProduct As SqlCommand
        Dim drProduct As SqlDataReader
        Dim lblProductNumber As Label = CType(e.Item.FindControl("lblProductNumber"), Label)
        Dim lblDiscount As Label = CType(e.Item.FindControl("lblDiscount"), Label)
        Dim strSQL As String = "Select * From Product Where ProductNumber = '" & lblProductNumber.Text & "'"
        connProduct = New SqlConnection(strConn)
        cmdProduct = New SqlCommand(strSQL, connProduct)
        connProduct.Open()
        drProduct = cmdProduct.ExecuteReader(CommandBehavior.CloseConnection)
        If drProduct.Read() Then
            If Session("Customer") <> "" Then
                lblDiscount.Text = (drProduct.Item("UnitPrice"))
                lblDiscount.Text = Math.Round((lblDiscount.Text - (drProduct.Item("UnitPrice") * 0.2)), 2)
                lblDiscount.Text = ("Discount Price: $" + lblDiscount.Text)
            End If
        End If
    End Sub



    'Public Function GetWholesalePrice(ByVal OriginalPrice As Decimal) As String
    '    Dim decWholesalePrice As Decimal = 0.00
    '    If Session("Customer") <> "" Then
    '        decWholesalePrice = OriginalPrice * 0.2
    '    Else
    '        decWholesalePrice = OriginalPrice
    '    End If
    '    Return decWholesalePrice
    'End Function

End Class