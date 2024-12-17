using Admin_Program.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

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
        private static List<User> userlist = new List<User>();

        static string connstr = Settings.Default.CONNECTION_STRING_SUPPLY;

        public User()
        {
            User.GetAllUserList();
        }
        private User(int id,string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
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
                            User u = new User(id, username, password);
                            userlist.Add(u);
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
            return userlist;
        }
        public static bool IsUserAvailable(string user)
        {
            bool userA = false;
            foreach(User u in userlist)
            {
                if(user == u.UserName)
                {
                    userA = true;
                }
            }
            return userA;
        }
        public static bool IsPasswordCorrect(string pass)
        {
            bool passC = false;
            foreach(User u in userlist)
            {
                if(pass == u.Password)
                {
                    passC = true;
                }
            }
            return passC;
        }
    }
}
