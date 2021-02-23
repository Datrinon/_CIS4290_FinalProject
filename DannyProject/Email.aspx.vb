Imports System.Net
Imports System.Net.Mail
Public Class Email
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim smtpClient As SmtpClient = New SmtpClient()
        Dim mailMessage As MailMessage = New MailMessage()
        mailMessage.To.Add("dtaotester@gmail.com")
        mailMessage.To.Add(tbEmail.Text)
        mailMessage.Subject = tbSubject.Text
        Dim n As String
        Dim em As String
        Dim p As String
        Dim co As String
        n = tbName.Text
        em = tbEmail.Text
        co = tbMessage.Text
        mailMessage.Body = "Name : " + n + vbCrLf + "E-Mail: " + em + vbCrLf + "Phone: " + vbCrLf + vbCrLf + "Comments: " + co
        Try
            smtpClient.Send(mailMessage)
            lblReturnMessage.Text = "Email Send Successfully!!!"
        Catch ex As Exception
            lblReturnMessage.Text = ex.ToString
        End Try
    End Sub
End Class