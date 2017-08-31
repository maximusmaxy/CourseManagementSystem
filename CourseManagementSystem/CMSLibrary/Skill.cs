using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Skill : IData
    {
        private int id;
        private int departmentId;
        private string name;
        private string description;

        public Skill() { }

        public Skill(int id)
        {
            this.id = id;
        }

        public Skill(int id, int departmentId, string name, string description)
        {
            this.id = id;
            this.departmentId = departmentId;
            this.name = name;
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
            return Database.Add("skills", out id, departmentId, name, description);
        }

        public bool Delete()
        {
            return Database.Delete("skills", "skillid", id);
        }

        public bool Update()
        {
            return Database.Update("skills", "skillid", id,
                "departmentid", departmentId,
                "skillname", name,
                "description", description);
        }

        public bool Search()
        {
            return Search("skillid", id);
        }

        public bool Search(params object[] values)
        {
            DataRow dataRow;
            if (Database.Search("skills", out dataRow, values))
            {
                id = Convert.ToInt32(dataRow[0]);
                departmentId = Convert.ToInt32(dataRow[1]);
                name = Convert.ToString(dataRow[2]);
                description = Convert.ToString(dataRow[3]);
                return true;
            }
            else
                return false;
        }
    }
}