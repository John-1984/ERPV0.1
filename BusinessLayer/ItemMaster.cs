using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class ItemMaster
    {
        public ItemMaster()
        {
           
        }

        private static List<BusinessModels.ItemMaster> ItemMasters = new List<BusinessModels.ItemMaster>();


        public BusinessModels.ItemMaster GetItemMaster(Int32 identity)
        {
            return ItemMasters.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.ItemMaster> GetAll()
        {
            return ItemMasters;
        }

        public Boolean Delete(Int32 identity)
        {
            ItemMasters.Remove(ItemMasters.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.ItemMaster ItemMaster)
        {
            ItemMasters.Remove(ItemMasters.Find(p => p.Identity.Equals(ItemMaster.Identity)));
            ItemMasters.Add(ItemMaster);
            return true;
        }

        public Boolean Insert(BusinessModels.ItemMaster ItemMaster)
        {
            ItemMasters.Add(ItemMaster);
            return true;
        }

        public void TestData()
        {
            ItemMasters.Add(
                new BusinessModels.ItemMaster()
                {
                    BrandID = 1,
                    Description = "sfdfsaf",
                    ItemName = "Mumbai",
                    ItemSize = "Engg",
                    ItemWeight = Convert.ToDecimal("0.00"),
                    PurchacePrice = Convert.ToDecimal("0.00"),
                    UOMID =1,
                    RetailPrice= Convert.ToDecimal("0.00"),
                    WarrantyID=1,                    
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    Identity = 1,

                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            ItemMasters.Add(
                new BusinessModels.ItemMaster()
                {
                    BrandID = 1,
                    Description = "sfdfsaf",
                    ItemName = "Mumbai",
                    ItemSize = "Engg",
                    Identity = 2,

                    ItemWeight = Convert.ToDecimal("0.00"),
                    PurchacePrice = Convert.ToDecimal("0.00"),
                    UOMID = 1,
                    RetailPrice = Convert.ToDecimal("0.00"),
                    WarrantyID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            ItemMasters.Add(
                new BusinessModels.ItemMaster()
                {
                    BrandID = 1,
                    Identity = 3,

                    Description = "sfdfsaf",
                    ItemName = "Mumbai",
                    ItemSize = "Engg",
                    ItemWeight = Convert.ToDecimal("0.00"),
                    PurchacePrice = Convert.ToDecimal("0.00"),
                    UOMID = 1,
                    RetailPrice = Convert.ToDecimal("0.00"),
                    WarrantyID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
