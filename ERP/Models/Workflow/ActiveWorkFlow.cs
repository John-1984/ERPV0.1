using System;
using System.Collections.Generic;

namespace ERP.Models.Workflow
{
    public class ActiveWorkflow
    {
        public ActiveWorkflow()
        {
            ActiveID = -1;
            WorkflowID = -1;
            CreatedBy = string.Empty;
            CreatedDate = string.Empty;
            Status = string.Empty;
            CurrentStepID = -1;
            PreviousStepID = -1;
            PurchaseID = -1;
            ActiveStep = new List<ActiveStep>();
            Workflow = new Workflow();
            CompletedDate = string.Empty;
        }
        public int ActiveID { get; set; }
        public int WorkflowID { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public int CurrentStepID { get; set; }
        public int PreviousStepID { get; set; }
        public int PurchaseID { get; set; }
        public string CompletedDate { get; set; }

        public ICollection<ActiveStep> ActiveStep { get; set; }
        public Workflow Workflow { get; set; }
    }
}