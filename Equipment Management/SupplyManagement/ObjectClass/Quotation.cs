using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class Quotation
    {
        int id;
        public int ID { get { return id; } }
        Supplier supplier;
        public Supplier Supplier { get { return supplier; }set { supplier = value; } }
        string quotationnumber;
        public string QuotationNumber { get { return quotationnumber; }set { quotationnumber = value; } }
        DateTime issuedate;
        public DateTime IssueDate { get { return issuedate; }set { issuedate = value; } }
        DateTime? validdate;
        public DateTime? ValidDate { get { return validdate; }set { validdate = value; } }
        bool hasvaliddate;
        public bool HasValidDate { get { return hasvaliddate; }set { hasvaliddate = value; } }
        string quotationpdf;
        public string QuotationPDF { get { return quotationpdf; }set { quotationpdf = value; } }
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
q.ID AS QuotationID, q.SupplierID, s.SupplierName, s.SupplierAddress, s.WarehouseID AS SWHID, q.QuotationNumber, q.IssueDate, q.ValidDate,
q.HasValidDate, q.QuotationPDF, q.WarehouseID
FROM Quotation q
LEFT JOIN Supplier s ON q.SupplierID = s.ID
WHERE q.ID = @id;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["QuotationID"]);

                            int sid = Convert.ToInt32(reader["SupplierID"]);
                            string sname = reader["SupplierName"].ToString();
                            string saddress = reader["SupplierAddress"].ToString();
                            int swhid = Convert.ToInt32(reader["SWHID"]);
                            supplier = new Supplier(sid, sname, saddress, swhid);

                            quotationnumber = reader["QuotationNumber"].ToString();
                            issuedate = Convert.ToDateTime(reader["IssueDate"]);
                            validdate = reader["ValidDate"] != DBNull.Value ? Convert.ToDateTime(reader["ValidDate"]) : (DateTime?)null;
                            hasvaliddate = Convert.ToBoolean(reader["HasValidDate"]);
                            quotationpdf = reader["QuotationPDF"].ToString();
                            warehouseID = Convert.ToInt32(reader["WarehouseID"]);
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

        public Quotation(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public Quotation(int id,int whid, Supplier supplier, string qnumber, DateTime issuedate, bool hasvdate, string qpdf
            , DateTime? vdate = null)
        {
            this.id = id;
            this.warehouseID = whid;
            this.supplier = supplier;
            this.quotationnumber = qnumber;
            this.issuedate = issuedate;
            this.hasvaliddate = hasvdate;
            this.quotationpdf = qpdf;
            this.validdate = vdate;
        }
        public Quotation(int whid,Supplier supplier, string qnumber, DateTime issuedate, bool hasvdate, string qpdf
            , DateTime? vdate = null)
        {
            this.warehouseID = whid;
            this.supplier = supplier;
            this.quotationnumber = qnumber;
            this.issuedate = issuedate;
            this.hasvaliddate = hasvdate;
            this.quotationpdf = qpdf;
            this.validdate = vdate;
        }

        public bool Create()
        {
            MySqlConnection conn = null;
            MySqlTransaction transaction = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();

                transaction = conn.BeginTransaction();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.Transaction = transaction;

                    string insert = "INSERT INTO Quotation (ID, SupplierID, QuotationNumber, IssueDate, ValidDate, HasValidDate, QuotationPDF, WarehouseID) VALUES (NULL, @supplierid, @quotationnumber, @issuedate, @validdate, @hasvaliddate, @quotationpdf, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@supplierid", supplier.ID);
                    cmd.Parameters.AddWithValue("@quotationnumber", quotationnumber);
                    cmd.Parameters.AddWithValue("@issuedate", issuedate);
                    if (validdate == null)
                    {
                        cmd.Parameters.AddWithValue("@validdate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@validdate", validdate);
                    }
                    cmd.Parameters.AddWithValue("@hasvaliddate", hasvaliddate);
                    cmd.Parameters.AddWithValue("@quotationpdf", quotationpdf);
                    cmd.Parameters.AddWithValue("@whid",warehouseID);
                    cmd.ExecuteNonQuery();

                    //Retrieve last inserted ID in this transaction
                    cmd.CommandText = "SELECT LAST_INSERT_ID();";
                    object result = cmd.ExecuteScalar();
                    if(result != null)
                    {
                        GlobalVariable.Global.ID = -1;
                        GlobalVariable.Global.ID = Convert.ToInt32(result);
                    }
                    // Commit the transaction
                    transaction.Commit();
                }
                return true;
            }
            catch (MySqlException e)
            {
                // Rollback the transaction in case of error
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                // Log the error
                Console.WriteLine("MySQL Error: " + e.Message);
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
                    string update = "UPDATE Quotation SET SupplierID = @supid, QuotationNumber = @qnum, IssueDate = @issuedate, ValidDate = @vdate, HasValidDate = @hasvdate, QuotationPDF = @qpdf WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@supid", supplier.ID);
                    cmd.Parameters.AddWithValue("@qnum", quotationnumber);
                    cmd.Parameters.AddWithValue("@issuedate", issuedate);
                    if(validdate == null)
                    {
                        cmd.Parameters.AddWithValue("@vdate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@vdate", validdate);
                    }
                    cmd.Parameters.AddWithValue("@hasvdate", hasvaliddate);
                    cmd.Parameters.AddWithValue("@qpdf", quotationpdf);
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
                    string delete = "DELETE FROM Quotation WHERE ID = @id";
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

        public static List<Quotation> GetAllQuotationList()
        {
            MySqlConnection conn = null;
            List<Quotation> qList = new List<Quotation>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
q.ID AS QuotationID, q.SupplierID, s.SupplierName, s.SupplierAddress, s.WarehouseID AS SWHID, q.QuotationNumber, q.IssueDate, q.ValidDate,
q.HasValidDate, q.QuotationPDF, q.WarehouseID
FROM Quotation q
LEFT JOIN Supplier s ON q.SupplierID = s.ID
WHERE q.WarehouseID = @whid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid",GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["QuotationID"]);

                            int sid = Convert.ToInt32(reader["SupplierID"]);
                            string sname = reader["SupplierName"].ToString();
                            string saddress = reader["SupplierAddress"].ToString();
                            int whid = Convert.ToInt32(reader["SWHID"]);
                            Supplier s = new Supplier(sid, sname, saddress, whid);

                            string qnum = reader["QuotationNumber"].ToString();
                            DateTime issuedate = Convert.ToDateTime(reader["IssueDate"]);
                            DateTime? vdate = reader["ValidDate"] != DBNull.Value ? Convert.ToDateTime(reader["ValidDate"]) : (DateTime?)null;
                            bool hasvdate = Convert.ToBoolean(reader["HasValidDate"]);
                            string qpdf = reader["QuotationPDF"].ToString();
                            int warehouseid = Convert.ToInt32(reader["WarehouseID"]);

                            Quotation q = new Quotation(id, warehouseid, s, qnum, issuedate, hasvdate, qpdf, vdate);
                            qList.Add(q);
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
            return qList;
        }
    }
}
