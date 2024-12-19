using Admin_Program.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Admin_Program.ObjectClass
{
    class EquipmentOwner
    {
        int id;
        public int ID { get { return id; } }
        string owner;
        public string Owner { get { return owner; }set { owner = value; } }
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
                    string select = "SELECT * FROM equipmentowner WHERE ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            owner = reader["Owner"].ToString();
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

        public EquipmentOwner(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public EquipmentOwner(string owner, int warehouseID)
        {
            this.owner = owner;
            this.warehouseID = warehouseID;
        }
        public EquipmentOwner(int id,string owner,int warehouseID)
        {
            this.id = id;
            this.owner = owner;
            this.warehouseID = warehouseID;
        }

        public bool Create()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    string insert = "INSERT INTO equipmentowner (ID, Owner, WarehouseID) VALUES (NULL, @owner, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@owner", owner);
                    cmd.Parameters.AddWithValue("@whid", warehouseID);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(MySqlException e)
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
                using(var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM equipmentowner WHERE ID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", id.ToString());
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(MySqlException e)
            {
                return false;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }

        public static List<EquipmentOwner> GetEquipmentOwnerList()
        {
            MySqlConnection conn = null;
            List<EquipmentOwner> eqoList = new List<EquipmentOwner>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM equipmentowner WHERE WarehouseID = @whid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid",GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string owner = reader["Owner"].ToString();
                            int whid = Convert.ToInt32(reader["WarehouseID"]);
                            EquipmentOwner eqo = new EquipmentOwner(id, owner,whid);
                            eqoList.Add(eqo);
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
            return eqoList;
        }
    }
}
