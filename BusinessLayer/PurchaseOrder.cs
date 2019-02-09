using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
         
        }

        private static List<BusinessModels.PurchaseOrder> PurchaseOrders = new List<BusinessModels.PurchaseOrder>();

      
        public BusinessModels.PurchaseOrder GetPurchaseOrder(Int32 identity)
        {
            return PurchaseOrders.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.PurchaseOrder> GetAll()
        {
            return PurchaseOrders;
        }

        public Boolean Delete(Int32 identity)
        {
            PurchaseOrders.Remove(PurchaseOrders.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.PurchaseOrder PurchaseOrder)
        {
            PurchaseOrders.Remove(PurchaseOrders.Find(p => p.Identity.Equals(PurchaseOrder.Identity)));
            PurchaseOrders.Add(PurchaseOrder);
            return true;
        }

        public Boolean Insert(BusinessModels.PurchaseOrder PurchaseOrder)
        {
            PurchaseOrders.Add(PurchaseOrder);
            return true;
        }

        public void TestData()
        {
            PurchaseOrders.Add(
                new BusinessModels.PurchaseOrder()
                {
                    Identity = 1,

                    Comments = "John",
                    LocationID = 1,
                    POCode = "Po788hyy",
                    Status = 1,
                    SupplierQuotationID = 1,
                    WarehouseID = 1,
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            PurchaseOrders.Add(
                new BusinessModels.PurchaseOrder()
                {
                    Identity = 2,

                    Comments = "John",
                    LocationID = 1,
                    POCode = "Po788hyy",
                    Status = 1,
                    SupplierQuotationID = 1,
                    WarehouseID = 1,
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            PurchaseOrders.Add(
                new BusinessModels.PurchaseOrder()
                {
                    Identity = 3,

                    Comments = "John",
                    LocationID = 1,
                    POCode = "Po788hyy",
                    Status = 1,
                    SupplierQuotationID = 1,
                    WarehouseID = 1,
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
