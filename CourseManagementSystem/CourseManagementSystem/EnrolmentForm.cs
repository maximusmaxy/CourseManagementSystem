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
            Forms.FillData(cmbAreaOfStudy, "departments", "departmentname", "departmentid");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this is add button code is stupid for some reason.
            if (!Validation.Many(
                txtId.ValidateNumeric(),
                cmbCourseName,
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
                    CourseId = cmbCourseName.Int(),
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
                    cmbCourseName.SelectedValue = enrolment.CourseId;
                    txtEnrolmentCost.Text = enrolment.EnrolmentCost.ToString();
                    txtDiscountCost.Text = enrolment.DiscountCost.ToString();
                    dtpEnrolment.Value = enrolment.EnrolmentDate;
                    dtpCompletion.Value = enrolment.CompletionDate;
                    Forms.CheckRadio(pnlSemester, Types.Semester, enrolment.Semester);
                    Forms.CheckRadio(pnlCourseResults, Types.CourseResults, enrolment.Result);
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Validation.Many(
                txtId.ValidateNumeric(),
                cmbCourseName,
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
                    CourseId = cmbCourseName.Int(),
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
                        cmbCourseName.SelectedValue = enrolment.CourseId;
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
        private void cmbAreaOfStudy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!Validation.Many(
            //    txtId.ValidateNumeric(),
            //    cmbCourseName))

            //{
            //    return;
            //}
            {
                Forms.FillData(cmbCourseName, "Courses", "coursename", "courseid", "departmentid", cmbAreaOfStudy.SelectedValue);
                if (cmbAreaOfStudy.SelectedIndex == 0)
                {
                    cmbCourseName.Text = "(Please select an area of study)";
                }
                //Forms.FillData(lstUnitslist, "units", "unitname", "unitid", "departmentid", cmbAreaOfStudy.SelectedValue);
            }
        }
        private void CourseId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //course
            if (cmbCourseName.SelectedIndex <= 0)
            {
                return;
            }
            Course course = new Course() { Id = cmbCourseName.Int() };
            double discount = 0.0;
            double total = 0.0;
            if (!course.Search())
            {
                return;
            }
            txtEnrolmentCost.Text = course.Cost.ToString();
            txtDiscountCost.Text = discount.ToString();
            total = course.Cost;
            txtTotal.Text = total.ToString();
            //student
            int i;
            if (string.IsNullOrEmpty(txtId.Text) || !int.TryParse(txtId.Text, out i))
            {
                return;
            }
            Student student = new Student() { Id = txtId.Int() };
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
            else if (student.Aboriginal && student.Disability && student.Centrelink)
            {
                discount = course.Cost * 0.9;
            }
            else
            {
                discount = 0.0;
            }
            txtDiscountCost.Text = discount.ToString();
            total = course.Cost - discount;
            txtTotal.Text = total.ToString();

        }

        private void txtId_Leave(object sender, EventArgs e)
        {
            CourseId_SelectedIndexChanged(sender, e);
        }
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(MainForm));
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(StudentForm));
        }

        private void teacherCoursesToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void aSsessmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(AssessmentForm));
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(SkillsForm));
        }

        private void allocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(AllocationForm));
        }

        private void globalSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(GlobalSearchForm));
        }
        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(UnitForm));
        }
    }
}

