using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarCode
{
    class DBAccess
    {
        private static MySqlConnection objConnection;
        private static MySqlDataAdapter objDataAdapter;
        public static string ConnectionString = "SERVER=localhost; DATABASE= productmanagements;" + "UID=root;" + "PASSWORD=root;";
        private static void OpenConnection()
        {
            try
            {
                if (objConnection == null)
                {
                    objConnection = new MySqlConnection(ConnectionString);
                    objConnection.Open();
                }
                else
                {
                    if (objConnection.State != ConnectionState.Open)
                    {
                        objConnection = new MySqlConnection(ConnectionString);
                        objConnection.Open();
                    }
                }
            }
            catch (Exception ex) { }
        }

        private static void CloseConnection()
        {
            try
            {
                if (!(objConnection == null))
                {
                    if (objConnection.State == ConnectionState.Open)
                    {
                        objConnection.Close();
                        objConnection.Dispose();
                    }
                }
            }
            catch (Exception ex) { }
        }

        public static DataTable FillDataTable(string Query, DataTable Table)
        {

            OpenConnection();
            try
            {
                objDataAdapter = new MySqlDataAdapter(Query, objConnection);
                objDataAdapter.Fill(Table);
                objDataAdapter.Dispose();
                CloseConnection();

                return Table;
            }
            catch
            {
                return null;
            }
        }
            public static MySqlDataReader ExecuteReader(string cmd)
            {
                try
                {
                MySqlDataReader objReader;
                    objConnection = new MySqlConnection(ConnectionString);
                    OpenConnection();
                    MySqlCommand cmdRedr = new MySqlCommand(cmd, objConnection);
                    objReader = cmdRedr.ExecuteReader(CommandBehavior.CloseConnection);
                    cmdRedr.Dispose();
                    return objReader;
                }
                catch
                {
                    return null;
                }
            }
            public static bool ExecuteQuery(string query)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        public static bool IsServerConnected()
        {
            using (var l_oConnection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    l_oConnection.Open();
                    return true;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }

    }
}

