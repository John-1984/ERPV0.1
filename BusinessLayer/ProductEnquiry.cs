using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class ProductEnquiry
    {
        public ProductEnquiry()
        {
            
        }

        private static List<BusinessModels.ProductEnquiry> ProductEnquirys = new List<BusinessModels.ProductEnquiry>();

      

        public BusinessModels.ProductEnquiry GetProductEnquiry(Int32 identity)
        {
            return ProductEnquirys.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.ProductEnquiry> GetAll()
        {
            return ProductEnquirys;
        }

        public Boolean Delete(Int32 identity)
        {
            ProductEnquirys.Remove(ProductEnquirys.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.ProductEnquiry ProductEnquiry)
        {
            ProductEnquirys.Remove(ProductEnquirys.Find(p => p.Identity.Equals(ProductEnquiry.Identity)));
            ProductEnquirys.Add(ProductEnquiry);
            return true;
        }

        public Boolean Insert(BusinessModels.ProductEnquiry ProductEnquiry)
        {
            ProductEnquirys.Add(ProductEnquiry);
            return true;
        }

        public void TestData()
        {
            ProductEnquirys.Add(
                new BusinessModels.ProductEnquiry()
                {
                    Identity = 1,

                    Comments = "djkasmnas",
                    CustomerInfoId = 1,
                    EnquiryLevel = 1,
                    LocationId = 1,
                    Status = 1,                   
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            ProductEnquirys.Add(
                new BusinessModels.ProductEnquiry()
                {
                    Identity = 2,

                    Comments = "djkasmnas",
                    CustomerInfoId = 1,
                    EnquiryLevel = 1,
                    LocationId = 1,
                    Status = 1,
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
            ProductEnquirys.Add(
                new BusinessModels.ProductEnquiry()
                {
                    Identity = 3,

                    Comments = "djkasmnas",
                    CustomerInfoId = 1,
                    EnquiryLevel = 1,
                    LocationId = 1,
                    Status = 1,
                    AssignedTo = 1,
                    VerifiedBy = 1,
                    ApprovedBy = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                });
        }

    }


}
