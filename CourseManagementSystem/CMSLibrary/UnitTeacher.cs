using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class UnitTeacher : IBridgingData
    {
        private int teacherId;
        private ListBox control;

        public UnitTeacher() { }

        public UnitTeacher(int teacherId, ListBox control)
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
            return Database.UpdateBridgingTable("unit_teachers", "teacherid", teacherId, "unitid", control, false);
        }

        public bool Delete()
        {
            control.ClearSelected();
            return Update();
        }
    }
}
