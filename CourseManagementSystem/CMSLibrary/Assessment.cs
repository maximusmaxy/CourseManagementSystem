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

        public Assessment(int id, int unitId, int teacherId, string name, DateTime startDate, DateTime dueDate, string description)
        {
            this.id = id;
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
            return Database.Add("assessments", out id, unitId, teacherId, name, startDate, dueDate, description);
        }

        public bool Update()
        {
            return Database.Update("assessments", "assessmentid", id,
                "unitid", unitId,
                "teacherid", teacherId,
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
                unitId = Convert.ToInt32(dataRow[1]);
                teacherId = Convert.ToInt32(dataRow[2]);
                name = Convert.ToString(dataRow[3]);
                startDate = Convert.ToDateTime(dataRow[4]);
                dueDate = Convert.ToDateTime(dataRow[5]);
                description = Convert.ToString(dataRow[6]);
                return true;
            }
            else
                return false;
        }
    }
}
