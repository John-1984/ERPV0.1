using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Country
    {

        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private  List<BusinessModels.Region> regionss = new List<BusinessModels.Region>();
        private DataLayer.CountryDAL _dataLayer = null;
        private DataLayer.RegionDAL _regdataLayer = null;

        public Country()
        {
            _dataLayer = new DataLayer.CountryDAL();
            _regdataLayer = new DataLayer.RegionDAL();
        }

        public BusinessModels.Country GetCountry(Int32 identity)
        {
            return _dataLayer.GetCountry(identity);
        }
        public IEnumerable<BusinessModels.Region> GetAllRegions()
        {
            //TestRegionData();
            return _regdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Country> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Country Country)
        {
            return _dataLayer.Update(Country);
        }

        public Boolean Insert(BusinessModels.Country Country)
        {
            return _dataLayer.Insert(Country);
        }



    }


}
