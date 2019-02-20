﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class PurchaseRequest
    {
        public PurchaseRequest()
        {
            Identity = -1;
            Comments = string.Empty;
            CaseNo = string.Empty;
            SOCode = String.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
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
        public int LocationID
        {
            get;
            set;
        }

        public int PurchaseRequestType
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
        public string CaseNo
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
    }
}