﻿using System;
using System.Collections.Generic;
using Admin_Program.ObjectClass;
using System.Linq;

namespace Admin_Program.CustomViewClass
{
    class AllEquipmentView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public string EDetails { get; set; }
        public DateTime InsDate { get; set; }
        public string EType { get; set; }
        public string EOwner { get; set; }
        public string EStatus { get; set; }
        public string InsDetails { get; set; }
        public string Zone { get; set; }
        public int ETypeID { get; set; }
        public int EStatusID { get; set; }
        public string InstallEPhoto { get; set; }
        public string EquipmentPhoto { get; set; }
        public bool Replacement { get; set; }
        public int EOwnerID { get; set; }
        public bool IsEJob { get; set; }

        public AllEquipmentView() { }
        public AllEquipmentView(int id,string name,string serial,int estatusid,string estatus,int etypeid,string ephoto)
        {
            ID = id;
            Name = name;
            Serial = serial;
            EStatusID = estatusid;
            EStatus = estatus;
            ETypeID = etypeid;
            EquipmentPhoto = ephoto;
        }

        public static List<AllEquipmentView> GetAllEquipmentView()
        {
            List<AllEquipmentView> equipmentListView = new List<AllEquipmentView>();
            List<Job> jlist = Job.GetJobList();
            foreach (Equipment e in Equipment.GetEquipmentList())
            {
                bool isEJob = false;

                foreach (Job j in jlist)
                {
                    if (e.ID == j.JEq.ID)
                    {
                        isEJob = true;
                        break;
                    }
                }
                AllEquipmentView view = new AllEquipmentView
                {
                    ID = e.ID,
                    Name = e.Name,
                    Serial = e.Serial,
                    EDetails = e.EDetails,
                    InsDate = e.InsDate,
                    EType = e.ETypeObj.EType,
                    EOwner = e.EOwnerObj.Owner,
                    EStatus = e.EStatusObj.EStatus,
                    InsDetails = e.InstallationDetails,
                    ETypeID = e.ETypeObj.ID,
                    EStatusID = e.EStatusObj.ID,
                    InstallEPhoto = e.OPlacePhotoPath,
                    EquipmentPhoto = e.EPhotoPath,
                    EOwnerID = e.EOwnerObj.ID,
                    IsEJob = isEJob,
                    Zone = e.Zone?.Name ?? "N/A"
                };
                equipmentListView.Add(view);
            }    
            return equipmentListView.OrderBy(e => e.EStatusID).ToList();
        }
        public static List<AllEquipmentView> GetAllEquipmentForPlanView()
        {
            List<AllEquipmentView> equipmentListView = new List<AllEquipmentView>();
            foreach (Equipment e in Equipment.GetEquipmentList())
            {
                if (e.EStatusObj.ID == 1 || e.EStatusObj.ID == 2)
                {
                    AllEquipmentView view = new AllEquipmentView
                    {
                        ID = e.ID,
                        Name = e.Name,
                        Serial = e.Serial,
                        EDetails = e.EDetails,
                        EStatus = e.EStatusObj.EStatus,
                        EStatusID = e.EStatusObj.ID,
                        InsDetails = e.InstallationDetails,
                        ETypeID = e.ETypeObj.ID,
                        EquipmentPhoto = e.EPhotoPath,
                        InstallEPhoto = e.OPlacePhotoPath
                    };
                    equipmentListView.Add(view);
                }
            }
            return equipmentListView.OrderBy(e => e.EStatusID).ToList();
        }
        public static List<AllEquipmentView> GetJobEquipmentView()
        {
            List<AllEquipmentView> equipmentListView = new List<AllEquipmentView>();
            foreach (Equipment e in Equipment.GetEquipmentList())
            {
                if (e.EStatusObj.ID == 1 || e.EStatusObj.ID == 2 || e.EStatusObj.ID == 3 ||
               e.EStatusObj.ID == 6 || e.EStatusObj.ID == 7)
                {
                    AllEquipmentView view = new AllEquipmentView
                    {
                        ID = e.ID,
                        Name = e.Name,
                        Serial = e.Serial,
                        EStatusID = e.EStatusObj.ID,
                        EStatus = e.EStatusObj.EStatus,
                        ETypeID = e.ETypeObj.ID,
                        EquipmentPhoto = e.EPhotoPath
                    };
                    equipmentListView.Add(view);
                }
            }
            return equipmentListView;
        }
        public static List<AllEquipmentView> GetJobProcessEquipmentView()
        {
            List<AllEquipmentView> equipmentListView = new List<AllEquipmentView>();
            foreach (Equipment e in Equipment.GetEquipmentList())
            {
                if (e.Replacement)
                {
                    if (e.EStatusObj.ID == 1 || e.EStatusObj.ID == 2 || e.EStatusObj.ID == 6
                   || e.EStatusObj.ID == 7)
                    {
                        AllEquipmentView view = new AllEquipmentView
                        {
                            ID = e.ID,
                            Name = e.Name,
                            Serial = e.Serial,
                            EStatusID = e.EStatusObj.ID,
                            EStatus = e.EStatusObj.EStatus,
                            ETypeID = e.ETypeObj.ID,
                            EquipmentPhoto = e.EPhotoPath
                        };
                        equipmentListView.Add(view);
                    }
                }
            }
            return equipmentListView;
        }
        public static List<AllEquipmentView> GetPlanProcessReplaceEquipmentView()
        {
            List<AllEquipmentView> List = new List<AllEquipmentView>();
            foreach(Equipment e in Equipment.GetEquipmentList())
            {
                //This logic for not showing same equipment in replace gridview
                if (e.ID != GlobalVariable.Global.selectedEquipmentInPlan.EID)
                {
                    if (e.EStatusObj.ID == 1 || e.EStatusObj.ID == 7)
                    {
                        AllEquipmentView view = new AllEquipmentView
                        {
                            ID = e.ID,
                            Name = e.Name,
                            Serial = e.Serial,
                            EStatusID = e.EStatusObj.ID,
                            EStatus = e.EStatusObj.EStatus,
                            EquipmentPhoto = e.EPhotoPath,
                            InstallEPhoto = e.OPlacePhotoPath,
                            InsDetails = e.InstallationDetails,
                            ETypeID = e.ETypeObj.ID
                        };
                        List.Add(view);
                    }
                }
            }
            return List;
        }
        public static List<AllEquipmentView> GetPlanProcessReplaceEquipmentEditView()
        {
            List<AllEquipmentView> List = new List<AllEquipmentView>();
            foreach (Equipment e in Equipment.GetEquipmentList())
            {
                //This logic for not showing same equipment in replace gridview
                if (e.ID != GlobalVariable.Global.selectedEquipmentInProcessedPlan.EID)
                {
                    if (e.EStatusObj.ID == 1 || e.EStatusObj.ID == 7)
                    {
                        AllEquipmentView view = new AllEquipmentView
                        {
                            ID = e.ID,
                            Name = e.Name,
                            Serial = e.Serial,
                            EStatusID = e.EStatusObj.ID,
                            EStatus = e.EStatusObj.EStatus,
                            EquipmentPhoto = e.EPhotoPath,
                            InstallEPhoto = e.OPlacePhotoPath,
                            InsDetails = e.InstallationDetails,
                            ETypeID = e.ETypeObj.ID
                        };
                        List.Add(view);
                    }
                }
            }
            return List;
        }
    }
}
