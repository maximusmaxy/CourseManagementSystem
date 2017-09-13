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
                txtId.ValidateNumeric(),
                txtCourseId.ValidateNumeric(),
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
                    Semester = Forms.RadioValue(pnlSemester, Types.Semester),
                    Result = Forms.RadioValue(pnlCourseResults, Types.CourseResults)
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

            DialogResult result = MessageBox.Show("Would you like to search for this Enrolment", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Enrolment enrolment = new Enrolment(txtId.Int());

                if (enrolment.Search())
                {
                    txtCourseId.Text = enrolment.CourseId.ToString();
                    txtEnrolmentCost.Text = enrolment.EnrolmentCost.ToString();
                    txtDiscountCost.Text = enrolment.DiscountCost.ToString();
                    dtpEnrolment.Value = enrolment.EnrolmentDate;
                    dtpEnrolment.Value = enrolment.CompletionDate;
                    Forms.CheckRadio(pnlSemester, Types.Semester, enrolment.Semester);
                    Forms.CheckRadio(pnlCourseResults, Types.CourseResults, enrolment.Result);
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Validation.Many(
                txtId.ValidateNumeric(),
                txtCourseId.ValidateNumeric(),
                pnlSemester,
                pnlCourseResults
                ))
            {
                return;
            }
            DialogResult result = MessageBox.Show("Would you like to update this record", "Question",
                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Enrolment enrolment = new Enrolment()
                {
                    Id = txtId.Int(),
                    CourseId = int.Parse(txtCourseId.Text),
                    EnrolmentDate = dtpEnrolment.Value,
                    CompletionDate = dtpCompletion.Value,
                    EnrolmentCost = int.Parse(txtEnrolmentCost.Text),
                    DiscountCost = int.Parse(txtDiscountCost.Text),
                    Semester = Forms.RadioValue(pnlSemester, Types.Semester),
                    Result = Forms.RadioValue(pnlCourseResults, Types.CourseResults)
                };
                if (!enrolment.Update())
                {
                    return;
                }

                MessageBox.Show($"Enrolment id: {enrolment.Id} successfully updated.");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtId))
            {
                return;
            }

            DialogResult result = MessageBox.Show("Would you like to delete this record", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //student
                Enrolment enrolment = new Enrolment(txtId.Int());
                if (!enrolment.Delete())
                {
                    return;
                }
                MessageBox.Show($"Enrolment id: {enrolment.Id} successfully deleted.");
                Forms.ClearControls(this);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            using (ViewAllForm form = new ViewAllForm("Enrolments"))
            {
                form.ShowDialog(this);
                if (form.Id != -1)
                {
                    Enrolment enrolment = new Enrolment(form.Id);
                    if (enrolment.Search())
                    {

                        txtEnrolmentId.Text = enrolment.Id.ToString();
                        txtId.Text = enrolment.StudentId.ToString();
                        txtCourseId.Text = enrolment.CourseId.ToString();
                        txtEnrolmentCost.Text = enrolment.EnrolmentCost.ToString();
                        txtDiscountCost.Text = enrolment.DiscountCost.ToString();
                        dtpEnrolment.Value = enrolment.EnrolmentDate;
                        dtpEnrolment.Value = enrolment.CompletionDate;
                        Forms.CheckRadio(pnlSemester, Types.Semester, enrolment.Semester);
                        Forms.CheckRadio(pnlCourseResults, Types.CourseResults, enrolment.Result);
                    }
                }
            }
        }

        private void CourseId_LostFocus(object sender, EventArgs e)
        {

            Course course = new Course() { Id = txtCourseId.Int() };
            Student student = new Student() { Id = txtId.Int()};
            double discount = 0.0;
            double total = 0.0;
            if (!course.Search()) {
                return;
            }
            if (!student.Search())
            {
                return;
            }
            if (student.Aboriginal)
            {
                discount = course.Cost * 0.5;
            }
            else if (student.Centrelink)
            {
                discount = course.Cost * 0.2;
            }
            else if (student.Disability && student.Centrelink)
            {
                discount = course.Cost * 0.4;
            }
            else if (student.Aboriginal && student.Disability && student.Centrelink) {
                discount = course.Cost * 0.9;
            }
            else
            {
                discount = 0.0;
            }

                txtEnrolmentCost.Text = course.Cost.ToString();
                txtDiscountCost.Text = discount.ToString();
                txtTotal.Text = total.ToString();
        }
    }
}
    
