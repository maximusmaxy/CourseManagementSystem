using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmsLibrary;

namespace CMS
{
    public partial class AllocationForm : Form
    {
        public AllocationForm()
        {
            InitializeComponent();
            //Forms.FillData(cmbAreaOfStudy, "departments", "departmentname", "departmentid");
        }

        private void cmbAreaOfStudy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Validation.Combo(cmbAreaOfStudy))
                return;
            //Forms.FillData(lstTeacher, "teachers", "teacherfirstname", "teacherid", "departmentid", cmbAreaOfStudy.SelectedValue);
        }

        private void lstTeacher_Click(object sender, EventArgs e)
        {
            if (!Validation.Combo(cmbAreaOfStudy))
                return;

        }
    }
}
