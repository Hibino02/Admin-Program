using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class DeliveryPlan
    {
        int id;
        public int ID { get { return id; } }
        string planname;
        public string PlanName { get { return planname; } set { planname = value; } }
        DeliveryMonth _month;
        public DeliveryMonth _Month { get { return _month; } set { _month = value; } }

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
dp.ID AS DeliveryPlanID, dp.PlanName, dp.MonthID, m.MonthName
FROM DeliveryPlan dp
LEFT JOIN Month m ON dp.MonthID = m.ID
WHERE dp.ID = @id;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using(var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["DeliveryPlanID"]);
                            planname = reader["PlanName"].ToString();
                            int mid = Convert.ToInt32(reader["MonthID"]);
                            string mname = reader["MonthName"].ToString();
                            _month = new DeliveryMonth(mid, mname);
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

        public DeliveryPlan(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public DeliveryPlan(int id, string planname, DeliveryMonth dm)
        {
            this.id = id;
            this.planname = planname;
            this._month = dm;
        }
        public DeliveryPlan(string planname, DeliveryMonth dm)
        {
            this.planname = planname;
            this._month = dm;
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
                    string insert = "INSERT INTO DeliveryPlan (ID, PlanName, MonthID) VALUES (NULL, @planname, @monthid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@planname", planname);
                    cmd.Parameters.AddWithValue("@monthid", _month.ID);
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
                    string update = "UPDATE DeliveryPlan SET PlanName = @planname, MonthID = @monthid WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@planname",planname);
                    cmd.Parameters.AddWithValue("@monthid",_month.ID);
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
                    string delete = "DELETE FROM DeliveryPlan WHERE ID = @id";
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

        public static List<DeliveryPlan> GetAllDeliveryPlanList()
        {
            MySqlConnection conn = null;
            List<DeliveryPlan> dpList = new List<DeliveryPlan>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
dp.ID AS DeliveryPlanID, dp.PlanName, dp.MonthID, m.MonthName
FROM DeliveryPlan dp
LEFT JOIN Month m ON dp.MonthID = m.ID;";
                    cmd.CommandText = selectAll;
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["DeliveryPlanID"]);
                            string planname = reader["PlanName"].ToString();
                            int mid = Convert.ToInt32(reader["MonthID"]);
                            string mname = reader["MonthName"].ToString();
                            DeliveryMonth dm = new DeliveryMonth(mid,mname);

                            DeliveryPlan dp = new DeliveryPlan(id,planname,dm);
                            dpList.Add(dp);
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
            return dpList;
        }
    }
}
