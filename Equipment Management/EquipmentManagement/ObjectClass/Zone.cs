using Admin_Program.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Admin_Program.EquipmentManagement.ObjectClass
{
    class Zone
    {
        int id;
        public int ID { get { return id; } }
        string name;
        public string Name { get { return name; }set { name = value; } }
        string photo;
        public string Photo { get { return photo; }set { photo = value; } }
        int warehouseid;
        public int WarehouseID { get { return warehouseid; }set { warehouseid = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING;

        void UpdateAtribute(string id)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string select = "SELECT * FROM zone WHERE ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.id = Convert.ToInt32(reader["ID"]);
                            this.name = reader["Name"].ToString();
                            this.photo = reader["Photo"].ToString();
                            this.warehouseid = Convert.ToInt32(reader["WarehouseID"]);
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

        public Zone(int id)
        {
            UpdateAtribute(id.ToString());
        }
        public Zone(string name,string photo, int whid)
        {
            this.name = name;
            this.photo = photo;
            this.warehouseid = whid;
        }
        public Zone(int id,string name,string photo, int whid)
        {
            this.id = id;
            this.name = name;
            this.photo = photo;
            this.warehouseid = whid;
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
                    string insert = "INSERT INTO zone (ID, Name, Photo, WarehouseID) VALUES (NULL, @n, @p, @w)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@p",photo);
                    cmd.Parameters.AddWithValue("@w", warehouseid);
                    cmd.ExecuteNonQuery();
                }
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
            return true;
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
                    string delete = "DELETE FROM zone WHERE ID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", id);
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

        public static List<Zone> GetAllZone()
        {
            MySqlConnection conn = null;
            List<Zone> zList = new List<Zone>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM zone WHERE WarehouseID = @w ORDER BY Name ASC";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@w",GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string n = reader["Name"].ToString();
                            string p = reader["Photo"].ToString();
                            int whid = Convert.ToInt32(reader["WarehouseID"]);
                            Zone z = new Zone(id,n,p,whid);
                            zList.Add(z);
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
            return zList;
        }
    }
}
