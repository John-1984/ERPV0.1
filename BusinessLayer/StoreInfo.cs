using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class StoreInfo
    {
        public StoreInfo()
        {
            
        }

        private static List<BusinessModels.StoreInfo> StoreInfos = new List<BusinessModels.StoreInfo>();

        public BusinessModels.StoreInfo GetStoreInfo(Int32 identity)
        {
            return StoreInfos.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.StoreInfo> GetAll()
        {
            return StoreInfos;
        }

        public Boolean Delete(Int32 identity)
        {
            StoreInfos.Remove(StoreInfos.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.StoreInfo StoreInfo)
        {
            StoreInfos.Remove(StoreInfos.Find(p => p.Identity.Equals(StoreInfo.Identity)));
            StoreInfos.Add(StoreInfo);
            return true;
        }

        public Boolean Insert(BusinessModels.StoreInfo StoreInfo)
        {
            StoreInfos.Add(StoreInfo);
            return true;
        }

        public void TestData()
        {
            StoreInfos.Add(
                new BusinessModels.StoreInfo()
                {
                    Identity = 1,

                    Storetype = 1,
                    StoreName = "John",
                    LocationID=1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            StoreInfos.Add(
                new BusinessModels.StoreInfo()
                {
                    Identity = 2,

                    Storetype = 1,
                    StoreName = "John",
                    LocationID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            StoreInfos.Add(
                new BusinessModels.StoreInfo()
                {
                    Identity = 3,

                    Storetype = 1,
                    StoreName = "John",
                    LocationID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
