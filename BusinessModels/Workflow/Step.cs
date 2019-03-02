using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels.Workflow
{
    public class Step
    {
        public Step()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string StepOwner { get; set; }
        public string NotificationType { get; set; }
        public string AdditionalNotificationUser { get; set; }
    }
}
