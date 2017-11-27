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
using System.Globalization;

namespace CMS
{
    public partial class EnrolmentForm : Form, ISearchForm
    {
        public EnrolmentForm()
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
                btnViewAll.Enabled = false;
            }
            if (Forms.Permission == Permission.Teacher || Forms.Permission == Permission.HeadTeacher)
            {
                btnAdd.Enabled = false;
            }
            if (Forms.Permission == Permission.Student)
            {
                txtStudentId.Text = Forms.Id.ToString();
                txtStudentId.Enabled = false;
                btnSearch.Enabled = false;
                Forms.CheckRadio(pnlCourseResults, "Not Completed");
                searchToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                viewAllToolStripMenuItem.Enabled = false;
                teacherCoursesToolStripMenuItem.Enabled = false;
                courseToolStripMenuItem.Enabled = false;
                unitToolStripMenuItem.Enabled = false;
                assessmentToolStripMenuItem.Enabled = false;
                skillsToolStripMenuItem.Enabled = false;
                allocationToolStripMenuItem.Enabled = false;
                globalSearchToolStripMenuItem.Enabled = false;
                Forms.DisableRadio(pnlCourseResults);
                dgvSearch.DataSource = Database.CreateDataTable($"Select students.studentId,(studentFirstName + ' ' + studentLastName) as 'Student Name', courses.courseId,courseName as 'Course Name' from students,enrolments, courses where" +
" students.studentId = enrolments.studentId and courses.courseId = enrolments.courseId and students.studentId = " + txtStudentId.Int());
                //DataTable table = Database.CreateDataTable($"select * from enrolments where studentId = {Forms.Id}");
                //dgvSearch.DataSource = null;
                //dgvSearch.DataSource = table;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //this is add button code is stupid for some reason.
            if (!Validation.Many(
                txtStudentId.ValidateNumeric(),
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
                    StudentId = txtStudentId.Int(),
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
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtStudentId))
                return;
            if (!Validation.Combo(cmbCourseName))
                return;

            DialogResult result = MessageBox.Show("Would you like to search for this Student's Enrolment", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                //Database.CreateDataTable("select unitName as 'Unit Name', assessmentName as 'Assessment Name' " +
                //      "from units, assessments where units.unitid = assessments.unitid and " +
                //      $"units.departmentId = {cmbAreaOfStudy.Int()}");
                //Database.CreateDataTable("Select (studentFirstName + ' ' + studentLastName) as 'Student Name', courseName from students,enrolments, courses where" +
                //    " student.studentId = enrolment.studentId and course.courseId = enrolment.courseId and student.studentId = " + txtId.Int());

                Enrolment enrolment = new Enrolment();

                if (!enrolment.Search("studentid", txtStudentId.Int(), "courseid", cmbCourseName.Int()))
                {
                    return;
                }
                txtEnrolmentCost.Text = enrolment.EnrolmentCost.ToString();
                txtDiscountCost.Text = enrolment.DiscountCost.ToString();
                dtpEnrolment.Value = enrolment.EnrolmentDate;
                dtpCompletion.Value = enrolment.CompletionDate;
                Forms.CheckRadio(pnlSemester, Types.Semester, enrolment.Semester);
                Forms.CheckRadio(pnlCourseResults, Types.CourseResults, enrolment.Result);

                Course course = new Course(enrolment.CourseId);
                if (!course.Search())
                {
                    return;
                }
                cmbAreaOfStudy.SelectedValue = course.DepartmentId;
                cmbCourseName.SelectedValue = enrolment.CourseId;
                dgvSearch.DataSource = Database.CreateDataTable($"Select students.studentId,(studentFirstName + ' ' + studentLastName) as 'Student Name', courses.courseId,courseName as 'Course Name' from students,enrolments, courses where" +
                    " students.studentId = enrolments.studentId and courses.courseId = enrolments.courseId and students.studentId = " + txtStudentId.Int());
                ;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Validation.Many(
                txtStudentId.ValidateNumeric(),
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


                Enrolment enrolment = new Enrolment();
                enrolment.Search("studentId", txtStudentId.Int(), "CourseId", cmbCourseName.Int());
                enrolment.EnrolmentDate = dtpEnrolment.Value;
                enrolment.CompletionDate = dtpCompletion.Value;
                enrolment.EnrolmentCost = double.Parse(txtEnrolmentCost.Text);
                enrolment.DiscountCost = double.Parse(txtDiscountCost.Text);
                enrolment.Semester = Forms.RadioValue(pnlSemester, Types.Semester);
                enrolment.Result = Forms.RadioValue(pnlCourseResults, Types.CourseResults);

                //Course course = new Course(enrolment.CourseId);
                //if (course.Search())
                //{
                //      course.DepartmentId= (int)cmbAreaOfStudy.SelectedValue;
                //      enrolment.CourseId = (int)cmbCourseName.SelectedValue;
                //}

                if (!enrolment.Update())
                {
                    return;
                }

                MessageBox.Show($"Enrolment id: {enrolment.Id} successfully updated.");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtStudentId))
            {
                return;
            }

            DialogResult result = MessageBox.Show("Would you like to delete this record", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //student
                Enrolment enrolment = new Enrolment();
                if (!enrolment.Search("studentid", txtStudentId.Int(), "courseid", cmbCourseName.Int()))
                {
                    return;
                }
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
                form.ReplaceColumn("students", "studentId", "studentFirstName");
                form.AddColumn("students", "studentId", "studentLastName");
                form.ReplaceColumn("courses", "courseId", "courseName");
                form.AddType("semester", Types.Semester);
                form.AddType("results", Types.CourseResults);
                form.ShowDialog(this);
                if (form.Id != -1)
                {
                    Search(form.Id);
                }
            }
        }

