using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels.Workflow
{
    public class Workflow
    {
        public Workflow()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }

        [ForeignKey("Employee")]
        public int CreatedBy { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }
        [ForeignKey("CompanyType")]
        public int CompanyTypeID { get; set; }
        [ForeignKey("Company")]
        public int CompanyID { get; set; }

        [ForeignKey("Menu")]
        public int ItemType { get; set; }

        public Location Location
        { get; set; }

        public CompanyType CompanyType
        { get; set; }

        public Company Company
        { get; set; }

        public Menu Menu
        { get; set; }

        public Employee Employee
        { get; set; }
    }
}
