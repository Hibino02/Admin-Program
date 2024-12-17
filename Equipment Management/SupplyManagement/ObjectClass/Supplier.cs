using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class Supplier
    {
        int id;
        public int ID { get { return id; } }
        string name;
        public string Name { get { return name; } set { name = value; } }
        string address;
        public string Address { get { return address; } set { address = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING_SUPPLY;

        void UpdateAttribute(string value)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string select = "SELECT * FROM Supplier WHERE ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            name = reader["SupplierName"].ToString();
                            address = reader["SupplierAddress"].ToString();
                        }
                    }
                }
            }
            catch (MySqlException e) { }
            finally
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        public Supplier(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public Supplier(int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
        public Supplier(string name, string address)
        {
            this.name = name;
            this.address = address;
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
                    string insert = "INSERT INTO Supplier (ID, SupplierName, SupplierAddress) VALUES (NULL, @name, @address)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
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
        public bool Change()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    string update = "UPDATE Supplier SET SupplierName = @name, SupplierAddress = @address WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
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
        public bool Remove()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM Supplier WHERE ID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", id);
                }
                return true;
            }
            catch(MySqlException e)
            {
                return false;
            }
        }

        public static List<Supplier> GetAllSupplierList()
        {
            MySqlConnection conn = null;
            List<Supplier> supplierList = new List<Supplier>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM Supplier";
                    cmd.CommandText = selectAll;
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string name = reader["SupplierName"].ToString();
                            string address = reader["SupplierAddress"].ToString();
                            Supplier s = new Supplier(id, name, address);
                            supplierList.Add(s);
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
            return supplierList;
        }
    }
}
