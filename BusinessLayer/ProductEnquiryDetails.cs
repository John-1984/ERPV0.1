using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLayer
{
    public class ProductEnquiryDetails
    {
        public ProductEnquiryDetails()
        {
            
        }

        private static List<BusinessModels.ProductEnquiryDetails> ProductEnquiryDetailss = new List<BusinessModels.ProductEnquiryDetails>();


        public BusinessModels.ProductEnquiryDetails GetProductEnquiryDetails(Int32 identity)
        {
            return ProductEnquiryDetailss.FirstOrDefault(p => p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.ProductEnquiryDetails> GetAll()
        {
            return ProductEnquiryDetailss;
        }

        public Boolean Delete(Int32 identity)
        {
            ProductEnquiryDetailss.Remove(ProductEnquiryDetailss.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.ProductEnquiryDetails ProductEnquiryDetails)
        {
            ProductEnquiryDetailss.Remove(ProductEnquiryDetailss.Find(p => p.Identity.Equals(ProductEnquiryDetails.Identity)));
            ProductEnquiryDetailss.Add(ProductEnquiryDetails);
            return true;
        }

        public Boolean Insert(BusinessModels.ProductEnquiryDetails ProductEnquiryDetails)
        {
            ProductEnquiryDetailss.Add(ProductEnquiryDetails);
            return true;
        }

        public void TestData()
        {
            ProductEnquiryDetailss.Add(
                new BusinessModels.ProductEnquiryDetails()
                {
                    itemID = 1,
                    ItemPrice = Convert.ToDecimal("0.0"),
                    ProductEnquiryID = 1,
                    Quantitiy = 1,
                    Identity = 1,

                    Size = "4*39"
                    
                    
                });
            ProductEnquiryDetailss.Add(
                new BusinessModels.ProductEnquiryDetails()
                {
                    Identity = 2,

                    itemID = 1,
                    ItemPrice = Convert.ToDecimal("0.0"),
                    ProductEnquiryID = 1,
                    Quantitiy = 1,
                    Size = "4*39"
                });
            ProductEnquiryDetailss.Add(
                new BusinessModels.ProductEnquiryDetails()
                {
                    Identity = 3,

                    itemID = 1,
                    ItemPrice = Convert.ToDecimal("0.0"),
                    ProductEnquiryID = 1,
                    Quantitiy = 1,
                    Size = "4*39"
                });
        }

    }


}
