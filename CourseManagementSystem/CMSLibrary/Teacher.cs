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
        private int departmentId;
        private string firstName;
        private string lastName;
        private string email;

        public Teacher() { }

        public Teacher(int id)
        {
            this.id = id;
        }

        public Teacher(int id, int locationId, int departmentId, string firstName, string lastName, string email)
        {
            this.id = id;
            this.LocationId = locationId;
            this.departmentId = departmentId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
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

        public int LocationId
        {
            get
            {
                return locationId;
            }

            set
            {
                locationId = value;
            }
        }

        public bool Add()
        {
            return Database.Add("teachers", out id, LocationId, departmentId, firstName, lastName, email);
        }


        public bool Update()
        {
            return Database.Update("teachers", "teacherid", id,
                "locationid", LocationId,
                "departmentid", departmentId,
                "teacherfirstName", firstName,
                "teacherlastName", lastName,
                "teacheremail", email);
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
                id = Convert.ToInt32(dataRow[0]);
                LocationId = Convert.ToInt32(dataRow[1]);
                departmentId = Convert.ToInt32(dataRow[2]);
                firstName = Convert.ToString(dataRow[3]);
                lastName = Convert.ToString(dataRow[4]);
                email = Convert.ToString(dataRow[5]);
                return true;
            }
            else
                return false;
        }
    }
}
