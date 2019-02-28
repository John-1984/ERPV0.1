using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class ReportMenu
    {
        public ReportMenu()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

       
        public string MenuName
        {
            get;
            set;
        }

        [ForeignKey("SubModules")]
        public int? SubModuleID
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

        public SubModules SubModules
        {
            get;
            set;
        }


    }
}