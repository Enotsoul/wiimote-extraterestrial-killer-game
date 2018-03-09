Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class ImageObject


    Public Sub New(ByVal img As System.Drawing.Bitmap)


        Dim g As Graphics = My.Forms.frmWii.pcbMain.CreateGraphics


        ' Dim image As System.Drawing.Image = img
        g.DrawImage(img, 100, 100, img.Width, img.Height)

        _graphic = g
        '   drawimage.di()

    End Sub


    Private _graphic As Graphics
    Public Property Graphic
        Get
            Return _graphic
        End Get
        Set(ByVal value)
            _graphic = value
        End Set
    End Property



End Class
