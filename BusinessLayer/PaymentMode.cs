using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class PaymentMode
    {
        private List<BusinessModels.PaymentMode> PaymentModes = new List<BusinessModels.PaymentMode>();
        private DataLayer.PaymentModeDAL _dataLayer = null;

        public PaymentMode()
        {
            _dataLayer = new DataLayer.PaymentModeDAL();
        }

        public BusinessModels.PaymentMode GetPaymentMode(Int32 identity)
        {
            return _dataLayer.GetPaymentMode(identity);
        }

        public IEnumerable<BusinessModels.PaymentMode> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.PaymentMode PaymentMode)
        {
            return _dataLayer.Update(PaymentMode);
        }

        public Boolean Insert(BusinessModels.PaymentMode PaymentMode)
        {
            return _dataLayer.Insert(PaymentMode);
        }

      

    }


}
