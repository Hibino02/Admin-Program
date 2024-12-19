using Admin_Program.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Admin_Program.ObjectClass
{
    class PlanPeriod
    {
        int id;
        public int ID { get { return id; } }
        string pperiod;
        public string PPeriod { get { return pperiod; } set { pperiod = value; } }
        int warehouseID;
        public int WarehouseID { get { return warehouseID; }set { warehouseID = value; } }

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
                    string select = "SELECT * FROM planperiod WHERE ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            pperiod = reader["PPeriod"].ToString();
                            warehouseID = Convert.ToInt32(reader["WarehouseID"]);
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

        public PlanPeriod(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public PlanPeriod(string pperiod, int warehouseid)
        {
            this.pperiod = pperiod;
            this.warehouseID = warehouseid;
        }
        public PlanPeriod(int id, string pperiod,int warehouseid)
        {
            this.id = id;
            this.pperiod = pperiod;
            this.warehouseID = warehouseid;
        }

        public bool Create()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string insert = "INSERT INTO planperiod (ID, PPeriod, WarehouseID) VALUES (NULL, @pperiod, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@pperiod", pperiod);
                    cmd.Parameters.AddWithValue("@whid", warehouseID);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        public bool Remove()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM planperiod WHERE ID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", id.ToString());
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public static List<PlanPeriod> GetPlanPeriodList()
        {
            MySqlConnection conn = null;
            List<PlanPeriod> ppList = new List<PlanPeriod>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM planperiod WHERE WarehouseID = @whid";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid",GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string acc = reader["PPeriod"].ToString();
                            int whid = Convert.ToInt32(reader["WarehouseID"]);
                            PlanPeriod acq = new PlanPeriod(id, acc, whid);
                            ppList.Add(acq);
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
            return ppList;
        }
    }
}
