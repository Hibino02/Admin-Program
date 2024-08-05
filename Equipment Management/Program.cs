using Equipment_Management.ObjectClass;
using System;
using System.Collections.Generic;

namespace Equipment_Management
{
    static class Program
    {
        static void Main(string[] args)
        {
            /*
            List<Plan> acc = Plan.GetPlanList();
            foreach (Plan job in acc)
            {
                Console.WriteLine($"ID: {job.ID}");
                Console.WriteLine($"Type: {job.PType.PType}");
                Console.WriteLine($"Period: {job.PPeriod.PPeriod}");
                Console.WriteLine($"Date To Do: {job.DateToDo}");
                Console.WriteLine("-----------------------------");
            }
            
            EquipmentType et = new EquipmentType(1);
            EquipmentOwner eo = new EquipmentOwner(1);
            Acquisition ea = new Acquisition(1);
            EquipmentStatus es = new EquipmentStatus(1);
            RentalBasis er = new RentalBasis(1);
            DateTime dt = new DateTime(2012, 2, 1);

             Equipment e = new Equipment("TEST2",dt,et,eo,ea,es,er,"TEST","TEST","TEST","TEST",false,null,0,null,null);
             e.Create();
            Plan p = new Plan(1);
            Console.WriteLine($"Plan Type: {p.PType.PType}");
            Console.WriteLine($"Plan Period: {p.PPeriod.PPeriod}");
            Console.WriteLine($"Equipment Name: {p.Eqp.Name}");
            Console.WriteLine($"Equipment Install Date: {p.Eqp.InsDate}");
            Console.WriteLine($"Equipment Install Date: {p.Eqp.EStatusObj.EStatus}");

            PlanProcess pp = new PlanProcess(1);
            Console.WriteLine($"Process Date: {pp.ProcessDate}");
            Console.WriteLine($"Equipment Name: {pp.RE.Name}"); */
        }
    }
}
