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
    public partial class AssessmentForm : Form, ISearchForm
    {
        public AssessmentForm()
        {
            InitializeComponent();
            Forms.FillData(cmbAreaOfStudy, "departments", "departmentname", "departmentid");
            Forms.FillData(cmbUnit, "units", "unitname", "unitid");
            SetPermission();
        }

        private void SetPermission()
        {
            if (!Forms.HasPermission(Permission.Admin))
            {
                btnDelete.Enabled = false;
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

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Validation.Combo(cmbAreaOfStudy) || !Validation.Combo(cmbUnit) || !Validation.Combo(cmbTeacher) || 
                !Validation.Date(dtpStart) || !Validation.Date(dtpDue) || !Validation.Word(txtDescription)
                )
            {
                MessageBox.Show("Failed to Validate, please try again");
            }

            else
            {
                Assessment Assessment = new Assessment();
                Assessment.Name = txtAssessmentName.Text;
                Assessment.DepartmentId = cmbAreaOfStudy.Int();
                Assessment.UnitId = cmbUnit.Int();
                Assessment.TeacherId = cmbTeacher.Int();
                Assessment.StartDate = dtpStart.Value;
                Assessment.DueDate = dtpDue.Value;
                Assessment.Description = txtDescription.Text;

                if (!Assessment.Add())
                {
                    MessageBox.Show("Failed to Add new Assessment");
                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtAssessmentId)
)
            {
                MessageBox.Show("Failed to Validate, please try again");
            }

            else
            {
                Search(txtAssessmentId.Int());
            }
        }

        public void Search(int id)
        {
            Assessment Assessment = new Assessment();
            Assessment.Id = id;
            if (!Assessment.Search())
            {
                MessageBox.Show("Failed to find an Assessment with the ID :" + txtAssessmentId.Text);
            }
            else
            {
                txtAssessmentId.Text = Assessment.Id.ToString();
                txtAssessmentName.Text = Assessment.Name;
                cmbAreaOfStudy.SelectedValue = Assessment.DepartmentId;
                cmbUnit.SelectedValue = Assessment.UnitId;
                cmbTeacher.SelectedValue = Assessment.TeacherId;
                dtpStart.Value = Assessment.StartDate;
                dtpDue.Value = Assessment.DueDate;
                txtDescription.Text = Assessment.Description;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtAssessmentId) || !Validation.Word(txtAssessmentName) || !Validation.Combo(cmbAreaOfStudy) || !Validation.Combo(cmbUnit)
                || !Validation.Combo(cmbTeacher) || !Validation.Date(dtpStart) || !Validation.Date(dtpDue) || !Validation.Word(txtDescription)
            )
            {
                MessageBox.Show("Failed to Validate, please try again");
            }


            else
            {
                Assessment Assessment = new Assessment();
                Assessment.Id = txtAssessmentId.Int();
                Assessment.Name = txtAssessmentName.Text;
                Assessment.DepartmentId = cmbAreaOfStudy.Int();
                Assessment.UnitId = cmbUnit.Int();
                Assessment.TeacherId = cmbTeacher.Int();
                Assessment.StartDate = dtpStart.Value;
                Assessment.DueDate = dtpDue.Value;
                Assessment.Description = txtDescription.Text;

                if (!Assessment.Update())
                {
                    MessageBox.Show("Failed to Update the Selected Assessment");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Assessment Assessment = new Assessment();
            Assessment.Id = txtAssessmentId.Int();
            if (!Assessment.Delete())
            {
                MessageBox.Show("Failed to Delete the Selected Assessment");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            using (ViewAllForm form = new ViewAllForm("Assessments"))
            {
                form.ShowDialog(this);
                if (form.Id != -1)
                {
                    Assessment Assessment = new Assessment(form.Id);
                    if (Assessment.Search())
                    {
                        txtAssessmentId.Text = Assessment.Id.ToString();
                        txtAssessmentName.Text = Assessment.Name;
                        cmbAreaOfStudy.SelectedValue = Assessment.DepartmentId;
                        cmbUnit.SelectedValue = Assessment.UnitId;
                        cmbTeacher.SelectedValue = Assessment.TeacherId;
                        dtpStart.Value = Assessment.StartDate;
                        dtpDue.Value = Assessment.DueDate;
                        txtDescription.Text = Assessment.Description;
                    }
                }
            }
        }

        private void cmbAreaOfStudy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Forms.FillData(cmbTeacher, "teachers", "(teacherfirstname + ' ' + teacherlastname)", "teacherid", "departmentid", cmbAreaOfStudy.SelectedValue);
        }
    }
}
