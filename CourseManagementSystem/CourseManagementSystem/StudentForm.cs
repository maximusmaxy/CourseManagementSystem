using CmsLibrary;
using System;
using System.Windows.Forms;

namespace CMS
{
    public partial class StudentForm : Form, ISearchForm
    {
        public StudentForm()
        {
            InitializeComponent();
            SetPermission();
        }

        private void SetPermission()
        {
            if (!Forms.HasPermission(Permission.Admin))
            {
                btnDelete.Enabled = false;
                btnViewAll.Enabled = false;
                btnUpdate.Enabled = false;
                btnAdd.Enabled = false;
            }
            if (!Forms.HasPermission(Permission.Teacher))
            {
                btnSearch.Enabled = false;
            }
            if (Forms.Permission == Permission.Student)
            {
                btnUpdate.Enabled = true;
                txtId.Text = Forms.Id.ToString();
                txtId.Enabled = false;
                addToolStripMenuItem.Enabled = false;
                searchToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                viewAllToolStripMenuItem.Enabled = false;
                teacherToolStripMenuItem.Enabled = false;
                courseToolStripMenuItem.Enabled = false;
                unitToolStripMenuItem.Enabled = false;
                assessmentToolStripMenuItem.Enabled = false;
                skillsToolStripMenuItem.Enabled = false;
                allocationToolStripMenuItem.Enabled = false;
                globalSearchToolStripMenuItem.Enabled = false;
                Search(Forms.Id);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //validation
            if (!Validation.Many(
            txtFirstName.ValidateWord(),
            txtLastName.ValidateWord(),
            txtStreet1.ValidateEmpty(),
            txtSuburb.ValidateEmpty(),
            cmbState,
            txtPostCode.ValidateNumericEmpty(),
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
                    ContactNumber = txtContactNumber.Text,
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
                Search(txtId.Int());
            }
        }

        public void Search(int id) 
        {
            //student
            Student student = new Student(id);
            //student.Search("studentfirstname", txtFirstName.Text);
            if (student.Search())
            {
                txtId.Text = student.Id.ToString();
                txtFirstName.Text = student.FirstName;
                txtLastName.Text = student.LastName;
                dtpDateOfBirth.Value = student.DateOfBirth;
                txtEmail.Text = student.Email;
                cmbCountryOfOrigin.Text = student.CountryOfOrigin;
                Forms.CheckRadio(pnlGender, Types.GenderType, student.Gender);
                txtContactNumber.Text = student.ContactNumber;
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
                    ContactNumber = txtContactNumber.Text,
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
                        txtContactNumber.Text = student.ContactNumber;
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
        
        private void btnClearForm_Click(object sender, EventArgs e)
        {
            Forms.ClearControls(this);
            if (Forms.Permission == Permission.Student)
                txtId.Text = Forms.Id.ToString();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

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
