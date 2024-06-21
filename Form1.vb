Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set KeyPreview to True
        Me.KeyPreview = True
    End Sub
    Private Sub Createsubmission_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim createForm As New CreateSubmissionForm()
        createForm.ShowDialog()
    End Sub

    Private Sub ViewSubmission_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim viewForm As New ViewSubmissionsForm()
        viewForm.ShowDialog()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Check for Ctrl+V (View Submission)
        If e.Control AndAlso e.KeyCode = Keys.V Then
            Dim viewForm As New ViewSubmissionsForm()
            viewForm.ShowDialog()
        End If

        ' Check for Ctrl+N (Create Submission)
        If e.Control AndAlso e.KeyCode = Keys.N Then
            Dim createForm As New CreateSubmissionForm()
            createForm.ShowDialog()
        End If
    End Sub
End Class

