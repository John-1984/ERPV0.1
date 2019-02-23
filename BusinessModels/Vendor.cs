using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Vendor
    {
        public Vendor()
        {
          
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        public string VendorName
        {
            get;
            set;
        }

        [ForeignKey("ProductMaster")]
        public int? ProductMasterID
        { get; set; }

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

        public ProductMaster ProductMaster
        {
            get;
            set;
        }
       


    }
}