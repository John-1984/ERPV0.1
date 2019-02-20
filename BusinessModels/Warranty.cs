using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Warranty
    {
        public Warranty()
        {
           
           // CountryName = string.Empty;
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        
        public int WarrantyValue
        {
            get;
            set;
        }

        public int ItemID
        {
            get;
            set;
        }

        public string ItemName
        {
            get;
            set;
        }


        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }


    }
}