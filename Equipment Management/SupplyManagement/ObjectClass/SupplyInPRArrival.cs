using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class SupplyInPRArrival
    {
        int id;
        public int ID { get { return id; }set { id = value; } }
        int prid;
        public int PRID { get { return prid; }set { prid = value; } }
        int supplyid;
        public int SupplyID { get { return supplyid; }set { supplyid = value; } }
        DateTime? arrivaldate;
        public DateTime? ArrivalDate { get { return arrivaldate; }set { arrivaldate = value; } }
        int quantity;
        public int Quantity { get { return quantity; }set { quantity = value; } }
        string invoicepdf;
        public string InvoicePDF { get { return invoicepdf; }set { invoicepdf = value; } }
        string recever;
        public string Recever { get { return recever; }set { recever = value; } }

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
                    string select = @"SELECT
sipra.ID, sipra.PRID, sipra.SupplyID, sipra.ArrivalDate, sipra.Quantity, sipra.InvoicePDF, sipra.Recever
WHERE sipra.ID = @id;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            prid = Convert.ToInt32(reader["PRID"]);
                            supplyid = Convert.ToInt32(reader["SupplyID"]);
                            arrivaldate = reader["ArrivalDate"] != DBNull.Value ? Convert.ToDateTime(reader["ArrivalDate"]) : (DateTime?)null;
                            quantity = Convert.ToInt32(reader["Quantity"]);
                            invoicepdf = reader["InvoicePDF"] != DBNull.Value ? reader["InvoicePDF"].ToString() : null;
                            recever = reader["Recever"] != DBNull.Value ? reader["Recever"].ToString() : null;
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
        public SupplyInPRArrival() { }
        public SupplyInPRArrival(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public SupplyInPRArrival(int prid, int supplyid, int quantity,DateTime? adate = null,string inv = null,string recever = null)
        {
            this.prid = prid;
            this.supplyid = supplyid;
            this.arrivaldate = adate;
            this.quantity = quantity;
            this.invoicepdf = inv;
            this.recever = recever;
        }
        public SupplyInPRArrival(int id,int prid,int supplyid, int quantity,DateTime? adate = null,string inv = null,string recever = null)
        {
            this.id = id;
            this.prid = prid;
            this.supplyid = supplyid;
            this.arrivaldate = adate;
            this.quantity = quantity;
            this.invoicepdf = inv;
            this.recever = recever;
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
                    string insert = "INSERT INTO SupplyInPRArrival (ID, PRID, SupplyID, ArrivalDate, Quantity, InvoicePDF, Recever) VALUES (NULL, @prid, @sid, @adate, @q, @invpdf, @rec)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@prid", prid);
                    cmd.Parameters.AddWithValue("@sid", supplyid);
                    cmd.Parameters.AddWithValue("@adate", arrivaldate);
                    cmd.Parameters.AddWithValue("@q", quantity);
                    cmd.Parameters.AddWithValue("@invpdf", invoicepdf);
                    cmd.Parameters.AddWithValue("@rec", recever);
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
        public static bool Change(int id,int quantity)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string update = "UPDATE SupplyInPRArrival SET Quantity = @q WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@q",quantity);
                    cmd.Parameters.AddWithValue("@id",id);
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
        public static bool Remove(int prid)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM SupplyInPRArrival WHERE PRID = @prid";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@prid", prid.ToString());
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

        public static List<SupplyInPRArrival> GetAllSupplyInPRByPRID(int prid)
        {
            MySqlConnection conn = null;
            List<SupplyInPRArrival> sipraList = new List<SupplyInPRArrival>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
sipra.ID, sipra.PRID, sipra.SupplyID, sipra.ArrivalDate, sipra.Quantity, sipra.InvoicePDF, sipra.Recever
FROM SupplyInPRArrival sipra
WHERE sipra.PRID = @prid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@prid", prid);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            int prida = Convert.ToInt32(reader["PRID"]);
                            int supid = Convert.ToInt32(reader["SupplyID"]);
                            DateTime? ad = reader["ArrivalDate"] != DBNull.Value ? Convert.ToDateTime(reader["ArrivalDate"]) : (DateTime?)null;
                            int q = Convert.ToInt32(reader["Quantity"]);
                            string inv = reader["InvoicePDF"] != DBNull.Value ? reader["InvoicePDF"].ToString() : (string)null;
                            string update = reader["Recever"] != DBNull.Value ? reader["Recever"].ToString() : (string)null;

                            SupplyInPRArrival sipr = new SupplyInPRArrival(id,prida,supid, q,ad,inv,update);
                            sipraList.Add(sipr);
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
            return sipraList;
        }
    }
}
