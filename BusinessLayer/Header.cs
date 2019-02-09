using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class Header
    {
        public Header()
        {
            
        }
        private static List<BusinessModels.Header> Headers = new List<BusinessModels.Header>();

        

        public BusinessModels.Header GetHeader(Int32 identity)
        {
            return Headers.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Header> GetAll()
        {
            return Headers;
        }

        public Boolean Delete(Int32 identity)
        {
            Headers.Remove(Headers.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Header Header)
        {
            Headers.Remove(Headers.Find(p => p.Identity.Equals(Header.Identity)));
            Headers.Add(Header);
            return true;
        }

        public Boolean Insert(BusinessModels.Header Header)
        {
            Headers.Add(Header);
            return true;
        }

        public void TestData()
        {
            Headers.Add(
                new BusinessModels.Header()
                {
                    Identity = 1,

                    LogoURL = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Headers.Add(
                new BusinessModels.Header()
                {
                    Identity = 2,

                    LogoURL = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Headers.Add(
                new BusinessModels.Header()
                {
                    Identity = 3,

                    LogoURL = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
