﻿using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class SupplyInQuotation
    {
        int id;
        public int ID { get { return id; } }
        int quotationid;
        public int QuotationID { get { return quotationid; }set { quotationid = value; } }
        Supply supply;
        public Supply Supply { get { return supply; }set { supply = value; } }
        float price;
        public float Price { get { return price; }set { price = value; } }

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
siq.ID, siq.QuotationID, siq.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.UserGroup, s.SupplyTypeID,
st.TypeName, siq.Price
FROM SupplyInQuotation siq
LEFT JOIN Supply s ON siq.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE siq.ID = @id;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            quotationid = Convert.ToInt32(reader["QuotationID"]);

                            int supid = Convert.ToInt32(reader["SupplyID"]);
                            string sname = reader["SupplyName"].ToString();
                            string sunit = reader["SupplyUnit"].ToString();
                            int moq = Convert.ToInt32(reader["MOQ"]);
                            bool isactive = Convert.ToBoolean(reader["IsActive"]);
                            string sphoto = reader["SupplyPhoto"].ToString();
                            string userg = reader["UserGroup"].ToString();

                            int stypeid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stypename = reader["TypeName"].ToString();
                            SupplyType stype = new SupplyType(stypeid,stypename,GlobalVariable.Global.warehouseID);

                            supply = new Supply(supid,sname,sunit,moq,isactive,stype,GlobalVariable.Global.warehouseID, userg, sphoto);

                            price = Convert.ToSingle(reader["Price"]);
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

        public SupplyInQuotation(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public SupplyInQuotation(int id, int qid, Supply s, float price)
        {
            this.id = id;
            this.quotationid = qid;
            this.supply = s;
            this.price = price;
        }
        public SupplyInQuotation(int qid, Supply s, float price)
        {
            this.quotationid = qid;
            this.supply = s;
            this.price = price;
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
                    string insert = "INSERT INTO SupplyInQuotation (ID, QuotationID, SupplyID, Price, WarehouseID) VALUES (NULL, @qid, @sid, @price, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@qid", quotationid);
                    cmd.Parameters.AddWithValue("@sid", supply.ID);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@whid", GlobalVariable.Global.warehouseID);
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
        public bool Change()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string update = "UPDATE SupplyInQuotation SET QuotationID = @qid, SupplyID = @sid, Price = @price WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@qid", quotationid);
                    cmd.Parameters.AddWithValue("@sid", supply.ID);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@id", id);
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
        public static bool Remove(int qid)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM SupplyInQuotation WHERE QuotationID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", qid);
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

        public static List<SupplyInQuotation> GetAllSupplyInQuotationList()
        {
            MySqlConnection conn = null;
            List<SupplyInQuotation> sinList = new List<SupplyInQuotation>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
siq.ID, siq.WarehouseID, siq.QuotationID, siq.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.UserGroup, s.SupplyTypeID,
st.TypeName, siq.Price
FROM SupplyInQuotation siq
LEFT JOIN Supply s ON siq.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE siq.WarehouseID = @warehouseID";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@warehouseID", GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            int qid = Convert.ToInt32(reader["QuotationID"]);

                            int sid = Convert.ToInt32(reader["SupplyID"]);
                            string sname = reader["SupplyName"].ToString();
                            string sunit = reader["SupplyUnit"].ToString();
                            int moq = Convert.ToInt32(reader["MOQ"]);
                            bool isactive = Convert.ToBoolean(reader["IsActive"]);
                            string sphoto = reader["SupplyPhoto"].ToString();
                            string userg = reader["UserGroup"].ToString();

                            int stid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stname = reader["TypeName"].ToString();
                            SupplyType st = new SupplyType(stid, stname,GlobalVariable.Global.warehouseID);

                            Supply s = new Supply(sid,sname,sunit,moq,isactive,st,GlobalVariable.Global.warehouseID, userg, sphoto);

                            float price = Convert.ToSingle(reader["Price"]);
                            SupplyInQuotation siq = new SupplyInQuotation(id,qid,s,price);

                            sinList.Add(siq);
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
            return sinList;
        }
        public static List<SupplyInQuotation> GetSupplyInQuotationList(int quotationID)
        {
            MySqlConnection conn = null;
            List<SupplyInQuotation> sinList = new List<SupplyInQuotation>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
siq.ID, siq.WarehouseID, siq.QuotationID, siq.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.UserGroup, s.SupplyTypeID,
st.TypeName, siq.Price
FROM SupplyInQuotation siq
LEFT JOIN Supply s ON siq.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE siq.QuotationID = @qid";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@qid", quotationID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            int qid = Convert.ToInt32(reader["QuotationID"]);

                            int sid = Convert.ToInt32(reader["SupplyID"]);
                            string sname = reader["SupplyName"].ToString();
                            string sunit = reader["SupplyUnit"].ToString();
                            int moq = Convert.ToInt32(reader["MOQ"]);
                            bool isactive = Convert.ToBoolean(reader["IsActive"]);
                            string sphoto = reader["SupplyPhoto"].ToString();
                            string userg = reader["UserGroup"].ToString();

                            int stid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stname = reader["TypeName"].ToString();
                            SupplyType st = new SupplyType(stid, stname, GlobalVariable.Global.warehouseID);

                            Supply s = new Supply(sid, sname, sunit, moq, isactive, st, GlobalVariable.Global.warehouseID, userg, sphoto);

                            float price = Convert.ToSingle(reader["Price"]);
                            SupplyInQuotation siq = new SupplyInQuotation(id, qid, s, price);

                            sinList.Add(siq);
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
            return sinList;
        }
    }
}
