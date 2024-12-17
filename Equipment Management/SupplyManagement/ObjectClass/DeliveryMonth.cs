using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class DeliveryMonth
    {
        int id;
        public int ID { get { return id; } }
        string _month;
        public string _Month { get { return _month; } }

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
                    string select = "SELECT * FROM Month WHERE ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            _month = reader["MonthName"].ToString();
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

        public DeliveryMonth(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public DeliveryMonth(int id, string month)
        {
            this.id = id;
            this._month = month;
        }

        public static List<DeliveryMonth> getAllDeliveryMonthList()
        {
            MySqlConnection conn = null;
            List<DeliveryMonth> deliveryMonthList = new List<DeliveryMonth>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM Month";
                    cmd.CommandText = selectAll;
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string month = reader["MonthName"].ToString();
                            DeliveryMonth m = new DeliveryMonth(id,month);
                            deliveryMonthList.Add(m);
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
            return deliveryMonthList;
        }
    }
}
