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
                txtId.ValidateWord(),
                txtCourseId.ValidateWord(),
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
                    //
                };

            }
        }
    }
}
