using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class LocalSupplier
    {

        private List<BusinessModels.LocalSupplier> LocalSuppliers = new List<BusinessModels.LocalSupplier>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.LocalSupplierDAL _dataLayer = null;
        private DataLayer.ItemMasterDAL _itemdataLayer = null;
        private DataLayer.LocationDAL _locdataLayer = null;
        private DataLayer.RegionDAL _regdataLayer = null;
        private DataLayer.CountryDAL _condataLayer = null;
        private DataLayer.StateDAL _statedataLayer = null;
        private DataLayer.DistrictDAL _distdataLayer = null;

        public LocalSupplier()
        {
            _dataLayer = new DataLayer.LocalSupplierDAL();
            _itemdataLayer = new DataLayer.ItemMasterDAL();
            _locdataLayer = new DataLayer.LocationDAL();
            _regdataLayer = new DataLayer.RegionDAL();
            _condataLayer = new DataLayer.CountryDAL();
            _statedataLayer = new DataLayer.StateDAL();
            _distdataLayer = new DataLayer.DistrictDAL();

        }

        public BusinessModels.LocalSupplier GetLocalSupplier(Int32 identity)
        {
            return _dataLayer.GetLocalSupplier(identity);
        }
        public IEnumerable<BusinessModels.ItemMaster> GetAllItemMaster()
        {
            //TestRegionData();
            return _itemdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Location> GetAlllocations()
        {
            //TestRegionData();
            return _locdataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.Country> GetAllCountrysOnRegion(string identity)
        {
            //TestRegionData();
            return _condataLayer.GetAll(int.Parse(identity));
        }
        public IEnumerable<BusinessModels.State> GetAllStatesOnCountry(string identity)
        {
            //TestRegionData();
            return _statedataLayer.GetAll(int.Parse(identity));
        }

        public IEnumerable<BusinessModels.District> GetAllDistrictsOnState(string identity)
        {
            //TestRegionData();
            return _distdataLayer.GetAll(int.Parse(identity));
        }

        public IEnumerable<BusinessModels.Location> GetAllLocationsOnDistrict(string identity)
        {
            //TestRegionData();
            return _locdataLayer.GetAll(int.Parse(identity));
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
        public IEnumerable<BusinessModels.LocalSupplier> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.LocalSupplier> GetAllLocalSupplierOnAItem(string fldidentity)
        {
            return _dataLayer.GetAll(int.Parse(fldidentity));
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.LocalSupplier LocalSupplier)
        {
            return _dataLayer.Update(LocalSupplier);
        }

        public Boolean Insert(BusinessModels.LocalSupplier LocalSupplier)
        {
            return _dataLayer.Insert(LocalSupplier);
        }



    }


}
