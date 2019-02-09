using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace ERP.Models
{
    public class ProductEnquiry
    {
        public ProductEnquiry()
        {
            Identity = -1;
            Comments = string.Empty;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public String Comments
        {
            get;
            set;
        }

        public int CustomerInfoId
        {
            get;
            set;
        }

        public int EnquiryLevel
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }


        public int LocationId
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