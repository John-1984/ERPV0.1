using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class SQAdvanceDetails
    {
        private List<BusinessModels.SQAdvanceDetails> SQAdvanceDetailss = new List<BusinessModels.SQAdvanceDetails>();
        private DataLayer.SQAdvanceDetailsDAL _dataLayer = null;

        public SQAdvanceDetails()
        {
            _dataLayer = new DataLayer.SQAdvanceDetailsDAL();
        }

        public BusinessModels.SQAdvanceDetails GetSQAdvanceDetails(Int32 identity)
        {
            return _dataLayer.GetSQAdvanceDetails(identity);
        }

        public IEnumerable<BusinessModels.SQAdvanceDetails> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.SQAdvanceDetails> GetAllAdvanceBySQ(int? identity)
        {
            return _dataLayer.GetAllAdvanceBySQ(identity);
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.SQAdvanceDetails SQAdvanceDetails)
        {
            return _dataLayer.Update(SQAdvanceDetails);
        }

        public Boolean Insert(BusinessModels.SQAdvanceDetails SQAdvanceDetails)
        {
            return _dataLayer.Insert(SQAdvanceDetails);
        }

      

    }


}
