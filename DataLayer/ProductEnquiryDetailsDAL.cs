using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DataLayer
{
    public class ProductEnquiryDetailsDAL
    {
        private static List<BusinessModels.ProductEnquiryDetails> ProductEnquiryDetailss = new List<BusinessModels.ProductEnquiryDetails>();

        public ProductEnquiryDetailsDAL()
        {
        }

        public BusinessModels.ProductEnquiryDetails GetProductEnquiryDetails(Int32 identity)
        {
            var _ProductEnquiryDetails = new BusinessModels.ProductEnquiryDetails();
            using (var dbContext = new ProductEnquiryDetailsDbContext())
            {
                _ProductEnquiryDetails = dbContext.ProductEnquiryDetails     
                    .Include(K => K.ItemMaster)
                            .FirstOrDefault(p => p.Identity.Equals(identity));
            }
            return _ProductEnquiryDetails;
        }

        public IEnumerable<BusinessModels.ProductEnquiryDetails> GetAll()
        {
            //Need to do
            var _ProductEnquiryDetailss = new List<BusinessModels.ProductEnquiryDetails>();
            using (var dbContext = new ProductEnquiryDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ProductEnquiryDetailss = dbContext.ProductEnquiryDetails
                     .Include(K => K.ItemMaster)
                            .ToList();
            }

            return _ProductEnquiryDetailss;
        }

     

        public IEnumerable<BusinessModels.ProductEnquiryDetails> GetAll(int prodEnquiryID)
        {
            //Need to do
            var _ProductEnquiryDetailss = new List<BusinessModels.ProductEnquiryDetails>();
            using (var dbContext = new ProductEnquiryDetailsDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ProductEnquiryDetailss = dbContext.ProductEnquiryDetails
                     .Include(K => K.ItemMaster)
                             .Where(p => p.ProductEnquiryID == prodEnquiryID)
                            .ToList();
            }

            return _ProductEnquiryDetailss;
        }

       


        public Boolean Update(BusinessModels.ProductEnquiryDetails ProductEnquiryDetails)
        {
            using (var dbContext = new ProductEnquiryDetailsDbContext())
            {
                dbContext.Entry(ProductEnquiryDetails).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new ProductEnquiryDetailsDbContext())
            {
                dbContext.Entry(new BusinessModels.ProductEnquiryDetails() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Insert(BusinessModels.ProductEnquiryDetails ProductEnquiryDetails)
        {
            using (var dbContext = new ProductEnquiryDetailsDbContext())
            {
                dbContext.Entry(ProductEnquiryDetails).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return true;
        }

    }
}
