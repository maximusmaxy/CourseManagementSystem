using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string sql = @"select locationid from locations
                           where addressstreet1 = @street1
                           and addressstreet2 = @street2
                           and addresssuburb = @suburb
                           and addressstate = @state
                           and addresspostcode = @postcode;
                           if @@ROWCOUNT = 0
                           begin
                           insert into locations
                           values (@street1, @street2, @suburb, @state, @postcode);
                           select @@identity;
                           end";
            using (SqlConnection connection = Database.Connection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {

                command.Parameters.AddWithNullValue("@street1", addressStreet1);
                command.Parameters.AddWithNullValue("@street2", addressStreet2);
                command.Parameters.AddWithNullValue("@suburb", addressSuburb);
                command.Parameters.AddWithNullValue("@state", addressState);
                command.Parameters.AddWithNullValue("@postcode", addressPostCode);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        id = Convert.ToInt32(dataReader[0]);
                        return true;
                    }
                    else if (dataReader.NextResult())
                    {
                        dataReader.Read();
                        id = Convert.ToInt32(dataReader[0]);
                        return true;
                    }
                    return false;
                }
            }
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
                addressStreet1 = Convert.ToString(dataRow[1]);
                addressStreet2 = Extensions.ConvertDBNullString(dataRow[2]);
                addressSuburb = Extensions.ConvertDBNullString(dataRow[3]);
                addressState = Extensions.ConvertDBNullString(dataRow[4]);
                addressPostCode = Extensions.ConvertDBNullInt(dataRow[5]);
                return true;
            }
            else
                return false;
        }
    }
}
