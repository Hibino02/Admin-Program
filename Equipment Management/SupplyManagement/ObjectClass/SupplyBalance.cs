using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class SupplyBalance
    {
        int id;
        public int ID { get { return id; } }
        Supply supply;
        public Supply Supply { get { return supply; }set { supply = value; } }
        int balance;
        public int Balance { get { return balance; }set { balance = value; } }
        DateTime updatedate;
        public DateTime UpdateDate { get { return updatedate; }set { updatedate = value; } }
        string updater;
        public string Updater { get { return updater; } set { updater = value; } }
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
sb.ID AS SupplyBalanceID, sb.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.UserGroup,
s.SupplyTypeID, st.TypeName, sb.Balance, sb.UpdateDate, sb.Updater
FROM SupplyBalance sb
LEFT JOIN Supply s ON sb.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE sb.ID = @id;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["SupplyBalanceID"]);
                            int sid = Convert.ToInt32(reader["SupplyID"]);
                            string sname = reader["SupplyName"].ToString();
                            string sunit = reader["SupplyUnit"].ToString();
                            int moq = Convert.ToInt32(reader["MOQ"]);
                            bool isactive = Convert.ToBoolean(reader["IsActive"]);
                            string sphoto = reader["SupplyPhoto"].ToString();
                            string userg = reader["UserGroup"].ToString();

                            int stid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stname = reader["TypeName"].ToString();
                            SupplyType st = new SupplyType(stid,stname,GlobalVariable.Global.warehouseID);

                            supply = new Supply(sid,sname,sunit,moq,isactive,st,GlobalVariable.Global.warehouseID, userg, sphoto);

                            balance = Convert.ToInt32(reader["Balance"]);
                            updatedate = Convert.ToDateTime(reader["UpdateDate"]);
                            updater = reader["Updater"].ToString();
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
        void UpdateAttributeBySupplyID(string value)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string select = @"SELECT
sb.ID AS SupplyBalanceID, sb.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.UserGroup,
s.SupplyTypeID, st.TypeName, sb.Balance, sb.UpdateDate, sb.Updater
FROM SupplyBalance sb
LEFT JOIN Supply s ON sb.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE sb.ID = (
    SELECT MAX(ID) 
    FROM SupplyBalance 
    WHERE SupplyID = @supplyid
);";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@supplyid", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["SupplyBalanceID"]);
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

                            supply = new Supply(sid, sname, sunit, moq, isactive, st, GlobalVariable.Global.warehouseID, userg, sphoto);

                            balance = Convert.ToInt32(reader["Balance"]);
                            updatedate = Convert.ToDateTime(reader["UpdateDate"]);
                            updater = reader["Updater"].ToString();
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

        public SupplyBalance(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public SupplyBalance(string sid)
        {
            UpdateAttributeBySupplyID(sid);
        }
        public SupplyBalance(int id, Supply supply, int balance, DateTime updatedate, string updater)
        {
            this.id = id;
            this.supply = supply;
            this.balance = balance;
            this.updatedate = updatedate;
            this.updater = updater;
        }
        public SupplyBalance(Supply supply, int balance, DateTime updatedate, string updater, int whid)
        {
            this.supply = supply;
            this.balance = balance;
            this.updatedate = updatedate;
            this.updater = updater;
            this.warehouseID = whid;
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
                    string insert = "INSERT INTO SupplyBalance (ID, SupplyID, Balance, UpdateDate, Updater, WarehouseID) VALUES (NULL, @supplyid, @balance, @updatedate, @updater, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@supplyid", supply.ID);
                    cmd.Parameters.AddWithValue("@balance", balance);
                    cmd.Parameters.AddWithValue("@updatedate", updatedate);
                    cmd.Parameters.AddWithValue("@updater", updater);
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
                    string update = "UPDATE SupplyBalance SET SupplyID = @supplyid, Balance = @balance, UpdateDate = @updatedate, Updater = @updater WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@supplyid", supply.ID);
                    cmd.Parameters.AddWithValue("@balance", balance);
                    cmd.Parameters.AddWithValue("@updatedate", updatedate);
                    cmd.Parameters.AddWithValue("@updater", updater);
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
        public static bool Remove(int sid)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM SupplyBalance WHERE SupplyID = @sid";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@sid", sid);
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

        public static List<SupplyBalance> GetAllSupplyBalanceList()
        {
            MySqlConnection conn = null;
            List<SupplyBalance> sbList = new List<SupplyBalance>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
sb.ID AS SupplyBalanceID, sb.WarehouseID, sb.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto,
s.SupplyTypeID, s.UserGroup, st.TypeName, sb.Balance, sb.UpdateDate, sb.Updater
FROM SupplyBalance sb
LEFT JOIN Supply s ON sb.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE sb.WarehouseID = @whid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid", GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int sbid = Convert.ToInt32(reader["SupplyBalanceID"]);

                            int sid = Convert.ToInt32(reader["SupplyID"]);
                            string sname = reader["SupplyName"].ToString();
                            string sunit = reader["SupplyUnit"].ToString();
                            int moq = Convert.ToInt32(reader["MOQ"]);
                            bool isactive = Convert.ToBoolean(reader["IsActive"]);
                            string sphoto = reader["SupplyPhoto"].ToString();
                            string userG = reader["UserGroup"].ToString();

                            int stid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stn = reader["TypeName"].ToString();
                            SupplyType st = new SupplyType(stid,stn,GlobalVariable.Global.warehouseID);

                            Supply s = new Supply(sid, sname, sunit, moq, isactive, st, GlobalVariable.Global.warehouseID, userG, sphoto);

                            int b = Convert.ToInt32(reader["Balance"]);
                            DateTime ud = Convert.ToDateTime(reader["UpdateDate"]);
                            string udt = reader["Updater"].ToString();

                            SupplyBalance sb = new SupplyBalance(sbid,s,b,ud,udt);
                            sbList.Add(sb);
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
            return sbList;
        }
    }
}
