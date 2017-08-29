using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsLibrary
{
    public class Teacher : IData
    {
        private int id;
        private int locationId;
        private string firstName;
        private string lastName;
        private string email;
        private string department;

        public Teacher() { }

        public Teacher(int id)
        {
            this.id = id;
        }

        public Teacher(int id, int locationId, string firstName, string lastName, string email, string department)
        {
            this.id = id;
            this.locationId = locationId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.department = department;
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

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Department
        {
            get
            {
                return department;
            }
            set
            {
                department = value;
            }
        }

        public bool Add()
        {
            return Database.Add("teachers", out id, locationId, firstName, lastName, email, department);
        }


        public bool Update()
        {
            return Database.Update("teachers", "teacherid", id,
                "locationid", locationId,
                "teacherfirstName", firstName,
                "teacherlastName", lastName,
                "teacheremail", email,
                "teacherdepartment", department);
        }

        public bool Delete()
        {
            return Database.Delete("teachers", "teacherid", id);
        }

        public bool Search()
        {
            return Search("teacherid", id);
        }

        public bool Search(params object[] values)
        {
            DataRow dataRow;
            if (Database.Search("teachers", out dataRow, values))
            {
                locationId = Convert.ToInt32(dataRow[1]);
                firstName = Convert.ToString(dataRow[2]);
                lastName = Convert.ToString(dataRow[3]);
                email = Convert.ToString(dataRow[4]);
                department = Convert.ToString(dataRow[5]);
                return true;
            }
            else
                return false;
        }
    }
}
