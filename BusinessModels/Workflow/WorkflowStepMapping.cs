using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace BusinessModels.Workflow
{
    public class WorkflowStepMapping
    {
        public WorkflowStepMapping() { }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity { get; set; }
        public int WorkflowID { get; set; }
        public int StepID { get; set; }
    }
}
