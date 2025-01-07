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
pr.Requester, pr.PRTitle, pr.IsCostOfSale, pr.IsCompanyAsset, pr.IsMaintainance, pr.IsRental, pr.IsOther, pr.OtherReason, pr.AddDetails, 
pr.PRStatusID, sta.Status,
pr.DeliveryDate, pr.ContactPerson, pr.ArrivalDate, pr.InvoicePDF
FROM PR pr
LEFT JOIN Supplier spr ON pr.SupplierID = spr.ID
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
        public PR(int id,int whid,Supplier prs,string requester,string prtitle,bool iscostofsale
            ,bool iscompanyasset,bool ismaintainance,bool isrental,bool isother,string otherreason,string adddetails
            ,PRStatus prstatus,DateTime deliverydate,string contactperson,string invpdf,DateTime? arrivaldate = null)
        {
            this.id = id;
            this.warehouseID = whid;
            this.supplier = prs;
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
        public PR(int whid,Supplier prs, string requester, string prtitle, bool iscostofsale
            , bool iscompanyasset, bool ismaintainance, bool isrental, bool isother, string otherreason, string adddetails
            , PRStatus prstatus, DateTime deliverydate, string contactperson, string invpdf, DateTime? arrivaldate = null)
        {
            this.warehouseID = whid;
            this.supplier = prs;
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
                    string insert = "INSERT INTO PR (ID, SupplierID, Requester, PRTitle, IsCostOfSale, IsCompanyAsset, IsMaintainance, IsRental, IsOther, OtherReason, AddDetails, PRStatusID, DeliveryDate, ContactPerson, Arrivaldate, InvoicePDF, WarehouseID) VALUES (NULL, @supid, @requester, @prtitle, @iscostofsale, @iscompanyasset, @ismaintainance, @isrental, @isother, @otherreason, @adddetails, @prstatusid, @deliverydate, @contactperson, @arrivaldate, @invoicepdf, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@supid",supplier.ID);
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
                    string update = "UPDATE PR SET SupplierID = @supid, Requester = @requester, PRTitle = @prtitle, IsCostOfSale = @iscostofsale, IsCompanyAsset = @iscompanyasset, IsMaintainance = @ismaintainance, IsRental = @isrental, IsOther = @isother, OtherReason = @otherreason, AddDetails = @adddetails, PRStatusID = @prstatusid, DeliveryDate = @deliverydate, ContactPerson = @contactperson, ArrivalDate = @arrivaldate, InvoicePDF = @invoicepdf WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@supid", supplier.ID);
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
pr.Requester, pr.PRTitle, pr.IsCostOfSale, pr.IsCompanyAsset, pr.IsMaintainance, pr.IsRental, pr.IsOther, pr.OtherReason, pr.AddDetails, 
pr.PRStatusID, sta.Status,
pr.DeliveryDate, pr.ContactPerson, pr.ArrivalDate, pr.InvoicePDF
FROM PR pr
LEFT JOIN Supplier spr ON pr.SupplierID = spr.ID
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

                            PR pr = new PR(id,GlobalVariable.Global.warehouseID, supplier, requester, prtitle, iscostofsale, iscompanyasset, ismaintainance, isrental, isother, otherreason, adddetails, prstatus, deliverydate, contactperson, invoicepdf, arrivaldate);
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
