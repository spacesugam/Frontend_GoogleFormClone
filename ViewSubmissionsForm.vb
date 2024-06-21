Imports System.Net.Http
Imports System.Text
Imports System.Xml
Imports Newtonsoft.Json


Public Class ViewSubmissionsForm
    Private currentIndex As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set KeyPreview to True
        Me.KeyPreview = True
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadSubmission(currentIndex)
    End Sub

    Private Async Function LoadSubmission(index As Integer) As Task
        ' Create a new HttpClient to make the API call
        Dim client As New HttpClient()

        ' Send a GET request to the backend API endpoint with the index parameter
        Dim response As HttpResponseMessage = Await client.GetAsync($"http://localhost:3000/read?index={index}")

        ' Check the response status code
        If response.IsSuccessStatusCode Then
            ' Get the response content as a string
            Dim responseContent As String = Await response.Content.ReadAsStringAsync()

            ' Deserialize the JSON response into an object
            Dim submission As Submission = JsonConvert.DeserializeObject(Of Submission)(responseContent)

            ' Update the form fields with the submission data
            RichTextBox1.Text = submission.Name
            RichTextBox2.Text = submission.Email
            RichTextBox3.Text = submission.Phone
            githublink.Text = submission.Github_Link
            stopwatchtime.Text = submission.Stopwatch_Time
        Else
            MessageBox.Show("Submission limit reached, No more submission to display!")
        End If
    End Function

    Private Async Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Check for Ctrl+V (View Submission)
        If e.Control AndAlso e.KeyCode = Keys.P Then
            If currentIndex > 0 Then
                currentIndex -= 1
                Await LoadSubmission(currentIndex)
            End If
        End If

        ' Check for Ctrl+N (Create Submission)
        If e.Control AndAlso e.KeyCode = Keys.N Then
            currentIndex += 1
            Await LoadSubmission(currentIndex)
        End If
    End Sub

    Private Async Sub NextButton_Click(sender As Object, e As EventArgs) Handles Button2.Click
        currentIndex += 1
        Await LoadSubmission(currentIndex)
    End Sub

    Private Async Sub PreviousButton_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            Await LoadSubmission(currentIndex)
        End If
    End Sub

    Private Sub RichTextBox3_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox3.TextChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub RichTextBox5_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RichTextBox4_TextChanged(sender As Object, e As EventArgs) Handles stopwatchtime.TextChanged

    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click

    End Sub

    Private Async Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        ' Make an HTTP DELETE request to the backend API
        Dim client As New HttpClient()
        Dim response As HttpResponseMessage = Await client.DeleteAsync($"http://localhost:3000/delete?index={currentIndex}")

        If response.IsSuccessStatusCode Then
            ' Submission deleted successfully
            MessageBox.Show("Submission deleted successfully!")
            ClearFormFields()
            Me.Close()
        Else
            MessageBox.Show("Something error occured! ")
        End If
    End Sub

    Private Async Sub ClearFormFields()
        ' Clear form fields (you can implement this method based on your UI design)
        ' ...
    End Sub

    Private Async Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click
        ' Toggle read-only mode for text boxes
        RichTextBox1.ReadOnly = Not RichTextBox1.ReadOnly
        RichTextBox2.ReadOnly = Not RichTextBox2.ReadOnly
        RichTextBox3.ReadOnly = Not RichTextBox3.ReadOnly
        githublink.ReadOnly = Not githublink.ReadOnly
        stopwatchtime.ReadOnly = Not stopwatchtime.ReadOnly

        ' Update button text based on read-only mode
        If RichTextBox1.ReadOnly Then
            EditButton.Text = "EDIT ON"
        Else
            EditButton.Text = "EDIT OFF"
        End If


    End Sub

    Private Async Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        ' Make an HTTP PUT request to update the submission data on the server
        Dim client As New HttpClient()
        Dim updatedSubmission As New Submission With {
              .Name = RichTextBox1.Text,
              .Email = RichTextBox2.Text,
              .Phone = RichTextBox3.Text,
              .Github_Link = githublink.Text,
              .Stopwatch_Time = stopwatchtime.Text
}

        Dim jsonContent As New StringContent(JsonConvert.SerializeObject(updatedSubmission), Encoding.UTF8, "application/json")

        Dim response As HttpResponseMessage = Await client.PutAsync($"http://localhost:3000/edit?index={currentIndex}", jsonContent)

        If response.IsSuccessStatusCode Then
            ' Submission updated successfully
            MessageBox.Show("Submission updated successfully!")
            ' Reload the submission data
            Await LoadSubmission(currentIndex)
        Else
            MessageBox.Show("something error occured!")
        End If
    End Sub



End Class

Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property Phone As String
    Public Property Github_Link As String
    Public Property Stopwatch_Time As String
End Class