using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class TeacherSkill : IBridgingData
    {
        private int teacherId;
        private ListBox control;

        public TeacherSkill() { }

        public TeacherSkill(int teacherId, ListBox control)
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
            return Database.UpdateBridgingTable("teacher_skills", "teacherid", teacherId, "skillid", control);
        }

        public bool Delete()
        {
            control.ClearSelected();
            return Update();
        }
    }
}
