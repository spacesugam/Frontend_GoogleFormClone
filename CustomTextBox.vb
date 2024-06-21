Imports System.Drawing
Imports System.Windows.Forms

Public Class CustomTextBox
    Inherits TextBox

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Draw custom border
        Dim borderColor As Color = Color.Blue ' Change this to your preferred border color
        Dim borderThickness As Integer = 2 ' Change this to your preferred border thickness

        ' Create a rectangle that defines the border area
        Dim borderRectangle As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        ' Draw the border
        Using borderPen As New Pen(borderColor, borderThickness)
            e.Graphics.DrawRectangle(borderPen, borderRectangle)
        End Using
    End Sub
End Class
