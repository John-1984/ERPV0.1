using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class IdentificationsType
    {
        private List<BusinessModels.IdentificationsType> IdentificationsTypes = new List<BusinessModels.IdentificationsType>();
        private DataLayer.IdentificationsTypeDAL _dataLayer = null;

        public IdentificationsType()
        {
            _dataLayer = new DataLayer.IdentificationsTypeDAL();
        }

        public BusinessModels.IdentificationsType GetIdentificationsType(Int32 identity)
        {
            return _dataLayer.GetIdentificationsType(identity);
        }

        public IEnumerable<BusinessModels.IdentificationsType> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.IdentificationsType IdentificationsType)
        {
            return _dataLayer.Update(IdentificationsType);
        }

        public Boolean Insert(BusinessModels.IdentificationsType IdentificationsType)
        {
            return _dataLayer.Insert(IdentificationsType);
        }



    }


}
