using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class PendingCustomerInfo
    {
        private static List<BusinessModels.Customer> customers = new List<BusinessModels.Customer>();
        private DataLayer.PendingCustomerInfoDAL _dataLayer = null;
        private DataLayer.EmployeeDAL _empdataLayer = null;
        private DataLayer.ProductEnquiryDAL _prodenqdataLayer = null;
        private DataLayer.PurposeDAL _purposedataLayer = null;
        private DataLayer.StatusDAL _statusdataLayer = null;
        private DataLayer.EnquiryLevelDAL _eqdataLayer = null;

        public PendingCustomerInfo()
        {
            _dataLayer = new DataLayer.PendingCustomerInfoDAL();
            _empdataLayer = new DataLayer.EmployeeDAL();
            _prodenqdataLayer = new DataLayer.ProductEnquiryDAL();
            _purposedataLayer = new DataLayer.PurposeDAL();
            _statusdataLayer = new DataLayer.StatusDAL();
            _eqdataLayer = new DataLayer.EnquiryLevelDAL();
        }

        public BusinessModels.Customer GetCustomer(Int32 identity){
            return _dataLayer.GetCustomer(identity);
        }

        public IEnumerable<BusinessModels.Customer> GetAll() { 
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.Customer> GetAll(int locID)
        {
            return _dataLayer.GetAll(locID);
        }

        public IEnumerable<BusinessModels.Customer> GetAll(int locID, int empID)
        {
            return _dataLayer.GetAll(locID,empID);
        }

        public IEnumerable<BusinessModels.Customer> GetMatchingCustomers(string prefix)
        {
            return _dataLayer.GetMatchingCustomers(prefix);
        }

        public Boolean Delete(Int32 identity){
            return _dataLayer.Delete(identity);
        }

        public BusinessModels.ProductEnquiry Update(BusinessModels.Customer customer){
            BusinessModels.ProductEnquiry prodEnq = new BusinessModels.ProductEnquiry();
            prodEnq.StatusID = 1;
            prodEnq.LocationId = customer.LocationID;
            prodEnq.CustomerID = customer.Identity;
            prodEnq.CreatedDate = DateTime.Now;
            prodEnq.EnquiryLevelID = customer.EnquiryLevelID;
            prodEnq.AssignedTo = customer.AssignedTo;
            prodEnq.OriginatorID = customer.AssignedTo;
            prodEnq.CreatedBy = customer.ModifiedBy;
            prodEnq.IsActive = true;
            _dataLayer.Update(customer);

            return _prodenqdataLayer.Insert(prodEnq);
         
        }

        public BusinessModels.Customer Insert(BusinessModels.Customer customer)
        {
            BusinessModels.Customer bscustomer = _dataLayer.Insert(customer);
            BusinessModels.ProductEnquiry prodEnq = new BusinessModels.ProductEnquiry();
            prodEnq.StatusID = 1;
            prodEnq.LocationId = customer.LocationID;
            prodEnq.CustomerID = bscustomer.Identity;
            prodEnq.CreatedDate = DateTime.Now;
            prodEnq.EnquiryLevelID = bscustomer.EnquiryLevelID;
            prodEnq.AssignedTo = customer.AssignedTo;
            prodEnq.OriginatorID = customer.AssignedTo;
            prodEnq.CreatedBy = customer.CreatedBy;
            _prodenqdataLayer.Insert(prodEnq);
            return bscustomer;
        }

        public IEnumerable<BusinessModels.Employee> GetAllEmployeeOnLocation( int fldIdentiity)
        {
            //TestRegionData();
            return _empdataLayer.GetAllEmployeesOnLocation(fldIdentiity);
        }

        public IEnumerable<BusinessModels.Employee> GetAllFloorExecutivesOnFloor(int? floorid, int fldIdentiity, int? companytypeid)
        {
            //TestRegionData();
            return _empdataLayer.GetAllFloorExecutivesOnFloor(floorid, fldIdentiity, companytypeid);
        }

        public IEnumerable<BusinessModels.Purpose> GetAllPurpose()
        {
            //TestRegionData();
            return _purposedataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.Status> GetAllStatus()
        {
            //TestRegionData();
            return _statusdataLayer.GetAll();
        }


        public IEnumerable<BusinessModels.EnquiryLevel> GetAllEnquiryLevels()
        {
            //TestRegionData();
            return _eqdataLayer.GetAll();
        }

    }


}
