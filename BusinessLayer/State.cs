using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class State
    {
        public State()
        {
            if (States == null)
                TestData();
        }
        private static List<BusinessModels.State> States = new List<BusinessModels.State>();

        public BusinessModels.State GetState(Int32 identity)
        {
            return States.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.State> GetAll()
        {
            return States;
        }

        public Boolean Delete(Int32 identity)
        {
            States.Remove(States.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.State State)
        {
            States.Remove(States.Find(p => p.Identity.Equals(State.Identity)));
            States.Add(State);
            return true;
        }

        public Boolean Insert(BusinessModels.State State)
        {
            States.Add(State);
            return true;
        }

        public void TestData()
        {
            States.Add(
                new BusinessModels.State()
                {
                    Identity = 1,

                    StateName = "John",
                    CountryID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            States.Add(
                new BusinessModels.State()
                {
                    Identity = 2,

                    StateName = "John",
                    CountryID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            States.Add(
                new BusinessModels.State()
                {
                    Identity = 3,

                    StateName = "John",
                    CountryID = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
