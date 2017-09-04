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
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Database.ServerName = "MAXIMUMPENIS\\SQLEXPRESS";
            Database.LoadDatabase();
        }

        

        private void btnTeacherForm_Click(object sender, EventArgs e)
        {
            TeacherForm frm = new TeacherForm();
            frm.Show();
        }

        private void btnStudentForm_Click(object sender, EventArgs e)
        {
            StudentForm frm = new StudentForm();
            frm.Show();
        }

        private void btnEnrolementForm_Click(object sender, EventArgs e)
        {
            EnrolmentForm frm = new EnrolmentForm();
            frm.Show();
        }

        private void btnCourseForm_Click(object sender, EventArgs e)
        {
            CourseForm frm = new CourseForm();
            frm.Show();
        }

        private void btnUnitForm_Click(object sender, EventArgs e)
        {
            UnitForm frm = new UnitForm();
            frm.Show();
        }

        private void btnAssessmentForm_Click(object sender, EventArgs e)
        {
            AssessmentForm frm = new AssessmentForm();
            frm.Show();
        }

        private void btnSkillsForm_Click(object sender, EventArgs e)
        {
            SkillsForm frm = new SkillsForm();
            frm.Show();
        }

        private void btnAllocationForm_Click(object sender, EventArgs e)
        {
            AllocationForm frm = new CMS.AllocationForm();
            frm.Show();
        }

        private void btnGlobalSearchForm_Click(object sender, EventArgs e)
        {
            GlobalSearchForm frm = new CMS.GlobalSearchForm();
            frm.Show();
        }
    }
}
