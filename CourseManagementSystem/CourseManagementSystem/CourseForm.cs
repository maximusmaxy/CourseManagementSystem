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
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            Database.LoadDatabase();
            InitializeComponent();
            Forms.FillData(cboxCampus, null, "campus", "locationid", "select locationid, campus from locations where campus is not null ");
            Forms.FillData(cboxAreaOfStudy, "departments", "departmentname", "departmentid");
            cboxAreaOfStudy_SelectedIndexChanged(null, null);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Validation.Word(txtCourseName) || !Validation.Numeric(txtCourseCost) || !Validation.Radio(pnlDeliveryType) 
                || !Validation.Date(dtpStart) || !Validation.Date(dtpEnd) || !Validation.Combo(cboxCampus) 
                || !Validation.Combo(cboxAreaOfStudy) || !Validation.Word(txtCourseDescription)
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
                newCourse.LocationId = Convert.ToInt32(cboxCampus.SelectedValue);
                newCourse.DepartmentId = Convert.ToInt32(cboxAreaOfStudy.SelectedValue);
                newCourse.Description = txtCourseDescription.Text;

                if(!newCourse.Add())
                {
                    MessageBox.Show("Failed to Add new Course");
                }

                CourseUnit CourseBridge = new CourseUnit(newCourse.Id, lboxUnits);
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
                Course newCourse = new Course();
                newCourse.Id = txtCourseID.Int();
                if(!newCourse.Search())
                {
                    MessageBox.Show("Failed to find a Course with the ID :" + txtCourseID.Text);
                }
                else
                {
                    txtCourseName.Text = newCourse.Name;
                    txtCourseCost.Text = newCourse.Cost.ToString();
                    Forms.CheckRadio(pnlDeliveryType, Types.DeliveryType, newCourse.DeliveryType);
                    dtpStart.Value = newCourse.StartDate;
                    dtpEnd.Value = newCourse.EndDate;
                    cboxCampus.SelectedValue = newCourse.LocationId;
                    cboxAreaOfStudy.SelectedValue = newCourse.DepartmentId;
                    txtCourseDescription.Text = newCourse.Description;
                    Forms.SelectData(lboxUnits, "course_units", "courseId", newCourse.Id, "unitId");

                }
                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Validation.Numeric(txtCourseID) || !Validation.Word(txtCourseName) || !Validation.Numeric(txtCourseCost) || !Validation.Radio(pnlDeliveryType)
            || !Validation.Date(dtpStart) || !Validation.Date(dtpEnd) || !Validation.Combo(cboxCampus)
            || !Validation.Combo(cboxAreaOfStudy) || !Validation.Word(txtCourseDescription)
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
                newCourse.LocationId = Convert.ToInt32(cboxCampus.SelectedValue);
                newCourse.DepartmentId = Convert.ToInt32(cboxAreaOfStudy.SelectedValue);
                newCourse.Description = txtCourseDescription.Text;

                if (!newCourse.Update())
                {
                    MessageBox.Show("Failed to Update the Selected Course");
                }

                CourseUnit CourseBridge = new CourseUnit(newCourse.Id, lboxUnits);
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

            Course newCourse = new Course();
            newCourse.Id = txtCourseID.Int();
            if (!newCourse.Delete())
            {
                MessageBox.Show("Failed to Delete the Selected Course");
            }

        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {

        }

        private void cboxAreaOfStudy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cboxAreaOfStudy.DisplayMember == "departmentname" && cboxAreaOfStudy.ValueMember == "departmentid")
            Forms.FillData(lboxUnits, "units", "unitname", "unitid", "departmentid", cboxAreaOfStudy.SelectedValue);
        }
    }
}
