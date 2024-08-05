using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipment_Management.ObjectClass
{
    class PlanProcess
    {
        int id;
        public int ID { get { return id; } }
        Plan plan;
        public Plan Plan { get { return plan; }set { plan = value; } }
        DateTime processdate;
        public DateTime ProcessDate { get { return processdate; }set { processdate = value; } }

    }
}
