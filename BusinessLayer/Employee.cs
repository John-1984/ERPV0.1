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
        private DataLayer.RegionDAL _regdataLayer = null;
        private DataLayer.CountryDAL _condataLayer = null;
        private DataLayer.StateDAL _statedataLayer = null;
        private DataLayer.DistrictDAL _distdataLayer = null;
       
        private DataLayer.RoleMasterDAL _roledataLayer = null;
        private DataLayer.FloorMasterDAL _floordataLayer = null;
        private DataLayer.LoginDAL _logdataLayer = null;
        public Employee()
        {
            _dataLayer = new DataLayer.EmployeeDAL();
            _compdataLayer = new DataLayer.CompanyDAL();
            _comptypedataLayer = new DataLayer.CompanyTypeDAL();
            _identificationdataLayer = new DataLayer.IdentificationsTypeDAL();
            _locdataLayer = new DataLayer.LocationDAL();

            _regdataLayer = new DataLayer.RegionDAL();
            _condataLayer = new DataLayer.CountryDAL();
            _statedataLayer = new DataLayer.StateDAL();
            _distdataLayer = new DataLayer.DistrictDAL();

            _roledataLayer = new DataLayer.RoleMasterDAL();
            _logdataLayer = new DataLayer.LoginDAL();

            _floordataLayer = new DataLayer.FloorMasterDAL();
        }
        public BusinessModels.Employee GetEmployee(Int32 identity)
        {
            return _dataLayer.GetEmployee(identity);
        }
        public BusinessModels.Employee GetEmployeeLoginDetails(Int32 identity)
        {
            return _dataLayer.GetEmployeeLogin(identity);
        }
        public IEnumerable<BusinessModels.IdentificationsType> GetAllIdentificationTypes()
        {
            //TestRegionData();
            return _identificationdataLayer.GetAll();
        }      
        public IEnumerable<BusinessModels.RoleMaster> GetAllRoles()
        {
            //TestRegionData();
            return _roledataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Country> GetAllCountrysOnRegion(string identity)
        {
            //TestRegionData();
            return _condataLayer.GetAll(int.Parse(identity));
        }
        public IEnumerable<BusinessModels.State> GetAllStatesOnCountry(string identity)
        {
            //TestRegionData();
            return _statedataLayer.GetAll(int.Parse(identity));
        }
        public IEnumerable<BusinessModels.District> GetAllDistrictsOnState(string identity)
        {
            //TestRegionData();
            return _distdataLayer.GetAll(int.Parse(identity));
        }
        public IEnumerable<BusinessModels.Location> GetAllLocationsOnDistrict(string identity)
        {
            //TestRegionData();
            return _locdataLayer.GetAll(int.Parse(identity));
        }
        public IEnumerable<BusinessModels.Company> GetAllCompaniesonLocation(string identity)
        {
            //TestRegionData();
            return _compdataLayer.GetAll(int.Parse(identity));
        }
        public IEnumerable<BusinessModels.CompanyType> GetAllCompaniesTypeonCompany(string identity)
        {
            //TestRegionData();
            return _comptypedataLayer.GetAll(int.Parse(identity));
        }
        public IEnumerable<BusinessModels.FloorMaster> GetAllFloorOnCompanyType(string identity)
        {
            //TestRegionData();
            return _floordataLayer.GetAll(int.Parse(identity));
        }
        public IEnumerable<BusinessModels.Region> GetAllRegions()
        {
            //TestRegionData();
            return _regdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Country> GetAllCountry()
        {
            //TestRegionData();
            return _condataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.State> GetAllStates()
        {
            //TestRegionData();
            return _statedataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.District> GetAllDistrict()
        {
            //TestRegionData();
            return _distdataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.Location> GetAllLocations()
        {
            //TestRegionData();
            return _locdataLayer.GetAll();
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
        public IEnumerable<BusinessModels.Employee> GetAll()
        {
            return _dataLayer.GetAll();
        }
        public IEnumerable<BusinessModels.FloorMaster> GetAllFloors()
        {
            //TestRegionData();
            return _floordataLayer.GetAll();
        }
        public Boolean Delete(Int32 identity)
        {
            return _dataLayer.Delete(identity);
        }
        public Boolean Update(BusinessModels.Employee Employee)
        {
            return _dataLayer.Update(Employee);
        }
        public BusinessModels.Employee Insert(BusinessModels.Employee Employee)
        {
            BusinessLayer.Login bslogin = new BusinessLayer.Login();
            BusinessModels.Login mdLogin = new BusinessModels.Login();           
            mdLogin = bslogin.Insert(mdLogin, Employee.EmployeeName);
            Employee.LoginID = mdLogin.Identity;
            Employee.Login = mdLogin;
            _dataLayer.Insert(Employee);
            return Employee;                
        }
        public BusinessModels.Login InsertLoginDetials(BusinessModels.Login empLoginDet)
        {
            return _logdataLayer.Insert(empLoginDet);
        }
        public Boolean UpdateLoginDetials(BusinessModels.Login empLoginDet)
        {
            return _logdataLayer.Update(empLoginDet);
        }


    }


}
