using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class PaymentType
    {
        private List<BusinessModels.PaymentType> PaymentTypes = new List<BusinessModels.PaymentType>();
        private DataLayer.PaymentTypeDAL _dataLayer = null;

        public PaymentType()
        {
            _dataLayer = new DataLayer.PaymentTypeDAL();
        }

        public BusinessModels.PaymentType GetPaymentType(Int32 identity)
        {
            return _dataLayer.GetPaymentType(identity);
        }

        public IEnumerable<BusinessModels.PaymentType> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.PaymentType PaymentType)
        {
            return _dataLayer.Update(PaymentType);
        }

        public Boolean Insert(BusinessModels.PaymentType PaymentType)
        {
            return _dataLayer.Insert(PaymentType);
        }

      

    }


}
