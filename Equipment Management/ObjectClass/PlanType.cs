using Equipment_Management.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Equipment_Management.ObjectClass
{
    class PlanType
    {
        int id;
        public int ID { get { return id; } }
        string ptype;
        public string PType { get { return ptype; }set { ptype = value; } }

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
                    string select = "SELECT * FROM plantype WHERE ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            ptype = reader["PType"].ToString();
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

        public PlanType(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public PlanType(string ptype)
        {
            this.ptype = ptype;
        }
        public PlanType(int id, string ptype)
        {
            this.id = id;
            this.ptype = ptype;
        }

        public static List<PlanType> GetPlanTypeList()
        {
            MySqlConnection conn = null;
            List<PlanType> ptList = new List<PlanType>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM plantype";
                    cmd.CommandText = selectAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string acc = reader["Accquire"].ToString();
                            PlanType acq = new PlanType(id, acc);
                            ptList.Add(acq);
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
            return ptList;
        }
    }
}
