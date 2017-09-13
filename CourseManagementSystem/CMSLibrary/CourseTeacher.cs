using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class CourseTeacher : IBridgingData
    {
        private int teacherId;
        private ListBox control;

        public CourseTeacher() { }

        public CourseTeacher(int teacherId)
        {
            this.teacherId = teacherId;
        }

        public CourseTeacher(int teacherId, ListBox control)
        {
            this.teacherId = teacherId;
            this.control = control;
        }

        public int TeacherId
        {
            get
            {
                return teacherId;
            }
            set
            {
                teacherId = value;
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

        public bool Update()
        {
            return Database.UpdateBridgingTable("course_teachers", "teacherid", teacherId, "courseid", control, false);
        }

        public bool Delete()
        {
            return Database.DeleteBridgingTable("Course_Teachers", "teacherId", teacherId);
        }
    }
}
