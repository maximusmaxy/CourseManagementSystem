using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class Enrolment : IData
    {
        private int id;
        private int studentId;
        private int courseId;
        private DateTime enrolmentDate;
        private DateTime completionDate;
        private double enrolmentCost;
        private double discountCost;
        private double totalCost;
        private int semester;
        private int result;

        public Enrolment() { }

        public Enrolment(int id)
        {
            this.id = id;
        }

        public Enrolment(int id, int studentId, int courseId, DateTime enrolmentDate, DateTime completionDate, double enrolmentCost, double discountCost, int semester, int result)
        {
            this.id = id;
            this.studentId = studentId;
            this.courseId = courseId;
            this.enrolmentDate = enrolmentDate;
            this.completionDate = completionDate;
            this.enrolmentCost = enrolmentCost;
            this.discountCost = discountCost;
            this.semester = semester;
            this.result = result;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int StudentId
        {
            get
            {
                return studentId;
            }

            set
            {
                studentId = value;
            }
        }

        public int CourseId
        {
            get
            {
                return courseId;
            }

            set
            {
                courseId = value;
            }
        }

        public DateTime EnrolmentDate
        {
            get
            {
                return enrolmentDate;
            }

            set
            {
                enrolmentDate = value;
            }
        }

        public DateTime CompletionDate
        {
            get
            {
                return completionDate;
            }

            set
            {
                completionDate = value;
            }
        }

        public double EnrolmentCost
        {
            get
            {
                return enrolmentCost;
            }

            set
            {
                enrolmentCost = value;
            }
        }

        public double DiscountCost
        {
            get
            {
                return discountCost;
            }

            set
            {
                discountCost = value;
            }
        }

        public int Semester
        {
            get
            {
                return semester;
            }

            set
            {
                semester = value;
            }
        }

        public int Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

        public double TotalCost
        {
            get
            {
                return totalCost;
            }

            set
            {
                totalCost = value;
            }
        }

        public bool Add()
        {
            try
            {
                bool success = Database.Add("enrolments", out id, studentId, courseId, enrolmentDate, completionDate, enrolmentCost, discountCost, totalCost, semester, result);
                if (success)
                {
                    StringBuilder suInsert = new StringBuilder("insert into student_units values ");
                    int suLength = suInsert.Length;
                    StringBuilder saInsert = new StringBuilder("insert into student_assessments values ");
                    int saLength = saInsert.Length;
                    int result = Types.CourseResults["Not Completed"];
                    string courseSql = $"select unitId from course_units where courseid = {CourseId}";
                    foreach (var row in Database.ExecuteQuery(courseSql))
                    {
                        int unitId = Convert.ToInt32(row["unitId"]);
                        suInsert.Append("(");
                        suInsert.Append(studentId);
                        suInsert.Append(", ");
                        suInsert.Append(unitId);
                        suInsert.Append(", ");
                        suInsert.Append(result);
                        suInsert.Append("), ");
                        string assessmentSql = $"select assessmentId from assessments where unitId = {unitId}";
                        foreach (var row2 in Database.ExecuteQuery(assessmentSql))
                        {
                            int assessmentId = Convert.ToInt32(row2["assessmentId"]);
                            saInsert.Append("(");
                            saInsert.Append(studentId);
                            saInsert.Append(", ");
                            saInsert.Append(assessmentId);
                            saInsert.Append(", ");
                            saInsert.Append(result);
                            saInsert.Append("), ");
                        }
                    }
                    if (suLength != suInsert.Length)
                    {
                        suInsert.Length -= 2;
                        Database.ExecuteNonQuery(suInsert.ToString());
                    }
                    if (saLength != saInsert.Length)
                    {
                        saInsert.Length -= 2;
                        Database.ExecuteNonQuery(saInsert.ToString());
                    }
                }
                return success;
            }
            catch (UniqueConstraintException ex)
            {
                if (ex.Constraint == "student_course_unique")
                    MessageBox.Show($"The selected student has already enrolled in the selected course.");
                else
                    MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Update()
        {
            return Database.Update("enrolments", "enrolmentid", id,
                "studentid", studentId,
                "courseid", courseId,
                "enrolmentDate", enrolmentDate,
                "completionDate", completionDate,
                "enrolmentCost", enrolmentCost,
                "discountCost", discountCost,
                "totalCost", totalCost,
                "semester", semester,
                "results", result);
        }

        public bool Delete()
        {
            return Database.Delete("enrolments", "enrolmentid", id);
        }

        public bool Search()
        {
            return Search("enrolmentid", id);
        }

        public bool Search(params object[] values)
        {
            DataRow dataRow;
            if (Database.Search("enrolments", out dataRow, values))
            {
                id = Convert.ToInt32(dataRow[0]);
                studentId = Convert.ToInt32(dataRow[1]);
                courseId = Convert.ToInt32(dataRow[2]);
                enrolmentDate = Convert.ToDateTime(dataRow[3]);
                completionDate = Convert.ToDateTime(dataRow[4]);
                enrolmentCost = Convert.ToDouble(dataRow[5]);
                discountCost = Convert.ToDouble(dataRow[6]);
                totalCost = Convert.ToDouble(dataRow[7]);
                semester = Convert.ToInt32(dataRow[8]);
                result = Convert.ToInt32(dataRow[9]);
                return true;
            }
            else
                return false;
        }
    }
}
