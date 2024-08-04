using Equipment_Management.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Equipment_Management.ObjectClass
{
    class EquipmentOwner
    {
        int id;
        public int ID { get { return id; } }
        string owner;
        public string Owner { get { return owner; }set { owner = value; } }

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
        public EquipmentOwner(string owner)
        {
            this.owner = owner;
        }
        public EquipmentOwner(int id,string owner)
        {
            this.id = id;
            this.owner = owner;
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
                    string insert = "INSERT INTO equipmentowner (ID, Owner) VALUES (NULL, @owner)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@owner", owner);
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
                    string selectAll = "SELECT * FROM equipmentowner";
                    cmd.CommandText = selectAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string owner = reader["Owner"].ToString();
                            EquipmentOwner eqo = new EquipmentOwner(id, owner);
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
