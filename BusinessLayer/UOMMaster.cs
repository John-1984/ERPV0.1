using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class UOMMaster
    {
        private List<BusinessModels.UOMMaster> UOMMasters = new List<BusinessModels.UOMMaster>();
        private DataLayer.UOMMasterDAL _dataLayer = null;

        public UOMMaster()
        {
            _dataLayer = new DataLayer.UOMMasterDAL();
        }

        public BusinessModels.UOMMaster GetUOMMaster(Int32 identity)
        {
            return _dataLayer.GetUOMMaster(identity);
        }

        public IEnumerable<BusinessModels.UOMMaster> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.UOMMaster UOMMaster)
        {
            return _dataLayer.Update(UOMMaster);
        }

        public Boolean Insert(BusinessModels.UOMMaster UOMMaster)
        {
            return _dataLayer.Insert(UOMMaster);
        }



    }


}
