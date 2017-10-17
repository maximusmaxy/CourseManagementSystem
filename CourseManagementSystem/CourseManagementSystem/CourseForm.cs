﻿using System;
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
    public partial class CourseForm : Form, ISearchForm
    {
        public CourseForm()
        {
            //Database.LoadDatabase();
            InitializeComponent();
            Forms.FillData(cmbCampus, null, "campus", "locationid", "select locationid, campus from locations where campus is not null ");
            Forms.FillData(cmbAreaOfStudy, "departments", "departmentname", "departmentid");
            cboxAreaOfStudy_SelectedIndexChanged(null, null);
            SetPermission();
        }

        private void SetPermission()
        {
            if (!Forms.HasPermission(Permission.Admin))
            {
                btnDelete.Enabled = false;
            }
            if (Forms.Permission == Permission.Teacher)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Validation.Word(txtCourseName) || !Validation.Numeric(txtCourseCost) || !Validation.Radio(pnlDeliveryType) 
                || !Validation.Date(dtpStart) || !Validation.Date(dtpEnd) || !Validation.Combo(cmbCampus) 
                || !Validation.Combo(cmbAreaOfStudy) || !Validation.Word(txtCourseDescription)
                )
            {
                MessageBox.Show("Failed to Validate, please try again");
            }


            else
            {
                Course newCourse = new Course();
                newCourse.Name = txtCourseName.Text;
                newCourse.Cost = double.Parse(txtCourseCost.Text);
                newCourse.DeliveryType = Forms.RadioValue(pnlDeliveryType, Types.DeliveryType);
                newCourse.StartDate = dtpStart.Value;
                newCourse.EndDate = dtpEnd.Value;
                newCourse.LocationId = Convert.ToInt32(cmbCampus.SelectedValue);
                newCourse.DepartmentId = Convert.ToInt32(cmbAreaOfStudy.SelectedValue);
                newCourse.Description = txtCourseDescription.Text;

                if(!newCourse.Add())
                {
                    MessageBox.Show("Failed to Add new Course");
                }

                CourseUnit CourseBridge = new CourseUnit(newCourse.Id, lstUnitslist);
                if(!CourseBridge.Update())
                {
                    MessageBox.Show("Failed to link the Course with the selected Units");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtCourseID)
            )
            {
                MessageBox.Show("Failed to Validate, please try again");
            }
            else
            {
                Search(txtCourseID.Int());
            }
        }

        public void Search(int id)
        {
            Course newCourse = new Course();
            newCourse.Id = id;
            if (!newCourse.Search())
            {
                MessageBox.Show("Failed to find a Course with the ID :" + txtCourseID.Text);
            }
            else
            {
                txtCourseID.Text = newCourse.Id.ToString();
                txtCourseName.Text = newCourse.Name;
                txtCourseCost.Text = newCourse.Cost.ToString();
                Forms.CheckRadio(pnlDeliveryType, Types.DeliveryType, newCourse.DeliveryType);
                dtpStart.Value = newCourse.StartDate;
                dtpEnd.Value = newCourse.EndDate;
                cmbCampus.SelectedValue = newCourse.LocationId;
                cmbAreaOfStudy.SelectedValue = newCourse.DepartmentId;
                txtCourseDescription.Text = newCourse.Description;
                Forms.SelectData(lstUnitslist, "course_units", "courseId", newCourse.Id, "unitId");

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtCourseID) || !Validation.Word(txtCourseName) || !Validation.Numeric(txtCourseCost) || !Validation.Radio(pnlDeliveryType)
            || !Validation.Date(dtpStart) || !Validation.Date(dtpEnd) || !Validation.Combo(cmbCampus)
            || !Validation.Combo(cmbAreaOfStudy) || !Validation.Word(txtCourseDescription)
            )
            {
                MessageBox.Show("Failed to Validate, please try again");
            }


            else
            {
                Course newCourse = new Course();
                newCourse.Id = txtCourseID.Int();
                newCourse.Name = txtCourseName.Text;
                newCourse.Cost = double.Parse(txtCourseCost.Text);
                newCourse.DeliveryType = Forms.RadioValue(pnlDeliveryType, Types.DeliveryType);
                newCourse.StartDate = dtpStart.Value;
                newCourse.EndDate = dtpEnd.Value;
                newCourse.LocationId = Convert.ToInt32(cmbCampus.SelectedValue);
                newCourse.DepartmentId = Convert.ToInt32(cmbAreaOfStudy.SelectedValue);
                newCourse.Description = txtCourseDescription.Text;

                if (!newCourse.Update())
                {
                    MessageBox.Show("Failed to Update the Selected Course");
                }

                CourseUnit CourseBridge = new CourseUnit(newCourse.Id, lstUnitslist);
                if (!CourseBridge.Update())
                {
                    MessageBox.Show("Failed to link the current Course with the selected Units");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtCourseID))
            {
                MessageBox.Show("Failed to Validate, please try again");
            }
            //CourseUnit
            CourseUnit newCourseUnit = new CourseUnit();
            newCourseUnit.CourseId = txtCourseID.Int();
            if (!newCourseUnit.Delete())
            {
                MessageBox.Show("Failed to Delete the Selected Course");
            }
            //Course
            Course newCourse = new Course();
            newCourse.Id = txtCourseID.Int();
            if (!newCourse.Delete())
            {
                MessageBox.Show("Failed to Delete the Selected Course");
            }

        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            using (ViewAllForm form = new ViewAllForm("Courses"))
            {

                //form.AddColumn("Courses", "UnitId");
                form.AddType("deliveryType", Types.DeliveryType);
                form.ShowDialog(this);
                if (form.Id != -1)
                {
                    Course course = new Course(form.Id);
                    if (course.Search())
                    {
                        txtCourseID.Text = course.Id.ToString();
                        txtCourseName.Text = course.Name;
                        txtCourseCost.Text = course.Cost.ToString();
                        Forms.CheckRadio(pnlDeliveryType, Types.DeliveryType, course.DeliveryType);
                        dtpStart.Value = course.StartDate;
                        dtpEnd.Value = course.EndDate;
                        cmbAreaOfStudy.SelectedValue = course.DepartmentId;
                        txtCourseDescription.Text = course.Description;

                        Location location = new Location(course.LocationId);
                        if (location.Search())
                        {
                            cmbCampus.Text = location.Campus;
                        }
                    }
                }
            }
        }

        private void cboxAreaOfStudy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Forms.FillData(lstUnitslist, "units", "unitname", "unitid", "departmentid", cmbAreaOfStudy.SelectedValue);
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

        private void studentsCoursesToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnViewAll_Click(sender, e);
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            Forms.ClearControls(this);
        }
    }
}
