using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class SalesRoleType
    {
        private List<BusinessModels.SalesRoleType> SalesRoleTypes = new List<BusinessModels.SalesRoleType>();
        private DataLayer.SalesRoleTypeDAL _dataLayer = null;

        public SalesRoleType()
        {
            _dataLayer = new DataLayer.SalesRoleTypeDAL();
        }

        public BusinessModels.SalesRoleType GetSalesRoleType(Int32 identity)
        {
            return _dataLayer.GetSalesRoleType(identity);
        }

        public IEnumerable<BusinessModels.SalesRoleType> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.SalesRoleType SalesRoleType)
        {
            return _dataLayer.Update(SalesRoleType);
        }

        public Boolean Insert(BusinessModels.SalesRoleType SalesRoleType)
        {
            return _dataLayer.Insert(SalesRoleType);
        }



    }


}
