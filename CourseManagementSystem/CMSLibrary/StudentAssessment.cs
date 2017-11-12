using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class StudentAssessment
    {
        private int assessmentId;
        private ListBox control;

        public StudentAssessment(int assessmentId, ListBox control)
        {
            this.assessmentId = assessmentId;
            this.control = control;
        }

        public int AssessmentId
        {
            get
            {
                return assessmentId;
            }

            set
            {
                assessmentId = value;
            }
        }

        public ListBox Control
        {
            get
            {
                return control;
            }

            set
            {
                control = value;
            }
        }

        public bool Delete()
        {
            return Database.DeleteBridgingTable("students_assessments", "studentId", assessmentId);
        }

        public bool Update()
        {
            DataTable table = (DataTable)control.DataSource;
            StringBuilder sb = new StringBuilder();
            foreach (var row in table.AsEnumerable())
            {
                sb.Append("update Student_Assessments set results = ");
                sb.Append(row["result"]);
                sb.Append("where studentId = ");
                sb.Append(row["studentId"]);
                sb.Append("and assessmentId = ");
                sb.Append(assessmentId);
                sb.Append(";");
            }
            try
            {
                Database.ExecuteNonQuery(sb.ToString());
                return true;
            } catch (SqlException ex) {
                MessageBox.Show("Error updating Student Assessment results.");
                return false;
            }
        }
    }
}
