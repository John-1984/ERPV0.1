using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels.Workflow
{
    public class ActiveStep
    {
        public ActiveStep()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActiveStepID { get; set; }
        public int StepID { get; set; }
        public string Comments { get; set; }
        public string UpdatedDate { get; set; }
        public string Status { get; set; }
        public int ActiveWorkflowID { get; set; }
        public string HasNotificationSend { get; set; }

        [ForeignKey("ActiveWorkflowID")]
        public virtual ActiveWorkflow ActiveWorkflow { get; set; }

        [ForeignKey("StepID")]
        public virtual Step Step { get; set; }
    }
}
