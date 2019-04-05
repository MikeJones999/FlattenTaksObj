using System;
using System.Collections.Generic;
using System.Text;

namespace FlattenTreeExample.Models
{
    public class FQJob
    {
        public int Id { get; set; }

        //public string ProjectId { get; set; }
        //public string Author { get; set; }
        //public string AgentId { get; set; }
        //public string JobId { get; set; }

        //public string JobGuid { get; set; }

        public List<FQTask> FQTasks { get; set; }

        //public DateTime CreatedDate { get; set; }
        //public DateTime EditedDate { get; set; }
        //public DateTime CompletedDate { get; set; }

        //public FQJobStatus FQJobStatus { get; set; }

    }


    public enum FQJobStatus
    {
        Pending = 0,
        Running = 10,
        Sucessfull = 20,
        Failed = 30,
    }
}
