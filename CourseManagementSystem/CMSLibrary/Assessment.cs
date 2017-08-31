using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Assessment : IData
    {
        private int id;
        private int departmentId;
        private int unitId;
        private int teacherId;
        private string name;
        private DateTime startDate;
        private DateTime dueDate;
        private string description;

        public Assessment() { }

        public Assessment(int id)
        {
            this.id = id;
        }

        public Assessment(int id, int departmentId, int unitId, int teacherId, string name, DateTime startDate, DateTime dueDate, string description)
        {
            this.id = id;
            this.departmentId = departmentId;
            this.unitId = unitId;
            this.teacherId = teacherId;
            this.name = name;
            this.startDate = startDate;
            this.dueDate = dueDate;
            this.description = description;
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

        public int DepartmentId
        {
            get
            {
                return departmentId;
            }
            set
            {
                departmentId = value;
            }
        }

        public int UnitId
        {
            get
            {
                return unitId;
            }

            set
            {
                unitId = value;
            }
        }

        public int TeacherId
        {
            get
            {
                return teacherId;
            }

            set
            {
                teacherId = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }

            set
            {
                dueDate = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public bool Add()
        {
            return Database.Add("assessments", out id, unitId, teacherId, departmentId, name, startDate, dueDate, description);
        }

        public bool Update()
        {
            return Database.Update("assessments", "assessmentid", id,
                "unitid", unitId,
                "teacherid", teacherId,
                "departmentid", departmentId,
                "assessmentname", name,
                "assessmentstartdate", startDate,
                "assessmentduedate", dueDate,
                "assessmentdescription", description);
        }

        public bool Delete()
        {
            return Database.Delete("assessments", "assessmentid", id);
        }

        public bool Search()
        {
            return Search("assessmentid", id);
        }

        public bool Search(params object[] values) { 
            DataRow dataRow;
            if (Database.Search("assessments", out dataRow, values))
            {
                id = Convert.ToInt32(dataRow[0]);
                unitId = Convert.ToInt32(dataRow[1]);
                teacherId = Convert.ToInt32(dataRow[2]);
                departmentId = Convert.ToInt32(dataRow[3]);
                name = Convert.ToString(dataRow[4]);
                startDate = Convert.ToDateTime(dataRow[5]);
                dueDate = Convert.ToDateTime(dataRow[6]);
                description = Convert.ToString(dataRow[7]);
                return true;
            }
            else
                return false;
        }
    }
}
