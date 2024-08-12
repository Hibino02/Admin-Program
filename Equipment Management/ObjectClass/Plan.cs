using Equipment_Management.Properties;
using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Equipment_Management.ObjectClass
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
p.PTypeID, pt.PType,
p.PPeriodID, pp.PPeriod,
p.EID, e.Name, e.Serial, e.EPhoto, e.OPlacePhoto, e.EDetails, e.OnPlan,
e.Replacement, e.SellDetails, e.Price, e.EDocument, e.InsDate, e.InsDetails,
e.WriteOff, e.ETypeID, et.EType, 
e.EOwnerID, eo.Owner,
e.EAcqID, ea.Accquire,
e.EStatusID, es.EStatus,
e.ERentID, er.Basis
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
                            this.ptype = new PlanType(ptypeid, ptype);
                            int pperiodid = Convert.ToInt32(reader["PPeriodID"]);
                            string pperiod = reader["PPeriod"].ToString();
                            this.pperiod = new PlanPeriod(pperiodid, pperiod);
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
                            string insdetail = reader["InsDetails"].ToString();
                            bool onplan = Convert.ToBoolean(reader["OnPlan"]);
                            eqp = new Equipment(id, name,onplan, insdate, etype, eowner, acquisition, estatus, erentalbasis,
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
        public Plan(Equipment eqp,PlanType ptype,PlanPeriod pperiod,int timestodo,bool planstatus, DateTime? datetodo = null)
        {
            this.eqp = eqp;
            this.ptype = ptype;
            this.pperiod = pperiod;
            this.timestodo = timestodo;
            this.datetodo = datetodo;
            this.planstatus = planstatus;
        }
        public Plan(int id,Equipment eqp, PlanType ptype, PlanPeriod pperiod, int timestodo, bool planstatus, DateTime? datetodo = null)
        {
            this.id = id;
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
                    string insert = "INSERT INTO plan (ID, EID, PTypeID, PPeriodID, TimesToDo, DateToDo, PlanStatus) VALUES (NULL, @eid, @ptypeid, @pperiodid, @timestodo, @datetodo, @planstatus)";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@eid", eqp.ID);
                    cmd.Parameters.AddWithValue("@ptypeid", ptype.ID);
                    cmd.Parameters.AddWithValue("@pperiodid", pperiod.ID);
                    cmd.Parameters.AddWithValue("@timestodo", timestodo);
                    cmd.Parameters.AddWithValue("@datetodo", datetodo);
                    cmd.Parameters.AddWithValue("@planstatus", planstatus);
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
                    string insert = "UPDATE plan SET EID = @eid, PTypeID = @ptypeid, PPeriodID = @pperiodid, TimesToDo = @timestodo, DateToDo = @datetodo, PlanStatus = @planstatus WHERE ID = @id";
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@eid", eqp.ID);
                    cmd.Parameters.AddWithValue("@ptypeid", ptype.ID);
                    cmd.Parameters.AddWithValue("@pperiodid", pperiod.ID);
                    cmd.Parameters.AddWithValue("@timestodo", timestodo);
                    cmd.Parameters.AddWithValue("@datetodo", datetodo);
                    cmd.Parameters.AddWithValue("@planstatus", planstatus);
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
p.PTypeID, pt.PType,
p.PPeriodID, pp.PPeriod,
p.EID, e.Name, e.Serial, e.EPhoto, e.OPlacePhoto, e.EDetails, e.OnPlan,
e.Replacement, e.SellDetails, e.Price, e.EDocument, e.InsDate, e.InsDetails,
e.WriteOff, e.ETypeID, et.EType, 
e.EOwnerID, eo.Owner,
e.EAcqID, ea.Accquire,
e.EStatusID, es.EStatus,
e.ERentID, er.Basis
FROM plan p
LEFT JOIN plantype pt ON p.PTypeID = pt.ID
LEFT JOIN planperiod pp ON p.PPeriodID = pp.ID
LEFT JOIN equipment e ON p.EID = e.ID
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
                            int timestodo = Convert.ToInt32(reader["TimesToDo"]);
                            DateTime? datetodo = reader["DateToDo"] != DBNull.Value ? Convert.ToDateTime(reader["DateToDo"]) : (DateTime?)null;
                            bool planstatus = Convert.ToBoolean(reader["PlanStatus"]);
                            int ptypeid = Convert.ToInt32(reader["PTypeID"]);
                            string ptype = reader["PType"].ToString();
                            PlanType ptype1 = new PlanType(ptypeid, ptype);
                            int pperiodid = Convert.ToInt32(reader["PPeriodID"]);
                            string pperiod = reader["PPeriod"].ToString();
                            PlanPeriod pperiod1 = new PlanPeriod(pperiodid, pperiod);
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
                            string insdetail = reader["InsDetails"].ToString();
                            bool onplan = Convert.ToBoolean(reader["OnPlan"]);
                            Equipment eqp = new Equipment(id, name,onplan, insdate, etype, eowner, acquisition, estatus, erentalbasis,
                                serial, ephotopath, oplacephotopath, edetails, replacement, selldetails, price, edocumentpath,
                                writeoffpath,insdetail);

                            Plan p = new Plan(id,eqp,ptype1,pperiod1,timestodo,planstatus, datetodo);
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
