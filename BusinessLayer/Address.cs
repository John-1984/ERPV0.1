using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class Address
    {
        public Address()
        {
        }
        private static List<BusinessModels.Address> Addresss = new List<BusinessModels.Address>();



        public BusinessModels.Address GetAddress(Int32 identity)
        {
            return Addresss.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Address> GetAll()
        {
            return Addresss;
        }

        public Boolean Delete(Int32 identity)
        {
            Addresss.Remove(Addresss.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Address Address)
        {
            Addresss.Remove(Addresss.Find(p => p.Identity.Equals(Address.Identity)));
            Addresss.Add(Address);
            return true;
        }

        public Boolean Insert(BusinessModels.Address Address)
        {
            Addresss.Add(Address);
            return true;
        }

        public void TestData()
        {
            Addresss.Add(
                new BusinessModels.Address()
                {
                    Identity = 1,
                    Line1 = "John",
                    Line2 = "1",
                    Pincode = "1"
                   
                });
            Addresss.Add(
                new BusinessModels.Address()
                {
                    Identity = 2,
                    Line1 = "John",
                    Line2 = "1",
                    Pincode = "1"
                });
            Addresss.Add(
                new BusinessModels.Address()
                {
                    Identity = 3,
                    Line1 = "John",
                    Line2 = "1",
                    Pincode = "1"
                });
        }

    }


}
