Imports System.Net.Mail
Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim servidorsmtp As New SmtpClient()

            servidorsmtp.Port = 587
            servidorsmtp.Host = "smtp.gmail.com"
            servidorsmtp.EnableSsl = True
            servidorsmtp.Credentials = New Net.NetworkCredential("piscinasegura306@gmail.com", "ps123456")

            Dim email As New MailMessage()

            email = New MailMessage
            email.From = New MailAddress("piscinasegura306@gmail.com")
            email.To.Add("daniellelima@gea.inatel.br")
            email.Subject = "Piscina Segura"
            email.Body = "Movimentação indesejada na piscina!"

            Dim Image1 = Image.FromFile("d:\piscinasegura\comp1.jpg")
            Dim Image2 = Image.FromFile("d:\piscinasegura\comp2.jpg")
            Dim Image3 = Image.FromFile("d:\piscinasegura\comp3.jpg")

            Dim ImageData() As Byte = Nothing
            Dim IC As New ImageConverter

            ImageData = DirectCast(IC.ConvertTo(Image1, GetType(Byte())), Byte())
            Dim Stream1 As New MemoryStream(ImageData)

            ImageData = DirectCast(IC.ConvertTo(Image2, GetType(Byte())), Byte())
            Dim Stream2 As New MemoryStream(ImageData)

            ImageData = DirectCast(IC.ConvertTo(Image3, GetType(Byte())), Byte())
            Dim Stream3 As New MemoryStream(ImageData)

            Dim img1 = New LinkedResource(Stream1, "image/jpeg")
            Dim img2 = New LinkedResource(Stream2, "image/jpeg")
            Dim img3 = New LinkedResource(Stream3, "image/jpeg")

            Dim strmsg As String = ""

            Dim av1 As AlternateView = AlternateView.CreateAlternateViewFromString(strmsg, Nothing)

            av1.LinkedResources.Add(img1)
            av1.LinkedResources.Add(img2)
            av1.LinkedResources.Add(img3)

            email.AlternateViews.Add(av1)
            email.IsBodyHtml = True

            servidorsmtp.Send(email)
            'MsgBox("Email Enviado!")

        Catch ex As Exception
            MsgBox("ERRO!")
        End Try

        Close()

    End Sub

End Class
