﻿using Equipment_Management.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Equipment_Management.ObjectClass
{
    class PlanProcess
    {
        int id;
        public int ID { get { return id; } }
        int planid;
        public int PlanID { get { return planid; }set { planid = value; } }
        DateTime processdate;
        public DateTime ProcessDate { get { return processdate; }set { processdate = value; } }
        string startdetails;
        public string StartDetails { get { return startdetails; }set { startdetails = value; } }
        string psup;
        public string PSup { get { return psup; }set { psup = value; } }
        string psupdetails;
        public string PSupDetails { get { return psupdetails; }set { psupdetails = value; } }
        double cost;
        public double Cost { get { return cost; }set { cost = value; } }
        string workpermit;
        public string WorkPermit { get { return workpermit; }set { workpermit = value; } }
        string contract;
        public string Contract { get { return contract; }set { contract = value; } }
        Equipment re;
        public Equipment RE { get { return re; }set { re = value; } }
        DateTime? finishdate;
        public DateTime? FinishDate { get { return finishdate; }set { finishdate = value; } }
        string finishdetails;
        public string FinishDetails { get { return finishdetails; }set { finishdetails = value; } }
        string finishdoc;
        public string FinishDoc { get { return finishdoc; }set { finishdoc = value; } }

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
pp.ID, pp.ProcessDate, pp.StartDetails, pp.PSup, pp.PSupDetails, pp.Cost,
pp.WorkPermit, pp.Contract, pp.FinishDate, pp.FinishDetails, pp.FinishDoc,
pp.PlanID, pp.REID, e.Name, e.Serial, e.EPhoto, e.OPlacePhoto, e.EDetails,
e.Replacement, e.SellDetails, e.Price, e.EDocument, e.InsDate, e.WriteOff, e.ETypeID, et.EType, 
e.EOwnerID, eo.Owner, e.EAcqID, ea.Accquire, e.EStatusID, es.EStatus, e.ERentID, er.Basis
FROM planprocess pp
LEFT JOIN equipment e ON pp.REID = e.ID
LEFT JOIN equipmenttype et ON e.ETypeID = et.ID
LEFT JOIN equipmentowner eo ON e.EOwnerID = eo.ID
LEFT JOIN acquisition ea ON e.EAcqID = ea.ID
LEFT JOIN equipmentstatus es ON e.EStatusID = es.ID
LEFT JOIN rentalbasis er ON e.ERentID = er.ID
WHERE pp.ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using(var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.id = Convert.ToInt32(reader["ID"]);
                            planid = Convert.ToInt32(reader["PlanID"]);
                            processdate = Convert.ToDateTime(reader["ProcessDate"]);
                            psup = reader["PSup"].ToString();
                            psupdetails = reader["PSupDetails"].ToString();
                            cost = Convert.ToDouble(reader["Cost"]);
                            workpermit = reader["WorkPermit"].ToString();
                            contract = reader["Contract"].ToString();
                            finishdate = reader["FinishDate"] != DBNull.Value ? Convert.ToDateTime(reader["FinishDate"]) : (DateTime?)null;
                            finishdetails = reader["FinishDetails"].ToString();
                            finishdoc = reader["FinishDoc"].ToString();
                            startdetails = reader["StartDetails"].ToString();
                            //Replace equipment forthis process
                            int? track = reader["REID"] != DBNull.Value ? Convert.ToInt32(reader["REID"]) : (int?)null;
                            if (track.HasValue)
                            {
                                int id1 = Convert.ToInt32(reader["REID"]);
                                string name = reader["Name"].ToString();
                                string serial = reader["Serial"].ToString();
                                string ephotopath = reader["EPhoto"].ToString();
                                string oplacephotopath = reader["OPlacePhoto"].ToString();
                                string edetails = reader["EDetails"].ToString();
                                bool replacement = Convert.ToBoolean(reader["Replacement"]);
                                string selldetails = reader["SellDetails"].ToString();
                                double price = Convert.ToDouble(reader["Price"]);
                                string edocumentpath = reader["EDocument"].ToString();
                                DateTime insdate = Convert.ToDateTime(reader["InsDate"]);
                                string writeoffpath = reader["WriteOff"].ToString();
                                int etypeid = Convert.ToInt32(reader["ETypeID"]);
                                string type = reader["EType"].ToString();
                                EquipmentType etype = new EquipmentType(etypeid, type);
                                int eownerid = Convert.ToInt32(reader["EOwnerID"]);
                                string owner = reader["Owner"].ToString();
                                EquipmentOwner eowner = new EquipmentOwner(eownerid, owner);
                                int acqid = Convert.ToInt32(reader["EAcqID"]);
                                string acq = reader["Accquire"].ToString();
                                Acquisition acquisition = new Acquisition(acqid, acq);
                                int estaid = Convert.ToInt32(reader["EStatusID"]);
                                string status = reader["EStatus"].ToString();
                                EquipmentStatus estatus = new EquipmentStatus(estaid, status);
                                int basisid = Convert.ToInt32(reader["ERentID"]);
                                string basis = reader["Basis"].ToString();
                                RentalBasis erentalbasis = new RentalBasis(basisid, basis);
                                re = new Equipment(id1, name, insdate, etype, eowner, acquisition, estatus, erentalbasis,
                                    serial, ephotopath, oplacephotopath, edetails, replacement, selldetails, price, edocumentpath,
                                    writeoffpath);
                            }
                            else
                            {
                                re = null;
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

        public PlanProcess(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public PlanProcess(int id,int planid,DateTime processdate,string startdetails,string psup,string psupdetails,
            double cost,string workpermit,string contract,string finishdetails,string finishdoc,Equipment re = null,
            DateTime? finishdate = null)
        {
            this.id = id;
            this.planid = planid;
            this.processdate = processdate;
            this.startdetails = startdetails;
            this.psup = psup;
            this.psupdetails = psupdetails;
            this.cost = cost;
            this.workpermit = workpermit;
            this.contract = contract;
            this.finishdetails = finishdetails;
            this.finishdoc = finishdoc;
            this.re = re;
            this.finishdate = finishdate;
        }
        public PlanProcess(int planid, DateTime processdate, string startdetails, string psup, string psupdetails,
            double cost, string workpermit, string contract, string finishdetails, string finishdoc, Equipment re = null,
            DateTime? finishdate = null)
        {
            this.planid = planid;
            this.processdate = processdate;
            this.startdetails = startdetails;
            this.psup = psup;
            this.psupdetails = psupdetails;
            this.cost = cost;
            this.workpermit = workpermit;
            this.contract = contract;
            this.finishdetails = finishdetails;
            this.finishdoc = finishdoc;
            this.re = re;
            this.finishdate = finishdate;
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
                    string insert = "INSERT INTO planprocess (ID, PlanID, ProcessDate, PSup, PSupDetails, Cost, WorkPermit, Contract, REID, FinishDate, FinishDetails, FinishDoc, StartDetails) VALUES (NULL, @planid, @processdate, @psup, @psupdetails, @cost, @workpermit, @contract, @reid ,@finishdate ,@finishdetails ,@finishdoc ,@startdetails)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@planid", planid);
                    cmd.Parameters.AddWithValue("@processdate", processdate);
                    cmd.Parameters.AddWithValue("@psup", psup);
                    cmd.Parameters.AddWithValue("@psupdetails", psupdetails);
                    cmd.Parameters.AddWithValue("@cost", cost);
                    cmd.Parameters.AddWithValue("@workpermit", workpermit);
                    cmd.Parameters.AddWithValue("@contract", contract);
                    cmd.Parameters.AddWithValue("@reid", re.ID);
                    cmd.Parameters.AddWithValue("@finishdate", finishdate);
                    cmd.Parameters.AddWithValue("@finishdetails", finishdetails);
                    cmd.Parameters.AddWithValue("@finishdoc", finishdoc);
                    cmd.Parameters.AddWithValue("@startdetails", startdetails);
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
                    string insert = "UPDATE planprocess SET PlanID = @planid, ProcessDate = @processdate, PSup = @psup, PSupDetails = @psupdetails, Cost = @cost, WorkPermit = @workpermit, Contract = @contract, REID = @reid, FinishDate = @finishdate, FinishDetails = @finishdetails, FinishDoc = @finishdoc, StartDetails = @startdetails WHERE ID = @id";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@planid", planid);
                    cmd.Parameters.AddWithValue("@processdate", processdate);
                    cmd.Parameters.AddWithValue("@psup", psup);
                    cmd.Parameters.AddWithValue("@psupdetails", psupdetails);
                    cmd.Parameters.AddWithValue("@cost", cost);
                    cmd.Parameters.AddWithValue("@workpermit", workpermit);
                    cmd.Parameters.AddWithValue("@contract", contract);
                    cmd.Parameters.AddWithValue("@reid", re.ID);
                    cmd.Parameters.AddWithValue("@finishdate", finishdate);
                    cmd.Parameters.AddWithValue("@finishdetails", finishdetails);
                    cmd.Parameters.AddWithValue("@finishdoc", finishdoc);
                    cmd.Parameters.AddWithValue("@startdetails", startdetails);
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
                    string delete = "DELETE FROM planprocess WHERE ID = @id";
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

        public static List<PlanProcess> GetPlanProcessList()
        {
            MySqlConnection conn = null;
            List<PlanProcess> planProcessList = new List<PlanProcess>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
pp.ID, pp.ProcessDate, pp.StartDetails, pp.PSup, pp.PSupDetails, pp.Cost,
pp.WorkPermit, pp.Contract, pp.FinishDate, pp.FinishDetails, pp.FinishDoc,
pp.PlanID, 
pp.REID, e.Name, e.Serial, e.EPhoto, e.OPlacePhoto, e.EDetails,
e.Replacement, e.SellDetails, e.Price, e.EDocument, e.InsDate,
e.WriteOff, e.ETypeID, et.EType, 
e.EOwnerID, eo.Owner,
e.EAcqID, ea.Accquire,
e.EStatusID, es.EStatus,
e.ERentID, er.Basis
FROM planprocess pp
LEFT JOIN equipment e ON pp.REID = e.ID
LEFT JOIN equipmenttype et ON e.ETypeID = et.ID
LEFT JOIN equipmentowner eo ON e.EOwnerID = eo.ID
LEFT JOIN acquisition ea ON e.EAcqID = ea.ID
LEFT JOIN equipmentstatus es ON e.EStatusID = es.ID
LEFT JOIN rentalbasis er ON e.ERentID = e.ID";
                    cmd.CommandText = selectAll;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            int planid = Convert.ToInt32(reader["PlanID"]);
                            DateTime processdate = Convert.ToDateTime(reader["ProcessDate"]);
                            string psup = reader["PSup"].ToString();
                            string psupdetails = reader["PSupDetails"].ToString();
                            double cost = Convert.ToDouble(reader["Cost"]);
                            string workpermit = reader["WorkPermit"].ToString();
                            string contract = reader["Contract"].ToString();
                            DateTime? finishdate = reader["FinishDate"] != DBNull.Value ? Convert.ToDateTime(reader["FinishDate"]) : (DateTime?)null;
                            string finishdetails = reader["FinishDetails"].ToString();
                            string finishdoc = reader["FinishDoc"].ToString();
                            string startdetails = reader["StartDetails"].ToString();
                            //Replace equipment forthis process
                            int reid = Convert.ToInt32(reader["REID"]);
                            string name = reader["Name"].ToString();
                            string serial = reader["Serial"].ToString();
                            string ephotopath = reader["EPhoto"].ToString();
                            string oplacephotopath = reader["OPlacePhoto"].ToString();
                            string edetails = reader["EDetails"].ToString();
                            bool replacement = Convert.ToBoolean(reader["Replacement"]);
                            string selldetails = reader["SellDetails"].ToString();
                            double price = Convert.ToDouble(reader["Price"]);
                            string edocumentpath = reader["EDocument"].ToString();
                            DateTime insdate = Convert.ToDateTime(reader["InsDate"]);
                            string writeoffpath = reader["WriteOff"].ToString();
                            int etypeid = Convert.ToInt32(reader["ETypeID"]);
                            string type = reader["EType"].ToString();
                            EquipmentType etype = new EquipmentType(etypeid, type);
                            int eownerid = Convert.ToInt32(reader["EOwnerID"]);
                            string owner = reader["Owner"].ToString();
                            EquipmentOwner eowner = new EquipmentOwner(eownerid, owner);
                            int acqid = Convert.ToInt32(reader["EAcqID"]);
                            string acq = reader["Accquire"].ToString();
                            Acquisition acquisition = new Acquisition(acqid, acq);
                            int estaid = Convert.ToInt32(reader["EStatusID"]);
                            string status = reader["EStatus"].ToString();
                            EquipmentStatus estatus = new EquipmentStatus(estaid, status);
                            int basisid = Convert.ToInt32(reader["ERentID"]);
                            string basis = reader["Basis"].ToString();
                            RentalBasis erentalbasis = new RentalBasis(basisid, basis);
                            Equipment re = new Equipment(reid, name, insdate, etype, eowner, acquisition, estatus, erentalbasis,
                                serial, ephotopath, oplacephotopath, edetails, replacement, selldetails, price, edocumentpath,
                                writeoffpath);

                            PlanProcess pp = new PlanProcess(id,planid,processdate,startdetails,psup,psupdetails,
                                cost,workpermit,contract,finishdetails,finishdoc,re,finishdate);
                            planProcessList.Add(pp);
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
            return planProcessList;
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
                    string clearReid = "UPDATE planprocess SET REID = NULL WHERE ID = @id";
                    cmd.CommandText = clearReid;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    if (re != null)
                    {
                        cmd.Parameters.Clear();
                        string update = "UPDATE planprocess SET REID = @reid WHERE ID = @id";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@reid", re.ID);
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
