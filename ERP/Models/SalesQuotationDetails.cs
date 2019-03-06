using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class SalesQuotationDetails
    {
        public SalesQuotationDetails()
        {
            Identity = -1;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }


        public string InvoiceNo
        {
            get;
            set;
        }
        public int WareHouseID
        {
            get;
            set;
        }

        public int SQID
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
        public bool IsActive
        {
            get;
            set;
        }
        public SalesQuotation SalesQuotation
        { get; set; }
    }
}