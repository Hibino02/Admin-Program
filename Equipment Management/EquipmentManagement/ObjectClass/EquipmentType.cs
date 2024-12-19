using Admin_Program.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Admin_Program.ObjectClass
{
    class EquipmentType
    {
        int id;
        public int ID { get { return id; } }
        string etype;
        public string EType {get { return etype; }set { etype = value; } }
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
                    string select = "SELECT * FROM equipmenttype WHERE ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            etype = reader["EType"].ToString();
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

        public EquipmentType(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public EquipmentType(string etype, int warehouseID)
        {
            this.etype = etype;
            this.warehouseID = warehouseID;
        }
        public EquipmentType(int id, string etype, int warehouseID)
        {
            this.id = id;
            this.etype = etype;
            this.warehouseID = warehouseID;
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
                    string insert = "INSERT INTO equipmenttype (ID, EType, WarehouseID) VALUES (NULL, @etype, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@etype", etype);
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
                    string delete = "DELETE FROM equipmenttype WHERE ID = @id";
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

        public static List<EquipmentType> GetEquipmentTypeList()
        {
            MySqlConnection conn = null;
            List<EquipmentType> eqtList = new List<EquipmentType>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM equipmenttype WHERE WarehouseID = @whid";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid",GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string etype = reader["EType"].ToString();
                            int whid = Convert.ToInt32(reader["WarehouseID"]);
                            EquipmentType eqt = new EquipmentType(id, etype, whid);
                            eqtList.Add(eqt);
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
            return eqtList;
        }
    }
}
