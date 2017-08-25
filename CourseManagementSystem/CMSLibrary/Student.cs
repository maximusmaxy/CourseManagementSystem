using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CmsLibrary
{
    public class Student : IData
    {
        public static string Table { get; set; } = "Students";

        private int id;
        private string firstName;
        private string lastName;
        private int locationId;
        private DateTime dateOfBirth;
        private string email;
        private string countryOfOrigin;
        private int gender;
        private bool disability;
        private string disabilityDescription;

        public Student() { }

        public Student(int id)
        {
            this.id = id;
        }

        public Student(int id, string firstName, string lastName, int locationId, DateTime dateOfBirth, string email, string countryOfOrigin, int gender, bool disability, string disabilityDescription)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.locationId = locationId;
            this.dateOfBirth = dateOfBirth;
            this.email = email;
            this.countryOfOrigin = countryOfOrigin;
            this.gender = gender;
            this.disability = disability;
            this.disabilityDescription = disabilityDescription;
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

        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }

            set
            {
                dateOfBirth = value;
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

        public string CountryOfOrigin
        {
            get
            {
                return countryOfOrigin;
            }

            set
            {
                countryOfOrigin = value;
            }
        }

        public int Gender
        {
            get
            {
                return gender;
            }

            set
            {
                gender = value;
            }
        }

        public bool Disability
        {
            get
            {
                return disability;
            }

            set
            {
                disability = value;
            }
        }

        public string DisabilityDescription
        {
            get
            {
                return disabilityDescription;
            }

            set
            {
                disabilityDescription = value;
            }
        }

        public bool Add()
        {
            return Database.Add(Table, out id, firstName, lastName, locationId, dateOfBirth, email, countryOfOrigin, gender, disability, disabilityDescription);
        }

        public bool Update()
        {
            return Database.Update(Table, "studentid", id,
                "studentfirstname", firstName,
                "studentlastname", lastName,
                "locationid", locationId,
                "studentdateofbirth", dateOfBirth,
                "studentemail", email,
                "studentcountryoforigin", countryOfOrigin,
                "studentgender", gender,
                "studentdisability", disability,
                "studentdisabilitydescription", disabilityDescription);
        }

        public bool Delete()
        {
            return Database.Delete(Table, "studentid", id);
        }

        public bool Search()
        {
            DataRow dataRow;
            if (Database.Search(Table, out dataRow, "studentid", id))
            {
                firstName = Convert.ToString(dataRow[1]);
                lastName = Convert.ToString(dataRow[2]);
                locationId = Convert.ToInt32(dataRow[3]);
                dateOfBirth = Convert.ToDateTime(dataRow[4]);
                email = Convert.ToString(dataRow[5]);
                countryOfOrigin = Convert.ToString(dataRow[6]);
                gender = Convert.ToInt32(dataRow[7]);
                disability = Convert.ToBoolean(dataRow[8]);
                disabilityDescription = Convert.ToString(dataRow[9]);
                return true;
            }
            else
                return false;
        }
    }
}
