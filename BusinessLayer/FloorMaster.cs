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
        private DataLayer.RegionDAL _regdataLayer = null;
        private DataLayer.CountryDAL _condataLayer = null;
        private DataLayer.StateDAL _statedataLayer = null;
        private DataLayer.DistrictDAL _distdataLayer = null;
        private DataLayer.LocationDAL _locdataLayer = null;


        public FloorMaster()
        {
            _dataLayer = new DataLayer.FloorMasterDAL();
            _compdataLayer = new DataLayer.CompanyDAL();
            _comptypedataLayer = new DataLayer.CompanyTypeDAL();

            _regdataLayer = new DataLayer.RegionDAL();
            _condataLayer = new DataLayer.CountryDAL();
            _statedataLayer = new DataLayer.StateDAL();
            _distdataLayer = new DataLayer.DistrictDAL();
            _locdataLayer = new DataLayer.LocationDAL();

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

        public IEnumerable<BusinessModels.Region> GetAllRegions()
        {
            //TestRegionData();
            return _regdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Country> GetAllCountry()
        {
            //TestRegionData();
            return _condataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.State> GetAllStates()
        {
            //TestRegionData();
            return _statedataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.District> GetAllDistrict()
        {
            //TestRegionData();
            return _distdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Location> GetAllLocaton()
        {
            //TestRegionData();
            return _locdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.CompanyType> GetAllCompanyTypes()
        {
            //TestRegionData();
            return _comptypedataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.Country> GetAllCountrys(string identity)
        {
            //TestRegionData();
            return _condataLayer.GetAll(int.Parse(identity));
        }
        public IEnumerable<BusinessModels.State> GetAllStates(string identity)
        {
            //TestRegionData();
            return _statedataLayer.GetAll(int.Parse(identity));
        }

        public IEnumerable<BusinessModels.District> GetAllDistricts(string identity)
        {
            //TestRegionData();
            return _distdataLayer.GetAll(int.Parse(identity));
        }

        public IEnumerable<BusinessModels.Location> GetAllLocations(string identity)
        {
            //TestRegionData();
            return _locdataLayer.GetAll(int.Parse(identity));
        }

        public IEnumerable<BusinessModels.Company> GetAllCompanies(string identity)
        {
            //TestRegionData();
            return _compdataLayer.GetAll(int.Parse(identity));
        }

        public IEnumerable<BusinessModels.CompanyType> GetAllCompanyTypes(string identity)
        {
            //TestRegionData();
            return _comptypedataLayer.GetAll(int.Parse(identity));
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
