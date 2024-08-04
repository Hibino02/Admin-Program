using Equipment_Management.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Equipment_Management.ObjectClass
{
    class Acquisition
    {
        int id;
        public int ID { get { return id; } }
        string accquire;
        public string Accquire { get { return accquire; } }

        static string connstr = Settings.Default.CONNECTION_STRING;

        void UpdateAttribute(string value)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string select = "SELECT * FROM acquisition WHERE ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using(var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            accquire = reader["Accquire"].ToString();
                        }
                    }
                }
            }
            catch (MySqlException e) { }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        
        public Acquisition(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public Acquisition(int id,string acc)
        {
            this.id = id;
            accquire = acc;
        }

        public static List<Acquisition> GetAcquisitionList()
        {
            MySqlConnection conn = null;
            List<Acquisition> accList = new List<Acquisition>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM acquisition";
                    cmd.CommandText = selectAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string acc = reader["Accquire"].ToString();
                            Acquisition acq = new Acquisition(id, acc);
                            accList.Add(acq);
                        }
                    }
                }
            }
            catch (MySqlException e) { }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
            return accList;
        }
    }
}
