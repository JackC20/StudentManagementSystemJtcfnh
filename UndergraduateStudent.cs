using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentManagementSystemJtcfnh
{
    class UndergraduateStudent : Person
    {
        public List<Course> Courses { get; private set; }



        public UndergraduateStudent(string firstName, string lastName, int studentID, int gender, int age)
        {
            Courses = new List<Course>();
            FirstName= firstName;
            LastName= lastName;
            StudentID= studentID;
            Gender= gender;
            Age= age;
            
        }

        public override bool AddCourse(Course course)
        {
            if (course.CourseNumber >= 1000 && course.CourseNumber <= 4999)
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
