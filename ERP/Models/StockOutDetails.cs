using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class StockOutDetails
    {
        public StockOutDetails()
        {
            Identity = -1;
            ContainerNo = string.Empty;
            VehicleNo = string.Empty;
            DisapatchTime = string.Empty;
            DriverName = string.Empty;
            DriverLicenceNumber = string.Empty;
            AdditionalAmountPaid = 0;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }
        public int CompletedWorkFlowID
        { get; set; }
        public int? SQID
        {
            get;
            set;
        }


        public string ContainerNo
        {
            get;
            set;
        }

        public string VehicleNo
        {
            get;
            set;
        }

        public string DisapatchTime
        {
            get;
            set;
        }

        public string DriverName
        {
            get;
            set;
        }

        public string DriverLicenceNumber
        {
            get;
            set;
        }

        public decimal AdditionalAmountPaid
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


        public bool IsActive
        {
            get;
            set;
        }

        public SalesQuotation SalesQuotation
        { get; set; }

    }
}