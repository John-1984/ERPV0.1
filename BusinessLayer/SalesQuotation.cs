using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class SalesQuotation
    {
        public SalesQuotation()
        {
            
        }
        private static List<BusinessModels.SalesQuotation> SalesQuotations = new List<BusinessModels.SalesQuotation>();

        

        public BusinessModels.SalesQuotation GetSalesQuotation(Int32 identity)
        {
            return SalesQuotations.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.SalesQuotation> GetAll()
        {
            return SalesQuotations;
        }

        public Boolean Delete(Int32 identity)
        {
            SalesQuotations.Remove(SalesQuotations.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.SalesQuotation SalesQuotation)
        {
            SalesQuotations.Remove(SalesQuotations.Find(p => p.Identity.Equals(SalesQuotation.Identity)));
            SalesQuotations.Add(SalesQuotation);
            return true;
        }

        public Boolean Insert(BusinessModels.SalesQuotation SalesQuotation)
        {
            SalesQuotations.Add(SalesQuotation);
            return true;
        }

        public void TestData()
        {
            SalesQuotations.Add(
                new BusinessModels.SalesQuotation()
                {
                    Identity = 1,

                    SOCode = "sfadf",
                    WarehouseId =1,
                    Status =1,
                    priority =1,
                    Comments ="fadsfasdaf",
                    InvoiceNo ="fddsaf",
                    CustomerID =1,
                    LocationID =1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            SalesQuotations.Add(
                new BusinessModels.SalesQuotation()
                {
                    Identity = 2,

                    SOCode = "sfadf",
                    WarehouseId = 1,
                    Status = 1,
                    priority = 1,
                    Comments = "fadsfasdaf",
                    InvoiceNo = "fddsaf",
                    CustomerID = 1,
                    LocationID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1,
                    
                });
            SalesQuotations.Add(
                new BusinessModels.SalesQuotation()
                {
                    Identity = 3,

                    SOCode = "sfadf",
                    WarehouseId = 1,
                    Status = 1,
                    priority = 1,
                    Comments = "fadsfasdaf",
                    InvoiceNo = "fddsaf",
                    CustomerID = 1,
                    LocationID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1,
                 
                });
        }

    }


}
