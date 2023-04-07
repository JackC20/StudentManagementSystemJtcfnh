using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentManagementSystemJtcfnh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<Person> studentList = new List<Person>();
        static List<Course> courses = new List<Course>();

        static Person currentSelectedPerson;  
        public MainWindow()
        {
            InitializeComponent();
        }


        private int GetSelectedGenderIndex()
        {
            string selectedItem = (string)(Gender.SelectedItem as ComboBoxItem).Content;

            switch (selectedItem)
            {
                case "Male":
                    return 0;
                case "Female":
                    return 1;
                case "Other":
                    return 2;
                default:
                    return -1;
            }
        }

        private int GetSelectedStudentTypeIndex()
        {
            string selectedItem = (string)(StudentType.SelectedItem as ComboBoxItem).Content;

            switch (selectedItem)
            {
                case "Undergraduate":
                    return 1;
                case "Graduate":
                    return 2;
                default:
                    return -1; 
            }
        }


        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {



            string firstName = FirstNameTextBox.Text; 
            string lastName = LastNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Please enter a valid first name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter a valid last name.");
                return;
            }

            int studentID;
            int gender = GetSelectedGenderIndex();
            int age; 
            int studentType = GetSelectedStudentTypeIndex();

            if (!int.TryParse(StudentIDTextBox.Text, out studentID))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                return;
            }

            if (!int.TryParse(AgeTextBox.Text, out age))
            {
                MessageBox.Show("Please enter a valid age.");
                return;
            }


            if (studentType == 1)
            {
                Person person = new UndergraduateStudent(firstName, lastName, studentID, gender, age);
                studentList.Add(person);
                currentSelectedPerson= person;
                

            }

            else if(studentType == 2) 
            {
                Person person = new GraduateStudent(firstName, lastName, studentID, gender, age);
                studentList.Add(person);
                currentSelectedPerson= person;
            }


            studentList = studentList.OrderBy(person => person.LastName).ThenBy(person => person.FirstName).ToList();


            StudentsListBox.Items.Clear();
            CoursesListBox.Items.Clear(); 

            foreach (Person person in studentList) 
            {
               
                StudentsListBox.Items.Add(person);

            }


           
        }

        private void StudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudentsListBox.SelectedIndex != -1)
            {
                Person selectedStudent = (Person)StudentsListBox.SelectedItem;
                currentSelectedPerson = selectedStudent;

               
                FirstNameTextBox.Text = selectedStudent.FirstName;
                LastNameTextBox.Text = selectedStudent.LastName;
                StudentIDTextBox.Text = selectedStudent.StudentID.ToString();
                AgeTextBox.Text = selectedStudent.Age.ToString();

               
                Gender.SelectedIndex = selectedStudent.Gender;

              
                if (selectedStudent is UndergraduateStudent)
                {
                    StudentType.SelectedIndex = 0; 
                }
                else if (selectedStudent is GraduateStudent)
                {
                    StudentType.SelectedIndex = 1; 
                }

                StudentIDTextBox.Text = selectedStudent.StudentID.ToString();
                
                

                try
                {

                    CoursesListBox.Items.Clear();
                    courses = currentSelectedPerson.getList();

                    

                    courses = courses.OrderBy(c => c.CoursePrefix).ThenBy(c => c.CourseNumber).ToList();

                    CoursesListBox.Items.Clear();

                    foreach (Course course1 in courses)
                    {
                        CoursesListBox.Items.Add(course1);
                    }

                }

                catch
                {

                }
               
            
            }
        }

        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {

            if (currentSelectedPerson == null)
            {
                MessageBox.Show("A student must be created or selected in order to add a class");
            }

            string courseName = CourseNameTextBox.Text;
            string coursePrefix = CoursePrefixTextBox.Text;
            int courseNumber;
            int creditHours;
            double grade; 

            if (!int.TryParse(CourseNumberTextBox.Text, out courseNumber))
            {

                MessageBox.Show("Please enter a valid courseNumber (type int).");
                return;

            }


            if (!int.TryParse(CreditHoursTextBox.Text, out creditHours))
            {

                MessageBox.Show("Please enter a valid credit hours (type int).");
                return;

            }

            if (!double.TryParse(GPATextBox.Text, out grade))
            {

                MessageBox.Show("Please enter a valid grade (type double).");
                return;

            }




            Course course = new Course(courseName, coursePrefix, courseNumber, creditHours, grade);

            bool result = currentSelectedPerson.AddCourse(course);

            if(!result)
            {
                MessageBox.Show("Please Make sure course number is between 1000-4999 for undergraduate and 5000-9999 for graduate student");
                return; 
            }

            

            courses = currentSelectedPerson.getList();

            courses = courses.OrderBy(c => c.CoursePrefix).ThenBy(c => c.CourseNumber).ToList();

            CoursesListBox.Items.Clear();

            int totalCredits = 0;
            double totalGpa = 0; 



            foreach (Course course1 in courses)
            {
                CoursesListBox.Items.Add(course1);
                totalCredits += course1.CreditHours;
                totalGpa += course1.CreditHours * course1.Grade;

            }

            double GPA = Math.Round(totalGpa / totalCredits, 2);

            TotalGPATextBox.Text = GPA.ToString();





        }



        private void CoursesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CoursesListBox.SelectedIndex != -1)
            {
                Course selectedCourse = (Course)CoursesListBox.SelectedItem;



                CourseNameTextBox.Text = selectedCourse.CourseName;
                CoursePrefixTextBox.Text = selectedCourse.CoursePrefix;
                CourseNumberTextBox.Text = selectedCourse.CourseNumber.ToString();
                CreditHoursTextBox.Text = selectedCourse.CreditHours.ToString();
                GPATextBox.Text = selectedCourse.Grade.ToString();      


            }
        }



    }
}
