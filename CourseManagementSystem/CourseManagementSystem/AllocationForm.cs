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
            Database.LoadDatabase();
            Forms.FillData(cmbAreaOfStudy, "departments", "departmentname", "departmentid");
            cmbAreaOfStudy.SelectedIndex = -1;
            cmbAreaOfStudy.Text = "Please select a department.";
        }

        private void cmbAreaOfStudy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!Validation.Combo(cmbAreaOfStudy))
                return;
            lstCourse.DataSource = null;
            lstUnit.DataSource = null;
            lstAssignment.DataSource = null;
            Forms.FillData(lstTeacher, "teachers", "(teacherfirstname + ' ' + teacherlastname)", "teacherid", "departmentid", cmbAreaOfStudy.SelectedValue);
        }

        private void lstTeacher_Click(object sender, EventArgs e)
        {
            Forms.FillData(lstCourse, "courses", "coursename", "courseid", "departmentid", cmbAreaOfStudy.SelectedValue);
        }

        private void lstCourse_Click(object sender, EventArgs e)
        {
            Forms.FillData(lstUnit, null, "unitname", "unitid", "select unitname, units.unitid as unitid from units, course_units where units.unitid = course_units.unitid");
        }

        private void lstUnit_Click(object sender, EventArgs e)
        {
            Forms.FillData(lstAssignment, "assessments", "assessmentname", "assessmentid", "unitid", lstUnit.SelectedValue);
        }
    }
}