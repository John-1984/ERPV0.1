using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Menu
    {
        public Menu()
        {                  
        }
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        [ForeignKey("Modules")]
        public Int32? ModuleID
        {
            get;
            set;
        }

        public DateTime? CreatedDate
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public int? CreatedBy
        {
            get;
            set;
        }

        public Boolean IsApprovalNeeded
        {
            get;
            set;
        }
        public Boolean IsActive
        {
            get;
            set;
        }


        public Modules Modules
        { get; set; }

    }
}
    
