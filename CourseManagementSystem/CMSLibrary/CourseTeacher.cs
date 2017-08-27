using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class CourseTeacher : IData
    {
        private ListBox control;
        private List<int> values;

        public CourseTeacher() { }

        public CourseTeacher(ListBox control)
        {
            this.control = control;
            DataTable table = (DataTable)control.DataSource;
            for (int i = 0; i < table.Rows.Count; i++)
                values.Add(Convert.ToInt32(table.Rows[i]));
            
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

        public bool Add()
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

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
