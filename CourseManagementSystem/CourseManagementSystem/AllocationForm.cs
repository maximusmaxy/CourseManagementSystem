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
        }

        private void cmbAreaOfStudy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAreaOfStudy.SelectedValue != DBNull.Value)
            {
                cmbSel1.DataSource = null;
                cmbSel1.DisplayMember = "Display";
                cmbSel1.ValueMember = "Value";
                cmbSel1.DataSource = new BindingList<Data>
                {
                    new Data("(Please select an option)", null),
                    new Data("Teachers", "teacher"),
                    new Data("Courses", "course"),
                    new Data("Units", "unit")
                };
            }
            else
            {
                cmbSel1.DataSource = null;
                cmbSel2.DataSource = null;
                lstOption1.DataSource = null;
                lstOption2.DataSource = null;
            }
        }

        private void cmbSel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSel1.SelectedValue == null)
            {
                cmbSel2.DataSource = null;
                lstOption1.DataSource = null;
                lstOption2.DataSource = null;
                return;
            }
            cmbSel2.DataSource = null;
            cmbSel2.ValueMember = "Value";
            cmbSel2.DisplayMember = "Display";
            switch ((string)cmbSel1.SelectedValue)
            {
                case "teacher":
                    cmbSel2.DataSource = new BindingList<Data>
                    {
                        new Data("(Please select an option)", null),
                        new Data("Courses", "course"),
                        new Data("Units", "unit")
                    };
                    Forms.FillData(lstOption1, "teachers", "(teacherfirstname + ' ' + teacherlastname)",
                        "teacherid", "departmentid", cmbAreaOfStudy.SelectedValue);
                    break;
                case "course":
                    cmbSel2.DataSource = new BindingList<Data>
                    {
                        new Data("(Please select an option)", null),
                        new Data("Units", "unit")
                    };
                    Forms.FillData(lstOption1, "courses", "coursename",
                        "courseid", "departmentid", cmbAreaOfStudy.SelectedValue);
                    break;
                case "unit":
                    cmbSel2.DataSource = new BindingList<Data>
                    {
                        new Data("(Please select an option)", null),
                        new Data("Assessments", "assessment")
                    };
                    Forms.FillData(lstOption1, "units", "unitname",
                        "unitid", "departmentid", cmbAreaOfStudy.SelectedValue);
                    break;
            }
        }

        private void cmbSel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSel2.SelectedValue == null)
            {
                lstOption2.DataSource = null;
            }
            switch ((string)cmbSel2.SelectedValue)
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
            switch ((string)cmbSel1.SelectedValue)
            {
                case "teacher":
                    switch ((string)cmbSel2.SelectedValue)
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
            if (!Validation.Many(cmbAreaOfStudy, cmbSel1, lstOption1, cmbSel2, lstOption2))
                return;
            DialogResult result = MessageBox.Show($"Would you like to update this {cmbSel1.SelectedValue}?", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            switch ((string)cmbSel1.SelectedValue)
            {
                case "teacher":
                    switch ((string)cmbSel2.SelectedValue)
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

        private void globalSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(GlobalSearchForm));
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }
    }
}