        public void Search(int id)
        {
            Enrolment enrolment = new Enrolment(id);
            if (!enrolment.Search())
            {
                return;

            }
            txtStudentId.Text = enrolment.StudentId.ToString();
            txtEnrolmentCost.Text = enrolment.EnrolmentCost.ToString();
            txtDiscountCost.Text = enrolment.DiscountCost.ToString();
            dtpEnrolment.Value = enrolment.EnrolmentDate;
            dtpCompletion.Value = enrolment.CompletionDate;
            Forms.CheckRadio(pnlSemester, Types.Semester, enrolment.Semester);
            Forms.CheckRadio(pnlCourseResults, Types.CourseResults, enrolment.Result);

            Course course = new Course(enrolment.CourseId);
            if (!course.Search())
            {
                return;
            }
            cmbAreaOfStudy.SelectedValue = course.DepartmentId;
            cmbCourseName.SelectedValue = enrolment.CourseId;
            dgvSearch.DataSource = Database.CreateDataTable($"Select students.studentId,(studentFirstName + ' ' + studentLastName) as 'Student Name', courses.courseId,courseName as 'Course Name' from students,enrolments, courses where" +
                " students.studentId = enrolments.studentId and courses.courseId = enrolments.courseId and students.studentId = " + txtStudentId.Int());
            ;
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
            StudentCourseChange();
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

        private void aSsessmentToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int studentId = Convert.ToInt32(((DataTable)dgvSearch.DataSource).Rows[e.RowIndex]["studentId"]);
            int courseId = Convert.ToInt32(((DataTable)dgvSearch.DataSource).Rows[e.RowIndex]["courseId"]);

            Enrolment enrolment = new Enrolment();
            if (enrolment.Search("studentId", studentId, "courseId", courseId))
            {
                txtStudentId.Text = enrolment.StudentId.ToString();

                txtEnrolmentCost.Text = enrolment.EnrolmentCost.ToString();
                txtDiscountCost.Text = enrolment.DiscountCost.ToString();
                dtpEnrolment.Value = enrolment.EnrolmentDate;
                dtpEnrolment.Value = enrolment.CompletionDate;
                Forms.CheckRadio(pnlSemester, Types.Semester, enrolment.Semester);
                Forms.CheckRadio(pnlCourseResults, Types.CourseResults, enrolment.Result);
            }
            Course course = new Course(enrolment.CourseId);
            if (course.Search())
            {
                cmbAreaOfStudy.SelectedValue = course.DepartmentId;
                cmbCourseName.SelectedValue = enrolment.CourseId;
            }
        }
        private void btnClearForm_Click(object sender, EventArgs e)
        {
            Forms.ClearControls(this);
            if (Forms.Permission == Permission.Student)
            {
                txtStudentId.Text = Forms.Id.ToString();
                Forms.CheckRadio(pnlCourseResults, "Not Completed");
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

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {
            StudentCourseChange();
        }

        private void StudentCourseChange()
        {
            try
            {
                //disable search errors
                Validation.ShowErrors = false;
                //course
                if (cmbCourseName.SelectedIndex <= 0)
                {
                    Forms.ClearRadio(pnlCourseResults);
                    txtEnrolmentCost.Text = string.Empty;
                    txtDiscountCost.Text = string.Empty;
                    txtTotal.Text = string.Empty;
                    return;
                }
                Course course = new Course() { Id = cmbCourseName.Int() };
                double discount = 0.0;
                double total = 0.0;
                if (!course.Search())
                {
                    Forms.ClearRadio(pnlCourseResults);
                    txtEnrolmentCost.Text = string.Empty;
                    txtDiscountCost.Text = string.Empty;
                    txtTotal.Text = string.Empty;
                    return;
                }
                CultureInfo ci = new CultureInfo("en-au");
                //String.Equals("AAAAA", "aaaaa", StringComparison.InvariantCultureIgnoreCase);
                txtEnrolmentCost.Text = String.Format(ci, "{0:C}", course.Cost);
                txtDiscountCost.Text = String.Format(ci, "{0:C}", discount);
                total = course.Cost;
                txtTotal.Text = String.Format(ci, "{0:C}", total);
                //student
                int i;
                if (string.IsNullOrEmpty(txtStudentId.Text) || !int.TryParse(txtStudentId.Text, out i))
                {
                    Forms.ClearRadio(pnlCourseResults);
                    return;
                }
                Student student = new Student() { Id = txtStudentId.Int() };
                if (!student.Search())
                {
                    Forms.ClearRadio(pnlCourseResults);
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

                txtDiscountCost.Text = String.Format(ci, "{0:C}", discount);
                total = course.Cost - discount;
                txtTotal.Text = String.Format(ci, "{0:C}", total);

                string sql = "select Student_Assessments.results as result from Student_Assessments, Assessments, Courses, Enrolments, Course_Units, Units where " +
                    "Enrolments.courseId = Courses.courseId and Courses.courseId = Course_Units.courseId and " +
                    "Course_Units.unitId = Units.unitId and Units.unitId = Assessments.unitId and " +
                    "Student_Assessments.assessmentId = Assessments.assessmentId and " +
                    "Enrolments.studentId = " + student.Id + " and Enrolments.courseId = " + course.Id +
                    " and Student_Assessments.studentId = " + student.Id;
                DataTable table = Database.CreateDataTable(sql);
                if (table.Rows.Count == 0)
                    Forms.CheckRadio(pnlCourseResults, "Not Completed");
                else if (table.AsEnumerable().Any(r => Convert.ToInt32(r["result"]) == Types.CourseResults["Fail"]))
                    Forms.CheckRadio(pnlCourseResults, "Fail");
                else if (table.AsEnumerable().Any(r => Convert.ToInt32(r["result"]) == Types.CourseResults["Not Completed"]))
                    Forms.CheckRadio(pnlCourseResults, "Not Completed");
                else
                    Forms.CheckRadio(pnlCourseResults, "Pass");
            }
            finally
            {
                //re-enable search errors
                Validation.ShowErrors = true;
            }
        }
    }
}

