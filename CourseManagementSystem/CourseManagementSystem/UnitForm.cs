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
    public partial class UnitForm : Form
    {
        public UnitForm()
        {
            InitializeComponent();
        }

        private void UnitForm_Load(object sender, EventArgs e)
        {
            Forms.FillData(cmbAreaOfStudy, "departments", "departmentname", "departmentid");
            cmbAreaOfStudy_SelectedIndexChanged_1(null, null);
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

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnViewAll_Click(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //validation
            if (!Validation.UnitCode(txtUnitCode))
                return;

            DialogResult result = MessageBox.Show("Would you like to search for this unit", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Unit unit = new Unit(txtUnitCode.Text);
                if (unit.Search())
                {
                    txtUnitCode.Text = unit.Code;
                    txtUnitName.Text = unit.Name;
                    Forms.CheckRadio(pnlUnitType, Types.UnitType, unit.Type);
                    txtNoOfHours.Text = unit.NumOfHours.ToString();
                    cmbAreaOfStudy.SelectedValue = unit.DepartmentId;
                    Forms.SelectData(lstSkill, "unit_skills", "skillId", unit.Id, "unitId");
                    txtUnitDesc.Text = unit.Description;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Would you like to update this record", "Question",
                                              MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!Validation.Many(
                 txtUnitCode.ValidateEmpty(),
                txtUnitCode.ValidateUnitCode(),
                txtUnitName.ValidateEmpty(),
                pnlUnitType,
                txtNoOfHours.ValidateNumeric(),
                cmbAreaOfStudy,
                lstSkill,
                txtUnitDesc.ValidateEmpty()
                ))
                {
                    return;
                }

                Unit unit = new Unit()
                {
                    Name = txtUnitName.Text,
                    Code = txtUnitCode.Text,
                    Type = Forms.RadioValue(pnlUnitType, Types.UnitType),
                    NumOfHours = Convert.ToInt32(txtNoOfHours.Text),
                    DepartmentId = cmbAreaOfStudy.Int(),
                    Description = txtUnitDesc.Text,
                };
                if (!unit.Update())
                {
                    return;
                }
                UnitSkill CourseBridge = new UnitSkill(unit.Code, lstSkill);
                if (!CourseBridge.Update())
                    return;
                //success!
                MessageBox.Show($"Unit Code: {unit.Code} added successfully.");
                txtUnitId.Text = unit.Id.ToString();
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            using (ViewAllForm form = new ViewAllForm("units"))
            {
                form.AddBridging("Unit_Skills", "Skills", "unitId", "skillId", "skillName");
                form.ShowDialog(this);
                if (form.Id != -1)
                {
                    Unit unit = new Unit();
                    if (unit.Search("unitid", form.Id))
                    {
                        txtUnitId.Text = unit.Id.ToString();
                        txtUnitCode.Text = unit.Code.ToString();
                        txtUnitName.Text = unit.Name;
                        Forms.CheckRadio(pnlUnitType, Types.UnitType, unit.Type);
                        txtNoOfHours.Text = unit.NumOfHours.ToString();
                        cmbAreaOfStudy.SelectedValue = unit.DepartmentId;
                        Forms.SelectData(lstSkill, "unit_skills", "skillId", unit.Id, "unitId");
                        txtUnitDesc.Text = unit.Description;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to delete this record", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!Validation.UnitCode(txtUnitCode))
                {
                    return;
                }
                UnitSkill unitskill = new UnitSkill(txtUnitCode.Text);
                if (!unitskill.Delete())
                {
                    return;
                }
                Unit unit = new Unit(txtUnitCode.Text);
                if (!unit.Delete())
                {
                    return;
                }
                MessageBox.Show($"Unit Code: {unit.Code} successfully deleted.");
                Forms.ClearControls(this);

            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("Would you like to add this Unit", "Question",
                                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (!Validation.Many(
                   txtUnitCode.ValidateEmpty(),
                   txtUnitCode.ValidateUnitCode(),
                   txtUnitName.ValidateEmpty(),
                   pnlUnitType,
                   txtNoOfHours.ValidateNumeric(),
                   cmbAreaOfStudy,
                   lstSkill,
                   txtUnitDesc.ValidateEmpty()
                   ))
                {
                    return;
                }

                Unit unit = new Unit()
                {
                    Name = txtUnitName.Text,
                    Code = txtUnitCode.Text,
                    Type = Forms.RadioValue(pnlUnitType, Types.UnitType),
                    NumOfHours = Convert.ToInt32(txtNoOfHours.Text),
                    DepartmentId = cmbAreaOfStudy.Int(),
                    Description = txtUnitDesc.Text,
                };
                if (!unit.Add())
                {
                    return;
                }

                UnitSkill CourseBridge = new UnitSkill(unit.Code, lstSkill);
                if (!CourseBridge.Update())
                    return;
                //success!
                MessageBox.Show($"Unit Code: {unit.Code} added successfully.");
                txtUnitId.Text = unit.Id.ToString();

            }
        }

        private void cmbAreaOfStudy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Forms.FillData(lstSkill, "skills", "skillname", "skillid", "departmentid", cmbAreaOfStudy.SelectedValue);
        }
    }
}
