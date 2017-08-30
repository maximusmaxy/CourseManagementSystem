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
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            Database.LoadDatabase();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //validation
            if (!Validation.Many(
            txtFirstName.ValidateWord(),
            txtLastName.ValidateWord(),
            txtStreet1.ValidateEmpty(),
            txtEmail.ValidateEmail(),
            cmbCountryOfOrigin,
            pnlGender
            ))
            {
                return;
            }

            DialogResult result = MessageBox.Show("Would you like to add this student", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //location
                Location location = new Location()
                {
                    AddressStreet1 = txtStreet1.Text,
                    AddressStreet2 = txtStreet2.NullString(),
                    AddressSuburb = txtSuburb.NullString(),
                    AddressState = cmbState.NullString(),
                    AddressPostCode = txtPostCode.NullInt()
                };
                if (!location.Add())
                {
                    return;
                }
                //student
                Student student = new Student()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    LocationId = location.Id,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Email = txtEmail.Text,
                    CountryOfOrigin = cmbCountryOfOrigin.Text,
                    Gender = Forms.RadioValue(pnlGender, Types.GenderType),
                    Disability = chkDisability.Checked,
                    DisabilityDescription = chkDisability.Checked ? txtDisabilityDescription.Text : null
                };
                if (!student.Add())
                {
                    return;
                }
                //success!
                MessageBox.Show($"Student id: {student.Id} added successfully.");
                txtId.Text = student.Id.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //validation
            if (!Validation.Numeric(txtId))
                return;

            DialogResult result = MessageBox.Show("Would you like to search for this student", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //student
                Student student = new Student(txtId.Int());
                if (student.Search())
                {
                    txtFirstName.Text = student.FirstName;
                    txtLastName.Text = student.LastName;
                    dtpDateOfBirth.Value = student.DateOfBirth;
                    txtEmail.Text = student.Email;
                    cmbCountryOfOrigin.Text = student.CountryOfOrigin;
                    Forms.CheckRadio(pnlGender, Types.GenderType, student.Gender);
                    chkDisability.Checked = student.Disability;
                    txtDisabilityDescription.Text = student.DisabilityDescription;
                    //location
                    Location location = new Location(student.LocationId);
                    if (location.Search())
                    {
                        txtStreet1.Text = location.AddressStreet1;
                        txtStreet2.Text = location.AddressStreet2;
                        txtSuburb.Text = location.AddressSuburb;
                        cmbState.Text = location.AddressState;
                        txtPostCode.Text = location.AddressPostCode.ToString();
                    }
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
                txtStreet1.ValidateEmpty(),
                txtEmail.ValidateEmail(),
                cmbCountryOfOrigin,
                pnlGender
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
                    AddressStreet1 = txtStreet1.Text,
                    AddressStreet2 = txtStreet2.NullString(),
                    AddressSuburb = txtSuburb.NullString(),
                    AddressState = cmbState.NullString(),
                    AddressPostCode = txtPostCode.NullInt()
                };
                if (!location.Update())
                {
                    return;
                }
                //student
                Student student = new Student()
                {
                    Id = txtId.Int(),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    LocationId = location.Id,
                    DateOfBirth = dtpDateOfBirth.Value,
                    Email = txtEmail.Text,
                    CountryOfOrigin = cmbCountryOfOrigin.Text,
                    Gender = Forms.RadioValue(pnlGender, Types.GenderType),
                    Disability = chkDisability.Checked,
                    DisabilityDescription = chkDisability.Checked ? txtDisabilityDescription.Text : null
                };
                if (!student.Update())
                {
                    return;
                }

                MessageBox.Show($"Student id: {student.Id} successfully updated.");
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
                //student
                Student student = new Student(txtId.Int());
                if (!student.Delete())
                {
                    return;
                }
                MessageBox.Show($"Student id: {student.Id} successfully deleted.");
                Forms.ClearControls(this);
            }
        }

        private void chkDisability_CheckedChanged(object sender, EventArgs e)
        {
            txtDisabilityDescription.Enabled = chkDisability.Checked;
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented.");
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









        //comment
    }
}
