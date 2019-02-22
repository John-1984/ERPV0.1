using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class District
    {

        private List<BusinessModels.District> Districts = new List<BusinessModels.District>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.DistrictDAL _dataLayer = null;
        private DataLayer.RegionDAL _regdataLayer = null;
        private DataLayer.CountryDAL _condataLayer = null;
        private DataLayer.StateDAL _statedataLayer = null;

        public District()
        {
            _dataLayer = new DataLayer.DistrictDAL();
            _regdataLayer = new DataLayer.RegionDAL();
            _condataLayer = new DataLayer.CountryDAL();
            _statedataLayer = new DataLayer.StateDAL();
        }

        public BusinessModels.District GetDistrict(Int32 identity)
        {
            return _dataLayer.GetDistrict(identity);
        }
        public IEnumerable<BusinessModels.Country> GetAllCountrys()
        {
            //TestRegionData();
            return _condataLayer.GetAll();
        }

       
        public IEnumerable<BusinessModels.Region> GetAllRegionss()
        {
            //TestRegionData();
            return _regdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.State> GetAllState()
        {
            //TestRegionData();
            return _statedataLayer.GetAll();
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
        public IEnumerable<BusinessModels.District> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.District District)
        {
            return _dataLayer.Update(District);
        }

        public Boolean Insert(BusinessModels.District District)
        {
            return _dataLayer.Insert(District);
        }



    }


}
