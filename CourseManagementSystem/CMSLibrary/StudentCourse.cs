using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class StudentCourse : IData
    {
        public static string Table { get; set; } = "Student_Courses";

        private int studentId;
        private int courseId;
        private bool courseResults;

        public StudentCourse() { }

        public StudentCourse(int studentId, int courseId, bool courseResults)
        {
            this.studentId = studentId;
            this.courseId = courseId;
            this.courseResults = courseResults;
        }

        public int StudentId
        {
            get
            {
                return studentId;
            }

            set
            {
                studentId = value;
            }
        }

        public int CourseId
        {
            get
            {
                return courseId;
            }

            set
            {
                courseId = value;
            }
        }

        public bool CourseResults
        {
            get
            {
                return courseResults;
            }

            set
            {
                courseResults = value;
            }
        }

        public bool Add()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Search()
        {
            throw new NotImplementedException();
        }
    }
}
