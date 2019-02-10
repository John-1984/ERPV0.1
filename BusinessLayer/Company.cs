using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Company
    {
        public Company()
        {
            
        }

        private static List<BusinessModels.Company> Companys = new List<BusinessModels.Company>();

        public BusinessModels.Company GetCompany(Int32 identity)
        {
            return Companys.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Company> GetAll()
        {
            return Companys;
        }

        public Boolean Delete(Int32 identity)
        {
            Companys.Remove(Companys.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Company Company)
        {
            Companys.Remove(Companys.Find(p => p.Identity.Equals(Company.Identity)));
            Companys.Add(Company);
            return true;
        }

        public Boolean Insert(BusinessModels.Company Company)
        {
            Companys.Add(Company);
            return true;
        }

        public void TestData()
        {
            Companys.Add(
                new BusinessModels.Company()
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
            Companys.Add(
                new BusinessModels.Company()
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
            Companys.Add(
                new BusinessModels.Company()
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
