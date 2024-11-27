using Admin_Program.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Admin_Program.ObjectClass
{
    class EquipmentStatus
    {
        int id;
        public int ID { get { return id; } }
        string estatus;
        public string EStatus { get { return estatus; } }

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
                    string select = "SELECT * FROM equipmentstatus WHERE ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            estatus = reader["EStatus"].ToString();
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

        public EquipmentStatus(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public EquipmentStatus(int id,string estatus)
        {
            this.id = id;
            this.estatus = estatus;
        }

        public static List<EquipmentStatus> GetEquipmentStatusList()
        {
            MySqlConnection conn = null;
            List<EquipmentStatus> eqsList = new List<EquipmentStatus>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM equipmentstatus";
                    cmd.CommandText = selectAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string estatus = reader["EStatus"].ToString();
                            EquipmentStatus eqs = new EquipmentStatus(id, estatus);
                            eqsList.Add(eqs);
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
            return eqsList;
        }
    }
}
