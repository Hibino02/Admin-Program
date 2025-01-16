using Admin_Program.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Admin_Program.GlobalVariable;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class User
    {
        int id;
        public int ID { get { return id; } }
        string username;
        public string UserName { get { return username; } }
        string password;
        public string Password { get { return password; } }
        int warehouseID;
        public int WarehouseID { get { return warehouseID; } }
        string userGroup;
        public string UserGroup { get { return userGroup; } }
        private static List<User> userList = new List<User>();

        static string connstr = Settings.Default.CONNECTION_STRING_SUPPLY;

        public User()
        {
            User.GetAllUserList();
        }
        private User(int id,string username, string password, int warehouseid, string userg)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.warehouseID = warehouseid;
            this.userGroup = userg;
        }

        private static List<User> GetAllUserList()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    string selectAll = "SELECT * FROM User";
                    cmd.CommandText = selectAll;
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string username = reader["UserName"].ToString();
                            string password = reader["Password"].ToString();
                            int whid = Convert.ToInt32(reader["WarehouseID"]);
                            string ug = reader["UserGroup"].ToString();
                            User u = new User(id, username, password, whid, ug);
                            userList.Add(u);
                        }
                    }
                }
            }
            catch(MySqlException e){ }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                    conn.Close();
            }
            return userList;
        }
        public static bool IsLoginSuccess(string user, string pass)
        {
            bool userA = false;
            foreach (User u in userList)
            {
                if (user == u.UserName && pass == u.Password)
                {
                    userA = true;
                    Global.warehouseID = u.warehouseID;
                    Global.userName = null;
                    Global.userName = u.UserName;
                    Global.userGroup = u.userGroup;
                    break;
                }
            }
            return userA;
        }
    }
}
