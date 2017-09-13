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

            Forms.FillData(cmbCampus, "locations", "campus", "locationid","select campus, locationid from locations where campus is not null");
            Forms.FillData(cmbDepartment, "Departments", "DepartmentName", "DepartmentId");
            cmbDepartment_SelectedIndexChanged(null, null);

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
                //Teacher
                Teacher teacher = new Teacher(txtId.Int());
                if(teacher.Search())
                {
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
                //Teacher
                Teacher teacher = new Teacher(txtId.Int());
                if (!teacher.Delete())
                {
                    return;
                }
                MessageBox.Show($"Student id: {teacher.Id} successfully deleted.");
                Forms.ClearControls(this);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            using (ViewAllForm form = new ViewAllForm("students"))
            {
               
                form.ShowDialog(this);
                if (form.Id != -1)
                {
                    Teacher teacher = new Teacher(form.Id);
                    if (teacher.Search())
                    {
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
            Forms.ShowForm(typeof(MainForm));
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(StudentForm));
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(TeacherForm));
        }

        private void enrolmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(EnrolmentForm));
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(CourseForm));
        }

        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(UnitForm));
        }

        private void assessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(AssessmentForm));
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(SkillsForm));
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cmbDepartment.DisplayMember == "DepartmentName" && cmbDepartment.ValueMember == "DepartmentId")
            Forms.FillData(lstSkillsList, "skills", "skillname", "skillId", "departmentid", cmbDepartment.SelectedValue);
        }
    }
}
