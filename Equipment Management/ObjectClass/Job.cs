using Equipment_Management.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Equipment_Management.ObjectClass
{
    class Job
    {
        int id;
        public int ID { get { return id; } }
        string jdetails;
        public string JDetails { get { return jdetails; } set { jdetails = value; } }
        string casephoto;
        public string CasePhoto { get { return casephoto; } set { casephoto = value; } }
        string reporter;
        public string Reporter { get { return reporter; } set { reporter = value; } }
        DateTime? rdate;
        public DateTime? RDate { get { return rdate; } set { rdate = value; } }
        DateTime? ddate;
        public DateTime? DDate { get { return ddate; } set { ddate = value; } }
        DateTime? adate;
        public DateTime? ADate { get { return adate; } set { adate = value; } }
        DateTime? startdate;
        public DateTime? StartDate { get { return startdate; } set { startdate = value; } }
        DateTime? finishdate;
        public DateTime? FinishDate { get { return finishdate; } set { finishdate = value; } }
        string jtypereason;
        public string JTypeReason { get { return jtypereason; } set { jtypereason = value; } }
        string decider;
        public string Decider { get { return decider; } set { decider = value; } }
        bool approve;
        public bool Approve { get { return approve; } set { approve = value; } }
        string appreason;
        public string AppReason { get { return appreason; } set { appreason = value; } }
        string approver;
        public string Approver { get { return approver; } set { approver = value; } }
        string jdocument;
        public string JDocument { get { return jdocument; } set { jdocument = value; } }
        string vendname;
        public string VendName { get { return vendname; } set { vendname = value; } }
        string venddetails;
        public string VendDetails { get { return venddetails; } set { venddetails = value; } }
        string repairdetails;
        public string RepairDetails { get { return repairdetails; } set { repairdetails = value; } }
        string workpermit;
        public string WorkPermit { get { return workpermit; } set { workpermit = value; } }
        double cost;
        public double Cost { get { return cost; } set { cost = value; } }
        string contract;
        public string Contract { get { return contract; } set { contract = value; } }
        string finishphoto;
        public string FinishPhoto { get { return finishphoto; } set { finishphoto = value; } }
        string finishdocument;
        public string FinishDocument { get { return finishdocument; } set { finishdocument = value; } }
        string acceptor;
        public string Acceptor { get { return acceptor; } set { acceptor = value; } }
        bool jobstatus;
        public bool JobStatus { get { return jobstatus; } set { jobstatus = value; } }
        JobType jtype;
        public JobType JType { get { return jtype; } set { jtype = value; } }
        Equipment jeq;
        public Equipment JEq { get { return jeq; } set { jeq = value; } }
        Equipment req;
        public Equipment REq { get { return req; } set { req = value; } }

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
    j.ID, j.JDetails, j.CasePhoto, j.Reporter, j.RDate,
    j.JTypeReason, j.Decider, j.DDate, j.Approve, j.AppReason,
    j.Approver, j.ADate, j.JDocument,
    j.VendName, j.VendDetails, j.RepairDetails,
    j.WorkPermit, j.Cost, j.Contract, j.StartDate, j.FinishDate,
    j.FinishPhoto, j.FinishDocument, j.Acceptor, j.JobStatus,
    j.JTypeID, jt.Type,
    j.EID, e1.Name AS E1_Name, e1.Serial AS E1_Serial, e1.EPhoto AS E1_EPhoto, e1.OnPlan AS E1_onPlan, 
    e1.OPlacePhoto AS E1_OPlacePhoto, e1.EDetails AS E1_EDetails, e1.Replacement AS E1_Replacement, 
    e1.SellDetails AS E1_SellDetails, e1.Price AS E1_Price, e1.InsDetails AS E1_InsDetails,
    e1.EDocument AS E1_EDocument, e1.InsDate AS E1_InsDate, e1.WriteOff AS E1_WriteOff,
    e1.ETypeID AS E1_ETypeID, et1.EType AS E1_EType,
    e1.EOwnerID AS E1_EOwnerID, eo1.Owner AS E1_Owner,
    e1.EAcqID AS E1_AcqID, ea1.Accquire AS E1_Accquire,
    e1.EStatusID AS E1_EStatusID, es1.EStatus AS E1_EStatus,
    e1.ERentID AS E1_ERentID, er1.Basis AS E1_Basis,
    j.REID, e2.Name AS E2_Name, e2.Serial AS E2_Serial, e2.EPhoto AS E2_EPhoto, e2.OnPlan AS E2_onPlan,
    e2.OPlacePhoto AS E2_OPlacePhoto, e2.EDetails AS E2_EDetails, e2.Replacement AS E2_Replacement, 
    e2.SellDetails AS E2_SellDetails, e2.Price AS E2_Price, e2.InsDetails AS E2_InsDetails,
    e2.EDocument AS E2_EDocument, e2.InsDate AS E2_InsDate, e2.WriteOff AS E2_WriteOff,
    e2.ETypeID AS E2_ETypeID, et2.EType AS E2_EType,
    e2.EOwnerID AS E2_EOwnerID, eo2.Owner AS E2_Owner,
    e2.EAcqID AS E2_AcqID, ea2.Accquire AS E2_Accquire,
    e2.EStatusID AS E2_EStatusID, es2.EStatus AS E2_EStatus,
    e2.ERentID AS E2_ERentID, er2.Basis AS E2_Basis
FROM 
    job j
LEFT JOIN equipment e1 ON j.EID = e1.ID
LEFT JOIN equipment e2 ON j.REID = e2.ID
LEFT JOIN equipmenttype et1 ON e1.ETypeID = et1.ID
LEFT JOIN equipmenttype et2 ON e2.ETypeID = et2.ID
LEFT JOIN equipmentowner eo1 ON e1.EOwnerID = eo1.ID
LEFT JOIN equipmentowner eo2 ON e2.EOwnerID = eo2.ID
LEFT JOIN acquisition ea1 ON e1.EAcqID = ea1.ID
LEFT JOIN acquisition ea2 ON e2.EAcqID = ea2.ID
LEFT JOIN equipmentstatus es1 ON e1.EStatusID = es1.ID
LEFT JOIN equipmentstatus es2 ON e2.EStatusID = es2.ID
LEFT JOIN rentalbasis er1 ON e1.ERentID = er1.ID
LEFT JOIN rentalbasis er2 ON e2.ERentID = er2.ID
LEFT JOIN jobtype jt ON j.JTypeID = jt.ID
WHERE j.ID = @jid;";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@jid", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["ID"]);
                            jdetails = reader["JDetails"].ToString();
                            casephoto = reader["CasePhoto"].ToString();
                            reporter = reader["Reporter"].ToString();
                            rdate = reader["RDate"] != DBNull.Value ? Convert.ToDateTime(reader["RDate"]) : (DateTime?)null;
                            ddate = reader["DDate"] != DBNull.Value ? Convert.ToDateTime(reader["DDate"]) : (DateTime?)null;
                            adate = reader["ADate"] != DBNull.Value ? Convert.ToDateTime(reader["ADate"]) : (DateTime?)null;
                            startdate = reader["StartDate"] != DBNull.Value ? Convert.ToDateTime(reader["StartDate"]) : (DateTime?)null;
                            finishdate = reader["FinishDate"] != DBNull.Value ? Convert.ToDateTime(reader["FinishDate"]) : (DateTime?)null;
                            jtypereason = reader["JTypeReason"].ToString();
                            decider = reader["Decider"].ToString();
                            approve = Convert.ToBoolean(reader["Approve"]);
                            appreason = reader["AppReason"].ToString();
                            approver = reader["Approver"].ToString();
                            jdocument = reader["JDocument"].ToString();
                            vendname = reader["VendName"].ToString();
                            venddetails = reader["VendDetails"].ToString();
                            repairdetails = reader["RepairDetails"].ToString();
                            workpermit = reader["WorkPermit"].ToString();
                            cost = Convert.ToDouble(reader["Cost"]);
                            contract = reader["Contract"].ToString();
                            finishphoto = reader["FinishPhoto"].ToString();
                            finishdocument = reader["FinishDocument"].ToString();
                            acceptor = reader["Acceptor"].ToString();
                            jobstatus = Convert.ToBoolean(reader["JobStatus"]);
                            int jtid = Convert.ToInt32(reader["JTypeID"]);
                            string jt = reader["Type"].ToString();
                            jtype = new JobType(jtid, jt);

                            //Equipment create in job
                            int eid = Convert.ToInt32(reader["EID"]);
                            string name = reader["E1_Name"].ToString();
                            string serial = reader["E1_Serial"].ToString();
                            string ephotopath = reader["E1_EPhoto"].ToString();
                            string oplacephotopath = reader["E1_OPlacePhoto"].ToString();
                            string edetails = reader["E1_EDetails"].ToString();
                            bool replacement = Convert.ToBoolean(reader["E1_Replacement"]);
                            string selldetails = reader["E1_SellDetails"].ToString();
                            double price = Convert.ToDouble(reader["E1_Price"]);
                            string edocumentpath = reader["E1_EDocument"].ToString();
                            DateTime insdate = Convert.ToDateTime(reader["E1_InsDate"]);
                            string writeoffpath = reader["E1_WriteOff"].ToString();
                            int etypeid = Convert.ToInt32(reader["E1_ETypeID"]);
                            string type = reader["E1_EType"].ToString();
                            EquipmentType etypeobj = new EquipmentType(etypeid, type);
                            int eownerid = Convert.ToInt32(reader["E1_EOwnerID"]);
                            string owner = reader["E1_Owner"].ToString();
                            EquipmentOwner eownerobj = new EquipmentOwner(eownerid, owner);
                            int acqid = Convert.ToInt32(reader["E1_AcqID"]);
                            string acq = reader["E1_Accquire"].ToString();
                            Acquisition acquisitionobj = new Acquisition(acqid, acq);
                            int estaid = Convert.ToInt32(reader["E1_EStatusID"]);
                            string status = reader["E1_EStatus"].ToString();
                            EquipmentStatus estatusobj = new EquipmentStatus(estaid, status);

                            int? basisid = reader["E1_ERentID"] != DBNull.Value ? Convert.ToInt32(reader["E1_ERentID"]) : (int?)null;
                            string basis = reader["E2_Basis"] != DBNull.Value ? reader["E2_Basis"].ToString() : null;
                            RentalBasis rent = basisid.HasValue ? new RentalBasis(basisid.Value, basis) : null;

                            string insdetail = reader["E1_InsDetails"].ToString();
                            bool onplan = Convert.ToBoolean(reader["E1_onPlan"]);
                            jeq = new Equipment(eid, name,onplan, insdate, etypeobj, eownerobj, acquisitionobj, estatusobj,
                                rent, serial, ephotopath, oplacephotopath, edetails, replacement, selldetails,
                                price, edocumentpath, writeoffpath,insdetail);

                            //Replacement equipment for this job
                            int? track = reader["REID"] != DBNull.Value ? Convert.ToInt32(reader["REID"]) : (int?)null;
                            if (track.HasValue)
                            {
                                int eid1 = track.Value;
                                string name1 = reader["E2_Name"].ToString();
                                string serial1 = reader["E2_Serial"].ToString();
                                string ephotopath1 = reader["E2_EPhoto"].ToString();
                                string oplacephotopath1 = reader["E2_OPlacePhoto"].ToString();
                                string edetails1 = reader["E2_EDetails"].ToString();
                                bool replacement1 = Convert.ToBoolean(reader["E2_Replacement"]);
                                string selldetails1 = reader["E2_SellDetails"].ToString();
                                double price1 = Convert.ToDouble(reader["E2_Price"]);
                                string edocumentpath1 = reader["E2_EDocument"].ToString();
                                DateTime insdate1 = Convert.ToDateTime(reader["E2_InsDate"]);
                                string writeoffpath1 = reader["E2_WriteOff"].ToString();
                                int etypeid1 = Convert.ToInt32(reader["E2_ETypeID"]);
                                string type1 = reader["E2_EType"].ToString();
                                EquipmentType etypeobj1 = new EquipmentType(etypeid, type);
                                int eownerid1 = Convert.ToInt32(reader["E2_EOwnerID"]);
                                string owner1 = reader["E2_Owner"].ToString();
                                EquipmentOwner eownerobj1 = new EquipmentOwner(eownerid, owner);
                                int acqid1 = Convert.ToInt32(reader["E2_AcqID"]);
                                string acq1 = reader["E2_Accquire"].ToString();
                                Acquisition acquisitionobj1 = new Acquisition(acqid, acq);
                                int estaid1 = Convert.ToInt32(reader["E2_EStatusID"]);
                                string status1 = reader["E2_EStatus"].ToString();
                                EquipmentStatus estatusobj1 = new EquipmentStatus(estaid, status);

                                int? basisid1 = reader["E1_ERentID"] != DBNull.Value ? Convert.ToInt32(reader["E1_ERentID"]) : (int?)null;
                                string basis1 = reader["E2_Basis"] != DBNull.Value ? reader["E2_Basis"].ToString() : null;
                                RentalBasis rent1 = basisid.HasValue ? new RentalBasis(basisid1.Value, basis1) : null;

                                string insdetail1 = reader["E2_InsDetails"].ToString();
                                bool onplan1 = Convert.ToBoolean(reader["E2_onPlan"]);
                                req = new Equipment(eid1, name1,onplan1, insdate1, etypeobj1, eownerobj1, acquisitionobj1, estatusobj1,
                                    rent1, serial1, ephotopath1, oplacephotopath1, edetails1, replacement1, selldetails1,
                                    price1, edocumentpath1, writeoffpath1,insdetail1);
                            }
                            else
                            {
                                req = null;
                            }
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

        public Job(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public Job(string jdetails, string casephoto, string reporter, DateTime? rdate = null,
            DateTime? ddate = null, DateTime? adate = null, DateTime? startdate = null, DateTime? finishdate = null,
            string jtypereason = null, string decider = null, bool approve = true, string appreason = null,
            string approver = null, string jdocument = null, string vendname = null, string venddetails = null,
            string repairdetails = null, string workpermit = null, double cost = 0, string contract = null,
            string finishphoto = null, string finishdocument = null, string acceptor = null, bool jobstatus = false,
            JobType jtype = null, Equipment jeq = null, Equipment req = null)
        {
            this.jdetails = jdetails;
            this.casephoto = casephoto;
            this.reporter = reporter;
            this.rdate = rdate;
            this.ddate = ddate;
            this.adate = adate;
            this.startdate = startdate;
            this.finishdate = finishdate;
            this.jtypereason = jtypereason;
            this.decider = decider;
            this.approve = approve;
            this.appreason = appreason;
            this.approver = approver;
            this.jdocument = jdocument;
            this.vendname = vendname;
            this.venddetails = venddetails;
            this.repairdetails = repairdetails;
            this.workpermit = workpermit;
            this.cost = cost;
            this.contract = contract;
            this.finishphoto = finishphoto;
            this.finishdocument = finishdocument;
            this.acceptor = acceptor;
            this.jobstatus = jobstatus;
            this.jtype = jtype;
            this.jeq = jeq;
            this.req = req;
        }
        public Job(int id, string jdetails, string casephoto, string reporter, DateTime? rdate = null,
            DateTime? ddate = null, DateTime? adate = null, DateTime? startdate = null, DateTime? finishdate = null,
            string jtypereason = null, string decider = null, bool approve = true, string appreason = null,
            string approver = null, string jdocument = null, string vendname = null, string venddetails = null,
            string repairdetails = null, string workpermit = null, double cost = 0, string contract = null,
            string finishphoto = null, string finishdocument = null, string acceptor = null, bool jobstatus = false,
            JobType jtype = null, Equipment jeq = null, Equipment req = null)
        {
            this.id = id;
            this.jdetails = jdetails;
            this.casephoto = casephoto;
            this.reporter = reporter;
            this.rdate = rdate;
            this.ddate = ddate;
            this.adate = adate;
            this.startdate = startdate;
            this.finishdate = finishdate;
            this.jtypereason = jtypereason;
            this.decider = decider;
            this.approve = approve;
            this.appreason = appreason;
            this.approver = approver;
            this.jdocument = jdocument;
            this.vendname = vendname;
            this.venddetails = venddetails;
            this.repairdetails = repairdetails;
            this.workpermit = workpermit;
            this.cost = cost;
            this.contract = contract;
            this.finishphoto = finishphoto;
            this.finishdocument = finishdocument;
            this.acceptor = acceptor;
            this.jobstatus = jobstatus;
            this.jtype = jtype;
            this.jeq = jeq;
            this.req = req;
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
                    string insert = "INSERT INTO Job (ID, JDetails, CasePhoto, Reporter, RDate, JTypeReason, Decider, DDate, Approve, AppReason, Approver, ADate, JDocument, EID, JTypeID, REID, VendName, VendDetails, RepairDetails, WorkPermit, Cost, Contract, StartDate, FinishDate, FinishPhoto, FinishDocument, Acceptor, JobStatus) VALUES (NULL, @jedtails, @casephoto, @reporter, @rdate, @jtypereason, @decider, @ddate, @approve ,@appreason ,@approver ,@adate ,@jdocument ,@eid ,@jtypeid ,@reid ,@vendname, @venddetails, @repairdetails, @workpermit, @cost, @contract, @startdate, @finishdate, @finishphoto, @finishdocument, @acceptor, @jobstatus)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@jedtails", jdetails);
                    cmd.Parameters.AddWithValue("@casephoto", casephoto);
                    cmd.Parameters.AddWithValue("@reporter", reporter);
                    cmd.Parameters.AddWithValue("@rdate", rdate);
                    cmd.Parameters.AddWithValue("@jtypereason", jtypereason);
                    cmd.Parameters.AddWithValue("@decider", decider);
                    cmd.Parameters.AddWithValue("@ddate", ddate);
                    cmd.Parameters.AddWithValue("@approve", approve);
                    cmd.Parameters.AddWithValue("@appreason", appreason);
                    cmd.Parameters.AddWithValue("@approver", approver);
                    cmd.Parameters.AddWithValue("@adate", adate);
                    cmd.Parameters.AddWithValue("@jdocument", jdocument);
                    cmd.Parameters.AddWithValue("@eid", jeq.ID);
                    cmd.Parameters.AddWithValue("@jtypeid", jtype.ID);

                    if (req?.ID == null)
                    {
                        cmd.Parameters.AddWithValue("@reid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@reid", req.ID);
                    }

                    cmd.Parameters.AddWithValue("@vendname", vendname);
                    cmd.Parameters.AddWithValue("@venddetails", venddetails);
                    cmd.Parameters.AddWithValue("@repairdetails", repairdetails);
                    cmd.Parameters.AddWithValue("@workpermit", workpermit);
                    cmd.Parameters.AddWithValue("@cost", cost);
                    cmd.Parameters.AddWithValue("@contract", contract);
                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@finishdate", finishdate);
                    cmd.Parameters.AddWithValue("@finishphoto", finishphoto);
                    cmd.Parameters.AddWithValue("@finishdocument", finishdocument);
                    cmd.Parameters.AddWithValue("@acceptor", acceptor);
                    cmd.Parameters.AddWithValue("@jobstatus", jobstatus);
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
                    string insert = "UPDATE job SET JDetails = @jedtails, CasePhoto = @casephoto, Reporter = @reporter, RDate = @rdate, JTypeReason = @jtypereason, Decider = @decider, DDate = @ddate, Approve = @approve, AppReason = @appreason, Approver = @approver, ADate = @adate, JDocument = @jdocument, EID = @eid, JTypeID = @jtypeid, REID = @reid, VendName = @vendname, VendDetails = @venddetails, RepairDetails = @repairdetails, WorkPermit = @workpermit, Cost = @cost, Contract = @contract, StartDate = @startdate, FinishDate = @finishdate, FinishPhoto = @finishphoto, FinishDocument = @finishdocument, Acceptor = @acceptor, JobStatus = @jobstatus WHERE ID = @id";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@jedtails", jdetails);
                    cmd.Parameters.AddWithValue("@casephoto", casephoto);
                    cmd.Parameters.AddWithValue("@reporter", reporter);
                    cmd.Parameters.AddWithValue("@rdate", rdate);
                    cmd.Parameters.AddWithValue("@jtypereason", jtypereason);
                    cmd.Parameters.AddWithValue("@decider", decider);
                    cmd.Parameters.AddWithValue("@ddate", ddate);
                    cmd.Parameters.AddWithValue("@approve", approve);
                    cmd.Parameters.AddWithValue("@appreason", appreason);
                    cmd.Parameters.AddWithValue("@approver", approver);
                    cmd.Parameters.AddWithValue("@adate", adate);
                    cmd.Parameters.AddWithValue("@jdocument", jdocument);
                    cmd.Parameters.AddWithValue("@eid", jeq.ID);
                    cmd.Parameters.AddWithValue("@jtypeid", jtype.ID);

                    if (req?.ID == null)
                    {
                        cmd.Parameters.AddWithValue("@reid", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@reid", req.ID);
                    }

                    cmd.Parameters.AddWithValue("@vendname", vendname);
                    cmd.Parameters.AddWithValue("@venddetails", venddetails);
                    cmd.Parameters.AddWithValue("@repairdetails", repairdetails);
                    cmd.Parameters.AddWithValue("@workpermit", workpermit);
                    cmd.Parameters.AddWithValue("@cost", cost);
                    cmd.Parameters.AddWithValue("@contract", contract);
                    cmd.Parameters.AddWithValue("@startdate", startdate);
                    cmd.Parameters.AddWithValue("@finishdate", finishdate);
                    cmd.Parameters.AddWithValue("@finishphoto", finishphoto);
                    cmd.Parameters.AddWithValue("@finishdocument", finishdocument);
                    cmd.Parameters.AddWithValue("@acceptor", acceptor);
                    cmd.Parameters.AddWithValue("@jobstatus", jobstatus);
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
                    string delete = "DELETE FROM job WHERE ID = @id";
                    cmd.CommandText = delete;
                    cmd.Parameters.AddWithValue("@id", id.ToString());
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

        public static List<Job> GetJobList()
        {
            MySqlConnection conn = null;
            List<Job> jobList = new List<Job>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
    j.ID, j.JDetails, j.CasePhoto, j.Reporter, j.RDate,
    j.JTypeReason, j.Decider, j.DDate, j.Approve, j.AppReason,
    j.Approver, j.ADate, j.JDocument,
    j.VendName, j.VendDetails, j.RepairDetails,
    j.WorkPermit, j.Cost, j.Contract, j.StartDate, j.FinishDate,
    j.FinishPhoto, j.FinishDocument, j.Acceptor, j.JobStatus,
    j.JTypeID, jt.Type,
    j.EID, e1.Name AS E1_Name, e1.Serial AS E1_Serial, e1.EPhoto AS E1_EPhoto, e1.OnPlan AS E1_onPlan,
    e1.OPlacePhoto AS E1_OPlacePhoto, e1.EDetails AS E1_EDetails, e1.Replacement AS E1_Replacement, 
    e1.SellDetails AS E1_SellDetails, e1.Price AS E1_Price, e1.InsDetails AS E1_InsDetails,
    e1.EDocument AS E1_EDocument, e1.InsDate AS E1_InsDate, e1.WriteOff AS E1_WriteOff,
    e1.ETypeID AS E1_ETypeID, et1.EType AS E1_EType,
    e1.EOwnerID AS E1_EOwnerID, eo1.Owner AS E1_Owner,
    e1.EAcqID AS E1_AcqID, ea1.Accquire AS E1_Accquire,
    e1.EStatusID AS E1_EStatusID, es1.EStatus AS E1_EStatus,
    e1.ERentID AS E1_ERentID, er1.Basis AS E1_Basis,
    j.REID, e2.Name AS E2_Name, e2.Serial AS E2_Serial, e2.EPhoto AS E2_EPhoto, e2.OnPlan AS E2_onPlan, 
    e2.OPlacePhoto AS E2_OPlacePhoto, e2.EDetails AS E2_EDetails, e2.Replacement AS E2_Replacement, 
    e2.SellDetails AS E2_SellDetails, e2.Price AS E2_Price, e2.InsDetails AS E2_InsDetails,
    e2.EDocument AS E2_EDocument, e2.InsDate AS E2_InsDate, e2.WriteOff AS E2_WriteOff,
    e2.ETypeID AS E2_ETypeID, et2.EType AS E2_EType,
    e2.EOwnerID AS E2_EOwnerID, eo2.Owner AS E2_Owner,
    e2.EAcqID AS E2_AcqID, ea2.Accquire AS E2_Accquire,
    e2.EStatusID AS E2_EStatusID, es2.EStatus AS E2_EStatus,
    e2.ERentID AS E2_ERentID, er2.Basis AS E2_Basis
FROM 
    job j
LEFT JOIN equipment e1 ON j.EID = e1.ID
LEFT JOIN equipment e2 ON j.REID = e2.ID
LEFT JOIN equipmenttype et1 ON e1.ETypeID = et1.ID
LEFT JOIN equipmenttype et2 ON e2.ETypeID = et2.ID
LEFT JOIN equipmentowner eo1 ON e1.EOwnerID = eo1.ID
LEFT JOIN equipmentowner eo2 ON e2.EOwnerID = eo2.ID
LEFT JOIN acquisition ea1 ON e1.EAcqID = ea1.ID
LEFT JOIN acquisition ea2 ON e2.EAcqID = ea2.ID
LEFT JOIN equipmentstatus es1 ON e1.EStatusID = es1.ID
LEFT JOIN equipmentstatus es2 ON e2.EStatusID = es2.ID
LEFT JOIN rentalbasis er1 ON e1.ERentID = er1.ID
LEFT JOIN rentalbasis er2 ON e2.ERentID = er2.ID
LEFT JOIN jobtype jt ON j.JTypeID = jt.ID";
                    cmd.CommandText = selectAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string jdetails = reader["JDetails"].ToString();
                            string casephoto = reader["CasePhoto"].ToString();
                            string reporter = reader["Reporter"].ToString();
                            DateTime? rdate = reader["RDate"] != DBNull.Value ? Convert.ToDateTime(reader["RDate"]) : (DateTime?)null;
                            DateTime? ddate = reader["DDate"] != DBNull.Value ? Convert.ToDateTime(reader["DDate"]) : (DateTime?)null;
                            DateTime? adate = reader["ADate"] != DBNull.Value ? Convert.ToDateTime(reader["ADate"]) : (DateTime?)null;
                            DateTime? startdate = reader["StartDate"] != DBNull.Value ? Convert.ToDateTime(reader["StartDate"]) : (DateTime?)null;
                            DateTime? finishdate = reader["FinishDate"] != DBNull.Value ? Convert.ToDateTime(reader["FinishDate"]) : (DateTime?)null;
                            string jtypereason = reader["JTypeReason"].ToString();
                            string decider = reader["Decider"].ToString();
                            bool approve = Convert.ToBoolean(reader["Approve"]);
                            string appreason = reader["AppReason"].ToString();
                            string approver = reader["Approver"].ToString();
                            string jdocument = reader["JDocument"].ToString();
                            string vendname = reader["VendName"].ToString();
                            string venddetails = reader["VendDetails"].ToString();
                            string repairdetails = reader["RepairDetails"].ToString();
                            string workpermit = reader["WorkPermit"].ToString();
                            double cost = Convert.ToDouble(reader["Cost"]);
                            string contract = reader["Contract"].ToString();
                            string finishphoto = reader["FinishPhoto"].ToString();
                            string finishdocument = reader["FinishDocument"].ToString();
                            string acceptor = reader["Acceptor"].ToString();
                            bool jobstatus = Convert.ToBoolean(reader["JobStatus"]);
                            int jtid = Convert.ToInt32(reader["JTypeID"]);
                            string jt = reader["Type"].ToString();
                            JobType jtype = new JobType(jtid, jt);

                            //Equipment create in job
                            int eid = Convert.ToInt32(reader["EID"]);
                            string name = reader["E1_Name"].ToString();
                            string serial = reader["E1_Serial"].ToString();
                            string ephotopath = reader["E1_EPhoto"].ToString();
                            string oplacephotopath = reader["E1_OPlacePhoto"].ToString();
                            string edetails = reader["E1_EDetails"].ToString();
                            bool replacement = Convert.ToBoolean(reader["E1_Replacement"]);
                            string selldetails = reader["E1_SellDetails"].ToString();
                            double price = Convert.ToDouble(reader["E1_Price"]);
                            string edocumentpath = reader["E1_EDocument"].ToString();
                            DateTime insdate = Convert.ToDateTime(reader["E1_InsDate"]);
                            string writeoffpath = reader["E1_WriteOff"].ToString();
                            int etypeid = Convert.ToInt32(reader["E1_ETypeID"]);
                            string type = reader["E1_EType"].ToString();
                            EquipmentType etypeobj = new EquipmentType(etypeid, type);
                            int eownerid = Convert.ToInt32(reader["E1_EOwnerID"]);
                            string owner = reader["E1_Owner"].ToString();
                            EquipmentOwner eownerobj = new EquipmentOwner(eownerid, owner);
                            int acqid = Convert.ToInt32(reader["E1_AcqID"]);
                            string acq = reader["E1_Accquire"].ToString();
                            Acquisition acquisitionobj = new Acquisition(acqid, acq);
                            int estaid = Convert.ToInt32(reader["E1_EStatusID"]);
                            string status = reader["E1_EStatus"].ToString();
                            EquipmentStatus estatusobj = new EquipmentStatus(estaid, status);

                            int? basisid = reader["E1_ERentID"] != DBNull.Value ? Convert.ToInt32(reader["E1_ERentID"]) : (int?)null;
                            string basis = reader["E2_Basis"] != DBNull.Value ? reader["E2_Basis"].ToString() : null;
                            RentalBasis rent = basisid.HasValue ? new RentalBasis(basisid.Value, basis) : null;

                            string insdetail = reader["E1_InsDetails"].ToString();
                            bool onplan = Convert.ToBoolean(reader["E1_onPlan"]);
                            Equipment jeq = new Equipment(eid, name,onplan, insdate, etypeobj, eownerobj, acquisitionobj, estatusobj,
                                rent, serial, ephotopath, oplacephotopath, edetails, replacement, selldetails,
                                price, edocumentpath, writeoffpath,insdetail);

                            //Replacement equipment for this job
                            int? track = reader["REID"] != DBNull.Value ? Convert.ToInt32(reader["REID"]) : (int?)null;
                            Equipment req;
                            if (track.HasValue)
                            {
                                int eid1 = track.Value;
                                string name1 = reader["E2_Name"].ToString();
                                string serial1 = reader["E2_Serial"].ToString();
                                string ephotopath1 = reader["E2_EPhoto"].ToString();
                                string oplacephotopath1 = reader["E2_OPlacePhoto"].ToString();
                                string edetails1 = reader["E2_EDetails"].ToString();
                                bool replacement1 = Convert.ToBoolean(reader["E2_Replacement"]);
                                string selldetails1 = reader["E2_SellDetails"].ToString();
                                double price1 = Convert.ToDouble(reader["E2_Price"]);
                                string edocumentpath1 = reader["E2_EDocument"].ToString();
                                DateTime insdate1 = Convert.ToDateTime(reader["E2_InsDate"]);
                                string writeoffpath1 = reader["E2_WriteOff"].ToString();
                                int etypeid1 = Convert.ToInt32(reader["E2_ETypeID"]);
                                string type1 = reader["E2_EType"].ToString();
                                EquipmentType etypeobj1 = new EquipmentType(etypeid, type);
                                int eownerid1 = Convert.ToInt32(reader["E2_EOwnerID"]);
                                string owner1 = reader["E2_Owner"].ToString();
                                EquipmentOwner eownerobj1 = new EquipmentOwner(eownerid, owner);
                                int acqid1 = Convert.ToInt32(reader["E2_AcqID"]);
                                string acq1 = reader["E2_Accquire"].ToString();
                                Acquisition acquisitionobj1 = new Acquisition(acqid, acq);
                                int estaid1 = Convert.ToInt32(reader["E2_EStatusID"]);
                                string status1 = reader["E2_EStatus"].ToString();
                                EquipmentStatus estatusobj1 = new EquipmentStatus(estaid, status);

                                int? basisid1 = reader["E1_ERentID"] != DBNull.Value ? Convert.ToInt32(reader["E1_ERentID"]) : (int?)null;
                                string basis1 = reader["E2_Basis"] != DBNull.Value ? reader["E2_Basis"].ToString() : null;
                                RentalBasis rent1 = basisid.HasValue ? new RentalBasis(basisid1.Value, basis1) : null;

                                string insdetail1 = reader["E2_InsDetails"].ToString();
                                bool onplan1 = Convert.ToBoolean(reader["E2_onPlan"]);
                                req = new Equipment(eid1, name1,onplan1, insdate1, etypeobj1, eownerobj1, acquisitionobj1, estatusobj1,
                                    rent1, serial1, ephotopath1, oplacephotopath1, edetails1, replacement1, selldetails1,
                                    price1, edocumentpath1, writeoffpath1,insdetail1);
                            }
                            else
                            {
                                req = null;
                            }
                            Job j = new Job(id, jdetails, casephoto, reporter, rdate, ddate, adate, startdate, finishdate,
                                jtypereason, decider, approve, appreason, approver, jdocument, vendname, venddetails,
                                repairdetails, workpermit, cost, contract, finishphoto, finishdocument, acceptor, jobstatus,
                                jtype, jeq, req);
                            jobList.Add(j);
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
            return jobList;
        }

        public bool UpdateEquipment()
        {
            MySqlConnection conn = null;
            try
            {
                if(jeq != null)
                {
                    conn = new MySqlConnection(connstr);
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        string update = "UPDATE job SET EID = @eid WHERE ID = @id";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@eid", jeq.ID);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }     
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
        public bool UpdateReplaceEquipment()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string clearReid = "UPDATE job SET REID = NULL WHERE ID = @id";
                    cmd.CommandText = clearReid;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    if (req != null)
                    {
                        cmd.Parameters.Clear();
                        string update = "UPDATE job SET REID = @reid WHERE ID = @id";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@reid", req.ID);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
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
    }
}
