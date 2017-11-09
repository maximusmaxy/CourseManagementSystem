using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class StudentUnit : IBridgingData
    {
        private int studentId;
        private int results;
        private ListBox control;

        public StudentUnit(int studentId, ListBox control)
        {
            this.studentId = studentId;
            this.control = control;
            results = Types.CourseResults["Not Completed"];
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

        public ListBox Control
        {
            get
            {
                return control;
            }

            set
            {
                control = value;
            }
        }

        public int Results
        {
            get
            {
                return results;
            }

            set
            {
                results = value;
            }
        }

        public bool Delete()
        {
            return Database.DeleteBridgingTable("students_units", "studentId", studentId);
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
