using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

namespace CmsLibrary
{
    public enum Permission
    {
        None = 0,
        Student = 1,
        Teacher = 2,
        HeadTeacher = 3,
        Admin = 4
    }

    public static class Database
    {

        //The static server name that is used for every connection.
        //public static string ServerName { get; set; } = "LISAWORKLAPTOP\\SQLEXPRESS";
        public static string ServerName { get; set; } = "(local)";

        //Database Name
        public static string DatabaseName { get; set; } = "CourseManage";

        //User Object
        public static User User { get; set; } = new User();

        /// <summary>
        /// Initializes a new Sql connection based on the static fields.
        /// </summary>
        /// <returns>The created Sql Connection.</returns>
        public static SqlConnection Connection(bool open = true)
        {
            string strConnection = $"server={ServerName};database={DatabaseName};Trusted_Connection=yes";
            SqlConnection connection = new SqlConnection(strConnection);
            if (open)
                connection.Open();
            return connection;
        }

        /// <summary>
        /// Loads the database using sql file in the library
        /// </summary>
        /// <returns>Whether the load was successful.</returns>
        public static bool LoadDatabase()
        {
            string connectionString = $"server={ServerName};database=master;Trusted_Connection=yes";
            string commandString = $"if db_id('{DatabaseName}') is null create database {DatabaseName};";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                if (!ExecuteSqlString(Properties.Resources.CmsSql, "CmsSql.sql"))
                    return false;
                if (!ExecuteSqlString(Properties.Resources.CmsStoredProcedures, "CmdStoredProcedures.sql"))
                    return false;
                string[] queries = Properties.Resources.CmsSql.Split(new string[] { "\r\ngo\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < queries.Length; i++)
                    ExecuteNonQuery(queries[i]);
                return true;
            }
            catch (SqlException ex)
            {
                if (new int[] {-1, 2}.Contains(ex.Number))
                {
                    MessageBox.Show($"The server \"{ServerName}\" is either not running or could not be found. Please make sure the server exists and is running.");
                }
                else
                {
                    MessageBox.Show($"{ex.Number}\n{ex.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// Executes an sql resource string.
        /// </summary>
        /// <param name="sql">The sql resource string to execute.</param>
        /// <param name="name">The name of the resource file for debugging purposes.</param>
        /// <returns></returns>
        public static bool ExecuteSqlString(string sql, string name)
        {
            try
            {
                string[] queries = sql.Split(new string[] { "\r\ngo\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < queries.Length; i++)
                    ExecuteNonQuery(queries[i]);
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error executing {name}\n{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Creates a data table from the sql string.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        public static DataTable CreateDataTable(string sql)
        {
            using (SqlConnection connection = Connection())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        /// <summary>
        /// Executes an sql query and returns a data reader.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns></returns>
        public static IEnumerable<SqlDataReader> ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = Connection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddRange(parameters);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        yield return dataReader;
                    }
                }
            }

        }

        /// <summary>
        /// Executes an sql query and returns the number of rows as an integer.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            using (SqlConnection connection = Connection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executes a stored procedure on the database and returns a datareader.
        /// </summary>
        /// <param name="storedProcedure">The name of the stored procedure.</param>
        /// <param name="parameters">An array of SqlParameters</param>
        /// <returns></returns>
        public static IEnumerable<SqlDataReader> StoredProcedure(string storedProcedure, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = Connection())
            using (SqlCommand command = new SqlCommand(storedProcedure, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (true)
                    {
                        if (reader.Read())
                            yield return reader;
                        else if (!reader.NextResult())
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Inserts an array of values to a table.
        /// </summary>
        /// <param name="table">The name of the table in the database.</param>
        /// <param name="id">The value of the newly created id.</param>
        /// <param name="values">The list of values.</param>
        /// <returns>Whether the insert was successful.</returns>
        public static bool Add(string table, out int id, params object[] values)
        {
            id = -1;
            if (values.Length == 0)
                return true;
            StringBuilder sql = new StringBuilder("insert into ");
            sql.Append(table);
            sql.Append(" values (");
            sql.Append("@0");
            for (int i = 1; i < values.Length; i++)
            {
                sql.Append(", @");
                sql.Append(i);
            }
            sql.Append(");");
            sql.Append("select @@identity;");
            using (SqlConnection connection = Connection())
            using (SqlCommand command = new SqlCommand(sql.ToString(), connection))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    command.Parameters.AddWithNullValue($"@{i}", values[i]);
                }
                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            id = Convert.ToInt32(reader[0]);
                            return true;
                        }
                        else
                            return false;
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                        throw new UniqueConstraintException(ex.Message);
                    else
                        MessageBox.Show($"{ex.Number}\n{ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Updates the values in a table.
        /// </summary>
        /// <param name="table">The name of the table in the database.</param>
        /// <param name="idName">The name of the ID column in the table.</param>
        /// <param name="idValue">The value of the ID.</param>
        /// <param name="values">Every even value is a string for the column name. Every odd value is an object for the value to insert.</param>
        /// <returns></returns>
        public static bool Update(string table, string idName, object idValue, params object[] values)
        {
            if (values.Length == 0)
                return true;
            StringBuilder sql = new StringBuilder("update ");
            sql.Append(table);
            sql.Append(" set ");
            sql.Append(values[0]);
            sql.Append(" = @0");
            for (int i = 2; i < values.Length; i++)
            {
                sql.Append(", ");
                sql.Append(values[i]);
                sql.Append(" = @");
                sql.Append(i++);
            }
            sql.Append(" where ");
            sql.Append(idName);
            sql.Append(" = @value");
            using (SqlConnection connection = Connection())
            using (SqlCommand command = new SqlCommand(sql.ToString(), connection))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    command.Parameters.AddWithNullValue($"@{i}", values[i + 1]);
                    i++;
                }
                command.Parameters.AddWithNullValue($"@value", idValue);
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"{ex.Number}\n{ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Delete a row from a table specified by id.
        /// </summary>
        /// <param name="table">The name of the table in the database.</param>
        /// <param name="idName">The name of the column in the database.</param>
        /// <param name="idValue">The value of the id.</param>
        /// <returns></returns>
        public static bool Delete(string table, string idName, object idValue)
        {
            string sql = $"delete from {table} where {idName} = @value";
            using (SqlConnection connection = Connection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithNullValue("@value", idValue);
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"{ex.Number}\n{ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Basic search functionality for a table.
        /// </summary>
        /// <param name="table">The name of the table in the database.</param>
        /// <param name="values">Every even value is a string for the column name. Every odd value is an object for the value to search for.</param>
        /// <returns></returns>
        public static bool Search(string table, out DataRow dataRow, params object[] values)
        {
            dataRow = null;
            if (values.Length == 0)
                return true;
            StringBuilder sql = new StringBuilder("select * from ");
            sql.Append(table);
            sql.Append(" where ");
            sql.Append(values[0]);
            sql.Append(" = @0");
            for (int i = 2; i < values.Length; i++)
            {
                sql.Append(" and ");
                sql.Append(values[i]);
                sql.Append(" = @");
                sql.Append(i++);
            }
            using (SqlConnection connection = Connection(false))
            using (SqlCommand command = new SqlCommand(sql.ToString(), connection))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    command.Parameters.AddWithNullValue($"@{i}", values[i + 1]);
                    i++;
                }
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    if (dataSet.Tables != null && dataSet.Tables[0].Rows.Count > 0)
                    {
                        dataRow = dataSet.Tables[0].Rows[0];
                        return true;
                    }
                    else
                    {
                        if (Validation.ShowErrors)
                            MessageBox.Show("No matching results found.");
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"{ex.Number}\n{ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Updates a bridging table in the databse.
        /// </summary>
        /// <param name="table">The name of the bridging table.</param>
        /// <param name="idName">The name of the main id column.</param>
        /// <param name="idValue">The value of the id.</param>
        /// <param name="controlName">The name of the controls column id.</param>
        /// <param name="control">The control holding the list of values.</param>
        /// <param name="idLeft">If true then id is the first column. Else it is the seccond.</param>
        /// <returns></returns>
        public static bool UpdateBridgingTable(string table, string idName, int idValue, string controlName, ListBox control, bool idLeft = true)
        {
            List<int> adds = new List<int>();
            List<int> deletes = new List<int>();
            foreach (DataRowView row in control.SelectedItems)
            {
                adds.Add(Convert.ToInt32(row[controlName]));
            }
            string sql = $"select {controlName} from {table} where {idName} = {idValue}";
            try
            {
                foreach (SqlDataReader row in Database.ExecuteQuery(sql))
                {
                    int id = Convert.ToInt32(row[0]);
                    if (adds.Contains(id))
                        adds.Remove(id);
                    else
                        deletes.Add(id);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Number}\n{ex.Message}");
                return false;
            }
            if (adds.Count == 0 && deletes.Count == 0)
                return true;
            StringBuilder sb = new StringBuilder();
            if (adds.Count > 0)
            {
                sb.Append("insert into ");
                sb.Append(table);
                if (idLeft)
                {
                    sb.Append(" values (");
                    sb.Append(idValue);
                    sb.Append(", @0)");
                }
                else
                {
                    sb.Append(" values (@0, ");
                    sb.Append(idValue);
                    sb.Append(")");
                }
                for (int i = 1; i < adds.Count; i++)
                {
                    sb.Append(", (");
                    if (idLeft)
                    {
                        sb.Append(idValue);
                        sb.Append(", @");
                        sb.Append(i);
                    }
                    else
                    {
                        sb.Append("@");
                        sb.Append(i);
                        sb.Append(", ");
                        sb.Append(idValue);
                    }
                    sb.Append(")");
                }
                sb.Append(";");
            }
            if (deletes.Count > 0)
            {
                sb.Append("delete from ");
                sb.Append(table);
                sb.Append(" where ");
                sb.Append(idName);
                sb.Append(" = ");
                sb.Append(idValue);
                sb.Append(" and (");
                sb.Append(controlName);
                sb.Append(" = @");
                sb.Append(adds.Count);
                for (int i = 1; i < deletes.Count; i++)
                {
                    sb.Append(" or ");
                    sb.Append(controlName);
                    sb.Append(" = @");
                    sb.Append(adds.Count + i);
                }
                sb.Append(");");
            }
            using (SqlConnection connection = Connection())
            using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
            {
                for (int i = 0; i < adds.Count; i++)
                {
                    command.Parameters.AddWithValue($"@{i}", adds[i]);
                }
                for (int i = 0; i < deletes.Count; i++)
                {
                    command.Parameters.AddWithValue($"@{adds.Count + i}", deletes[i]);
                }
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"{ex.Number}\n{ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Deletes all references to an id from the bridging table.
        /// </summary>
        /// <param name="table">The name of the bridging table.</param>
        /// <param name="idName">The name of the column being deleted from.</param>
        /// <param name="idValue">The value of the id.</param>
        public static bool DeleteBridgingTable(string table, string idName, int idValue)
        {
            string sql = $"delete from {table} where {idName} = {idValue}";
            try
            {
                ExecuteNonQuery(sql);
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Number}\n{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Creates a bridging table used for resolution of 1 to many relations in data grid views.
        /// </summary>
        /// <param name="bridge">The bridge object containing all the information.</param>
        public static DataTable CreateBridgingTable(Bridge bridge)
        {
            string sql = $"select {bridge.BridgingTable}.{bridge.IdColumn} as '{bridge.IdColumn}', " +
                $"{bridge.BridgingTable}.{bridge.ForeignColumn} as '{bridge.ForeignColumn}', " +
                $"{bridge.ForeignTable}.{bridge.ForeignDisplay} as '{bridge.ForeignDisplay}' " +
                $"from {bridge.BridgingTable}, {bridge.ForeignTable} " +
                $"where {bridge.BridgingTable}.{bridge.ForeignColumn} = " +
                $"{bridge.ForeignTable}.{bridge.ForeignColumn}";
            return CreateDataTable(sql);
        }

        /// <summary>
        /// Adds a bridging table to another table used by data grid views.
        /// </summary>
        /// <param name="mainTable">The table recieving the join.</param>
        /// <param name="bridgeTable">The table to be joined.</param>
        /// <param name="bridge">The bridge object specifying the bridge information.</param>
        public static void AddBridgingTable(DataTable mainTable, DataTable bridgeTable, Bridge bridge)
        {
            int max = mainTable.Columns.Count - 1;
            foreach (DataRow row in mainTable.AsEnumerable())
            {
                int j = 0;
                foreach (var bridgeRow in bridgeTable.AsEnumerable().Where(
                    r => Convert.ToInt32(r[bridge.IdColumn]) ==
                    Convert.ToInt32(row[Extensions.CamelToHuman(bridge.IdColumn)])))
                {
                    j++;
                    if (j + max > mainTable.Columns.Count - 1)
                        mainTable.Columns.Add($"{Extensions.CamelToHuman(bridge.ForeignDisplay)} {j}", typeof(string));
                    row[j + max] = (string)bridgeRow[bridge.ForeignDisplay];
                }
            }
        }

        /// <summary>
        /// Returns the column names of a table without quering the entire table.
        /// </summary>
        /// <param name="table">The name of the table in the database.</param>
        /// <returns></returns>
        public static string[] GetTableColumns(string table)
        {
            List<string> strings = new List<string>();
            string sql = $"select * from {DatabaseName}.information_schema.columns where table_name = '{table}'";
            string column = "column_name";
            foreach (SqlDataReader dataReader in ExecuteQuery(sql))
            {
                strings.Add((string)dataReader[column]);
            }
            return strings.ToArray();
        }

        /// <summary>
        /// Converts the column values into human readable names using a dictionary.
        /// </summary>
        /// <param name="columnName">The name of the column in the database.</param>
        /// <param name="dictionary">The dictionary from the Types class.</param>
        /// <returns></returns>
        public static string GetDictionaryNames(string columnName, Dictionary<string, int> dictionary)
        {
            StringBuilder sb = new StringBuilder(" case ");
            sb.Append(columnName);
            sb.Append(" ");
            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                sb.Append("when ");
                sb.Append(kvp.Value);
                sb.Append(" then '");
                sb.Append(kvp.Key);
                sb.Append("' ");
            }
            sb.Append("end ");
            return sb.ToString();
        }

        /// <summary>
        /// Removes a column from a data table.
        /// </summary>
        /// <typeparam name="T">The data type of the column</typeparam>
        /// <param name="dataTable">The table to remove the column from.</param>
        /// <param name="index">The index of the column to remove.</param>
        public static void RemoveColumn(DataTable dataTable, string columnName)
        {
            dataTable.Columns.Remove(columnName);
        }

        /// <summary>
        /// Removes a column from a data table and returns a list of values that were removed.
        /// </summary>
        /// <typeparam name="T">The data type of the column</typeparam>
        /// <param name="dataTable">The table to remove the column from.</param>
        /// <param name="index">The index of the column to remove.</param>
        public static List<T> RemoveColumn<T>(DataTable dataTable, string columnName)
        {
            List<T> list = new List<T>();
            foreach (DataRow column in dataTable.AsEnumerable())
                list.Add((T)column[columnName]);
            dataTable.Columns.Remove(columnName);
            return list;
        }

        /// <summary>
        /// Gets a user permission type based on username and password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>Whether the login was successful or not.</returns>
        public static bool Login(string username, string password)
        {
            string sql = "select * from Users where userName = @username";
            SqlParameter usernameParameter = new SqlParameter("@username", username);
            foreach (SqlDataReader row in ExecuteQuery(sql, usernameParameter))
            {
                Byte[] passwordBytes = null;
                Byte[] saltBytes = null;
                Byte[] hashedBytes = null;
                Byte[] hashedPassword = null;
                try
                {
                    passwordBytes = Encoding.UTF8.GetBytes(password);
                    saltBytes = Convert.FromBase64String(Convert.ToString(row["salt"]));
                    hashedBytes = GetSaltedHashedPassword(passwordBytes, saltBytes);
                    hashedPassword = Convert.FromBase64String(Convert.ToString(row["passwords"]));
                    if (hashedPassword.SequenceEqual(hashedBytes))
                    {
                        User.Permission = (Permission)Convert.ToInt32(row["permissionType"]);
                        User.Id = Extensions.ConvertDBNullInt(row["studentTeacherId"]);
                        return true;
                    }
                }
                finally
                {
                    Array.Clear(passwordBytes, 0, passwordBytes.Length);
                    Array.Clear(saltBytes, 0, saltBytes.Length);
                    Array.Clear(hashedBytes, 0, hashedBytes.Length);
                    Array.Clear(hashedPassword, 0, hashedPassword.Length);
                }
            }
            return false;
        }

        /// <summary>
        /// Gets a cryptographically random 32 byte array for use with password hashing
        /// </summary>
        public static byte[] GetSalt()
        {
            RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[32];
            rnd.GetBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// Gets a salted and hashed password.
        /// </summary>
        public static byte[] GetSaltedHashedPassword(byte[] password, byte[] salt)
        {
            return new SHA256Managed().ComputeHash(salt.Concat(password).ToArray());
        }

        /// <summary>
        /// Returns the mac address of the current computer
        /// </summary>
        public static string MacAddress()
        {
            return NetworkInterface.GetAllNetworkInterfaces().Where(nic => nic.OperationalStatus == OperationalStatus.Up).Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();
        }
    }
}