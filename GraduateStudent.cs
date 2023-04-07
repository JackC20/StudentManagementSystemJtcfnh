using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace StudentManagementSystemJtcfnh
{
    class GraduateStudent : Person
    {
        public List<Course> Courses { get; private set; }

        public GraduateStudent(string firstName, string lastName, int studentID, int gender, int age)
        {
            Courses = new List<Course>();
            FirstName = firstName;
            LastName = lastName;
            StudentID = studentID;
            Gender = gender;
            Age = age;
        }

        public override bool AddCourse(Course course)
        {
            if (course.CourseNumber >= 5000 && course.CourseNumber <= 9999)
            {
                Courses.Add(course);
                return true;
            }
            else
            {
                return false; 
            }
        }

        public override List<Course> getList()
        {
            return Courses;
        }

        public override string ToString()
        {
            return LastName + " " + FirstName;
        }
    }
}
