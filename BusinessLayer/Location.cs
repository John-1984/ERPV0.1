using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Location
    {

        private List<BusinessModels.Location> Locations = new List<BusinessModels.Location>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.LocationDAL _dataLayer = null;
        private DataLayer.RegionDAL _regdataLayer = null;
        private DataLayer.CountryDAL _condataLayer = null;
        private DataLayer.StateDAL _statedataLayer = null;
        private DataLayer.DistrictDAL _dstdataLayer = null;

        public Location()
        {
            _dataLayer = new DataLayer.LocationDAL();
            _regdataLayer = new DataLayer.RegionDAL();
            _condataLayer = new DataLayer.CountryDAL();
            _statedataLayer = new DataLayer.StateDAL();
            _dstdataLayer = new DataLayer.DistrictDAL();
        }

        public BusinessModels.Location GetLocation(Int32 identity)
        {
            return _dataLayer.GetLocation(identity);
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
            return _dstdataLayer.GetAll(int.Parse(identity));
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
        public IEnumerable<BusinessModels.State> GetAllStates()
        {
            //TestRegionData();
            return _statedataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.District> GetAllDistrict()
        {
            //TestRegionData();
            return _dstdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Location> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Location Location)
        {
            return _dataLayer.Update(Location);
        }

        public Boolean Insert(BusinessModels.Location Location)
        {
            return _dataLayer.Insert(Location);
        }



    }


}
