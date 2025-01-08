using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class SupplyInPR
    {
        int id;
        public int ID { get { return id; } }
        int prid;
        public int PRID { get { return prid; } set { prid = value; } }
        Supply supply;
        public Supply Supply { get { return supply; } set { supply = value; } }
        float price;
        public float Price { get { return price; } set { price = value; } }
        int quantity;
        public int Quantity { get { return quantity; } set { quantity = value; } }
        float amount;
        public float Amount { get { return amount; } set { amount = value; } }
        string quotationPDF;
        public string QuotationPDF { get { return quotationPDF; } set { quotationPDF = value; } }
        string quotationNumber;
        public string QuotationNumber { get { return quotationNumber; } set { quotationNumber = value; } }

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
sipr.ID, sipr.PRID, sipr.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.SupplyTypeID,
st.TypeName, sipr.Price, sipr.Quantity, sipr.Amount, sipr.QuotationPDF, sipr.QuotationNumber
FROM SupplyInPR sipr
LEFT JOIN Supply s ON sipr.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE sipr.ID = @id;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            prid = Convert.ToInt32(reader["PRID"]);
                            //Supply
                            int sid = Convert.ToInt32(reader["SupplyID"]);
                            string sname = reader["SupplyName"].ToString();
                            string sunit = reader["SupplyUnit"].ToString();
                            int moq = Convert.ToInt32(reader["MOQ"]);
                            bool isactive = Convert.ToBoolean(reader["IsActive"]);
                            string sphoto = reader["SupplyPhoto"].ToString();
                            //SupplyType
                            int stid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stname = reader["TypeName"].ToString();
                            SupplyType st = new SupplyType(stid, stname, GlobalVariable.Global.warehouseID);

                            supply = new Supply(sid, sname, sunit, moq, isactive, st,GlobalVariable.Global.warehouseID,sphoto);

                            price = Convert.ToSingle(reader["Price"]);
                            quantity = Convert.ToInt32(reader["Quantity"]);
                            amount = Convert.ToSingle(reader["Amount"]);
                            quotationPDF = reader["QuotationPDF"].ToString();
                            quotationNumber = reader["QuotationNumber"].ToString();
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

        public SupplyInPR(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public SupplyInPR(int id, int prid, Supply supply, float price, int quantity, float amount, string quotationpdf, string quotationnum)
        {
            this.id = id;
            this.prid = prid;
            this.supply = supply;
            this.price = price;
            this.quantity = quantity;
            this.amount = amount;
            this.quotationPDF = quotationpdf;
            this.quotationNumber = quotationnum;
        }
        public SupplyInPR(int prid, Supply supply, float price, int quantity, float amount, string quotationpdf, string quotationnum)
        {
            this.prid = prid;
            this.supply = supply;
            this.price = price;
            this.quantity = quantity;
            this.amount = amount;
            this.quotationPDF = quotationpdf;
            this.quotationNumber = quotationnum;
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
                    string insert = "INSERT INTO SupplyInPR (ID, PRID, SupplyID, Price, Quantity, Amount, WarehouseID, QuotationPDF, QuotationNumber) VALUES (NULL, @prid, @sid, @price, @quantity, @amount, @whid, @qpdf, @qnum)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@prid", prid);
                    cmd.Parameters.AddWithValue("@sid", supply.ID);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@whid", GlobalVariable.Global.warehouseID);
                    cmd.Parameters.AddWithValue("@qpdf", quotationPDF);
                    cmd.Parameters.AddWithValue("@qnum", quotationNumber);
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
                    string update = "UPDATE SupplyInPR SET Quantity = @quantity, Amount = @amount WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@amount", amount);
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
        public bool Remove(int prid)
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string delete = "DELETE FROM SupplyInPR WHERE PRID = @pridid";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@pridid", prid);
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

        public static List<SupplyInPR> GetAllSupplyInPRList()
        {
            MySqlConnection conn = null;
            List<SupplyInPR> siprList = new List<SupplyInPR>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
sipr.ID, sipr.PRID, sipr.SupplyID, s.SupplyName, s.SupplyUnit, s.MOQ, s.IsActive, s.SupplyPhoto, s.SupplyTypeID,
st.TypeName, sipr.Price, sipr.Quantity, sipr.Amount, sipr.QuotationPDF, sipr.QuotationNumber
FROM SupplyInPR sipr
LEFT JOIN Supply s ON sipr.SupplyID = s.ID
LEFT JOIN SupplyType st ON s.SupplyTypeID = st.ID
WHERE sipr.WarehouseID = @whid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid", GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            int prid = Convert.ToInt32(reader["PRID"]);
                            //Supply
                            int sid = Convert.ToInt32(reader["SupplyID"]);
                            string sname = reader["SupplyName"].ToString();
                            string sunit = reader["SupplyUnit"].ToString();
                            int moq = Convert.ToInt32(reader["MOQ"]);
                            bool isactive = Convert.ToBoolean(reader["IsActive"]);
                            string sphoto = reader["SupplyPhoto"].ToString();
                            //SupplyType
                            int stid = Convert.ToInt32(reader["SupplyTypeID"]);
                            string stname = reader["TypeName"].ToString();
                            SupplyType st = new SupplyType(stid, stname,GlobalVariable.Global.warehouseID);

                            Supply supply = new Supply(sid, sname, sunit, moq, isactive, st,GlobalVariable.Global.warehouseID, sphoto);

                            float price = Convert.ToSingle(reader["Price"]);
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            float amount = Convert.ToSingle(reader["Amount"]);
                            string qPDF = reader["QuotationPDF"].ToString();
                            string qNum = reader["QuotationNumber"].ToString();

                            SupplyInPR sipr = new SupplyInPR(id,prid,supply,price,quantity,amount,qPDF,qNum);

                            siprList.Add(sipr);
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
            return siprList;
        }
    }
}
