using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class CompanyType
    {
        private static List<BusinessModels.CompanyType> CompanyTypes = new List<BusinessModels.CompanyType>();
        private DataLayer.CompanyTypeDAL _dataLayer = null;
        private DataLayer.CompanyDAL _compdataLayer = null;
        private DataLayer.RegionDAL _regdataLayer = null;
        private DataLayer.CountryDAL _condataLayer = null;
        private DataLayer.StateDAL _statedataLayer = null;
        private DataLayer.DistrictDAL _distdataLayer = null;
        private DataLayer.LocationDAL _locdataLayer = null;

        public CompanyType()
        {
            _dataLayer = new DataLayer.CompanyTypeDAL();
            _compdataLayer = new DataLayer.CompanyDAL();
            _regdataLayer = new DataLayer.RegionDAL();
            _condataLayer = new DataLayer.CountryDAL();
            _statedataLayer = new DataLayer.StateDAL();
            _distdataLayer = new DataLayer.DistrictDAL();
            _locdataLayer = new DataLayer.LocationDAL();
        }

        public BusinessModels.CompanyType GetCompanyType(Int32 identity)
        {
            return _dataLayer.GetCompanyType(identity);
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

        public IEnumerable<BusinessModels.Company> GetAllCompanies()
        {
            //TestRegionData();
            return _compdataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.Company> GetAllCompanys()
        {
            //TestRegionData();
            return _compdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.CompanyType> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.CompanyType CompanyType)
        {
            return _dataLayer.Update(CompanyType);
        }

        public Boolean Insert(BusinessModels.CompanyType CompanyType)
        {
            return _dataLayer.Insert(CompanyType);
        }

       

    }


}
