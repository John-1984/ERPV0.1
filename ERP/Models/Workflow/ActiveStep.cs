using System;
namespace ERP.Models.Workflow
{
    public class ActiveStep
    {
        public ActiveStep()
        {
            ActiveStepID = -1;
            StepID = -1;
            Comments = string.Empty;
            UpdatedDate = string.Empty;
            Status = string.Empty;
            ActiveWorkflowID = -1;
            HasNotificationSend = "No";
            ActiveWorkflow = new ActiveWorkflow();
            Step = new Step();
            Action = string.Empty;
        }

        public int ActiveStepID { get; set; }
        public int StepID { get; set; }
        public string Comments { get; set; }
        public string UpdatedDate { get; set; }
        public string Status { get; set; }
        public int ActiveWorkflowID { get; set; }
        public string HasNotificationSend { get; set; }
        public string Action { get; set; }

        public ActiveWorkflow ActiveWorkflow { get; set; }

        public Step Step { get; set; }
    }

}

