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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetPermissions();
        }

        private void SetPermissions()
        {
            if (Forms.Permission == Permission.Student)
            {
                btnAllocationForm.Enabled = false;
                btnAssessmentForm.Enabled = false;
                btnCourseForm.Enabled = false;
                btnGlobalSearchForm.Enabled = false;
                btnSkillsForm.Enabled = false;
                btnTeacherForm.Enabled = false;
                btnUnitForm.Enabled = false;
            }
            else if (Forms.Permission == Permission.Teacher)
            {
                btnSkillsForm.Enabled = false;
                btnAllocationForm.Enabled = false;
                btnGlobalSearchForm.Enabled = false;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Database.ServerName = "MAXIMUMPENIS\\SQLEXPRESS";
            //Database.LoadDatabase();
        }

        private void btnTeacherForm_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(TeacherForm));
            Close();
        }

        private void btnStudentForm_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(StudentForm));
            Close();
        }

        private void btnEnrolementForm_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(EnrolmentForm));
            Close();
        }

        private void btnCourseForm_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(CourseForm));
            Close();
        }

        private void btnUnitForm_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(UnitForm));
            Close();
        }

        private void btnAssessmentForm_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(AssessmentForm));
            Close();
        }

        private void btnSkillsForm_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(SkillsForm));
            Close();
        }

        private void btnAllocationForm_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(AllocationForm));
            Close();
        }

        private void btnGlobalSearchForm_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(GlobalSearchForm));
            Close();
        }
    }
}
