using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class Unit : IData
    {
        private int id;
        private int departmentId;
        private string code;
        private string name;
        private int type;
        private int numOfHours;
        private string description;

        public Unit() { }

        public Unit(int id)
        {
            this.id = id;
        }

        public Unit(string code)
        {
            this.code = code;
        }

        public Unit(int id, int departmentId, string code, string name, int type, int numOfHours, string description)
        {
            this.id = id;
            this.departmentId = departmentId;
            this.code = code;
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

        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
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
            try
            {
                return Database.Add("units", out id, departmentId, code, name, type, numOfHours, description);
            }
            catch (UniqueConstraintException ex)
            {
                if (ex.Constraint == "unique_unit_code")
                    MessageBox.Show("Unit code is already in use. Please choose a different unit code.");
                else
                    MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Update()
        {
            #region update by id
            //return Database.Update("units", "unitid", id,
            //    "departmentid", departmentId,
            //    "unitcode", code,
            //    "unitname", name,
            //    "unittype", type,
            //    "numofhours", numOfHours,
            //    "unitdescription", description);
            #endregion
            return Database.Update("units", "unitcode", code,
                "departmentid", departmentId,
                "unitname", name,
                "unittype", type,
                "numofhours", numOfHours,
                "unitdescription", description);
        }

        public bool Delete()
        {
            return Database.Delete("units", "unitcode", code);
        }
                
        public bool Search()
        {
            return Search("unitcode", code);
        }

        public bool Search(params object[] values)
        {
            DataRow dataRow;
            if (Database.Search("units", out dataRow, values))
            {
                id = Convert.ToInt32(dataRow[0]);
                departmentId = Convert.ToInt32(dataRow[1]);
                code = Convert.ToString(dataRow[2]);
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