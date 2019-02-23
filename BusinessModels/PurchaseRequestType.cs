﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class PurchaseRequestType
    {
        public PurchaseRequestType()
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


    }
}