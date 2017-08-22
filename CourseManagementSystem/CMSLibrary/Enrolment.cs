using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class Enrolment : IData
    {
        public static string Table { get; set; } = "enrolments";

        private int id;
        private int studentId;
        private int courseId;
        private DateTime enrolmentDate;
        private DateTime completionDate;
        private double enrolmentCost;
        private double discountCost;
        private int semester;

        public Enrolment() { }

        public Enrolment(int id)
        {
            this.id = id;
        }

        public Enrolment(int id, int studentId, int courseId, DateTime enrolmentDate, DateTime completionDate, double enrolmentCost, double discountCost, int semester)
        {
            this.id = id;
            this.studentId = studentId;
            this.courseId = courseId;
            this.enrolmentDate = enrolmentDate;
            this.completionDate = completionDate;
            this.enrolmentCost = enrolmentCost;
            this.discountCost = discountCost;
            this.semester = semester;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
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

        public DateTime EnrolmentDate
        {
            get
            {
                return enrolmentDate;
            }

            set
            {
                enrolmentDate = value;
            }
        }

        public DateTime CompletionDate
        {
            get
            {
                return completionDate;
            }

            set
            {
                completionDate = value;
            }
        }

        public double EnrolmentCost
        {
            get
            {
                return enrolmentCost;
            }

            set
            {
                enrolmentCost = value;
            }
        }

        public double DiscountCost
        {
            get
            {
                return discountCost;
            }

            set
            {
                discountCost = value;
            }
        }

        public int Semester
        {
            get
            {
                return semester;
            }

            set
            {
                semester = value;
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

        public bool Search()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool ViewAll(DataGridView dgv)
        {
            throw new NotImplementedException();
        }
    }
}
