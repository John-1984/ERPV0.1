using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class RoleMaster
    {

        private List<BusinessModels.RoleMaster> RoleMasters = new List<BusinessModels.RoleMaster>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.RoleMasterDAL _dataLayer = null;
        private DataLayer.RegionDAL _regdataLayer = null;
        private DataLayer.RoleTypeDAL _roletypedataLayer = null;
        private DataLayer.ModulesDAL _modulesdataLayer = null;

        public RoleMaster()
        {
            _dataLayer = new DataLayer.RoleMasterDAL();
            _regdataLayer = new DataLayer.RegionDAL();
            _roletypedataLayer = new DataLayer.RoleTypeDAL();
            _modulesdataLayer = new DataLayer.ModulesDAL();
        }

        public BusinessModels.RoleMaster GetRoleMaster(Int32 identity)
        {
            return _dataLayer.GetRoleMaster(identity);
        }
        public IEnumerable<BusinessModels.Modules> GetAllModules()
        {
            //TestRegionData();
            return _modulesdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Region> GetAllRegionss()
        {
            //TestRegionData();
            return _regdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.RoleType> GetAllRoleTypes()
        {
            //TestRegionData();
            return _roletypedataLayer.GetAll();
        }
       
        public IEnumerable<BusinessModels.RoleMaster> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.RoleMaster RoleMaster)
        {
            return _dataLayer.Update(RoleMaster);
        }

        public Boolean Insert(BusinessModels.RoleMaster RoleMaster)
        {
            return _dataLayer.Insert(RoleMaster);
        }



    }


}
