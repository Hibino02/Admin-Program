using Admin_Program.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Admin_Program.SupplyManagement.ObjectClass
{
    class PR
    {
        int id;
        public int ID { get { return id; } }
        Supplier supplier;
        public Supplier Supplier { get { return supplier; }set { supplier = value; } }
        Quotation quotation1;
        public Quotation Quotation1 { get { return quotation1; }set { quotation1 = value; } }
        Quotation quotation2;
        public Quotation Quotation2 { get { return quotation2; }set { quotation2 = value; } }
        string requester;
        public string Requester { get { return requester; }set { requester = value; } }
        string prtitle;
        public string PRTitle { get { return prtitle; }set { prtitle = value; } }
        bool iscostofsale;
        public bool IsCostOfSale { get { return iscostofsale; }set { iscostofsale = value; } }
        bool iscompanyasset;
        public bool IsCompanyAsset { get { return iscompanyasset; }set { iscompanyasset = value; } }
        bool ismaintainance;
        public bool IsMaintainance { get { return ismaintainance; }set { ismaintainance = value; } }
        bool isrental;
        public bool IsRental { get { return isrental; }set { isrental = value; } }
        bool isother;
        public bool IsOther { get { return isother; }set { isother = value; } }
        string otherreason;
        public string OtherReason { get { return otherreason; }set { otherreason = value; } }
        string adddetails;
        public string AddDetails { get { return adddetails; }set { adddetails = value; } }
        PRStatus prstatus;
        public PRStatus PRStatus { get { return prstatus; }set { prstatus = value; } }
        DateTime deliverydate;
        public DateTime DeliveryDate { get { return deliverydate; }set { deliverydate = value; } }
        string contactperson;
        public string ContactPerson { get { return contactperson; }set { contactperson = value; } }
        DateTime? arrivaldate;
        public DateTime? ArrivalDate { get { return arrivaldate; }set { arrivaldate = value; } }
        string invoicepdf;
        public string InvoicePDF { get { return invoicepdf; }set { invoicepdf = value; } }
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
pr.ID AS PRID, pr.SupplierID AS PRSupplierID, spr.SupplierName AS PRSupplierName, spr.SupplierAddress AS PRSupplierAddress, 
pr.QuotationID1, q1.SupplierID AS Q1SupplierID, s1.SupplierName AS Q1SupplierName, s1.SupplierAddress AS Q1SupplierAddress, q1.QuotationNumber AS Q1Number, q1.IssueDate AS Q1IsuDate, q1.ValidDate AS Q1VDate, q1.HasValidDate AS Q1HasVDate, q1.QuotationPDF AS Q1PDF,
pr.QuotationID2, q2.SupplierID AS Q2SupplierID, s2.SupplierName AS Q2SupplierName, s2.SupplierAddress AS Q2SupplierAddress, q2.QuotationNumber AS Q2Number, q2.IssueDate AS Q2IsuDate, q2.ValidDate AS Q2VDate, q2.HasValidDate AS Q2HasVDate, q2.QuotationPDF AS Q2PDF,
pr.Requester, pr.PRTitle, pr.IsCostOfSale, pr.IsCompanyAsset, pr.IsMaintainance, pr.IsRental, pr.IsOther, pr.OtherReason, pr.AddDetails, 
pr.PRStatusID, sta.Status, 
pr.DeliveryDate, pr.ContactPerson, pr.ArrivalDate, pr.InvoicePDF
FROM PR pr
LEFT JOIN Supplier spr ON pr.SupplierID = spr.ID
LEFT JOIN Quotation q1 ON pr.QuotationID1 = q1.ID
LEFT JOIN Supplier s1 ON q1.SupplierID = s1.ID
LEFT JOIN Quotation q2 ON pr.QuotationID2 = q2.ID
LEFT JOIN Supplier s2 ON q2.SupplierID = s2.ID
LEFT JOIN PRStatus sta ON pr.PRStatusID = sta.ID
WHERE pr.ID = @id;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["PRID"]);
                            //PRSupplier
                            int prsid = Convert.ToInt32(reader["PRSupplierID"]);
                            string prsname = reader["PRSupplierName"].ToString();
                            string prsaddress = reader["PRSupplierAddress"].ToString();
                            supplier = new Supplier(prsid,prsname,prsaddress,GlobalVariable.Global.warehouseID);
                            //Quotation 1
                            int q1id = Convert.ToInt32(reader["QuotationID1"]);
                            int q1sid = Convert.ToInt32(reader["Q1SupplierID"]);
                            string q1sname = reader["Q1SupplierName"].ToString();
                            string q1saddress = reader["Q1SupplierAddress"].ToString();
                            Supplier q1s = new Supplier(q1sid,q1sname,q1saddress,GlobalVariable.Global.warehouseID);
                            string q1num = reader["Q1Number"].ToString();
                            DateTime q1isdate = Convert.ToDateTime(reader["Q1IsuDate"]);
                            DateTime? q1vdate = reader["Q1VDate"] != DBNull.Value ? Convert.ToDateTime(reader["Q1VDate"]) : (DateTime?)null;
                            bool q1hasvdate = Convert.ToBoolean(reader["Q1HasVDate"]);
                            string q1pdf = reader["Q1PDF"].ToString();
                            quotation1 = new Quotation(q1id,GlobalVariable.Global.warehouseID,q1s,q1num,q1isdate,q1hasvdate,q1pdf,q1vdate);
                            //Quotation 2
                            int q2id = Convert.ToInt32(reader["QuotationID2"]);
                            int q2sid = Convert.ToInt32(reader["Q2SupplierID"]);
                            string q2sname = reader["Q2SupplierName"].ToString();
                            string q2saddress = reader["Q2SupplierAddress"].ToString();
                            Supplier q2s = new Supplier(q1sid, q1sname, q1saddress,GlobalVariable.Global.warehouseID);
                            string q2num = reader["Q2Number"].ToString();
                            DateTime q2isdate = Convert.ToDateTime(reader["Q2IsuDate"]);
                            DateTime? q2vdate = reader["Q2VDate"] != DBNull.Value ? Convert.ToDateTime(reader["Q2VDate"]) : (DateTime?)null;
                            bool q2hasvdate = Convert.ToBoolean(reader["Q2HasVDate"]);
                            string q2pdf = reader["Q2PDF"].ToString();
                            quotation2 = new Quotation(q2id,GlobalVariable.Global.warehouseID, q2s, q2num, q2isdate, q2hasvdate, q2pdf, q2vdate);

                            requester = reader["Requester"].ToString();
                            prtitle = reader["PRTitle"].ToString();
                            iscostofsale = Convert.ToBoolean(reader["IsCostOfSale"]);
                            iscompanyasset = Convert.ToBoolean(reader["IsCompanyAsset"]);
                            ismaintainance = Convert.ToBoolean(reader["IsMaintainance"]);
                            isrental = Convert.ToBoolean(reader["IsRental"]);
                            isother = Convert.ToBoolean(reader["IsOther"]);
                            otherreason = reader["OtherReason"].ToString();
                            adddetails = reader["AddDetails"].ToString();
                            //PRStatus
                            int sid = Convert.ToInt32(reader["PRStatusID"]);
                            string sta = reader["Status"].ToString();
                            prstatus = new PRStatus(sid,sta);
                            deliverydate = Convert.ToDateTime(reader["DeliveryDate"]);
                            contactperson = reader["ContactPerson"].ToString();
                            arrivaldate = reader["ArrivalDate"] != DBNull.Value ? Convert.ToDateTime(reader["ArrivalDate"]) : (DateTime?)null;
                            invoicepdf = reader["InvoicePDF"].ToString();
                            warehouseID = GlobalVariable.Global.warehouseID;
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

        public PR(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public PR(int id,int whid,Supplier prs,Quotation q1,Quotation q2,string requester,string prtitle,bool iscostofsale
            ,bool iscompanyasset,bool ismaintainance,bool isrental,bool isother,string otherreason,string adddetails
            ,PRStatus prstatus,DateTime deliverydate,string contactperson,string invpdf,DateTime? arrivaldate = null)
        {
            this.id = id;
            this.warehouseID = whid;
            this.supplier = prs;
            this.quotation1 = q1;
            this.quotation2 = q2;
            this.requester = requester;
            this.prtitle = prtitle;
            this.iscostofsale = iscostofsale;
            this.iscompanyasset = iscompanyasset;
            this.ismaintainance = ismaintainance;
            this.isrental = isrental;
            this.isother = isother;
            this.otherreason = otherreason;
            this.adddetails = adddetails;
            this.prstatus = prstatus;
            this.deliverydate = deliverydate;
            this.contactperson = contactperson;
            this.invoicepdf = invpdf;
            this.arrivaldate = arrivaldate;
        }
        public PR(int whid,Supplier prs, Quotation q1, Quotation q2, string requester, string prtitle, bool iscostofsale
            , bool iscompanyasset, bool ismaintainance, bool isrental, bool isother, string otherreason, string adddetails
            , PRStatus prstatus, DateTime deliverydate, string contactperson, string invpdf, DateTime? arrivaldate = null)
        {
            this.warehouseID = whid;
            this.supplier = prs;
            this.quotation1 = q1;
            this.quotation2 = q2;
            this.requester = requester;
            this.prtitle = prtitle;
            this.iscostofsale = iscostofsale;
            this.iscompanyasset = iscompanyasset;
            this.ismaintainance = ismaintainance;
            this.isrental = isrental;
            this.isother = isother;
            this.otherreason = otherreason;
            this.adddetails = adddetails;
            this.prstatus = prstatus;
            this.deliverydate = deliverydate;
            this.contactperson = contactperson;
            this.invoicepdf = invpdf;
            this.arrivaldate = arrivaldate;
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
                    string insert = "INSERT INTO PR (ID, SupplierID, QuotationID1, QuotationID2, Requester, PRTitle, IsCostOfSale, IsCompanyAsset, IsMaintainance, IsRental, IsOther, OtherReason, AddDetails, PRStatusID, DeliveryDate, ContactPerson, Arrivaldate, InvoicePDF, WarehouseID) VALUES (NULL, @supid, @q1, @q2, @requester, @prtitle, @iscostofsale, @iscompanyasset, @ismaintainance, @isrental, @isother, @otherreason, @adddetails, @prstatusid, @deliverydate, @contactperson, @arrivaldate, @invoicepdf, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@supid",supplier.ID);
                    cmd.Parameters.AddWithValue("@q1", quotation1.ID);
                    cmd.Parameters.AddWithValue("@q2", quotation2.ID);
                    cmd.Parameters.AddWithValue("@requester", requester);
                    cmd.Parameters.AddWithValue("@prtitle", prtitle);
                    cmd.Parameters.AddWithValue("@iscostofsale", iscostofsale);
                    cmd.Parameters.AddWithValue("@iscompanyasset", iscompanyasset);
                    cmd.Parameters.AddWithValue("@ismaintainance", ismaintainance);
                    cmd.Parameters.AddWithValue("@isrental", isrental);
                    cmd.Parameters.AddWithValue("@isother", isother);
                    cmd.Parameters.AddWithValue("@otherreason", otherreason);
                    cmd.Parameters.AddWithValue("@adddetails", adddetails);
                    cmd.Parameters.AddWithValue("@prstatusid", prstatus.ID);
                    cmd.Parameters.AddWithValue("@deliverydate", deliverydate);
                    cmd.Parameters.AddWithValue("@contactperson", contactperson);
                    cmd.Parameters.AddWithValue("@whid", warehouseID);
                    if(arrivaldate == null)
                    {
                        cmd.Parameters.AddWithValue("@arrivaldate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@arrivaldate", arrivaldate);
                    }
                    cmd.Parameters.AddWithValue("@invoicepdf", invoicepdf);
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
                    string update = "UPDATE PR SET SupplierID = @supid, QuotationID1 = @q1, QuotationID2 = @q2, Requester = @requester, PRTitle = @prtitle, IsCostOfSale = @iscostofsale, IsCompanyAsset = @iscompanyasset, IsMaintainance = @ismaintainance, IsRental = @isrental, IsOther = @isother, OtherReason = @otherreason, AddDetails = @adddetails, PRStatusID = @prstatusid, DeliveryDate = @deliverydate, ContactPerson = @contactperson, ArrivalDate = @arrivaldate, InvoicePDF = @invoicepdf WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@supid", supplier.ID);
                    cmd.Parameters.AddWithValue("@q1", quotation1.ID);
                    cmd.Parameters.AddWithValue("@q2", quotation2.ID);
                    cmd.Parameters.AddWithValue("@requester", requester);
                    cmd.Parameters.AddWithValue("@prtitle", prtitle);
                    cmd.Parameters.AddWithValue("@iscostofsale", iscostofsale);
                    cmd.Parameters.AddWithValue("@iscompanyasset", iscompanyasset);
                    cmd.Parameters.AddWithValue("@ismaintainance", ismaintainance);
                    cmd.Parameters.AddWithValue("@isrental", isrental);
                    cmd.Parameters.AddWithValue("@isother", isother);
                    cmd.Parameters.AddWithValue("@otherreason", otherreason);
                    cmd.Parameters.AddWithValue("@adddetails", adddetails);
                    cmd.Parameters.AddWithValue("@prstatusid", prstatus.ID);
                    cmd.Parameters.AddWithValue("@deliverydate", deliverydate);
                    cmd.Parameters.AddWithValue("@contactperson", contactperson);
                    if (arrivaldate == null)
                    {
                        cmd.Parameters.AddWithValue("@arrivaldate", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@arrivaldate", arrivaldate);
                    }
                    cmd.Parameters.AddWithValue("@invoicepdf", invoicepdf);
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
                    string delete = "DELETE FROM PR WHERE ID = @id";
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

        public static List<PR> GetAllPRList()
        {
            MySqlConnection conn = null;
            List<PR> prList = new List<PR>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
pr.ID AS PRID, pr.SupplierID AS PRSupplierID, spr.SupplierName AS PRSupplierName, spr.SupplierAddress AS PRSupplierAddress, 
pr.QuotationID1, q1.SupplierID AS Q1SupplierID, s1.SupplierName AS Q1SupplierName, s1.SupplierAddress AS Q1SupplierAddress, q1.QuotationNumber AS Q1Number, q1.IssueDate AS Q1IsuDate, q1.ValidDate AS Q1VDate, q1.HasValidDate AS Q1HasVDate, q1.QuotationPDF AS Q1PDF,
pr.QuotationID2, q2.SupplierID AS Q2SupplierID, s2.SupplierName AS Q2SupplierName, s2.SupplierAddress AS Q2SupplierAddress, q2.QuotationNumber AS Q2Number, q2.IssueDate AS Q2IsuDate, q2.ValidDate AS Q2VDate, q2.HasValidDate AS Q2HasVDate, q2.QuotationPDF AS Q2PDF,
pr.Requester, pr.PRTitle, pr.IsCostOfSale, pr.IsCompanyAsset, pr.IsMaintainance, pr.IsRental, pr.IsOther, pr.OtherReason, pr.AddDetails, 
pr.PRStatusID, sta.Status, 
pr.DeliveryDate, pr.ContactPerson, pr.ArrivalDate, pr.InvoicePDF
FROM PR pr
LEFT JOIN Supplier spr ON pr.SupplierID = spr.ID
LEFT JOIN Quotation q1 ON pr.QuotationID1 = q1.ID
LEFT JOIN Supplier s1 ON q1.SupplierID = s1.ID
LEFT JOIN Quotation q2 ON pr.QuotationID2 = q2.ID
LEFT JOIN Supplier s2 ON q2.SupplierID = s2.ID
LEFT JOIN PRStatus sta ON pr.PRStatusID = sta.ID
WHERE pr.WarehouseID = @whid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid",GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["PRID"]);
                            //PRSupplier
                            int prsid = Convert.ToInt32(reader["PRSupplierID"]);
                            string prsname = reader["PRSupplierName"].ToString();
                            string prsaddress = reader["PRSupplierAddress"].ToString();
                            Supplier supplier = new Supplier(prsid, prsname, prsaddress, GlobalVariable.Global.warehouseID);
                            //Quotation 1
                            int q1id = Convert.ToInt32(reader["QuotationID1"]);
                            int q1sid = Convert.ToInt32(reader["Q1SupplierID"]);
                            string q1sname = reader["Q1SupplierName"].ToString();
                            string q1saddress = reader["Q1SupplierAddress"].ToString();
                            Supplier q1s = new Supplier(q1sid, q1sname, q1saddress,GlobalVariable.Global.warehouseID);
                            string q1num = reader["Q1Number"].ToString();
                            DateTime q1isdate = Convert.ToDateTime(reader["Q1IsuDate"]);
                            DateTime? q1vdate = reader["Q1VDate"] != DBNull.Value ? Convert.ToDateTime(reader["Q1VDate"]) : (DateTime?)null;
                            bool q1hasvdate = Convert.ToBoolean(reader["Q1HasVDate"]);
                            string q1pdf = reader["Q1PDF"].ToString();
                            Quotation quotation1 = new Quotation(q1id, GlobalVariable.Global.warehouseID, q1s, q1num, q1isdate, q1hasvdate, q1pdf, q1vdate);
                            //Quotation 2
                            int q2id = Convert.ToInt32(reader["QuotationID2"]);
                            int q2sid = Convert.ToInt32(reader["Q2SupplierID"]);
                            string q2sname = reader["Q2SupplierName"].ToString();
                            string q2saddress = reader["Q2SupplierAddress"].ToString();
                            Supplier q2s = new Supplier(q1sid, q1sname, q1saddress,GlobalVariable.Global.warehouseID);
                            string q2num = reader["Q2Number"].ToString();
                            DateTime q2isdate = Convert.ToDateTime(reader["Q2IsuDate"]);
                            DateTime? q2vdate = reader["Q2VDate"] != DBNull.Value ? Convert.ToDateTime(reader["Q2VDate"]) : (DateTime?)null;
                            bool q2hasvdate = Convert.ToBoolean(reader["Q2HasVDate"]);
                            string q2pdf = reader["Q2PDF"].ToString();
                            Quotation quotation2 = new Quotation(q2id,GlobalVariable.Global.warehouseID, q2s, q2num, q2isdate, q2hasvdate, q2pdf, q2vdate);

                            string requester = reader["Requester"].ToString();
                            string prtitle = reader["PRTitle"].ToString();
                            bool iscostofsale = Convert.ToBoolean(reader["IsCostOfSale"]);
                            bool iscompanyasset = Convert.ToBoolean(reader["IsCompanyAsset"]);
                            bool ismaintainance = Convert.ToBoolean(reader["IsMaintainance"]);
                            bool isrental = Convert.ToBoolean(reader["IsRental"]);
                            bool isother = Convert.ToBoolean(reader["IsOther"]);
                            string otherreason = reader["OtherReason"].ToString();
                            string adddetails = reader["AddDetails"].ToString();
                            //PRStatus
                            int sid = Convert.ToInt32(reader["PRStatusID"]);
                            string sta = reader["Status"].ToString();
                            PRStatus prstatus = new PRStatus(sid, sta);
                            DateTime deliverydate = Convert.ToDateTime(reader["DeliveryDate"]);
                            string contactperson = reader["ContactPerson"].ToString();
                            DateTime? arrivaldate = reader["ArrivalDate"] != DBNull.Value ? Convert.ToDateTime(reader["ArrivalDate"]) : (DateTime?)null;
                            string invoicepdf = reader["InvoicePDF"].ToString();

                            PR pr = new PR(id,GlobalVariable.Global.warehouseID, supplier, quotation1, quotation2, requester, prtitle, iscostofsale, iscompanyasset, ismaintainance, isrental, isother, otherreason, adddetails, prstatus, deliverydate, contactperson, invoicepdf, arrivaldate);
                            prList.Add(pr);
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
            return prList;
        }
    }
}
