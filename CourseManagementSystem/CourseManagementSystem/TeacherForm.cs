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
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            Database.LoadDatabase();

            //Forms.FillData(cmbCampus, "locations", "campus", "locationid");
            Forms.FillData(cmbDepartment, "Departments", "DepartmentName", "DepartmentId");
            Forms.FillData(lstSkillsList, "skills", "skillname", "skillId");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //validation
            if (!Validation.Many(
            txtFirstName.ValidateWord(),
            txtLastName.ValidateWord(),
            cmbCampus,
            cmbDepartment
            ))
            {
                return;
            }

            DialogResult result = MessageBox.Show("Would you like to add this teacher", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Teacher
                Teacher teacher = new Teacher()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    LocationId = cmbCampus.Int(),
                    DepartmentId = cmbDepartment.Int()
                };
                //Teacher Skill
                TeacherSkill teacherskill = new TeacherSkill(teacher.Id, lstSkillsList);
                teacherskill.Update();
                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //validation
            if (!Validation.Numeric(txtId))
                return;

            DialogResult result = MessageBox.Show("Would you like to search for this teacher", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //validation
            if (!Validation.Many(
                txtId.ValidateNumeric(),
                txtFirstName.ValidateWord(),
                txtLastName.ValidateWord(),
                cmbCampus,
                cmbDepartment
                ))
            {
                return;
            }

            DialogResult result = MessageBox.Show("Would you like to update this record", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //validation
            if (!Validation.Numeric(txtId))
            {
                return;
            }

            DialogResult result = MessageBox.Show("Would you like to delete this record", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet coded");
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnViewAll_Click(sender, e);
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForm frm = new StudentForm();
            frm.Show();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherForm frm = new TeacherForm();
            frm.Show();
        }

        private void enrolmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnrolmentForm frm = new EnrolmentForm();
            frm.Show();
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseForm frm = new CourseForm();
            frm.Show();
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitForm frm = new UnitForm();
            frm.Show();
        }

        private void assessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssessmentForm frm = new AssessmentForm();
            frm.Show();
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkillsForm frm = new SkillsForm();
            frm.Show();
        }
    }
}
