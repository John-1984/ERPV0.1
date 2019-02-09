using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class WarehouseMaster
    {
        public WarehouseMaster()
        {
           
        }


        private static List<BusinessModels.WarehouseMaster> WarehouseMasters = new List<BusinessModels.WarehouseMaster>();
       

        public BusinessModels.WarehouseMaster GetWarehouseMaster(Int32 identity)
        {
            return WarehouseMasters.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.WarehouseMaster> GetAll()
        {
            return WarehouseMasters;
        }

        public Boolean Delete(Int32 identity)
        {
            WarehouseMasters.Remove(WarehouseMasters.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.WarehouseMaster WarehouseMaster)
        {
            WarehouseMasters.Remove(WarehouseMasters.Find(p => p.Identity.Equals(WarehouseMaster.Identity)));
            WarehouseMasters.Add(WarehouseMaster);
            return true;
        }

        public Boolean Insert(BusinessModels.WarehouseMaster WarehouseMaster)
        {
            WarehouseMasters.Add(WarehouseMaster);
            return true;
        }

        public void TestData()
        {
            WarehouseMasters.Add(
                new BusinessModels.WarehouseMaster()
                {
                    Identity = 1,

                    WarehouseName = "John",
                    LocationID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
            ModifiedDate=DateTime.Now,
            ModifiedBy=1
                    
                });
            WarehouseMasters.Add(
                new BusinessModels.WarehouseMaster()
                {
                    Identity = 2,

                    WarehouseName = "John",
                    LocationID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            WarehouseMasters.Add(
                new BusinessModels.WarehouseMaster()
                {
                    Identity = 3,

                    WarehouseName = "John",
                    LocationID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1

                });
        }

    }


}
