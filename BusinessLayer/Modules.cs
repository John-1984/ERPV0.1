using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class Modules
    {
        public Modules()
        {
            
        }
        private static List<BusinessModels.Modules> Moduless = new List<BusinessModels.Modules>();

       

        public BusinessModels.Modules GetModules(Int32 identity)
        {
            return Moduless.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Modules> GetAll()
        {
            return Moduless;
        }

        public Boolean Delete(Int32 identity)
        {
            Moduless.Remove(Moduless.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Modules Modules)
        {
            Moduless.Remove(Moduless.Find(p => p.Identity.Equals(Modules.Identity)));
            Moduless.Add(Modules);
            return true;
        }

        public Boolean Insert(BusinessModels.Modules Modules)
        {
            Moduless.Add(Modules);
            return true;
        }

        public void TestData()
        {
            Moduless.Add(
                new BusinessModels.Modules()
                {
                    Identity = 1,

                    ModuleName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Moduless.Add(
                new BusinessModels.Modules()
                {
                    Identity = 2,

                    ModuleName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            Moduless.Add(
                new BusinessModels.Modules()
                {
                    Identity = 3,

                    ModuleName = "John",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
