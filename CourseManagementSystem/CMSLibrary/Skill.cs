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
        private string name;
        private string description;

        public Skill() { }

        public Skill(int id)
        {
            this.id = id;
        }

        public Skill(int id, string name, string description)
        {
            this.id = id;
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
            return Database.Add("skills", out id, name, description);
        }

        public bool Delete()
        {
            return Database.Delete("skills", "skillid", id);
        }

        public bool Update()
        {
            return Database.Update("skills", "skillid", id,
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
                name = Convert.ToString(dataRow[1]);
                description = Convert.ToString(dataRow[2]);
                return true;
            }
            else
                return false;
        }
    }
}