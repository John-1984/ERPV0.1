using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class SupplierQuotation
    {
        public SupplierQuotation()
        {
            Identity = -1;
            SOCOde = string.Empty;
            InvoiceNo = string.Empty;
            Comments = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
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
        public string SOCOde
        {
            get;
            set;
        }

        public string InvoiceNo
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

        public int Priority
        {
            get;
            set;
        }
        public int locationId
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