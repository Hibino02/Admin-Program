using Admin_Program.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Admin_Program.ObjectClass
{
    class Plan
    {
        int id;
        public int ID { get { return id; } }
        Equipment eqp;
        public Equipment Eqp { get { return eqp; }set { eqp = value; } }
        PlanType ptype;
        public PlanType PType { get { return ptype; }set { ptype = value; } }
        PlanPeriod pperiod;
        public PlanPeriod PPeriod { get { return pperiod; }set { pperiod = value; } }
        int timestodo;
        public int TimesToDo { get { return timestodo; }set { timestodo = value; } }
        DateTime? datetodo;
        public DateTime? DateToDo { get { return datetodo; }set { datetodo = value; } }
        bool planstatus;
        public bool PlanStatus { get { return planstatus; }set { planstatus = value; } }
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
p.ID, p.TimesToDo, p.DateToDo, p.PlanStatus,
p.PTypeID, pt.PType, pt.WarehouseID AS PTWHID,
p.PPeriodID, pp.PPeriod, pp.WarehouseID AS PPWHID,
p.EID, p.WarehouseID,
e.Name, e.Serial, e.EPhoto, e.OPlacePhoto, e.EDetails, e.OnPlan,
e.Replacement, e.SellDetails, e.Price, e.EDocument, e.InsDate, e.InsDetails,
e.WriteOff, e.ETypeID, et.EType, et.WarehouseID AS ETWHID,
e.EOwnerID, eo.Owner, eo.WarehouseID AS EOWHID,
e.EAcqID, ea.Accquire,
e.EStatusID, es.EStatus,
e.ERentID, er.Basis,
e.WarehouseID
FROM plan p
LEFT JOIN plantype pt ON p.PTypeID = pt.ID
LEFT JOIN planperiod pp ON p.PPeriodID = pp.ID
LEFT JOIN equipment e ON p.EID = e.ID
LEFT JOIN equipmenttype et ON e.ETypeID = et.ID
LEFT JOIN equipmentowner eo ON e.EOwnerID = eo.ID
LEFT JOIN acquisition ea ON e.EAcqID = ea.ID
LEFT JOIN equipmentstatus es ON e.EStatusID = es.ID
LEFT JOIN rentalbasis er ON e.ERentID = e.ID
WHERE p.ID = @id";
                    cmd.CommandText = select;
                    cmd.Parameters.AddWithValue("@id", value);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.id = Convert.ToInt32(reader["ID"]);
                            timestodo = Convert.ToInt32(reader["TimesToDo"]);
                            datetodo = reader["DateToDo"] != DBNull.Value ? Convert.ToDateTime(reader["DateToDo"]) : (DateTime?)null;
                            planstatus = Convert.ToBoolean(reader["PlanStatus"]);
                            int ptypeid = Convert.ToInt32(reader["PTypeID"]);
                            string ptype = reader["PType"].ToString();
                            int ptwhid = Convert.ToInt32(reader["PTWHID"]);
                            this.ptype = new PlanType(ptypeid, ptype, ptwhid);
                            int pperiodid = Convert.ToInt32(reader["PPeriodID"]);
                            string pperiod = reader["PPeriod"].ToString();
                            int ppwhid = Convert.ToInt32(reader["PPWHID"]);
                            this.pperiod = new PlanPeriod(pperiodid, pperiod, ppwhid);
                            this.warehouseID = Convert.ToInt32(reader["WarehouseID"]);
                            //Equipment on this plan
                            int id = Convert.ToInt32(reader["EID"]);
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
                            int etwhid = Convert.ToInt32(reader["ETWHID"]);
                            EquipmentType etype = new EquipmentType(etypeid, type, etwhid);
                            int eownerid = Convert.ToInt32(reader["EOwnerID"]);
                            string owner = reader["Owner"].ToString();
                            int eowhid = Convert.ToInt32(reader["EOWHID"]);
                            EquipmentOwner eowner = new EquipmentOwner(eownerid, owner, eowhid);
                            int acqid = Convert.ToInt32(reader["EAcqID"]);
                            string acq = reader["Accquire"].ToString();
                            Acquisition acquisition = new Acquisition(acqid, acq);
                            int estaid = Convert.ToInt32(reader["EStatusID"]);
                            string status = reader["EStatus"].ToString();
                            EquipmentStatus estatus = new EquipmentStatus(estaid, status);

                            int? basisid = reader["ERentID"] != DBNull.Value ? Convert.ToInt32(reader["ERentID"]) : (int?)null;
                            string basis = reader["Basis"] != DBNull.Value ? reader["Basis"].ToString() : null;
                            RentalBasis erentalbasis = basisid.HasValue ? new RentalBasis(basisid.Value, basis) : null;

                            string insdetail = reader["InsDetails"].ToString();
                            bool onplan = Convert.ToBoolean(reader["OnPlan"]);
                            int ewhid = Convert.ToInt32(reader["WarehouseID"]);
                            eqp = new Equipment(id, ewhid, name,onplan, insdate, etype, eowner, acquisition, estatus, erentalbasis,
                                serial, ephotopath, oplacephotopath, edetails, replacement, selldetails, price, edocumentpath,
                                writeoffpath,insdetail);
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

        public Plan(int id)
        {
            UpdateAttribute(id.ToString());
        }
        public Plan(int warehouseid,Equipment eqp,PlanType ptype,PlanPeriod pperiod,int timestodo,bool planstatus, 
            DateTime? datetodo = null)
        {
            this.warehouseID = warehouseid;
            this.eqp = eqp;
            this.ptype = ptype;
            this.pperiod = pperiod;
            this.timestodo = timestodo;
            this.datetodo = datetodo;
            this.planstatus = planstatus;
        }
        public Plan(int id,int warehouseid,Equipment eqp, PlanType ptype, PlanPeriod pperiod, int timestodo, bool planstatus, 
            DateTime? datetodo = null)
        {
            this.id = id;
            this.warehouseID = warehouseid;
            this.eqp = eqp;
            this.ptype = ptype;
            this.pperiod = pperiod;
            this.timestodo = timestodo;
            this.datetodo = datetodo;
            this.planstatus = planstatus;
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
                    string insert = "INSERT INTO plan (ID, EID, PTypeID, PPeriodID, TimesToDo, DateToDo, PlanStatus, WarehouseID) VALUES (NULL, @eid, @ptypeid, @pperiodid, @timestodo, @datetodo, @planstatus, @whid)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@eid", eqp.ID);
                    cmd.Parameters.AddWithValue("@ptypeid", ptype.ID);
                    cmd.Parameters.AddWithValue("@pperiodid", pperiod.ID);
                    cmd.Parameters.AddWithValue("@timestodo", timestodo);
                    cmd.Parameters.AddWithValue("@datetodo", datetodo);
                    cmd.Parameters.AddWithValue("@planstatus", planstatus);
                    cmd.Parameters.AddWithValue("@whid",warehouseID);
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
                    string insert = "UPDATE plan SET EID = @eid, PTypeID = @ptypeid, PPeriodID = @pperiodid, TimesToDo = @timestodo, DateToDo = @datetodo, PlanStatus = @planstatus, WarehouseID = @whid WHERE ID = @id";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@eid", eqp.ID);
                    cmd.Parameters.AddWithValue("@ptypeid", ptype.ID);
                    cmd.Parameters.AddWithValue("@pperiodid", pperiod.ID);
                    cmd.Parameters.AddWithValue("@timestodo", timestodo);
                    cmd.Parameters.AddWithValue("@datetodo", datetodo);
                    cmd.Parameters.AddWithValue("@planstatus", planstatus);
                    cmd.Parameters.AddWithValue("@whid", warehouseID);
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
                    string delete = "DELETE FROM plan WHERE ID = @id";
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

        public static List<Plan> GetPlanList()
        {
            MySqlConnection conn = null;
            List<Plan> planList = new List<Plan>();
            try
            {
                conn = new MySqlConnection(connstr);
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    string selectAll = @"SELECT
p.ID, p.TimesToDo, p.DateToDo, p.PlanStatus,
p.PTypeID, pt.PType, pt.WarehouseID AS PTWHID,
p.PPeriodID, pp.PPeriod, pp.WarehouseID AS PPWHID,
p.EID, p.WarehouseID,
e.Name, e.Serial, e.EPhoto, e.OPlacePhoto, e.EDetails, e.OnPlan,
e.Replacement, e.SellDetails, e.Price, e.EDocument, e.InsDate, e.InsDetails,
e.WriteOff, e.ETypeID, et.EType, et.WarehouseID AS ETWHID,
e.EOwnerID, eo.Owner, eo.WarehouseID AS EOWHID,
e.EAcqID, ea.Accquire,
e.EStatusID, es.EStatus,
e.ERentID, er.Basis,
e.WarehouseID AS EQMWharehouseID
FROM plan p
LEFT JOIN plantype pt ON p.PTypeID = pt.ID
LEFT JOIN planperiod pp ON p.PPeriodID = pp.ID
LEFT JOIN equipment e ON p.EID = e.ID
LEFT JOIN equipmenttype et ON e.ETypeID = et.ID
LEFT JOIN equipmentowner eo ON e.EOwnerID = eo.ID
LEFT JOIN acquisition ea ON e.EAcqID = ea.ID
LEFT JOIN equipmentstatus es ON e.EStatusID = es.ID
LEFT JOIN rentalbasis er ON e.ERentID = e.ID
WHERE p.WarehouseID = @whid;";
                    cmd.CommandText = selectAll;
                    cmd.Parameters.AddWithValue("@whid",GlobalVariable.Global.warehouseID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            int timestodo = Convert.ToInt32(reader["TimesToDo"]);
                            DateTime? datetodo = reader["DateToDo"] != DBNull.Value ? Convert.ToDateTime(reader["DateToDo"]) : (DateTime?)null;
                            bool planstatus = Convert.ToBoolean(reader["PlanStatus"]);
                            int ptypeid = Convert.ToInt32(reader["PTypeID"]);
                            string ptype = reader["PType"].ToString();
                            int ptwhid = Convert.ToInt32(reader["PTWHID"]);
                            PlanType ptype1 = new PlanType(ptypeid, ptype, ptwhid);
                            int pperiodid = Convert.ToInt32(reader["PPeriodID"]);
                            string pperiod = reader["PPeriod"].ToString();
                            int ppwhid = Convert.ToInt32(reader["PPWHID"]);
                            PlanPeriod pperiod1 = new PlanPeriod(pperiodid, pperiod, ppwhid);
                            int warehouseid = Convert.ToInt32(reader["WarehouseID"]);
                            //Equipment on this plan
                            int eid = Convert.ToInt32(reader["EID"]);
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
                            int etwhid = Convert.ToInt32(reader["ETWHID"]);
                            EquipmentType etype = new EquipmentType(etypeid, type, etwhid);
                            int eownerid = Convert.ToInt32(reader["EOwnerID"]);
                            string owner = reader["Owner"].ToString();
                            int eowhid = Convert.ToInt32(reader["EOWHID"]);
                            EquipmentOwner eowner = new EquipmentOwner(eownerid, owner, eowhid);
                            int acqid = Convert.ToInt32(reader["EAcqID"]);
                            string acq = reader["Accquire"].ToString();
                            Acquisition acquisition = new Acquisition(acqid, acq);
                            int estaid = Convert.ToInt32(reader["EStatusID"]);
                            string status = reader["EStatus"].ToString();
                            EquipmentStatus estatus = new EquipmentStatus(estaid, status);

                            int? basisid = reader["ERentID"] != DBNull.Value ? Convert.ToInt32(reader["ERentID"]) : (int?)null;
                            string basis = reader["Basis"] != DBNull.Value ? reader["Basis"].ToString() : null;
                            RentalBasis erentalbasis = basisid.HasValue ? new RentalBasis(basisid.Value, basis) : null;

                            string insdetail = reader["InsDetails"].ToString();
                            bool onplan = Convert.ToBoolean(reader["OnPlan"]);
                            int eqwhid = Convert.ToInt32(reader["EQMWharehouseID"]);
                            Equipment eqp = new Equipment(eid, eqwhid, name,onplan, insdate, etype, eowner, acquisition, estatus, erentalbasis,
                                serial, ephotopath, oplacephotopath, edetails, replacement, selldetails, price, edocumentpath,
                                writeoffpath,insdetail);

                            Plan p = new Plan(id,warehouseid,eqp,ptype1,pperiod1,timestodo,planstatus, datetodo);
                            planList.Add(p);
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
            return planList;
        }

        public bool UpdateEquipment()
        {
            MySqlConnection conn = null;
            try
            {
                if (eqp != null)
                {
                    conn = new MySqlConnection(connstr);
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        string update = "UPDATE job SET EID = @eid WHERE ID = @id";
                        cmd.CommandText = update;
                        cmd.Parameters.AddWithValue("@eid", eqp.ID);
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
