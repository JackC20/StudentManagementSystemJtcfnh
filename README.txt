Student Management System
A simple WPF application for managing students and their courses.

Features
Add and manage students with basic information such as first name, last name, student ID, age, and gender.
Add and manage courses for each student with details such as course name, course prefix, course number, credit hours, and grade.
Display and update student information upon selection from a list.
Display and update course information upon selection from a list.
Calculate and display the total GPA for each student based on their enrolled courses.
Implementation
The application uses C# and the Windows Presentation Foundation (WPF) for the user interface. The main classes used in the application are:

Person: An abstract base class representing a person with basic information such as first name, last name, student ID, age, and gender. It also has a list of courses and abstract methods to add and retrieve courses.

UndergraduateStudent: A class that inherits from the Person class, representing an undergraduate student. It overrides the methods for adding and retrieving courses, ensuring that course numbers are within the valid range (1000-4999).

GraduateStudent: A class that inherits from the Person class, representing a graduate student. It overrides the methods for adding and retrieving courses, ensuring that course numbers are within the valid range (5000-9999).

Course: A class representing a course with information such as course name, course prefix, course number, credit hours, and grade.

MainWindow: The main window class for the application, containing the user interface and event handlers for user interactions such as adding students, selecting students, adding courses, and selecting courses.

Usage
Run the application.
Add a student by filling in the required information and clicking the "Add Student" button.
Select a student from the list to view and update their information.
Add a course for the selected student by filling in the required information and clicking the "Add Course" button.
Select a course from the list to view and update its information.
The total GPA for the selected student is displayed at the bottom of the window.
Note: To add a course, a student must be created or selected first.