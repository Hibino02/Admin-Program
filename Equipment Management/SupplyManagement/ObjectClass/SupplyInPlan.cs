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
sip.ID, sip.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.SupplyTypeID,
st.TypeName, sip.ReqW1, sip.ReqW2, sip.ReqW3, sip.Reqw4
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

                            int stypeid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stypename = reader["TypeName"].ToString();
                            SupplyType stype = new SupplyType(stypeid,stypename);
                            supply = new Supply(supid,sname,sunit,moq,isactive,stype,sphoto);

                            reqw1 = Convert.ToInt32(reader["ReqW1"]);
                            reqw2 = Convert.ToInt32(reader["ReqW2"]);
                            reqw3 = Convert.ToInt32(reader["ReqW3"]);
                            reqw4 = Convert.ToInt32(reader["ReqW4"]);
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
        public SupplyInPlan(int id, Supply supply, int reqw1, int reqw2, int reqw3, int reqw4)
        {
            this.id = id;
            this.supply = supply;
            this.reqw1 = reqw1;
            this.reqw2 = reqw2;
            this.reqw3 = reqw3;
            this.reqw4 = reqw4;
        }
        public SupplyInPlan(Supply supply, int reqw1, int reqw2, int reqw3, int reqw4)
        {
            this.supply = supply;
            this.reqw1 = reqw1;
            this.reqw2 = reqw2;
            this.reqw3 = reqw3;
            this.reqw4 = reqw4;
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
                    string insert = "INSERT INTO SupplyInPlan (ID, SupplyID, ReqW1, ReqW2, ReqW3, ReqW4) VALUES (NULL, @sid, @w1, @w2, @w3, @w4)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@sid", supply.ID);
                    cmd.Parameters.AddWithValue("@w1", reqw1);
                    cmd.Parameters.AddWithValue("@w2", reqw2);
                    cmd.Parameters.AddWithValue("@w3", reqw3);
                    cmd.Parameters.AddWithValue("@w4", reqw4);
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
                    string update = "UPDATE SupplyInPlan SET SupplyID = @sid, ReqW1 = @w1, ReqW2 = @w2, ReqW3 = @w3, ReqW4 = @4 WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@sid", supply.ID);
                    cmd.Parameters.AddWithValue("@w1", reqw1);
                    cmd.Parameters.AddWithValue("@w2", reqw2);
                    cmd.Parameters.AddWithValue("@w3", reqw3);
                    cmd.Parameters.AddWithValue("@w4", reqw4);
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
                    string delete = "DELETE FROM SupplyInPlan WHERE ID = @id";
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
sip.ID, sip.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.SupplyTypeID,
st.TypeName, sip.ReqW1, sip.ReqW2, sip.ReqW3, sip.Reqw4
FROM SupplyInPlan sip
LEFT JOIN Supply s ON sip.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID";
                    cmd.CommandText = selectAll;
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

                            int stypeid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stypename = reader["TypeName"].ToString();
                            SupplyType stype = new SupplyType(stypeid, stypename);
                            Supply supply = new Supply(supid, sname, sunit, moq, isactive, stype, sphoto);

                            int reqw1 = Convert.ToInt32(reader["ReqW1"]);
                            int reqw2 = Convert.ToInt32(reader["ReqW2"]);
                            int reqw3 = Convert.ToInt32(reader["ReqW3"]);
                            int reqw4 = Convert.ToInt32(reader["ReqW4"]);

                            SupplyInPlan sip = new SupplyInPlan(id,supply,reqw1,reqw2,reqw3,reqw4);
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
