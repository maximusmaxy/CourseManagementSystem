﻿using CmsLibrary;
using System;
using System.Windows.Forms;

namespace CMS
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //validation
            if (!Validation.Many(
            txtFirstName.ValidateWord(),
            txtLastName.ValidateWord(),
            txtStreet1.ValidateEmpty(),
            txtContactNumber.ValidatePhone(),
            txtEmail.ValidateEmail(),
            dtpDateOfBirth,
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
                    Aboriginal = chkDropKick.Checked,
                    Centrelink = chkCentrelink.Checked,
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
                //student.Search("studentfirstname", txtFirstName.Text);
                if (student.Search())
                {
                    txtFirstName.Text = student.FirstName;
                    txtLastName.Text = student.LastName;
                    dtpDateOfBirth.Value = student.DateOfBirth;
                    txtEmail.Text = student.Email;
                    cmbCountryOfOrigin.Text = student.CountryOfOrigin;
                    Forms.CheckRadio(pnlGender, Types.GenderType, student.Gender);
                    chkDropKick.Checked = student.Aboriginal;
                    chkCentrelink.Checked = student.Centrelink;
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
                    Aboriginal = chkDropKick.Checked,
                    Centrelink = chkCentrelink.Checked,
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
            using (ViewAllForm form = new ViewAllForm("students"))
            {
                form.ReplaceColumn("locations", "locationId", "addressStreet1");
                form.AddColumn("locations", "locationId", "addressStreet2");
                form.AddColumn("locations", "locationId", "addressSuburb");
                form.AddColumn("locations", "locationId", "addressState");
                form.AddColumn("locations", "locationId", "addressPostCode");
                form.AddType("studentGender", Types.GenderType);
                form.ShowDialog(this);
                if (form.Id != -1)
                {
                    Student student = new Student(form.Id);
                    if (student.Search())
                    {
                        txtId.Text = student.Id.ToString();
                        txtFirstName.Text = student.FirstName;
                        txtLastName.Text = student.LastName;
                        dtpDateOfBirth.Value = student.DateOfBirth;
                        txtEmail.Text = student.Email;
                        cmbCountryOfOrigin.Text = student.CountryOfOrigin;
                        Forms.CheckRadio(pnlGender, Types.GenderType, student.Gender);
                        chkDropKick.Checked = student.Aboriginal;
                        chkCentrelink.Checked = student.Centrelink;
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

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }









        //comment
    }
}
