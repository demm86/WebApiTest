using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class TicketList
    {
        public int TicketID { get; set; }

        public string Key { get; set; }
        public string AgentName { get; set; }
        public DateTime StartDate { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public string Company { get; set; }
        public Boolean Completed { get; set; }
        public int TotalDuration { get; set; }
        public int Open { get; set; }
        public int InProgress { get; set; }
        public int Waiting { get; set; }
        public int InternalValidadtion { get; set; }


    }

    public class Tickets { 
      public int id { get; set; }
      public string key { get; set; } 
      public List<Fields> fields { get; set; }
    }

    public class Fields
    {
        public int agentId { get; set; }
        public string agentName { get; set; }
        public DateTime startDate  { get; set; }
        public string type { get; set; }
        public string priority { get; set; }
        public string company{ get; set; }
        public bool completed { get; set; }
        public int totalDuration { get; set; }
        public List<SummaryStates> summaryStates { get; set; }

    }


    public class SummaryStates
    {
        public int id { get; set; }
        public string name { get; set; }
        public string duration { get; set; }
    }



}
