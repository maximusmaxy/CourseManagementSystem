using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class CourseUnit
    {
        public static string Table { get; set; } = "course_units";

        private int courseId;
        private int unitId;

        public CourseUnit() { }

        public CourseUnit(int courseId, int unitId)
        {
            this.courseId = courseId;
            this.unitId = unitId;
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

        public int UnitId
        {
            get
            {
                return unitId;
            }

            set
            {
                unitId = value;
            }
        }
    }
}
