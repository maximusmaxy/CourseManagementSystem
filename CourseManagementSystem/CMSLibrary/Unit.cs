using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Unit : IData
    {
        private int id;
        private int teacherId;
        private int skillId;
        private int departmentId;
        private string name;
        private int type;
        private int numOfHours;
        private string description;

        public Unit() { }

        public Unit(int id)
        {
            this.id = id;
        }

        public Unit(int id, int teacherId, int skillId, int departmentId, string name, int type, int numOfHours, string description)
        {
            this.id = id;
            this.teacherId = teacherId;
            this.skillId = skillId;
            this.departmentId = departmentId;
            this.name = name;
            this.type = type;
            this.numOfHours = numOfHours;
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

        public int SkillId
        {
            get
            {
                return skillId;
            }
            set
            {
                skillId = value;
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

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
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
            return Database.Add("units", out id, teacherId, departmentId, name, type, numOfHours, description);
        }

        public bool Update()
        {
            return Database.Update("units", "unitid", id,
                "teacherid", id,
                "departmentid", departmentId,
                "unitname", name,
                "unittype", type,
                "numofhours", numOfHours,
                "unitdescription", description);
        }

        public bool Delete()
        {
            return Database.Delete("units", "unitid", id);
        }
                
        public bool Search()
        {
            return Search("unitid", id);
        }

        public bool Search(params object[] values)
        {
            DataRow dataRow;
            if (Database.Search("units", out dataRow, values))
            {
                id = Convert.ToInt32(dataRow[0]);
                teacherId = Convert.ToInt32(dataRow[1]);
                departmentId = Convert.ToInt32(dataRow[2]);
                name = Convert.ToString(dataRow[3]);
                type = Convert.ToInt32(dataRow[4]);
                numOfHours = Convert.ToInt32(dataRow[5]);
                description = Convert.ToString(dataRow[6]);
                return true;
            }
            else
                return false;
        }
    }
}