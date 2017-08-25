using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Assessment : IData
    {
        public static string Table { get; set; } = "Assessments";

        private int id;
        private int unitId;
        private int teacherId;
        private string name;
        private DateTime startDate;
        private DateTime dueDate;

        public Assessment() { }

        public Assessment(int id)
        {
            this.id = id;
        }

        public Assessment(int id, int unitId, int teacherId, string name, DateTime startDate, DateTime dueDate)
        {
            this.id = id;
            this.unitId = unitId;
            this.teacherId = teacherId;
            this.name = name;
            this.startDate = startDate;
            this.dueDate = dueDate;
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

        public bool Add()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool Search()
        {
            throw new NotImplementedException();
        }
    }
}
