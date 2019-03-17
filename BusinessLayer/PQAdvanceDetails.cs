using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class PQAdvanceDetails
    {
        private List<BusinessModels.PQAdvanceDetails> PQAdvanceDetailss = new List<BusinessModels.PQAdvanceDetails>();
        private DataLayer.PQAdvanceDetailsDAL _dataLayer = null;

        public PQAdvanceDetails()
        {
            _dataLayer = new DataLayer.PQAdvanceDetailsDAL();
        }

        public BusinessModels.PQAdvanceDetails GetPQAdvanceDetails(Int32 identity)
        {
            return _dataLayer.GetPQAdvanceDetails(identity);
        }

        public IEnumerable<BusinessModels.PQAdvanceDetails> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.PQAdvanceDetails> GetAllAdvanceByPQ(int? identity)
        {
            return _dataLayer.GetAllAdvanceByPQ(identity);
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.PQAdvanceDetails PQAdvanceDetails)
        {
            return _dataLayer.Update(PQAdvanceDetails);
        }

        public Boolean Insert(BusinessModels.PQAdvanceDetails PQAdvanceDetails)
        {
            return _dataLayer.Insert(PQAdvanceDetails);
        }

      

    }


}
