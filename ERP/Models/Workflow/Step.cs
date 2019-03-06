using System;
using System.Runtime;
using System.Web.Mvc;

namespace ERP.Models.Workflow
{
    public class Step
    {
        public Step()
        {
            Identity = -1;
            Description = string.Empty;
            Name = string.Empty;
            CreatedDate = string.Empty;
            CreatedBy = string.Empty;
            StepOwner = string.Empty;
            NotificationType = string.Empty;
            AdditionalNotificationUser = string.Empty;
        }

        public int Identity { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string StepOwner { get; set; }
        public string NotificationType { get; set; }
        public string AdditionalNotificationUser { get; set; }

        public SelectList LocationList
        { get; set; }

        public SelectList EmployeeList
        { get; set; }
    }
}
