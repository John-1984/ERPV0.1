using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using System.ComponentModel.DataAnnotations;
//using System.Data.Entity.
namespace DataLayer
{
    public class ProductEnquiryDAL
    {
        private static List<BusinessModels.ProductEnquiry> ProductEnquirys = new List<BusinessModels.ProductEnquiry>();

        public ProductEnquiryDAL()
        {
        }

        public BusinessModels.ProductEnquiry GetProductEnquiry(Int32 identity)
        {
            var _ProductEnquiry = new BusinessModels.ProductEnquiry();
            using (var dbContext = new ProductEnquiryDbContext())
            {
                _ProductEnquiry = dbContext.ProductEnquiry
                             .Include(K => K.Location)
                             .Include(l => l.Customer)
                             .Include(l => l.Status)
                             .Include(l => l.EnquiryLevel)                             
                            .FirstOrDefault(p => p.Identity.Equals(identity));

                dbContext.Entry(_ProductEnquiry).Collection(p => p.ProductEnquiryDetails).Load();
            }
            return _ProductEnquiry;
        }

        public IEnumerable<BusinessModels.ProductEnquiry> GetAll()
        {
            //Need to do
            var _ProductEnquirys = new List<BusinessModels.ProductEnquiry>();
            using (var dbContext = new ProductEnquiryDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ProductEnquirys = dbContext.ProductEnquiry
                             .Include(K => K.Location)
                             .Include(l => l.Customer)
                             .Include(r => r.Status)
                             .Include(y => y.EnquiryLevel)                          
                            .ToList();
            }

            return _ProductEnquirys;
        }

     

        public IEnumerable<BusinessModels.ProductEnquiry> GetAll(int locID)
        {
            //Need to do
            var _ProductEnquirys = new List<BusinessModels.ProductEnquiry>();
            using (var dbContext = new ProductEnquiryDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ProductEnquirys = dbContext.ProductEnquiry
                              .Include(K => K.Location)
                             .Include(l => l.Customer)
                             .Include(r => r.Status)
                             .Include(y => y.EnquiryLevel)
                           //  .Include(o => o.ProductEnquiryDetails)
                             .Where(p => p.Location.Identity == locID)
                            .ToList();
            }

            return _ProductEnquirys;
        }

        public IEnumerable<BusinessModels.ProductEnquiry> GetAll(int locID, int empID)
        {
            //Need to do
            var _ProductEnquirys = new List<BusinessModels.ProductEnquiry>();
            using (var dbContext = new ProductEnquiryDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                _ProductEnquirys = dbContext.ProductEnquiry
                              .Include(K => K.Location)
                             .Include(l => l.Customer)
                             .Include(r => r.Status)
                             .Include(y => y.EnquiryLevel)
                           //  .Include(o => o.ProductEnquiryDetails)
                             .Where(p => p.Location.Identity == locID && p.OriginatorID == empID)
                            .ToList();
            }

            return _ProductEnquirys;
        }


        public Boolean Update(BusinessModels.ProductEnquiry ProductEnquiry)
        {
            using (var dbContext = new ProductEnquiryDbContext())
            {
                dbContext.Entry(ProductEnquiry).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return true;
        }

        public Boolean Delete(Int32 identity)
        {
            using (var dbContext = new ProductEnquiryDbContext())
            {
                dbContext.Entry(new BusinessModels.ProductEnquiry() { Identity = identity }).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
            }
            return true;
        }

        public BusinessModels.ProductEnquiry Insert(BusinessModels.ProductEnquiry ProductEnquiry)
        {
            using (var dbContext = new ProductEnquiryDbContext())
            {
                dbContext.Entry(ProductEnquiry).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }

            return ProductEnquiry;
        }

    }
}
