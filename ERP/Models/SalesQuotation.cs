using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class SalesQuotation
    {
        public SalesQuotation()
        {
            Identity = -1;
            SOCode = string.Empty;
            InvoiceNo = String.Empty;
            Comments = String.Empty;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string SOCode
        {
            get;
            set;
        }
        public int WarehouseId
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public int priority
        {
            get;
            set;
        }
        [DefaultValue("")]
        public string Comments
        {
            get;
            set;
        }
        [DefaultValue("")]
        public string InvoiceNo
        {
            get;
            set;
        }

        public int CustomerID
        {
            get;
            set;
        }

        public int LocationID
        {
            get;
            set;
        }
        public int AssignedTo
        {
            get;
            set;
        }
        public int VerifiedBy
        {
            get;
            set;
        }
        public int ApprovedBy
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