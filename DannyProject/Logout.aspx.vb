Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Customer") <> "" Then
            Session.Abandon()
            Response.Redirect("Logout.aspx")
        End If
    End Sub

End Class