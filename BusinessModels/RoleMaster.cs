using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class RoleMaster
    {
        public RoleMaster()
        {
           
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        public string RoleName
        {
            get;
            set;
        }

        [ForeignKey("RoleType")]
        public int? RoleTypeID
        {
            get;
            set;
        }

        [ForeignKey("Modules")]
        public int? ModuleID
        {
            get;
            set;
        }

        [ForeignKey("Region")]
        public int? RegionID
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

        public RoleType RoleType
        {
            get;
            set;
        }

        public Modules Modules
        {
            get;
            set;
        }

        public Region Region
        {
            get;
            set;
        }
    }
}