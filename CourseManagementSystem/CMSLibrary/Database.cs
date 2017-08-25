using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace CmsLibrary
{
    public static class Database
    {
        //These can be changed staticly using Database.ServerName = "localHost" or whatever.
        //home - MAXIMUMPENIS\\SQLEXPRESS
        //tafe - (local)
        public static string ServerName { get; set; } = "(local)";
        public static string DatabaseName { get; set; } = "CourseManage";
        public static string SqlFileName { get; set; } = "CmsSql.sql";

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
        public static void LoadDatabase()
        {
            string connectionString = $"server={ServerName};database=master;Trusted_Connection=yes";
            string commandString = $"if db_id('{DatabaseName}') is null create database {DatabaseName};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(commandString, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            ExecuteNonQuery(File.ReadAllText(SqlFileName));
        }

        /// <summary>
        /// Creates a data table from the sql string.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(string sql)
        {
            try
            {
                using (SqlConnection connection = Connection())
                {

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Executes an sql query and returns a data reader.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns></returns>
        public static IEnumerable<SqlDataReader> ExecuteQuery(string sql)
        {
            using (SqlConnection connection = Connection())
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    yield return dataReader;
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
        /// Returns whether an id exists within a database.
        /// </summary>
        /// <param name="table">Name of the table in the database</param>
        /// <param name="idName">Name of the id column in the database</param>
        /// <param name="idValue">The value of the id</param>
        /// <param name="idName2">Name of the second option id in the database</param>
        /// <param name="idValue2">The value of the second id</param>
        /// <returns></returns>
        public static bool IdExists(string table, string idName, int idValue, string idName2 = null, int idValue2 = -1)
        {
            string sql;
            sql = $"select * from {table} where {idName} = {idValue}";
            if (idName2 != null)
                sql += $" and {idName2} = {idValue2}";
            foreach (SqlDataReader dataReader in ExecuteQuery(sql))
                return dataReader.HasRows;
            return false;
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
        }

        /// <summary>
        /// Updates the values in a table.
        /// </summary>
        /// <param name="table">The name of the table in the database.</param>
        /// <param name="idName">The name of the ID column in the table.</param>
        /// <param name="idValue">The value of the ID.</param>
        /// <param name="values">Every even value is a string for the column name. Every odd value is an object for the value to insert.</param>
        /// <returns></returns>
        public static bool Update(string table, string idName, int idValue, params object[] values)
        {
            if (!IdExists(table, idName, idValue))
            {
                MessageBox.Show($"{idName}: {idValue} from {table} table does not exist.");
                return false;
            }
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
            sql.Append(" = ");
            sql.Append(idValue);
            using (SqlConnection connection = Connection())
            using (SqlCommand command = new SqlCommand(sql.ToString(), connection))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    command.Parameters.AddWithNullValue($"@{i}", values[i + 1]);
                    i++;
                }
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
        public static bool Delete(string table, string idName, int idValue)
        {
            if (!IdExists(table, idName, idValue))
            {
                MessageBox.Show($"{idName}: {idValue} from {table} table does not exist.");
                return false;
            } 
            string sql = $"delete from {table} where {idName} = {idValue}";
            return ExecuteNonQuery(sql) > 0;
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
                sql.Append(", ");
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
                        MessageBox.Show("No matching results found.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
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
        /// Converts the column values into human readable names using an enum.
        /// </summary>
        /// <param name="columnName">The name of the column in the database.</param>
        /// <param name="enumType">The enums type from the typeof keyword.</param>
        /// <returns></returns>
        public static string GetEnumNames(string columnName, Type enumType)
        {
            StringBuilder s = new StringBuilder(" case ");
            s.Append(columnName);
            s.Append(" ");
            string[] names = Enum.GetNames(enumType);
            int[] values = (int[])Enum.GetValues(enumType);
            for (int i = 0; i < names.Length; i++)
            {
                s.Append("when ");
                s.Append(values[i]);
                s.Append(" then '");
                s.Append(names[i]);
                s.Append("' ");
            }
            s.Append("end ");
            return s.ToString();
        }
    }
}