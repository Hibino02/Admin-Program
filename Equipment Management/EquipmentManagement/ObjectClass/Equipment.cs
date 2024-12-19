using Admin_Program.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Admin_Program.ObjectClass
{
    class Equipment
    {
        int id;
        public int ID { get { return id; } }
        string name;
        public string Name { get { return name; }set { name = value; } }
        string serial;
        public string Serial { get { return serial; }set { serial = value; } }
        string ephotopath;
        public string EPhotoPath { get { return ephotopath; }set { ephotopath = value; } }
        string oplacephotopath;
        public string OPlacePhotoPath { get { return oplacephotopath; }set { oplacephotopath = value; } }
        string edetails;
        public string EDetails { get { return edetails; }set { edetails = value; } }
        bool replacement;
        public bool Replacement { get { return replacement; }set { replacement = value; } }
        string selldetails;
        public string SellDetails { get { return selldetails; }set { selldetails = value; } }
        double price;
        public double Price { get { return price; }set { price = value; } }
        string edocumentpath;
        public string EDocumentPath { get { return edocumentpath; }set { edocumentpath = value; } }
        DateTime insdate;
        public DateTime InsDate { get { return insdate; }set { insdate = value; } }
        string writeoffpath;
        public string WriteOffPath { get { return writeoffpath; }set { writeoffpath = value; } }
        EquipmentType etypeobj;
        public EquipmentType ETypeObj { get { return etypeobj; }set { etypeobj = value; } }
        EquipmentOwner eownerobj;
        public EquipmentOwner EOwnerObj { get { return eownerobj; }set { eownerobj = value; } }
        Acquisition acquisitionobj;
        public Acquisition AcquisitionObj { get { return acquisitionobj; }set { acquisitionobj = value; } }
        EquipmentStatus estatusobj;
        public EquipmentStatus EStatusObj { get { return estatusobj; }set { estatusobj = value; } }
        RentalBasis erentalbasis;
        public RentalBasis ERentalBasis { get { return erentalbasis; }set { erentalbasis = value; } }
        string installationDetails;
        public string InstallationDetails { get { return installationDetails; }set { installationDetails = value; } }
        bool onplan;
        public bool OnPlan { get { return onplan; }set { onplan = value; } }
        int warehouseID;
        public int WarehouseID { get { return warehouseID; }set { warehouseID = value; } }

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
                    string select = @"SELECT
e.ID AS EquipmentID, e.Name AS EquipmentName, e.Serial AS EquipmentSerial,
e.EPhoto AS EquipmentPhoto, e.OPlacePhoto AS OperationPlacePhoto,
e.EDetails AS EquipmentDetails, e.Replacement AS ForReplace,
e.SellDetails AS SellerDetails, e.Price AS EquipmentPrice,
e.EDocument AS EquipmentDocumentPath, e.InsDate AS InstallationDate, e.OnPlan AS onPlan,
e.ETypeID AS EquipmentTypeID, et.EType, et.WarehouseID AS ETWHID,
e.EOwnerID AS EquipmentOwnerID, eo.Owner, eo.WarehouseID AS EOWHID,
e.EAcqID AS AcquisitionID, ea.Accquire,
e.EStatusID AS EquipmentStatusID, es.EStatus,
e.ERentID AS RentalBasisID, er.Basis,
e.WriteOff AS WriteOffDocument,
e.InsDetails AS InstallationDetails,
e.WarehouseID
FROM equipment e
LEFT JOIN equipmenttype et ON e.ETypeID = et.ID
LEFT JOIN equipmentowner eo ON e.EOwnerID = eo.ID
LEFT JOIN acquisition ea ON e.EAcqID = ea.ID
LEFT JOIN equipmentstatus es ON e.EStatusID = es.ID
LEFT JOIN rentalbasis er ON e.ERentID = er.ID
WHERE e.ID = @id;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["EquipmentID"]);
                            name = reader["EquipmentName"].ToString();
                            serial = reader["EquipmentSerial"].ToString();
                            ephotopath = reader["EquipmentPhoto"].ToString();
                            oplacephotopath = reader["OperationPlacePhoto"].ToString();
                            edetails = reader["EquipmentDetails"].ToString();
                            replacement = Convert.ToBoolean(reader["ForReplace"]);
                            selldetails = reader["SellerDetails"].ToString();
                            price = Convert.ToDouble(reader["EquipmentPrice"]);
                            edocumentpath = reader["EquipmentDocumentPath"].ToString();
                            insdate = Convert.ToDateTime(reader["InstallationDate"]);
                            onplan = Convert.ToBoolean(reader["onPlan"]);
                            writeoffpath = reader["WriteOffDocument"].ToString();
                            int etypeid = Convert.ToInt32(reader["EquipmentTypeID"]);
                            string type = reader["EType"].ToString();
                            int etwhid = Convert.ToInt32(reader["ETWHID"]);
                            etypeobj = new EquipmentType(etypeid,type,etwhid);
                            int eownerid = Convert.ToInt32(reader["EquipmentOwnerID"]);
                            string owner = reader["Owner"].ToString();
                            int eowhid = Convert.ToInt32(reader["EOWHID"]);
                            eownerobj = new EquipmentOwner(eownerid,owner, eowhid);
                            int acqid = Convert.ToInt32(reader["AcquisitionID"]);
                            string acq = reader["Accquire"].ToString();
                            acquisitionobj = new Acquisition(acqid,acq);
                            int estaid = Convert.ToInt32(reader["EquipmentStatusID"]);
                            string status = reader["EStatus"].ToString();
                            estatusobj = new EquipmentStatus(estaid,status);

                            int? basisid = reader["RentalBasisID"] != DBNull.Value ? Convert.ToInt32(reader["RentalBasisID"]) : (int?)null;
                            string basis = reader["Basis"] != DBNull.Value ? reader["Basis"].ToString() : null;
                            erentalbasis = basisid.HasValue ? new RentalBasis(basisid.Value, basis) : null;

                            installationDetails = reader["InstallationDetails"].ToString();
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

        public Equipment(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public Equipment(int warehouseID,string name,bool onplan, DateTime insdate, EquipmentType etype, EquipmentOwner eowner, Acquisition acc, 
            EquipmentStatus esta, RentalBasis rent, string serial = null, string ephoto = null, string oplacephoto = null,
            string edetail = null, bool replacement = false, string selldetails = null, double price = 0.0, string edoc = null,
            string write = null,string insdetails = null)
        {
            this.warehouseID = warehouseID;
            this.name = name;
            this.onplan = onplan;
            this.serial = serial;
            this.ephotopath = ephoto;
            this.oplacephotopath = oplacephoto;
            this.edetails = edetail;
            this.replacement = replacement;
            this.selldetails = selldetails;
            this.price = price;
            this.edocumentpath = edoc;
            this.insdate = insdate;
            this.etypeobj = etype;
            this.eownerobj = eowner;
            this.acquisitionobj = acc;
            this.estatusobj = esta;
            this.erentalbasis = rent;
            this.writeoffpath = write;
            this.installationDetails = insdetails;
        }
        public Equipment(int id ,int warehouseID, string name,bool onplan, DateTime insdate, EquipmentType etype, EquipmentOwner eowner, Acquisition acc,
            EquipmentStatus esta, RentalBasis rent, string serial = null, string ephoto = null, string oplacephoto = null,
            string edetail = null, bool replacement = false, string selldetails = null, double price = 0.0, string edoc = null,
            string write = null, string insdetails = null)
        {
            this.id = id;
            this.warehouseID = warehouseID;
            this.name = name;
            this.onplan = onplan;
            this.serial = serial;
            this.ephotopath = ephoto;
            this.oplacephotopath = oplacephoto;
            this.edetails = edetail;
            this.replacement = replacement;
            this.selldetails = selldetails;
            this.price = price;
            this.edocumentpath = edoc;
            this.insdate = insdate;
            this.etypeobj = etype;
            this.eownerobj = eowner;
            this.acquisitionobj = acc;
            this.estatusobj = esta;
            this.erentalbasis = rent;
            this.writeoffpath = write;
            this.installationDetails = insdetails;
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
                    string insert = "INSERT INTO equipment (ID, Name, Serial, EPhoto, OPlacePhoto, EDetails, Replacement, SellDetails, Price, EDocument, InsDate, ETypeID, EOwnerID, EAcqID, EStatusID, ERentID, WriteOff, InsDetails, OnPlan, WarehouseID) VALUES (NULL, @name, @serial, @ephoto, @oplacephoto, @edetails, @replacement, @selldetails, @price ,@edocument ,@insdate ,@etypeid ,@eownerid ,@eacqid ,@estatusid ,@erentid ,@writeoff, @insdetails, @onplan, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@serial", serial);
                    cmd.Parameters.AddWithValue("@ephoto", ephotopath);
                    cmd.Parameters.AddWithValue("@oplacephoto", oplacephotopath);
                    cmd.Parameters.AddWithValue("@edetails", edetails);
                    cmd.Parameters.AddWithValue("@replacement", replacement);
                    cmd.Parameters.AddWithValue("@selldetails", selldetails);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@edocument", edocumentpath);
                    cmd.Parameters.AddWithValue("@insdate", insdate);
                    cmd.Parameters.AddWithValue("@etypeid", etypeobj.ID);
                    cmd.Parameters.AddWithValue("@eownerid", eownerobj.ID);
                    cmd.Parameters.AddWithValue("@eacqid", acquisitionobj.ID);
                    cmd.Parameters.AddWithValue("@estatusid", estatusobj.ID);
                    if (erentalbasis?.ID == null)
                        cmd.Parameters.AddWithValue("@erentid", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@erentid", erentalbasis.ID);
                    cmd.Parameters.AddWithValue("@writeoff", writeoffpath);
                    cmd.Parameters.AddWithValue("@insdetails", installationDetails);
                    cmd.Parameters.AddWithValue("@onplan", onplan);
                    cmd.Parameters.AddWithValue("@whid", warehouseID);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(MySqlException e)
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
                    string update = "UPDATE equipment SET Name = @name, Serial = @serial, EPhoto = @ephoto, OPlacePhoto = @oplacephoto, EDetails = @edetails, Replacement = @replacement, SellDetails = @selldetails, Price = @price, EDocument = @edocument, InsDate = @insdate, ETypeID = @etypeid, EOwnerID = @eownerid, EAcqID = @eacqid, EStatusID = @estatusid, ERentID = @erentid, WriteOff = @writeoff, InsDetails = @insdetails, OnPlan = @onplan, WarehouseID = @whid WHERE ID = @id";
                    cmd.CommandText = update;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@serial", serial);
                    cmd.Parameters.AddWithValue("@ephoto", ephotopath);
                    cmd.Parameters.AddWithValue("@oplacephoto", oplacephotopath);
                    cmd.Parameters.AddWithValue("@edetails", edetails);
                    cmd.Parameters.AddWithValue("@replacement", replacement);
                    cmd.Parameters.AddWithValue("@selldetails", selldetails);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@edocument", edocumentpath);
                    cmd.Parameters.AddWithValue("@insdate", insdate);
                    cmd.Parameters.AddWithValue("@etypeid", etypeobj.ID);
                    cmd.Parameters.AddWithValue("@eownerid", eownerobj.ID);
                    cmd.Parameters.AddWithValue("@eacqid", acquisitionobj.ID);
                    cmd.Parameters.AddWithValue("@estatusid", estatusobj.ID);
                    if (erentalbasis?.ID == null)
                        cmd.Parameters.AddWithValue("@erentid", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@erentid", erentalbasis.ID);
                    cmd.Parameters.AddWithValue("@writeoff", writeoffpath);
                    cmd.Parameters.AddWithValue("@insdetails", installationDetails);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@onplan", onplan);
                    cmd.Parameters.AddWithValue("@whid", warehouseID);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(MySqlException e)
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
                    string delete = "DELETE FROM equipment WHERE ID = @id";
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

        public static List<Equipment> GetEquipmentList()
        {
            MySqlConnection conn = null;
            List<Equipment> eqList = new List<Equipment>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
e.ID AS EquipmentID, e.Name AS EquipmentName, e.Serial AS EquipmentSerial,
e.EPhoto AS EquipmentPhoto, e.OPlacePhoto AS OperationPlacePhoto,
e.EDetails AS EquipmentDetails, e.Replacement AS ForReplace,
e.SellDetails AS SellerDetails, e.Price AS EquipmentPrice,
e.EDocument AS EquipmentDocumentPath, e.InsDate AS InstallationDate, e.OnPlan AS onPlan,
e.ETypeID AS EquipmentTypeID, et.EType, et.WarehouseID AS ETWHID,
e.EOwnerID AS EquipmentOwnerID, eo.Owner, eo.WarehouseID AS EOWHID,
e.EAcqID AS AcquisitionID, ea.Accquire,
e.EStatusID AS EquipmentStatusID, es.EStatus,
e.ERentID AS RentalBasisID, er.Basis,
e.WriteOff AS WriteOffDocument,
e.InsDetails AS InstallationDetails,
e.WarehouseID
FROM equipment e
LEFT JOIN equipmenttype et ON e.ETypeID = et.ID
LEFT JOIN equipmentowner eo ON e.EOwnerID = eo.ID
LEFT JOIN acquisition ea ON e.EAcqID = ea.ID
LEFT JOIN equipmentstatus es ON e.EStatusID = es.ID
LEFT JOIN rentalbasis er ON e.ERentID = er.ID
WHERE e.WarehouseID = @whid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid",GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["EquipmentID"]);
                            string name = reader["EquipmentName"].ToString();
                            DateTime insdate = Convert.ToDateTime(reader["InstallationDate"]);
                            int etypeid = Convert.ToInt32(reader["EquipmentTypeID"]);
                            string type = reader["EType"].ToString();
                            int etwhid = Convert.ToInt32(reader["ETWHID"]);
                            EquipmentType etype = new EquipmentType(etypeid, type, etwhid);
                            int eownerid = Convert.ToInt32(reader["EquipmentOwnerID"]);
                            string owner = reader["Owner"].ToString();
                            int eowhid = Convert.ToInt32(reader["EOWHID"]);
                            EquipmentOwner eowner = new EquipmentOwner(eownerid, owner, eowhid);
                            int acqid = Convert.ToInt32(reader["AcquisitionID"]);
                            string acq = reader["Accquire"].ToString();
                            Acquisition acc = new Acquisition(acqid, acq);
                            int estaid = Convert.ToInt32(reader["EquipmentStatusID"]);
                            string status = reader["EStatus"].ToString();
                            EquipmentStatus esta = new EquipmentStatus(estaid, status);

                            int? basisid = reader["RentalBasisID"] != DBNull.Value ? Convert.ToInt32(reader["RentalBasisID"]) : (int?)null;
                            string basis = reader["Basis"] != DBNull.Value ? reader["Basis"].ToString() : null;
                            RentalBasis rent = basisid.HasValue ? new RentalBasis(basisid.Value, basis) : null;

                            string serial = reader["EquipmentSerial"].ToString();
                            string ephoto = reader["EquipmentPhoto"].ToString();
                            string oplacephoto = reader["OperationPlacePhoto"].ToString();
                            string edetail = reader["EquipmentDetails"].ToString();
                            bool replacement = Convert.ToBoolean(reader["ForReplace"]);
                            string selldetails = reader["SellerDetails"].ToString();
                            double price = Convert.ToDouble(reader["EquipmentPrice"]);
                            string edoc = reader["EquipmentDocumentPath"].ToString();
                            string write = reader["WriteOffDocument"].ToString();
                            string ins = reader["InstallationDetails"].ToString();
                            bool onplan = Convert.ToBoolean(reader["onPlan"]);
                            int warehouseID = Convert.ToInt32(reader["WarehouseID"]);
                            Equipment eq = new Equipment(id, warehouseID, name,onplan, insdate, etype, eowner, acc, esta, rent, serial, ephoto,
                                oplacephoto, edetail, replacement, selldetails, price, edoc, write,ins);
                            eqList.Add(eq);
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
            return eqList;
        }
    }
}
