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
    public partial class EnrolmentForm : Form
    {
        public EnrolmentForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this is add button code is stupid for some reason.
            if (!Validation.Many(
                txtId.ValidateWord(),
                txtCourseId.ValidateWord(),
                dtpCompletion,
                pnlSemester,
                pnlCourseResults
                ))
            {
                return;
            }
            DialogResult result = MessageBox.Show("Would you like to enrol this student", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Enrolment enrolment = new Enrolment()
                {
                    StudentId = txtId.Int(),
                    CourseId = txtCourseId.Int(),
                    EnrolmentDate = dtpEnrolment.Value,
                    CompletionDate = dtpCompletion.Value,
                    EnrolmentCost = txtEnrolmentCost.Cost(),
                    DiscountCost = txtDiscountCost.Cost(),
                    Semester = Forms.RadioValue(pnlSemester,Types.Semester),
                    Result= Forms.RadioValue(pnlCourseResults,Types.CourseResults)
                };
                if (!enrolment.Add())
                {
                    return;
                }
                //success!
                MessageBox.Show($"Enrolment id: {enrolment.Id} added successfully.");
                txtId.Text = enrolment.Id.ToString();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtId))
                return;

            DialogResult result = MessageBox.Show("Would you like to search for this student", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //student
                Enrolment enrolment = new Enrolment(txtId.Int());
                //student.Search("studentfirstname", txtFirstName.Text);
                if (enrolment.Search())
                {
                    txtCourseId.Text = enrolment.CourseId.ToString();

                    //txtFirstName.Text = student.FirstName;
                    //txtLastName.Text = student.LastName;
                    //dtpDateOfBirth.Value = student.DateOfBirth;
                    //txtEmail.Text = student.Email;
                    //cmbCountryOfOrigin.Text = student.CountryOfOrigin;
                    //Forms.CheckRadio(pnlGender, Types.GenderType, student.Gender);
                    //chkDisability.Checked = student.Disability;
                    //txtDisabilityDescription.Text = student.DisabilityDescription;
                }
            }
        }
    }
}
