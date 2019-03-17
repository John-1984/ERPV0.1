using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Region
    {
        private List<BusinessModels.Region> Regions = new List<BusinessModels.Region>();
        private DataLayer.RegionDAL _dataLayer = null;

        public Region()
        {
            _dataLayer = new DataLayer.RegionDAL();
        }

        public BusinessModels.Region GetRegion(Int32 identity)
        {
            return _dataLayer.GetRegion(identity);
        }
        public IEnumerable<BusinessModels.Region> GetMatchingRegions(string prefix)
        {
            return _dataLayer.GetMatchingRegions(prefix);
        }
        public IEnumerable<BusinessModels.Region> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Region Region)
        {
            return _dataLayer.Update(Region);
        }

        public Boolean Insert(BusinessModels.Region Region)
        {
            return _dataLayer.Insert(Region);
        }

      

    }


}
