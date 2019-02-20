using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Company
    {

        private List<BusinessModels.Company> Companys = new List<BusinessModels.Company>();
        private List<BusinessModels.Region> regionss = new List<BusinessModels.Region>();
        private DataLayer.CompanyDAL _dataLayer = null;
        private DataLayer.RegionDAL _regdataLayer = null;
        private DataLayer.CountryDAL _condataLayer = null;
        private DataLayer.StateDAL _statedataLayer = null;
        private DataLayer.DistrictDAL _distdataLayer = null;
        private DataLayer.LocationDAL _locdataLayer = null;
        private DataLayer.CompanyTypeDAL _comptypedataLayer = null;

        public Company()
        {
            _dataLayer = new DataLayer.CompanyDAL();
            _regdataLayer = new DataLayer.RegionDAL();
            _condataLayer = new DataLayer.CountryDAL();
            _statedataLayer = new DataLayer.StateDAL();
            _distdataLayer = new DataLayer.DistrictDAL();
            _locdataLayer = new DataLayer.LocationDAL();
            _comptypedataLayer = new DataLayer.CompanyTypeDAL();
        }

        public BusinessModels.Company GetCompany(Int32 identity)
        {
            return _dataLayer.GetCompany(identity);
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
        public IEnumerable<BusinessModels.CompanyType> GetAllCompanyType()
        {
            //TestRegionData();
            return _comptypedataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Company> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Company Company)
        {
            return _dataLayer.Update(Company);
        }

        public Boolean Insert(BusinessModels.Company Company)
        {
            return _dataLayer.Insert(Company);
        }



    }


}
