﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class CompanyType
    {
        public CompanyType()
        {
           // Identity = -1;
           // TypeName = string.Empty;
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        public string TypeName
        {
            get;
            set;
        }

        [ForeignKey("Company")]
        public int CompanyID
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

        public Company Company
        {
            get;
            set;
        }

    }
}