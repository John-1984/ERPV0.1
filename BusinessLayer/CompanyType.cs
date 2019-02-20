using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class CompanyType
    {
        private static List<BusinessModels.CompanyType> CompanyTypes = new List<BusinessModels.CompanyType>();
        private DataLayer.CompanyTypeDAL _dataLayer = null;
        private DataLayer.CompanyDAL _compdataLayer = null;

        public CompanyType()
        {
            _dataLayer = new DataLayer.CompanyTypeDAL();
            _compdataLayer = new DataLayer.CompanyDAL();
        }

        public BusinessModels.CompanyType GetCompanyType(Int32 identity)
        {
            return _dataLayer.GetCompanyType(identity);
        }
        public IEnumerable<BusinessModels.Company> GetAllCompanys()
        {
            //TestRegionData();
            return _compdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.CompanyType> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.CompanyType CompanyType)
        {
            return _dataLayer.Update(CompanyType);
        }

        public Boolean Insert(BusinessModels.CompanyType CompanyType)
        {
            return _dataLayer.Insert(CompanyType);
        }

       

    }


}
