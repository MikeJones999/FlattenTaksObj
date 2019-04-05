using System;
using System.Collections.Generic;
using System.Text;

namespace FlattenTreeExample.Models
{
    public class FQTask
    {
        public int Id { get; set; }
        public string FQTaskGuid { get; set; } // to look up the task as being unique and carried throughout its life

        public int FQJobId { get; set; }
        //public FQJob FQJob { get; set; }

        //public string AgentId { get; set; }

        public int ProcessSeq { get; set; }
        //public string Query { get; set; }

        public int? ParentId { get; set; }
        //public FQTask Parent { get; set; }

        //public FQTaskType FQTaskType { get; set; }
        //public FQTaskKernal FQTaskKernal { get; set; }
        //public FQTaskOrder FQTaskOrder { get; set; }
        //public FQTaskStatus FQTaskStatus { get; set; }

        public List<FQTask> FQTasks { get; set; }


        public FQTask(int id, string fqTaskGuid, int seq, int? ParentId = null)
        {
            this.Id = id;
            FQTaskGuid = fqTaskGuid;
            ProcessSeq = seq;
            this.ParentId = ParentId;
        }

    }


    public enum FQTaskType
    {
        None = 0,
        Command = 10,
        MetaQuery = 20,
        DataQuery = 30,
    }

    public enum FQTaskKernal
    {
        Python = 0,
        SQL = 10,
        R = 20,
    }

    public enum FQTaskOrder
    {
        Seq = 0,
        Par = 10,
    }

    public enum FQTaskStatus
    {
        Pending = 0,
        Running = 10,
        Sucessfull = 20,
        Failed = 30,
    }
}
