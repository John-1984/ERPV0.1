using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Tax
    {
        public Tax()
        {
          
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        
        public decimal TaxValue 
        {
            get;
            set;
        }

        public String ItemName
        {
            get;
            set;
        }

        public int ItemID
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