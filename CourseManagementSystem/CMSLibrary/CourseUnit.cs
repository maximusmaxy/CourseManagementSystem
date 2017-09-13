using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class CourseUnit : IBridgingData
    {
        private int courseId;
        private ListBox control;

        public CourseUnit() { }

        public CourseUnit(int courseId)
        {
            this.courseId = courseId;
        }

        public CourseUnit(int courseId, ListBox control)
        {
            this.courseId = courseId;
            this.control = control;
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
            return Database.UpdateBridgingTable("course_units", "courseid", courseId, "unitid", control);
        }

        public bool Delete()
        {
            return Database.DeleteBridgingTable("course_units", "courseid", courseId);
        }
    }
}
