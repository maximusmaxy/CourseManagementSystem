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
    public partial class SkillsForm : Form, ISearchForm
    {
        public SkillsForm()
        {
            InitializeComponent();
            Forms.FillData(cmbAreaOfStudy, "departments", "departmentname", "departmentid");
            SetPermission();
        }

        private void SetPermission()
        {
            if (!Forms.HasPermission(Permission.Admin))
            {
                btnDelete.Enabled = false;
            }
            if (Forms.Permission == Permission.Teacher)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnSearch.Enabled = false;
                btnViewAll.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Validation.Word(txtSkillName) || !Validation.Combo(cmbAreaOfStudy)  || !Validation.Word(txtSkillDescription))
            {
                MessageBox.Show("Failed to Validate, please try again");
            }


            else
            {
                Skill newSkill = new Skill();
                newSkill.Name = txtSkillName.Text;
                newSkill.DepartmentId = Convert.ToInt32(cmbAreaOfStudy.SelectedValue);
                newSkill.Description = txtSkillDescription.Text;

                if (!newSkill.Add())
                {
                    MessageBox.Show("Failed to Add new Skill");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtSkillID)
           )
            {
                MessageBox.Show("Failed to Validate, please try again");
            }

            else
            {
                Search(txtSkillID.Int());
            }
        }

        public void Search(int id)
        {
            Skill Skill = new Skill();
            Skill.Id = id;
            if (!Skill.Search())
            {
                MessageBox.Show("Failed to find a Skill with the ID :" + txtSkillID.Text);
            }
            else
            {
                txtSkillID.Text = Skill.Id.ToString();
                txtSkillName.Text = Skill.Name;
                cmbAreaOfStudy.SelectedValue = Skill.DepartmentId;
                txtSkillDescription.Text = Skill.Description;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtSkillID) || !Validation.Word(txtSkillName) || !Validation.Combo(cmbAreaOfStudy) || !Validation.Word(txtSkillDescription))
            { 
                MessageBox.Show("Failed to Validate, please try again");
            }


            else
            {
                Skill Skill = new Skill()
                {
                    Id = txtSkillID.Int(),
                    Name = txtSkillName.Text,
                    DepartmentId = Convert.ToInt32(cmbAreaOfStudy.SelectedValue),
                    Description = txtSkillDescription.Text
                };
                MessageBox.Show("I MADE IT WOOOO");
                if (!Skill.Update())
                {
                    MessageBox.Show("Failed to Update the Selected Skill");
                    return;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtSkillID))
            {
                MessageBox.Show("Failed to Validate, please try again");
            }

            Skill Skill = new Skill();
            Skill.Id = txtSkillID.Int();
            if (!Skill.Delete())
            {
                MessageBox.Show("Failed to Delete the Selected Skill");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            using (ViewAllForm form = new ViewAllForm("Units"))
            {
                form.ShowDialog(this);
                if (form.Id != -1)
                {
                    Skill Skill = new Skill(form.Id);
                    if (Skill.Search())
                    {
                        txtSkillID.Text = Skill.Id.ToString();
                        txtSkillName.Text = Skill.Name;
                        cmbAreaOfStudy.SelectedValue = Skill.DepartmentId;
                        txtSkillDescription.Text = Skill.Description;
                    }
                }
            }
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
    }
}
