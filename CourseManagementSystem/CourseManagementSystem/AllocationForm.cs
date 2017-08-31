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
            Database.ServerName = @"MAXIMUMPENIS\SQLEXPRESS";
            Database.LoadDatabase();
            
            Forms.FillData(cmbAreaOfStudy, "departments", "departmentname", "departmentid");
            cmbAreaOfStudy.Text = "Please select a department.";
        }

        private void cmbAreaOfStudy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!Validation.Combo(cmbAreaOfStudy))
                return;
            Forms.FillData(lstTeacher, "teachers", "(teacherfirstname + ' ' + teacherlastname)", "teacherid", "departmentid", cmbAreaOfStudy.SelectedValue);
        }

        private void lstTeacher_Click(object sender, EventArgs e)
        {
            Forms.FillData(lstCourse, "courses", "coursename", "courseid", "departmentid", cmbAreaOfStudy.SelectedValue);
        }

        private void cmbAreaOfStudy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}