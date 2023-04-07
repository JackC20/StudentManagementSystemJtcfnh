using System;

namespace StudentManagementSystemJtcfnh
{
    public class Course
    {
        public string CourseName { get; set; }
        public string CoursePrefix { get; set; }
        public int CourseNumber { get; set; }

        public int CreditHours { get; set; }

        public double Grade { get; set; }

        public Course(string courseName, string coursePrefix, int courseNumber, int creditHours, double grade)
        {
            CourseName = courseName;
            CoursePrefix = coursePrefix;
            CourseNumber = courseNumber;
            CreditHours = creditHours;
            Grade = grade;
        }

        public override string ToString()
        {
            return CoursePrefix + " " + CourseNumber; 
        }
    }
}
