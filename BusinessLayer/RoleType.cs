using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class RoleType
    {
        private List<BusinessModels.RoleType> RoleTypes = new List<BusinessModels.RoleType>();
        private DataLayer.RoleTypeDAL _dataLayer = null;

        public RoleType()
        {
            _dataLayer = new DataLayer.RoleTypeDAL();
        }

        public BusinessModels.RoleType GetRoleType(Int32 identity)
        {
            return _dataLayer.GetRoleType(identity);
        }

        public IEnumerable<BusinessModels.RoleType> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.RoleType RoleType)
        {
            return _dataLayer.Update(RoleType);
        }

        public Boolean Insert(BusinessModels.RoleType RoleType)
        {
            return _dataLayer.Insert(RoleType);
        }



    }


}
