using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystemJtcfnh
{
    abstract class Person
    {
        private string? firstName;
        private string? lastName;
        /// <summary>
        /// 0 for male
        /// 1 for female
        /// 2 for other
        /// </summary>
        private int gender;
        private int age;
        private int studentID;

        public List<Course> Courses { get; private set; }



        public string? FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string? LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public int Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public int StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                studentID = value;
            }
        }

        public virtual bool AddCourse(Course course){ return true; }

        public virtual List<Course> getList() { return Courses; }

    }
}

