using Admin_Program.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Admin_Program.EquipmentManagement.ObjectClass
{
    class Zone
    {
        string name;
        public string Name { get { return name; } }
        string photo;
        public string Photo { get { return photo; }set { photo = value; } }
        int warehouseid;
        public int WarehouseID { get { return warehouseid; }set { warehouseid = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING;

        void UpdateAtribute(string name)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string select = "SELECT * FROM zone WHERE Name = @name";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@name", name);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
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

        public Zone(string name)
        {
            UpdateAtribute(name);
        }
        public Zone(string name,string photo, int whid)
        {
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
                    string insert = "INSERT INTO zone (Name, Photo, WarehouseID) VALUES (@n, @p, @w)";
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
                    string delete = "DELETE FROM zone WHERE Name = @n";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@n",name);
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
                            string n = reader["Name"].ToString();
                            string p = reader["Photo"].ToString();
                            int whid = Convert.ToInt32(reader["WarehouseID"]);
                            Zone z = new Zone(n,p,whid);
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
