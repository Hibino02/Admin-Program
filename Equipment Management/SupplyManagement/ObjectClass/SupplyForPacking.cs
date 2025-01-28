using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class SupplyForPacking
    {
        int id;
        public int ID { get { return id; } }
        DateTime packdate;
        public DateTime PackDate { get { return packdate; }set { packdate = value; } }
        string invnum;
        public string InvNum { get { return invnum; }set { invnum = value; } }
        string details;
        public string Details { get { return details; }set { details = value; } }

        static string connstr = Settings.Default.CONNECTION_STRING_SUPPLY;

        public SupplyForPacking( DateTime pdate, string inv, string details)
        {
            this.packdate = pdate;
            this.invnum = inv;
            this.details = details;
        }
        public SupplyForPacking(int id, DateTime pdate, string inv, string details)
        {
            this.id = id;
            this.packdate = pdate;
            this.invnum = inv;
            this.details = details;
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
                    string insert = "INSERT INTO SupplyForPacking (ID, PackDate, InvNum, Details) VALUES (NULL, @pdate, @inv, @details)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@pdate", packdate);
                    cmd.Parameters.AddWithValue("@inv", invnum);
                    cmd.Parameters.AddWithValue("@details", details);
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

        public static List<SupplyForPacking> GetAllSupplyForPacking()
        {
            MySqlConnection conn = null;
            List<SupplyForPacking> sfpList = new List<SupplyForPacking>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM SupplyForPacking;";
                    cmd.CommandText = selectAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            DateTime date = Convert.ToDateTime(reader["PackDate"]);
                            string inv = reader["InvNum"].ToString();
                            string details = reader["Details"].ToString();

                            SupplyForPacking sfp = new SupplyForPacking(id,date,inv,details);
                            sfpList.Add(sfp);
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
            return sfpList;
        }

    }
}
