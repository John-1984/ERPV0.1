using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class SupplierQuotation
    {
        public SupplierQuotation()
        {
           
        }
        private static List<BusinessModels.SupplierQuotation> SupplierQuotations = new List<BusinessModels.SupplierQuotation>();


        public BusinessModels.SupplierQuotation GetSupplierQuotation(Int32 identity)
        {
            return SupplierQuotations.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.SupplierQuotation> GetAll()
        {
            return SupplierQuotations;
        }

        public Boolean Delete(Int32 identity)
        {
            SupplierQuotations.Remove(SupplierQuotations.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.SupplierQuotation SupplierQuotation)
        {
            SupplierQuotations.Remove(SupplierQuotations.Find(p => p.Identity.Equals(SupplierQuotation.Identity)));
            SupplierQuotations.Add(SupplierQuotation);
            return true;
        }

        public Boolean Insert(BusinessModels.SupplierQuotation SupplierQuotation)
        {
            SupplierQuotations.Add(SupplierQuotation);
            return true;
        }

        public void TestData()
        {
            SupplierQuotations.Add(
                new BusinessModels.SupplierQuotation()
                {
                    Identity = 1,

                    Comments = "dsfsfadfa",
                    SOCOde ="dss93934sdff",
                    InvoiceNo ="4oodssfd",
                    WarehouseId =1,
                    Status =1,
                    Priority =1,
                    locationId =1,
                    AssignedTo =1,
                    VerifiedBy =1,
                    ApprovedBy =1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            SupplierQuotations.Add(
                new BusinessModels.SupplierQuotation()
                {
                    Identity = 2,

                    Comments = "dsfsfadfa",
                    SOCOde = "dss93934sdff",
                    InvoiceNo = "4oodssfd",
                    WarehouseId = 1,
                    Status = 1,
                    Priority = 1,
                    locationId = 1,
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            SupplierQuotations.Add(
                new BusinessModels.SupplierQuotation()
                {
                    Identity = 3,

                    Comments = "dsfsfadfa",
                    SOCOde = "dss93934sdff",
                    InvoiceNo = "4oodssfd",
                    WarehouseId = 1,
                    Status = 1,
                    Priority = 1,
                    locationId = 1,
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
