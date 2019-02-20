using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class PurchaseRequestType
    {
        private List<BusinessModels.PurchaseRequestType> PurchaseRequestTypes = new List<BusinessModels.PurchaseRequestType>();
        private DataLayer.PurchaseRequestTypeDAL _dataLayer = null;

        public PurchaseRequestType()
        {
            _dataLayer = new DataLayer.PurchaseRequestTypeDAL();
        }

        public BusinessModels.PurchaseRequestType GetPurchaseRequestType(Int32 identity)
        {
            return _dataLayer.GetPurchaseRequestType(identity);
        }

        public IEnumerable<BusinessModels.PurchaseRequestType> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.PurchaseRequestType PurchaseRequestType)
        {
            return _dataLayer.Update(PurchaseRequestType);
        }

        public Boolean Insert(BusinessModels.PurchaseRequestType PurchaseRequestType)
        {
            return _dataLayer.Insert(PurchaseRequestType);
        }



    }


}
