﻿# Frontend_GoogleFormClone
FormClone

Table of Contents

Description

Features

Installation

Usage

Creating a New Submission

Viewing Submissions

Keyboard Shortcuts

Validation

API Endpoints

Additional Features

Screenshots

Contributing

License

Description

FormClone is a Windows desktop application developed using Visual Basic in Visual Studio. It allows users to create and view submissions with ease. The application features a simple form for creating new submissions and another form for viewing existing submissions. Additionally, it supports keyboard shortcuts for various actions to enhance user experience.

Features

Create New Submission

Fields for Name, Email, Phone Number, and GitHub Repository Link.

Stopwatch functionality that pauses and resumes without resetting.

Validation for form fields to ensure correct input.

Submit button to send data to the backend.

View Submissions

Navigation through submissions using "Previous" and "Next" buttons.

Displays submission details including Name, Email, Phone Number, GitHub Repository Link, and Stopwatch Time.

Keyboard Shortcuts

Ctrl + V: Open View Submissions form.

Ctrl + N: Open Create New Submission form.

Ctrl + S: Submit the form on Create New Submission page.

Ctrl + T: Pause/Resume the stopwatch.

Form Field Validation

Name: Should contain only letters.

Email: Must be a valid email address format.

Phone: Must be a 10-digit number.

All Fields: Must be filled out before submission.

Additional Features

Option to delete submitted forms.

Option to edit submitted forms.

User-friendly interface with intuitive navigation.

Installation

Clone the Repository

bash

Copy code

git clone https://github.com/yourusername/FormClone.git

Open the Project

Open Visual Studio.

Select File > Open > Project/Solution.

Navigate to the cloned repository and open the solution file (FormClone.sln).

Build the Project

In Visual Studio, select Build > Build Solution to compile the project.

Run the Application

Press F5 to run the application.

Usage

Creating a New Submission

Click on the "Create New Submission" button or press Ctrl + N.

Fill in the form fields (Name, Email, Phone Number, GitHub Repository Link).

Use the stopwatch button to pause/resume the timer.

Click "Submit" or press Ctrl + S to submit the form.

Viewing Submissions

Click on the "View Submissions" button or press Ctrl + V.

Use the "Previous" and "Next" buttons to navigate through the submissions.

View the submission details displayed on the form.

Keyboard Shortcuts

Ctrl + V: Open View Submissions form.

Ctrl + N: Open Create New Submission form.

Ctrl + S: Submit the form on Create New Submission page.

Ctrl + T: Pause/Resume the stopwatch.

Validation

Name: Only letters are allowed.

Email: Must follow a valid email format (e.g., example@example.com).

Phone Number: Must be a 10-digit number.

All Fields: Must be filled out before submission.

API Endpoints

The application interacts with a backend server to fetch and update submission data.

GET /read: Fetches submission data.

POST /submit: Creates a new submission.

PUT /edit: Updates an existing submission.

DELETE /delete: Deletes a submission.

Additional Features

Edit Submission: Toggle read-only mode for text boxes to edit submission details.

Delete Submission: Delete an existing submission.

Screenshots

<!-- Include screenshots of your application here -->

Contributing

Contributions are welcome! Please follow these steps to contribute:

Fork the repository.

Create a new branch (git checkout -b feature-branch).

Make your changes.

Commit your changes (git commit -m 'Add new feature').

Push to the branch (git push origin feature-branch).

Open a Pull Request.

License

This project is licensed under the MIT License. See the LICENSE file for details.
