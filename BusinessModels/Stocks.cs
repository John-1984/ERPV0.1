using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Stocks
    {
        public Stocks()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }


        [ForeignKey("ItemMaster")]
        public int ItemID
        {
            get;
            set;
        }



        [ForeignKey("Location")]
        public int? LocationId
        {
            get;
            set;
        }



        public string Size
        {
            get;
            set;
        }

        public decimal Quantity
        {
            get;
            set;
        }

        [ForeignKey("CompanyType")]
        public int CompanyTypeID
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

        

        public Location Location
        {
            get;
            set;
        }

        public ItemMaster ItemMaster
        {
            get;
            set;
        }

        public CompanyType CompanyType
        {
            get;
            set;
        }

        public Boolean IsActive
        { get; set; }

    }
}
