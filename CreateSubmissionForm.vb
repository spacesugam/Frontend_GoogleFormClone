Imports System.Net.Http
Imports System.Text.RegularExpressions

Public Class CreateSubmissionForm
    Private stopwatch As New Stopwatch()
    Private totalElapsedTime As TimeSpan = TimeSpan.Zero
    Private WithEvents timer As New Timer()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set KeyPreview to True
        Me.KeyPreview = True
    End Sub

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the stopwatch display
        UpdateStopwatchDisplay()

        ' Set up the timer to update every second
        timer.Interval = 1000 ' 1 second
        timer.Start()
    End Sub



    Private Sub UpdateStopwatchDisplay()
        ' Calculate the current stopwatch time (including previously paused time)
        Dim currentElapsedTime As TimeSpan = stopwatch.Elapsed + totalElapsedTime
        RichTextBox5.Text = currentElapsedTime.ToString("hh\:mm\:ss")
    End Sub

    Private Async Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Get the values from the form fields
        Dim name As String = RichTextBox1.Text
        Dim email As String = RichTextBox2.Text
        Dim phone As String = RichTextBox3.Text
        Dim githubLink As String = RichTextBox4.Text

        ' Check if all fields are filled
        If String.IsNullOrWhiteSpace(name) OrElse String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(phone) OrElse String.IsNullOrWhiteSpace(githubLink) Then
            MessageBox.Show("All fields are required.")
            Return
        End If

        ' Validate the input
        If Not IsValidName(name) Then
            MessageBox.Show("Name should contain only letters.")
            Return
        End If

        If Not IsValidEmail(email) Then
            MessageBox.Show("Please enter a valid email address.")
            Return
        End If

        If Not IsValidPhoneNumber(phone) Then
            MessageBox.Show("Phone number should be 10 digits and contain only numbers.")
            Return
        End If

        ' Calculate the current stopwatch time (including previously paused time)
        Dim currentElapsedTime As TimeSpan = stopwatch.Elapsed + totalElapsedTime
        Dim stopwatchTime As String = currentElapsedTime.ToString()

        ' Create a new HttpClient to make the API call
        Dim client As New HttpClient()

        ' Create a new FormUrlEncodedContent with the form data
        Dim formData As New FormUrlEncodedContent(New Dictionary(Of String, String) From {
            {"name", name},
            {"email", email},
            {"phone", phone},
            {"github_link", githubLink},
            {"stopwatch_time", stopwatchTime}
        })

        ' Send a POST request to the backend API endpoint
        Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost:3000/submit", formData)

        ' Check the response status code
        If response.IsSuccessStatusCode Then
            MessageBox.Show("Submission created successfully!")
            Me.Close()
        Else
            MessageBox.Show("Failed to create submission. Please try again.")
        End If
    End Sub

    Private Function IsValidName(name As String) As Boolean
        Return Regex.IsMatch(name, "^[a-zA-Z]+$")
    End Function

    Private Function IsValidEmail(email As String) As Boolean
        Return Regex.IsMatch(email, "^[^@\s]+@[^@\s]+\.[^@\s]+$")
    End Function

    Private Function IsValidPhoneNumber(phone As String) As Boolean
        Return Regex.IsMatch(phone, "^\d{10}$")
    End Function


    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            SubmitButton_Click(sender, e)
        End If
    End Sub

    Private Sub StopWatch_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If stopwatch.IsRunning Then
            ' Pause the stopwatch and store the elapsed time
            stopwatch.Stop()
            totalElapsedTime += stopwatch.Elapsed
        Else
            ' Resume the stopwatch
            stopwatch.Start()
        End If
    End Sub

    Private Sub Stopwatch_clickKeydown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            StopWatch_Click(sender, e)
        End If
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        ' Update the stopwatch display every second
        UpdateStopwatchDisplay()
    End Sub
End Class

