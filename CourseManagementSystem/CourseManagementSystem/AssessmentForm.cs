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
    public partial class AssessmentForm : Form
    {
        public AssessmentForm()
        {
            InitializeComponent();
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

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnViewAll_Click(sender, e);
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(MainForm));
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ShowForm(typeof(StudentForm));
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to add this Assessment", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!Validation.Many(
                   //txtUnitCode.ValidateEmpty(),
                   //txtUnitCode.ValidateUnitCode(),
                   //txtUnitName.ValidateEmpty(),
                   //pnlUnitType,
                   //txtNoOfHours.ValidateNumeric(),
                   //cmbAreaOfStudy,
                   //lstSkill,
                   //txtUnitDesc.ValidateEmpty()
                   ))
                {
                    return;
                }

                //Unit unit = new Unit()
                //{
                //    Name = txtUnitName.Text,
                //    Code = txtUnitCode.Text,
                //    Type = Forms.RadioValue(pnlUnitType, Types.UnitType),
                //    NumOfHours = Convert.ToInt32(txtNoOfHours.Text),
                //    DepartmentId = cmbAreaOfStudy.Int(),
                //    Description = txtUnitDesc.Text,
                //};
                //if (!unit.Add())
                //{
                //    return;
                //}

                //UnitSkill CourseBridge = new UnitSkill(unit.Id, lstSkill);
                //if (!CourseBridge.Update())
                //    return;
                ////success!
                //MessageBox.Show($"Unit ID: {unit.Id} added successfully.");
                //txtUnitId.Text = unit.Id.ToString();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //validation
            //if (!Validation.Numeric(txtUnitId))
            //    return;

            //DialogResult result = MessageBox.Show("Would you like to search for this unit", "Question",
            //                                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    Unit unit = new Unit(txtUnitId.Int());
            //    if (unit.Search())
            //    {
            //        txtUnitCode.Text = unit.Code;
            //        txtUnitName.Text = unit.Name;
            //        Forms.CheckRadio(pnlUnitType, Types.UnitType, unit.Type);
            //        txtNoOfHours.Text = unit.NumOfHours.ToString();
            //        cmbAreaOfStudy.SelectedValue = unit.DepartmentId;
            //        Forms.SelectData(lstSkill, "unit_skills", "skillId", unit.Id, "unitId");
            //        txtUnitDesc.Text = unit.Description;

            //    }
            //}
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
