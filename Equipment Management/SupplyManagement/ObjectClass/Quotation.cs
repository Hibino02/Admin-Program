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
q.ID AS QuotationID, q.SupplierID, s.SupplierName, s.SupplierAddress, q.QuotationNumber, q.IssueDate, q.ValidDate,
q.HasValidDate, q.QuotationPDF
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
                            Supplier s = new Supplier(sid, sname, saddress);

                            quotationnumber = reader["QuotationNumber"].ToString();
                            issuedate = Convert.ToDateTime(reader["IssueDate"]);
                            validdate = reader["ValidDate"] != DBNull.Value ? Convert.ToDateTime(reader["ValidDate"]) : (DateTime?)null;
                            hasvaliddate = Convert.ToBoolean(reader["HasValidDate"]);
                            quotationpdf = reader["QuotationPDF"].ToString();
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
        public Quotation(int id, Supplier supplier, string qnumber, DateTime issuedate, bool hasvdate, string qpdf
            , DateTime? vdate = null)
        {
            this.id = id;
            this.supplier = supplier;
            this.quotationnumber = qnumber;
            this.issuedate = issuedate;
            this.hasvaliddate = hasvdate;
            this.quotationpdf = qpdf;
            this.validdate = vdate;
        }
        public Quotation(Supplier supplier, string qnumber, DateTime issuedate, bool hasvdate, string qpdf
            , DateTime? vdate = null)
        {
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
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string insert = "INSERT INTO Quotation (ID, SupplierID, QuotationNumber, IssueDate, ValidDate, HasValidDate, QuotationPDF) VALUES (NULL, @supplierid, @quotationnumber, @issuedate, @validdate, @hasvaliddate, @quotationpdf)";
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
q.ID AS QuotationID, q.SupplierID, s.SupplierName, s.SupplierAddress, q.QuotationNumber, q.IssueDate, q.ValidDate,
q.HasValidDate, q.QuotationPDF
FROM Quotation q
LEFT JOIN Supplier s ON q.SupplierID = s.ID;";
                    cmd.CommandText = selectAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["QuotationID"]);

                            int sid = Convert.ToInt32(reader["SupplierID"]);
                            string sname = reader["SupplierName"].ToString();
                            string saddress = reader["SupplierAddress"].ToString();
                            Supplier s = new Supplier(sid, sname, saddress);

                            string qnum = reader["QuotationNumber"].ToString();
                            DateTime issuedate = Convert.ToDateTime(reader["IssueDate"]);
                            DateTime? vdate = reader["ValidDate"] != DBNull.Value ? Convert.ToDateTime(reader["ValidDate"]) : (DateTime?)null;
                            bool hasvdate = Convert.ToBoolean(reader["HasValidDate"]);
                            string qpdf = reader["QuotationPDF"].ToString();

                            Quotation q = new Quotation(id, s, qnum, issuedate, hasvdate, qpdf, vdate);
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
