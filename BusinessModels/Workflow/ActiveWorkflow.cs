using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels.Workflow
{
    public class ActiveWorkflow
    {
        public ActiveWorkflow()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActiveID { get; set; }
        public int WorkflowID { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public int CurrentStepID { get; set; }
        public int PreviousStepID { get; set; }
        public int PurchaseID { get; set; }
        public string CompletedDate { get; set; }

        public virtual ICollection<ActiveStep> ActiveStep { get; set; }

        [ForeignKey("WorkflowID")]
        public virtual Workflow Workflow { get; set; }
    }
}
