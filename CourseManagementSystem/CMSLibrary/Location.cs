using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CmsLibrary
{
    public class Location : IData
    {
        private int id;
        private string addressStreet1;
        private string addressStreet2;
        private string addressSuburb;
        private string addressState;
        private int? addressPostCode;
        private string campus;

        public Location() { }

        public Location(int id)
        {
            this.id = id;
        }

        public Location(int id, string addressStreet1, string addressStreet2, string addressSuburb, string addressState, int? addressPostCode)
        {
            this.id = id;
            this.addressStreet1 = addressStreet1;
            this.addressStreet2 = addressStreet2;
            this.addressSuburb = addressSuburb;
            this.addressState = addressState;
            this.addressPostCode = addressPostCode;
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

        public string AddressStreet1
        {
            get
            {
                return addressStreet1;
            }

            set
            {
                addressStreet1 = value;
            }
        }

        public string AddressStreet2
        {
            get
            {
                return addressStreet2;
            }

            set
            {
                addressStreet2 = value;
            }
        }

        public string AddressSuburb
        {
            get
            {
                return addressSuburb;
            }

            set
            {
                addressSuburb = value;
            }
        }

        public string AddressState
        {
            get
            {
                return addressState;
            }

            set
            {
                addressState = value;
            }
        }

        public int? AddressPostCode
        {
            get
            {
                return addressPostCode;
            }

            set
            {
                addressPostCode = value;
            }
        }

        public string Campus
        {
            get
            {
                return campus;
            }
            set
            {
                campus = value;
            }
        }


        public bool Add()
        {
            return AddUpdate();
        }

        public bool Update()
        {
            return AddUpdate();
        }

        /// <summary>
        /// Adds a location to the database. 
        /// If it already exists it will return that location id. If not it will create it and return it.
        /// </summary>
        private bool AddUpdate()
        {
            try
            {
                foreach (SqlDataReader reader in Database.StoredProcedure("Location",
                   new SqlParameter("@street1", Extensions.ConvertDBNullString(addressStreet1)),
                   new SqlParameter("@street2", Extensions.ConvertDBNullString(addressStreet2)),
                   new SqlParameter("@suburb", Extensions.ConvertDBNullString(addressSuburb)),
                   new SqlParameter("@state", Extensions.ConvertDBNullString(addressState)),
                   new SqlParameter("@postcode", Extensions.ConvertDBNullInt(addressPostCode)),
                   new SqlParameter("@campus", Extensions.ConvertDBNullString(campus))))
                {
                    id = Convert.ToInt32(reader[0]);
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public bool Delete()
        {
            return Database.Delete("locations", "locationid", id);
        }

        public bool Search()
        {
            return Search("locationid", id);
        }

        public bool Search(params object[] values)
        {
            DataRow dataRow;
            if (Database.Search("locations", out dataRow, values))
            {
                id = Convert.ToInt32(dataRow[0]);
                addressStreet1 = Extensions.ConvertDBNullString(dataRow[1]);
                addressStreet2 = Extensions.ConvertDBNullString(dataRow[2]);
                addressSuburb = Extensions.ConvertDBNullString(dataRow[3]);
                addressState = Extensions.ConvertDBNullString(dataRow[4]);
                addressPostCode = Extensions.ConvertDBNullInt(dataRow[5]);
                campus = Extensions.ConvertDBNullString(dataRow[6]);
                return true;
            }
            else
                return false;
        }
    }
}
