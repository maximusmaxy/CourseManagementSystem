using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Unit : IData
    {
        public static string Table { get; set; } = "Units";

        private int id;
        private int teacherId;
        private string unitName;
        private int unitType;
        private int numOfHours;

        public Unit() { }

        public Unit(int id)
        {
            this.id = id;
        }

        public Unit(int id, int teacherId, string unitName, int unitType, int numOfHours)
        {
            this.id = id;
            this.teacherId = teacherId;
            this.unitName = unitName;
            this.unitType = unitType;
            this.numOfHours = numOfHours;
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

        public string UnitName
        {
            get
            {
                return unitName;
            }

            set
            {
                unitName = value;
            }
        }

        public int UnitType
        {
            get
            {
                return unitType;
            }

            set
            {
                unitType = value;
            }
        }

        public int NumOfHours
        {
            get
            {
                return numOfHours;
            }

            set
            {
                numOfHours = value;
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
