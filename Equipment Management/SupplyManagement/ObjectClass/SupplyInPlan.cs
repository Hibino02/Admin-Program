using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class SupplyInPlan
    {
        int id;
        public int ID { get { return id; } }
        Supply supply;
        public Supply Supply { get { return supply; }set { supply = value; } }
        int reqw1;
        public int ReqW1 { get { return reqw1; }set { reqw1 = value; } }
        int reqw2;
        public int ReqW2 { get { return reqw2; }set { reqw2 = value; } }
        int reqw3;
        public int ReqW3 { get { return reqw3; }set { reqw3 = value; } }
        int reqw4;
        public int ReqW4 { get { return reqw4; }set { reqw4 = value; } }
        int planID;
        public int PlanID { get { return planID; }set { planID = value; } }
        DateTime? datew1;
        public DateTime? DateW1 { get { return datew1; }set { datew1 = value; } }
        DateTime? datew2;
        public DateTime? DateW2 { get { return datew2; }set { datew2 = value; } }
        DateTime? datew3;
        public DateTime? DateW3 { get { return datew3; }set { datew3 = value; } }
        DateTime? datew4;
        public DateTime? DateW4 { get { return datew4; }set { datew4 = value; } }

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
sip.ID, sip.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.SupplyTypeID, s.UserGroup,
st.TypeName, sip.ReqW1, sip.ReqW2, sip.ReqW3, sip.Reqw4, sip.PlanID,
sip.DateW1, sip.DateW2, sip.DateW3, sip.DateW4
FROM SupplyInPlan sip
LEFT JOIN Supply s ON sip.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE sip.ID = @id;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            //Supply
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

                            reqw1 = Convert.ToInt32(reader["ReqW1"]);
                            reqw2 = Convert.ToInt32(reader["ReqW2"]);
                            reqw3 = Convert.ToInt32(reader["ReqW3"]);
                            reqw4 = Convert.ToInt32(reader["ReqW4"]);
                            planID = Convert.ToInt32(reader["PlanID"]);

                            datew1 = reader["DateW1"] != DBNull.Value ? Convert.ToDateTime(reader["DateW1"]) : (DateTime?)null;
                            datew2 = reader["DateW2"] != DBNull.Value ? Convert.ToDateTime(reader["DateW2"]) : (DateTime?)null;
                            datew3 = reader["DateW3"] != DBNull.Value ? Convert.ToDateTime(reader["DateW3"]) : (DateTime?)null;
                            datew4 = reader["DateW4"] != DBNull.Value ? Convert.ToDateTime(reader["DateW4"]) : (DateTime?)null;
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

        public SupplyInPlan(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public SupplyInPlan(int id, Supply supply, int reqw1, int reqw2, int reqw3, int reqw4, int pid, DateTime? datew1, DateTime? datew2, DateTime? datew3, DateTime? datew4)
        {
            this.id = id;
            this.supply = supply;
            this.reqw1 = reqw1;
            this.reqw2 = reqw2;
            this.reqw3 = reqw3;
            this.reqw4 = reqw4;
            this.planID = pid;
            this.datew1 = datew1;
            this.datew2 = datew2;
            this.datew3 = datew3;
            this.datew4 = datew4;
        }
        public SupplyInPlan(Supply supply, int reqw1, int reqw2, int reqw3, int reqw4, int pid, DateTime? datew1, DateTime? datew2, DateTime? datew3, DateTime? datew4)
        {
            this.supply = supply;
            this.reqw1 = reqw1;
            this.reqw2 = reqw2;
            this.reqw3 = reqw3;
            this.reqw4 = reqw4;
            this.planID = pid;
            this.datew1 = datew1;
            this.datew2 = datew2;
            this.datew3 = datew3;
            this.datew4 = datew4;
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
                    string insert = "INSERT INTO SupplyInPlan (ID, SupplyID, ReqW1, ReqW2, ReqW3, ReqW4, WarehouseID, PlanID, DateW1, DateW2, DateW3, DateW4) VALUES (NULL, @sid, @w1, @w2, @w3, @w4, @whid, @pid, @dw1, @dw2, @dw3, @dw4)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@sid", supply.ID);
                    cmd.Parameters.AddWithValue("@w1", reqw1);
                    cmd.Parameters.AddWithValue("@w2", reqw2);
                    cmd.Parameters.AddWithValue("@w3", reqw3);
                    cmd.Parameters.AddWithValue("@w4", reqw4);
                    cmd.Parameters.AddWithValue("@whid", GlobalVariable.Global.warehouseID);
                    cmd.Parameters.AddWithValue("@pid", planID);
                    cmd.Parameters.AddWithValue("@dw1", datew1);
                    cmd.Parameters.AddWithValue("@dw2", datew2);
                    cmd.Parameters.AddWithValue("@dw3", datew3);
                    cmd.Parameters.AddWithValue("@dw4", datew4);
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
                    string update = "UPDATE SupplyInPlan SET SupplyID = @sid, ReqW1 = @w1, ReqW2 = @w2, ReqW3 = @w3, ReqW4 = @w4 , DateW1 = @dw1, DateW2 = @dw2, DateW3 = @dw3, DateW4 = @dw4 WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@sid", supply.ID);
                    cmd.Parameters.AddWithValue("@w1", reqw1);
                    cmd.Parameters.AddWithValue("@w2", reqw2);
                    cmd.Parameters.AddWithValue("@w3", reqw3);
                    cmd.Parameters.AddWithValue("@w4", reqw4);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@dw1", datew1);
                    cmd.Parameters.AddWithValue("@dw2", datew2);
                    cmd.Parameters.AddWithValue("@dw3", datew3);
                    cmd.Parameters.AddWithValue("@dw4", datew4);
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
        public static bool Remove(int pid)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM SupplyInPlan WHERE PlanID = @pid";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@pid", pid);
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
        public static bool RemoveBySupplyID(int sid)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM SupplyInPlan WHERE SupplyID = @sid";
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

        public static List<SupplyInPlan> GetAllSupplyInPlanList()
        {
            MySqlConnection conn = null;
            List<SupplyInPlan> sipList = new List<SupplyInPlan>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd= conn.CreateCommand())
                {
                    string selectAll = @"SELECT
sip.ID, sip.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.SupplyTypeID, s.UserGroup,
st.TypeName, sip.ReqW1, sip.ReqW2, sip.ReqW3, sip.Reqw4, sip.PlanID,
sip.DateW1, sip.DateW2, sip.DateW3, sip.DateW4
FROM SupplyInPlan sip
LEFT JOIN Supply s ON sip.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE sip.WarehouseID = @whid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid", GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            //Supply
                            int supid = Convert.ToInt32(reader["SupplyID"]);
                            string sname = reader["SupplyName"].ToString();
                            string sunit = reader["SupplyUnit"].ToString();
                            int moq = Convert.ToInt32(reader["MOQ"]);
                            bool isactive = Convert.ToBoolean(reader["IsActive"]);
                            string sphoto = reader["SupplyPhoto"].ToString();
                            string userg = reader["UserGroup"].ToString();

                            int stypeid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stypename = reader["TypeName"].ToString();
                            SupplyType stype = new SupplyType(stypeid, stypename,GlobalVariable.Global.warehouseID);
                            Supply supply = new Supply(supid, sname, sunit, moq, isactive, stype,GlobalVariable.Global.warehouseID, userg, sphoto);

                            int reqw1 = Convert.ToInt32(reader["ReqW1"]);
                            int reqw2 = Convert.ToInt32(reader["ReqW2"]);
                            int reqw3 = Convert.ToInt32(reader["ReqW3"]);
                            int reqw4 = Convert.ToInt32(reader["ReqW4"]);
                            int planID = Convert.ToInt32(reader["PlanID"]);

                            DateTime? datew1 = reader["DateW1"] != DBNull.Value ? Convert.ToDateTime(reader["DateW1"]) : (DateTime?)null;
                            DateTime? datew2 = reader["DateW2"] != DBNull.Value ? Convert.ToDateTime(reader["DateW2"]) : (DateTime?)null;
                            DateTime? datew3 = reader["DateW3"] != DBNull.Value ? Convert.ToDateTime(reader["DateW3"]) : (DateTime?)null;
                            DateTime? datew4 = reader["DateW4"] != DBNull.Value ? Convert.ToDateTime(reader["DateW4"]) : (DateTime?)null;

                            SupplyInPlan sip = new SupplyInPlan(id,supply,reqw1,reqw2,reqw3,reqw4,planID,datew1,datew2,datew3,datew4);
                            sipList.Add(sip);
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
            return sipList;
        }
        public static List<SupplyInPlan> GetAllSupplyInPlanByPlanID(int pid)
        {
            MySqlConnection conn = null;
            List<SupplyInPlan> sipList = new List<SupplyInPlan>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
sip.ID, sip.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.SupplyTypeID, s.UserGroup,
st.TypeName, sip.ReqW1, sip.ReqW2, sip.ReqW3, sip.Reqw4, sip.PlanID,
sip.DateW1, sip.DateW2, sip.DateW3, sip.DateW4
FROM SupplyInPlan sip
LEFT JOIN Supply s ON sip.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE sip.PlanID = @pid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@pid", pid);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            //Supply
                            int supid = Convert.ToInt32(reader["SupplyID"]);
                            string sname = reader["SupplyName"].ToString();
                            string sunit = reader["SupplyUnit"].ToString();
                            int moq = Convert.ToInt32(reader["MOQ"]);
                            bool isactive = Convert.ToBoolean(reader["IsActive"]);
                            string sphoto = reader["SupplyPhoto"].ToString();
                            string userg = reader["UserGroup"].ToString();

                            int stypeid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stypename = reader["TypeName"].ToString();
                            SupplyType stype = new SupplyType(stypeid, stypename, GlobalVariable.Global.warehouseID);
                            Supply supply = new Supply(supid, sname, sunit, moq, isactive, stype, GlobalVariable.Global.warehouseID, userg, sphoto);

                            int reqw1 = Convert.ToInt32(reader["ReqW1"]);
                            int reqw2 = Convert.ToInt32(reader["ReqW2"]);
                            int reqw3 = Convert.ToInt32(reader["ReqW3"]);
                            int reqw4 = Convert.ToInt32(reader["ReqW4"]);
                            int planID = Convert.ToInt32(reader["PlanID"]);

                            DateTime? datew1 = reader["DateW1"] != DBNull.Value ? Convert.ToDateTime(reader["DateW1"]) : (DateTime?)null;
                            DateTime? datew2 = reader["DateW2"] != DBNull.Value ? Convert.ToDateTime(reader["DateW2"]) : (DateTime?)null;
                            DateTime? datew3 = reader["DateW3"] != DBNull.Value ? Convert.ToDateTime(reader["DateW3"]) : (DateTime?)null;
                            DateTime? datew4 = reader["DateW4"] != DBNull.Value ? Convert.ToDateTime(reader["DateW4"]) : (DateTime?)null;

                            SupplyInPlan sip = new SupplyInPlan(id, supply, reqw1, reqw2, reqw3, reqw4, planID, datew1, datew2, datew3, datew4);
                            sipList.Add(sip);
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
            return sipList;
        }
    }
}
