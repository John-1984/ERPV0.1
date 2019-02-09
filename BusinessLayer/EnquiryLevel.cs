using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class EnquiryLevel
    {
        public EnquiryLevel()
        {
          
        }
        private static List<BusinessModels.EnquiryLevel> EnquiryLevels = new List<BusinessModels.EnquiryLevel>();

       

        public BusinessModels.EnquiryLevel GetEnquiryLevel(Int32 identity)
        {
            return EnquiryLevels.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.EnquiryLevel> GetAll()
        {
            return EnquiryLevels;
        }

        public Boolean Delete(Int32 identity)
        {
            EnquiryLevels.Remove(EnquiryLevels.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.EnquiryLevel EnquiryLevel)
        {
            EnquiryLevels.Remove(EnquiryLevels.Find(p => p.Identity.Equals(EnquiryLevel.Identity)));
            EnquiryLevels.Add(EnquiryLevel);
            return true;
        }

        public Boolean Insert(BusinessModels.EnquiryLevel EnquiryLevel)
        {
            EnquiryLevels.Add(EnquiryLevel);
            return true;
        }

        public void TestData()
        {
            EnquiryLevels.Add(
                new BusinessModels.EnquiryLevel()
                {
                    Identity = 1,

                    EnquiryLevelName = "John"
                    
                });
            EnquiryLevels.Add(
                new BusinessModels.EnquiryLevel()
                {
                    Identity = 2,

                    EnquiryLevelName = "John"
                });
            EnquiryLevels.Add(
                new BusinessModels.EnquiryLevel()
                {
                    Identity = 3,

                    EnquiryLevelName = "John"
                });
        }

    }


}
