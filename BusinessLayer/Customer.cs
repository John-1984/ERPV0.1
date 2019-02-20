using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Customer
    {
        private static List<BusinessModels.Customer> customers = new List<BusinessModels.Customer>();
        private DataLayer.CustomerDAL _dataLayer = null;

        public Customer()
        {
            _dataLayer = new DataLayer.CustomerDAL();
        }

        public BusinessModels.Customer GetCustomer(Int32 identity){
            return _dataLayer.GetCustomer(identity);
        }

        public IEnumerable<BusinessModels.Customer> GetAll() { 
            return _dataLayer.GetAll();
        }

        public IEnumerable<BusinessModels.Customer> GetMatchingCustomers(string prefix)
        {
            return _dataLayer.GetMatchingCustomers(prefix);
        }

        public Boolean Delete(Int32 identity){
            return _dataLayer.Delete(identity);
        }

        public Boolean Update(BusinessModels.Customer customer){
            return _dataLayer.Update(customer);
        }

        public Boolean Insert(BusinessModels.Customer customer)
        {
            return _dataLayer.Insert(customer);
        }

        public void TestData()
        {

            for (int i = 0; i < 10; i++)
            {
                customers.Add(
                    new BusinessModels.Customer()
                    {
                        Address = new BusinessModels.Address() { Line1 = "Line1", Line2 = "Line2", Pincode = "12345" },
                        CustomerName = "John",
                        EmailID = "m@mail.com",
                        Identity = 1,
                        Location = "Mumbai",
                        Profession = "Engg",
                        Purpose = "Just So",
                        Quantity = "12"
                    });
                customers.Add(
                    new BusinessModels.Customer()
                    {
                        Address = new BusinessModels.Address() { Line1 = "Line1", Line2 = "Line2", Pincode = "12345" },
                        CustomerName = "Rajeesh",
                        EmailID = "m@mail.com",
                        Identity = 2,
                        Location = "Mumbai",
                        Profession = "Engg",
                        Purpose = "Just So",
                        Quantity = "12"
                    });
                customers.Add(

                    new BusinessModels.Customer()
                    {
                        Address = new BusinessModels.Address() { Line1 = "Line1", Line2 = "Line2", Pincode = "12345" },
                        CustomerName = "Ashraf",
                        EmailID = "m@mail.com",
                        Identity = i,
                        Location = "Mumbai",
                        Profession = "Engg",
                        Purpose = "Just So",
                        Quantity = "12",
                        CreatedDate = DateTime.Now
                    });
            }
        }

    }


}
