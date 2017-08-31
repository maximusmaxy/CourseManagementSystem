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
            InitializeComponent();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!Validation.Word(txtCourseName) || !Validation.Numeric(txtCourseCost) || !Validation.Radio(pnlDeliveryType) 
                || !Validation.Date(dtpStart) || !Validation.Date(dtpEnd) || !Validation.Combo(cboxCampus) 
                || !Validation.Combo(cboxAreaOfStudy) || !Validation.Word(txtCourseDescription)
                )
            {
                MessageBox.Show("Failed to Submit, please try again");
            }


            else
            {
                Course newCourse = new Course();
                newCourse.Name = txtCourseName.Text;
                newCourse.Cost = double.Parse(txtCourseCost.Text);
                newCourse.DeliveryType = Forms.RadioValue(pnlDeliveryType, Types.DeliveryType);
                newCourse.StartDate = dtpStart.Value;
                newCourse.EndDate = dtpEnd.Value;
                newCourse.LocationId = int.Parse(cboxCampus.SelectedItem.ToString());
                newCourse.DepartmentId = int.Parse(cboxAreaOfStudy.SelectedItem.ToString());
                newCourse.Description = txtCourseDescription.Text;
                newCourse.Add();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {

        }
    }
}
