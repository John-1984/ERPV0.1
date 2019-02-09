using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Vendor
    {
        public Vendor()
        {
          
        }

        private static List<BusinessModels.Vendor> Vendors = new List<BusinessModels.Vendor>();

       

        public BusinessModels.Vendor GetVendor(Int32 identity)
        {
            return Vendors.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Vendor> GetAll()
        {
            return Vendors;
        }

        public Boolean Delete(Int32 identity)
        {
            Vendors.Remove(Vendors.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Vendor Vendor)
        {
            Vendors.Remove(Vendors.Find(p => p.Identity.Equals(Vendor.Identity)));
            Vendors.Add(Vendor);
            return true;
        }

        public Boolean Insert(BusinessModels.Vendor Vendor)
        {
            Vendors.Add(Vendor);
            return true;
        }

        public void TestData()
        {
            Vendors.Add(
                new BusinessModels.Vendor()
                {
                    Identity = 1,
                    VendorName = "dad",

                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1


                });
            Vendors.Add(
                new BusinessModels.Vendor()
                {
                    Identity = 2,
                    VendorName = "dad",

                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                });
            Vendors.Add(
                new BusinessModels.Vendor()
                {
                    Identity = 3,
                    VendorName = "dad",

                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                });
        }

    }


}
