using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Company
    {
        public Company()
        {
            Identity = -1;
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        public string CompanyName
        {
            get;
            set;
        }

        [ForeignKey("Location")]
        public int LocationID
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

        public Location Location
        {
            get;
            set;
        }
    }
}