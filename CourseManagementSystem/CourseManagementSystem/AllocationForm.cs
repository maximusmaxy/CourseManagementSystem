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
    public partial class AllocationForm : Form
    {
        public AllocationForm()
        {
            InitializeComponent();
            Forms.FillData(cmbAreaOfStudy, "departments", "departmentname", "departmentid");
            SetPermission();
        }

        private void SetPermission()
        {
            //permission
        }

        private void cmbAreaOfStudy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAreaOfStudy.SelectedValue != DBNull.Value)
            {
                BindingList<Data> list = new BindingList<Data>
                {
                    new Data("(Please select an option)", null),
                    new Data("Teachers", "teacher"),
                    new Data("Courses", "course"),
                    new Data("Units", "unit")
                };
                Forms.SetDataSource(cmbSel1, list);
            }
            else
            {
                Forms.ClearDataSource(cmbSel1);
                Forms.ClearDataSource(cmbSel2);
                Forms.ClearDataSource(lstOption1);
                Forms.ClearDataSource(lstOption2);
            }
        }

        private void cmbSel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSel1.SelectedValue == null)
            {
                Forms.ClearDataSource(cmbSel2);
                Forms.ClearDataSource(lstOption1);
                Forms.ClearDataSource(lstOption2);
                return;
            }
            switch (cmbSel1.Get<string>())
            {
                case "teacher":
                    BindingList<Data> teacherList = new BindingList<Data>
                    {
                        new Data("(Please select an option)", null),
                        new Data("Courses", "course"),
                        new Data("Units", "unit")
                    };
                    Forms.SetDataSource(cmbSel2, teacherList);
                    Forms.FillData(lstOption1, "teachers", "(teacherfirstname + ' ' + teacherlastname)",
                        "teacherid", "departmentid", cmbAreaOfStudy.SelectedValue);
                    break;
                case "course":
                    BindingList<Data> courseList = new BindingList<Data>
                    {
                        new Data("(Please select an option)", null),
                        new Data("Units", "unit")
                    };
                    Forms.SetDataSource(cmbSel2, courseList);
                    Forms.FillData(lstOption1, "courses", "coursename",
                        "courseid", "departmentid", cmbAreaOfStudy.SelectedValue);
                    break;
                case "unit":
                    BindingList<Data> unitList = new BindingList<Data>
                    {
                        new Data("(Please select an option)", null),
                        new Data("Assessments", "assessment")
                    };
                    Forms.SetDataSource(cmbSel2, unitList);
                    Forms.FillData(lstOption1, "units", "unitname",
                        "unitid", "departmentid", cmbAreaOfStudy.SelectedValue);
                    break;
            }
        }

        private void cmbSel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSel2.SelectedValue == null)
            {
                Forms.ClearDataSource(lstOption2);
            }
            switch (cmbSel2.Get<string>())
            {
                case "course":
                    Forms.FillData(lstOption2, "courses", "coursename",
                        "courseid", "departmentid", cmbAreaOfStudy.SelectedValue);
                    break;
                case "unit":
                    Forms.FillData(lstOption2, "units", "unitname",
                        "unitid", "departmentid", cmbAreaOfStudy.SelectedValue);
                    break;
                case "assessment":
                    Forms.FillData(lstOption2, "assessments", "assessmentname",
                        "assessmentid", "departmentid", cmbAreaOfStudy.SelectedValue);
                    break;
            }
        }

        private void lstOption1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbSel1.Get<string>())
            {
                case "teacher":
                    switch (cmbSel2.Get<string>())
                    {
                        case "course":
                            Forms.SelectData(lstOption2, "course_teachers", "teacherid",
                                lstOption1.Int(), "courseid");
                            break;
                        case "unit":
                            Forms.SelectData(lstOption2, "unit_teachers", "teacherid", lstOption1.Int(), "unitid");
                            break;
                    }
                    break;
                case "course":
                    Forms.SelectData(lstOption2, "course_units", "courseid", lstOption1.Int(), "unitid");
                    break;
                case "unit":
                    Forms.SelectOneToMany("assessments", "assessmentid", "unitid", lstOption1.Int(), lstOption2);
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Validation.Many(cmbAreaOfStudy, cmbSel1, lstOption1, cmbSel2))
                return;
            DialogResult result = MessageBox.Show($"Would you like to update this {cmbSel1.SelectedValue}?", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            switch (cmbSel1.Get<string>())
            {
                case "teacher":
                    switch (cmbSel2.Get<string>())
                    {
                        case "course":
                            CourseTeacher courseTeacher = new CourseTeacher(lstOption1.Int(), lstOption2);
                            if (courseTeacher.Update())
                                MessageBox.Show($"Teacher: {lstOption1.Text} has been updated.");
                            break;
                        case "unit":
                            UnitTeacher unitTeacher = new UnitTeacher(lstOption1.Int(), lstOption2);
                            if (unitTeacher.Update())
                                MessageBox.Show($"Teacher: {lstOption1.Text} has been updated.");
                            break;
                    }
                    break;
                case "course":
                    CourseUnit courseUnit = new CourseUnit(lstOption1.Int(), lstOption2);
                    if (courseUnit.Update())
                        MessageBox.Show($"Course: {lstOption1.Text} has been updated.");
                    break;
                case "unit":
                    if (Forms.UpdateOneToMany("assessments", "assessmentid", "unitid", lstOption1.Int(), lstOption2))
                        MessageBox.Show($"Unit: {lstOption1.Text} has been updated.");
                    break;
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            if (!Validation.Many(cmbAreaOfStudy, cmbSel1, lstOption1, cmbSel2))
                return;
            switch (cmbSel1.Get<string>())
            {
                case "teacher":
                    switch (cmbSel2.Get<string>())
                    {
                        case "course":
                            LoadDataTable("Teachers", "teacherId", "teacherFirstName", "Course_Teachers", "Courses", "courseId", "courseName");
                            break;
                        case "unit":
                            LoadDataTable("Teachers", "teacherId", "teacherFirstName", "Unit_Teachers", "Units", "unitId", "unitName");
                            break;
                    }
                    break;
                case "course":
                    LoadDataTable("Courses", "courseId", "courseName", "Course_Units", "Units", "unitId", "unitName");
                    break;
                case "unit":
                    dgvAllocations.DataSource =
                        Database.CreateDataTable("select unitName as 'Unit Name', assessmentName as 'Assessment Name' " +
                        "from units, assessments where units.unitid = assessments.unitid and " +
                        $"units.departmentId = {cmbAreaOfStudy.Int()}");
                    break;
            }
        }

        private void LoadDataTable(string mainTable, string mainId, string mainDisplay, string bridgingTable, string foreignTable, string foreignId, string foreignDisplay)
        {
            DataTable dataTable = Database.CreateDataTable($"select {mainId} as '{Extensions.CamelToHuman(mainId)}', " +
                $"{mainDisplay} as '{Extensions.CamelToHuman(mainDisplay)}' from {mainTable} where " +
                $"{mainTable}.departmentId = {cmbAreaOfStudy.Int()}");
            Bridge bridge = new Bridge(bridgingTable, foreignTable, mainId, foreignId, foreignDisplay);
            DataTable bridgeTable = Database.CreateBridgingTable(bridge);
            Database.AddBridgingTable(dataTable, bridgeTable, bridge);
            Database.RemoveColumn(dataTable, Extensions.CamelToHuman(mainId));
            dgvAllocations.DataSource = dataTable;
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
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