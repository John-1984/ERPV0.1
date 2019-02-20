using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class FloorMaster
    {

        private List<BusinessModels.FloorMaster> FloorMasters = new List<BusinessModels.FloorMaster>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.FloorMasterDAL _dataLayer = null;
        private DataLayer.CompanyDAL _compdataLayer = null;
        private DataLayer.CompanyTypeDAL _comptypedataLayer = null;
       

        public FloorMaster()
        {
            _dataLayer = new DataLayer.FloorMasterDAL();
            _compdataLayer = new DataLayer.CompanyDAL();
            _comptypedataLayer = new DataLayer.CompanyTypeDAL();
            
        }

        public BusinessModels.FloorMaster GetFloorMaster(Int32 identity)
        {
            return _dataLayer.GetFloorMaster(identity);
        }
        public IEnumerable<BusinessModels.Company> GetAllCompanies()
        {
            //TestRegionData();
            return _compdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.CompanyType> GetAllCompanyTypes()
        {
            //TestRegionData();
            return _comptypedataLayer.GetAll();
        }
        
        public IEnumerable<BusinessModels.FloorMaster> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.FloorMaster FloorMaster)
        {
            return _dataLayer.Update(FloorMaster);
        }

        public Boolean Insert(BusinessModels.FloorMaster FloorMaster)
        {
            return _dataLayer.Insert(FloorMaster);
        }



    }


}
