using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class LocalSupplier
    {
        public LocalSupplier()
        {
            Identity = -1;
            SupplierName = string.Empty;
            Email = String.Empty;
            Address = string.Empty;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string SupplierName
        {
            get;
            set;
        }
        [DefaultValue("")]
        public string Email
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string Address
        {
            get;
            set;
        }

        public int ContactNumber
        {
            get;
            set;
        }

        public int LocationID
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