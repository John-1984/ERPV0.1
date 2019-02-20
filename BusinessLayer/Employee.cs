using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Employee
    {

        private List<BusinessModels.Employee> Employees = new List<BusinessModels.Employee>();
        private List<BusinessModels.Country> Countrys = new List<BusinessModels.Country>();
        private DataLayer.EmployeeDAL _dataLayer = null;
        private DataLayer.CompanyDAL _compdataLayer = null;
        private DataLayer.CompanyTypeDAL _comptypedataLayer = null;
        private DataLayer.IdentificationsTypeDAL _identificationdataLayer = null;
        private DataLayer.LocationDAL _locdataLayer = null;

        private DataLayer.RoleMasterDAL _roledataLayer = null;

        public Employee()
        {
            _dataLayer = new DataLayer.EmployeeDAL();
            _compdataLayer = new DataLayer.CompanyDAL();
            _comptypedataLayer = new DataLayer.CompanyTypeDAL();
            _identificationdataLayer = new DataLayer.IdentificationsTypeDAL();
            _locdataLayer = new DataLayer.LocationDAL();

            _roledataLayer = new DataLayer.RoleMasterDAL();
        }

        public BusinessModels.Employee GetEmployee(Int32 identity)
        {
            return _dataLayer.GetEmployee(identity);
        }
        public IEnumerable<BusinessModels.Company> GetAllCompanies()
        {
            //TestRegionData();
            return _compdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.CompanyType> GetAllCompanyType()
        {
            //TestRegionData();
            return _comptypedataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.IdentificationsType> GetAllIdentificationTypes()
        {
            //TestRegionData();
            return _identificationdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Location> GetAllLocations()
        {
            //TestRegionData();
            return _locdataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.RoleMaster> GetAllRoles()
        {
            //TestRegionData();
            return _roledataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Employee> GetAll()
        {
            return _dataLayer.GetAll();
        }

        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Employee Employee)
        {
            return _dataLayer.Update(Employee);
        }

        public Boolean Insert(BusinessModels.Employee Employee)
        {
            return _dataLayer.Insert(Employee);
        }



    }


}
