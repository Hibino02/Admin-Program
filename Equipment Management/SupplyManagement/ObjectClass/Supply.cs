using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class Supply
    {
        int id;
        public int ID { get { return id; } }
        string supplyname;
        public string SupplyName { get { return supplyname; }set { supplyname = value; } }
        string supplyunit;
        public string SupplyUnit { get { return supplyunit; }set { supplyunit = value; } }
        int moq;
        public int MOQ { get { return moq; }set { moq = value; } }
        bool isactive;
        public bool IsActive { get { return isactive; }set { isactive = value; } }
        string supplyphoto;
        public string SupplyPhoto { get { return supplyphoto; }set { supplyphoto = value; } }
        SupplyType supplytype;
        public SupplyType SupplyType {get{ return supplytype; }set { supplytype = value; } }
        int warehouseID;
        public int WarehouseID { get { return warehouseID; }set { warehouseID = value; } }

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
s.ID AS SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.SupplyTypeID, s.WarehouseID,
st.TypeName, st.WarehouseID AS STWHID
FROM Supply s
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE s.ID = @id;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["SupplyID"]);
                            supplyname = reader["SupplyName"].ToString();
                            supplyunit = reader["SupplyUnit"].ToString();
                            moq = Convert.ToInt32(reader["MOQ"]);
                            isactive = Convert.ToBoolean(reader["IsActive"]);
                            supplyphoto = reader["SupplyPhoto"].ToString();
                            warehouseID = Convert.ToInt32(reader["WarehouseID"]);

                            int stid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stname = reader["TypeName"].ToString();
                            int whid = Convert.ToInt32(reader["STWHID"]);
                            supplytype = new SupplyType(stid,stname,whid);

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

        public Supply(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public Supply(int id,string supplyname,string supplyunit,int moq,bool isactive, SupplyType st,int whid, string supplyphoto = null)
        {
            this.id = id;
            this.supplyname = supplyname;
            this.supplyunit = supplyunit;
            this.moq = moq;
            this.isactive = isactive;
            this.supplyphoto = supplyphoto;
            this.supplytype = st;
            this.warehouseID = whid;
        }
        public Supply(string supplyname, string supplyunit, int moq, bool isactive, SupplyType st,int whid, string supplyphoto = null)
        {
            this.supplyname = supplyname;
            this.supplyunit = supplyunit;
            this.moq = moq;
            this.isactive = isactive;
            this.supplyphoto = supplyphoto;
            this.supplytype = st;
            this.warehouseID = whid;
        }

        public bool Create()
        {
            MySqlConnection conn = null;
            MySqlTransaction transaction = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();

                transaction = conn.BeginTransaction();

                using (var cmd = conn.CreateCommand())
                {
                    string insert = "INSERT INTO Supply (ID, SupplyName, SupplyUnit, MOQ, IsActive, SupplyPhoto, SupplyTypeID, WarehouseID) VALUES (NULL, @supplyname, @supplyunit, @moq, @isactive, @supplyphoto, @supplytypeid, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@supplyname", supplyname);
                    cmd.Parameters.AddWithValue("@supplyunit", supplyunit);
                    cmd.Parameters.AddWithValue("@moq", moq);
                    cmd.Parameters.AddWithValue("@isactive", isactive);
                    cmd.Parameters.AddWithValue("@supplyphoto", supplyphoto);
                    cmd.Parameters.AddWithValue("@supplytypeid", supplytype.ID);
                    cmd.Parameters.AddWithValue("@whid", warehouseID);
                    cmd.ExecuteNonQuery();

                    //Retrieve last inserted ID in this transaction
                    cmd.CommandText = "SELECT LAST_INSERT_ID();";
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                       id = Convert.ToInt32(result);
                    }
                    // Commit the transaction
                    transaction.Commit();
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
                    string update = "UPDATE Supply SET SupplyName = @supplyname, SupplyUnit = @supplyunit, MOQ = @moq, IsActive = @isactive, SupplyPhoto = @supplyphoto, SupplyTypeID = @supplytypeid WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@supplyname", supplyname);
                    cmd.Parameters.AddWithValue("@supplyunit", supplyunit);
                    cmd.Parameters.AddWithValue("@moq", moq);
                    cmd.Parameters.AddWithValue("@isactive", isactive);
                    cmd.Parameters.AddWithValue("@supplyphoto", supplyphoto);
                    cmd.Parameters.AddWithValue("@supplytypeid", supplytype.ID);
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
        public bool Remove()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM Supply WHERE ID = @id";
                    cmd.CommandText = delete;
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

        public static List<Supply> GetAllSupplyList()
        {
            MySqlConnection conn = null;
            List<Supply> spList = new List<Supply>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
s.ID AS SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.SupplyTypeID, s.WarehouseID,
st.TypeName, st.WarehouseID AS STWHID
FROM Supply s
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE s.WarehouseID = @whid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid", GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["SupplyID"]);
                            string supplyname = reader["SupplyName"].ToString();
                            string supplyunit = reader["SupplyUnit"].ToString();
                            int moq = Convert.ToInt32(reader["MOQ"]);
                            bool isactive = Convert.ToBoolean(reader["IsActive"]);
                            string supplyphoto = reader["SupplyPhoto"].ToString();
                            int whid = Convert.ToInt32(reader["WarehouseID"]);

                            int supplytypeid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string supplytypename = reader["TypeName"].ToString();
                            int stwhid = Convert.ToInt32(reader["STWHID"]);
                            SupplyType st = new SupplyType(supplytypeid, supplytypename, stwhid);

                            Supply s = new Supply(id,supplyname,supplyunit,moq,isactive,st,whid,supplyphoto);
                            spList.Add(s);
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
            return spList;
        }
    }
}
