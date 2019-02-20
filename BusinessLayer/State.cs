using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class State
    {

        private List<BusinessModels.State> States = new List<BusinessModels.State>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.StateDAL _dataLayer = null;
        private DataLayer.RegionDAL _regdataLayer = null;
         private DataLayer.CountryDAL _condataLayer = null;

        public State()
        {
            _dataLayer = new DataLayer.StateDAL();
            _regdataLayer = new DataLayer.RegionDAL();
            _condataLayer = new DataLayer.CountryDAL();
        }

        public BusinessModels.State GetState(Int32 identity)
        {
            return _dataLayer.GetState(identity);
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
        public IEnumerable<BusinessModels.State> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.State State)
        {
            return _dataLayer.Update(State);
        }

        public Boolean Insert(BusinessModels.State State)
        {
            return _dataLayer.Insert(State);
        }



    }


}
