using System;
namespace ERP.Models.Workflow
{
    public class WorkflowStepMapping
    {
        public WorkflowStepMapping()
        {
            Identity = -1;
            WorkflowID = -1;
            StepID = -1;
        }

        public int Identity { get; set; }
        public int WorkflowID { get; set; }
        public int StepID { get; set; }
    }
}
