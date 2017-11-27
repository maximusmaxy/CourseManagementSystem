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
                label2.Enabled = false;
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

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(MainForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(MainForm));
                Close();
            }
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(StudentForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(StudentForm));
                Close();
            }
        }

        private void teacherCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(TeacherForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(TeacherForm));
                Close();
            }
        }

        private void enrolmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(EnrolmentForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(EnrolmentForm));
                Close();
            }
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(CourseForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(CourseForm));
                Close();
            }
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(UnitForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(UnitForm));
                Close();
            }
        }

        private void assessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(AssessmentForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(AssessmentForm));
                Close();
            }
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(SkillsForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(SkillsForm));
                Close();
            }
        }

        private void allocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(AllocationForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(AllocationForm));
                Close();
            }
        }

        private void globalSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to open this form in a new window", "Question",
                                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Forms.ShowForm(typeof(GlobalSearchForm));
            }
            else if (result == DialogResult.No)
            {
                Forms.ShowForm(typeof(GlobalSearchForm));
                Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VBProject.VBClass.ShowCredits();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.LogOut(typeof(LoginForm));
        }
    }
}
