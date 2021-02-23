Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows

Public Class ViewCart1
    Inherits System.Web.UI.Page
    Public strCartNo As String = " "
    Dim CookieBack As HttpCookie = HttpContext.Current.Request.Cookies("CartNo")
    Public strConn As String = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' get CartNo
        If Not CookieBack Is Nothing Then
            strCartNo = CookieBack.Value
        End If
        sqlDSCart1.SelectCommand = "Select * From Cart Where CartNo = '" & strCartNo & "'"

        ' get cart total

        Dim connection As SqlConnection
        connection = New SqlConnection(strConn)
        Dim sql As String = "SELECT SUM(Price * Quantity) As CartTotal FROM Cart"
        connection.Open()
        Dim cmd As New SqlCommand(sql, connection)
        lblTotalCart.Text = cmd.ExecuteScalar.ToString()
        connection.Close()

        'Dim connectionString As String
        'Dim connection As SqlConnection
        'connectionString = ConfigurationManager.ConnectionStrings("ConnectionStringOnlineStore2").ToString
        'connection = New SqlConnection(connectionString)
        'Dim sql As String = "SELECT SUM(Price * Quantity) As CartTotal FROM Cart"
        'Try
        '    connection.Open()
        '    Dim cmd As New SqlCommand(sql, connection)
        '    Dim result As Double = cmd.ExecuteScalar
        '    connection.Close()
        '    lblTotalCart.Text = result
        'Catch ex As Exception
        '    lblTotalCart.Text = "" & ex.ToString
        'End Try
    End Sub
    Protected Sub lvCart_OnItemCommand(ByVal sender As Object, ByVal e As ListViewCommandEventArgs)
        If e.CommandName = "cmdUpdate" Then

            ' get ProductNumber and quantity
            Dim strProductNumber As String = e.CommandArgument
            Dim tbQuantity As TextBox = CType(e.Item.FindControl("tbQuantity"), TextBox)
            'Validate if Numeric
            Dim id As Integer
            If Not Int32.TryParse(tbQuantity.Text, id) Then
                Forms.MessageBox.Show("Error, not a valid number")
                Return
            End If
            Dim strSQL As String = "Update Cart set Quantity = '" & CInt(tbQuantity.Text) & "' where ProductNumber = '" & strProductNumber & "' and CartNo = '" & strCartNo & "'"
            ' update
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
            sqlDSCart1.DataBind()
        ElseIf e.CommandName = "cmdDelete" Then
            ' get productid and quantity
            Dim strProductNumber As String = e.CommandArgument
            Dim tbQuantity As TextBox = CType(e.Item.FindControl("tbQuantity"), TextBox)
            Dim strSQL As String = "Delete From Cart WHERE CartNo = '" & strCartNo & "' And ProductNumber = '" & strProductNumber & "'"

            ' delete
            Dim connCart As SqlConnection
            Dim cmdCart As SqlCommand
            Dim drCart As SqlDataReader
            connCart = New SqlConnection(strConn)
            cmdCart = New SqlCommand(strSQL, connCart)
            connCart.Open()
            drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
            sqlDSCart1.DataBind()
        End If
        Response.Redirect("ViewCart1.aspx")
    End Sub

    Protected Sub DataPager1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataPager1.PreRender
        Dim total_pages As Integer
        Dim current_page As Integer
        lvCart.DataBind()
        total_pages = DataPager1.TotalRowCount / DataPager1.PageSize
        current_page = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        If DataPager1.TotalRowCount Mod DataPager1.PageSize <> 0 Then
            total_pages = total_pages + 1
        End If
        If CInt(lvCart.Items.Count) <> 0 Then
            Dim lbl As Label = lvCart.FindControl("lblPage")
            lbl.Text = "Page " + CStr(current_page) + " of " + CStr(total_pages) + " (Total items: " + CStr(DataPager1.TotalRowCount) + ")"
        End If
        If CInt(lvCart.Items.Count) = 0 Then
            DataPager1.Visible = False
            show_next.Visible = False
            show_prev.Visible = False
        End If
    End Sub

    Protected Sub show_prev_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles show_prev.Click
        Dim pagesize As Integer = DataPager1.PageSize
        Dim current_page As Integer = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        Dim total_pages As Integer = DataPager1.TotalRowCount / DataPager1.PageSize
        Dim last As Integer = total_pages \ 3
        last = last * 3
        Do While current_page < last
            last = last - 3
        Loop
        If last < 3 Then
            last = 0
        Else
            last = last - 3
        End If
        DataPager1.SetPageProperties(last * pagesize, pagesize, True)
    End Sub

    Protected Sub show_next_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles show_next.Click
        Dim last As Integer = 3
        Dim pagesize As Integer = DataPager1.PageSize
        Dim current_page As Integer = DataPager1.StartRowIndex / DataPager1.PageSize + 1
        Dim total_pages As Integer = DataPager1.TotalRowCount / DataPager1.PageSize
        Do While current_page > last
            last = last + 3
        Loop
        If last > total_pages Then
            last = total_pages
        End If
        DataPager1.SetPageProperties(last * pagesize, pagesize, True)
    End Sub

    Private Sub btnEmptyCart_Command(sender As Object, e As CommandEventArgs) Handles btnEmptyCart.Command
        ' get productid and quantity
        Dim strProductNumber As String = e.CommandArgument
        Dim strSQL As String = "DELETE FROM Cart;"

        ' delete
        Dim connCart As SqlConnection
        Dim cmdCart As SqlCommand
        Dim drCart As SqlDataReader
        connCart = New SqlConnection(strConn)
        cmdCart = New SqlCommand(strSQL, connCart)
        connCart.Open()
        drCart = cmdCart.ExecuteReader(CommandBehavior.CloseConnection)
        sqlDSCart1.DataBind()
        Response.Redirect("ViewCart1.aspx")
    End Sub

End Class