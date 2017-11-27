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
    public partial class TeacherForm : Form, ISearchForm
    {
        public TeacherForm()
        {
            InitializeComponent();
            Forms.FillData(cmbCampus, "locations", "campus", "locationid", "select campus, locationid from locations where campus is not null");
            Forms.FillData(cmbDepartment, "Departments", "DepartmentName", "DepartmentId");
            cmbDepartment_SelectedIndexChanged(null, null);
            SetPermission();
        }

        private void SetPermission()
        {
            if (!Forms.HasPermission(Permission.Admin))
            {
                btnDelete.Enabled = false;
                btnViewAll.Enabled = false;
                btnAdd.Enabled = false;
            }
            if (Forms.Permission == Permission.HeadTeacher)
            {
                Search(Forms.Id);
            }
            if (Forms.Permission == Permission.Teacher)
            {
                btnSearch.Enabled = false;
                txtId.Text = Forms.Id.ToString();
                if (Forms.Permission == Permission.Teacher)
                    txtId.Enabled = false;
                Search(Forms.Id);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //validation
            if (!Validation.Many(
            txtFirstName.ValidateWord(),
            txtLastName.ValidateWord(),
            txtContactNumber.ValidatePhone(),
            txtEmail.ValidateEmail(),
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
                //location
                Location location = new Location()
                {
                   Campus = cmbCampus.NullString()
                };
                if (!location.Add())
                {
                    return;
                }

                //Teacher
                Teacher teacher = new Teacher()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    ContactNumber = txtContactNumber.Text,
                    Email = txtEmail.Text,
                    LocationId = cmbCampus.Int(),
                    DepartmentId = cmbDepartment.Int()
                };
                if(!teacher.Add())
                {
                    return;
                }

                //Teacher Skill
                TeacherSkill teacherskill = new TeacherSkill(teacher.Id, lstSkillsList);
                if (!teacherskill.Update())
                {
                    return;
                }
                MessageBox.Show($"Teacher id: {teacher.Id} successfully added.");
                txtId.Text = teacher.Id.ToString();
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
                Search(txtId.Int());
            }
        }

        public void Search(int id)
        {
            //Teacher
            Teacher teacher = new Teacher(id);
            if (teacher.Search())
            {
                txtId.Text = teacher.Id.ToString();
                txtFirstName.Text = teacher.FirstName;
                txtLastName.Text = teacher.LastName;
                txtContactNumber.Text = teacher.ContactNumber;
                txtEmail.Text = teacher.Email;
                cmbDepartment.SelectedValue = teacher.DepartmentId;
                //Location
                Location location = new Location(teacher.LocationId);
                if (location.Search())
                {
                    cmbCampus.Text = location.Campus;
                }
                Forms.SelectData(lstSkillsList, "teacher_skills", "teacherid", teacher.Id, "skillid");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //validation
            if (!Validation.Many(
                txtId.ValidateNumeric(),
                txtFirstName.ValidateWord(),
                txtLastName.ValidateWord(),
                txtContactNumber.ValidatePhone(),
                txtEmail.ValidateEmail(),
                cmbCampus,
                cmbDepartment
                ))
            {
                return;
            }
            //make sure head teachers can only update themself
            if (Forms.Permission == Permission.HeadTeacher)
            {
                if (txtId.Int() != Forms.Id)
                {
                    MessageBox.Show("You can only update your own record.");
                    return;
                }
            }

            DialogResult result = MessageBox.Show("Would you like to update this record", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //location
                Location location = new Location()
                {
                    Campus = cmbCampus.NullString()
                };
                if (!location.Update())
                {
                    return;
                }

                //Teacher
                Teacher teacher = new Teacher()
                {
                    Id = txtId.Int(),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    ContactNumber = txtContactNumber.Text,
                    Email = txtEmail.Text,
                    LocationId = location.Id,
                    DepartmentId = cmbDepartment.Int()
                };
                if (!teacher.Update())
                {
                    return;
                }
                MessageBox.Show($"Teacher id: {teacher.Id} successfully updated.");
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
                //Teacher Skill
                TeacherSkill teacherSkill = new TeacherSkill(txtId.Int());
                if (!teacherSkill.Delete())
                {
                    return;
                }
                //Teacher
                Teacher teacher = new Teacher(txtId.Int());
                if (!teacher.Delete())
                {
                    return;
                }
                MessageBox.Show($"Teacher id: {teacher.Id} successfully deleted.");
                Forms.ClearControls(this);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            using (ViewAllForm form = new ViewAllForm("teachers"))
            {
                form.AddLookUp("departments", "departmentId", "departmentid", "departmentname");
                form.ReplaceColumn("locations", "locationId", "campus");
                form.ShowDialog(this);
                if (form.Id != -1)
                {
                    Teacher teacher = new Teacher(form.Id);
                    if (teacher.Search())
                    {
                        txtId.Text = teacher.Id.ToString();
                        txtFirstName.Text = teacher.FirstName;
                        txtLastName.Text = teacher.LastName;
                        txtContactNumber.Text = teacher.ContactNumber;
                        txtEmail.Text = teacher.Email;
                        cmbDepartment.SelectedValue = teacher.DepartmentId;
                        //Location
                        Location location = new Location(teacher.LocationId);
                        if (location.Search())
                        {
                            cmbCampus.Text = location.Campus;
                        }

                        Forms.SelectData(lstSkillsList, "teacher_skills", "teacherid", teacher.Id, "skillid");
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

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cmbDepartment.DisplayMember == "DepartmentName" && cmbDepartment.ValueMember == "DepartmentId")
            Forms.FillData(lstSkillsList, "skills", "skillname", "skillId", "departmentid", cmbDepartment.SelectedValue);
            lstSkillsList.ClearSelected();
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            Forms.ClearControls(this);
            if (Forms.Permission == Permission.Teacher || Forms.Permission == Permission.HeadTeacher)
            {
                txtId.Text = Forms.Id.ToString();
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

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.LogOut(typeof(LoginForm));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VBProject.VBClass.ShowCredits();
        }
    }
}
