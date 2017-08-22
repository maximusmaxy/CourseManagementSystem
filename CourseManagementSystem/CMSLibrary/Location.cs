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
        public static string Table { get; set; } = "locations";

        private int id;
        private string addressStreet1;
        private string addressStreet2;
        private string addressSuburb;
        private string addressState;
        private int addressPostCode;

        public Location() { }

        public Location(int id)
        {
            this.id = id;
        }

        public Location(int id, string addressStreet1, string addressStreet2, string addressSuburb, string addressState, int addressPostCode)
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

        public int AddressPostCode
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

        /// <summary>
        /// Adds a location to the database. 
        /// If it already exists it will return that location id. If not it will create it and return it.
        /// </summary>
        /// <param name="locationid">The id of the newly inserted location.</param>
        /// <returns>Whether the insert was successful.</returns>
        public bool Add()
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
                command.Parameters.AddWithValue("@street1", addressStreet1);
                command.Parameters.AddWithValue("@street2", addressStreet2);
                command.Parameters.AddWithValue("@suburb", addressSuburb);
                command.Parameters.AddWithValue("@state", addressState);
                command.Parameters.AddWithValue("@postcode", addressPostCode);
                using (SqlDataReader dataReader = Database.ExecuteQuery(sql))
                {
                    if (dataReader.Read())
                    {
                        id = dataReader.GetInt32(0);
                        return true;
                    }
                    if (dataReader.NextResult())
                    {
                        id = dataReader.GetInt32(0);
                        return true;
                    }
                    return false;
                }
            }
        }

        public bool Update()
        {
            return Database.Update(Table, "locationid", id,
                "addressstreet1", addressStreet1,
                "addressstreet2", addressStreet2,
                "addresssuburb", addressSuburb,
                "addressstate", addressState,
                "addresspostcode", addressPostCode);
        }

        public bool Delete()
        {
            return Database.Delete(Table, "locationid", id);
        }

        public bool Search()
        {
            DataRow dataRow;
            if (Database.Search(Table, out dataRow, "locationid", id))
            {
                addressStreet1 = (string)dataRow[1];
                addressStreet2 = (string)dataRow[2];
                addressSuburb = (string)dataRow[3];
                addressState = (string)dataRow[4];
                addressPostCode = (int)dataRow[5];
                return true;
            }
            else
                return false;
        }
    }
}
