using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class StockOutDetails
    {
        public StockOutDetails()
        {

        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }


        [ForeignKey("SalesQuotation")]
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

        public int CompletedWorkFlowID
        { get; set; }

    }
    
}