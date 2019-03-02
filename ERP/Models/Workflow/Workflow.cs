using System;
using System.Runtime;
namespace ERP.Models.Workflow
{
    public class Workflow
    {
        public Workflow()
        {
            Identity = -1;
            Description = string.Empty;
            Name = string.Empty;
            CreatedDate = string.Empty;
            CreatedBy = string.Empty;
        }

        public int Identity { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
