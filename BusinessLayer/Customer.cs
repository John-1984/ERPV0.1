using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Customer
    {
        private static List<BusinessModels.Customer> customers = new List<BusinessModels.Customer>();

        public Customer()
        {
            if (customers.Count == 0)
                TestData();
        }

        public BusinessModels.Customer GetCustomer(Int32 identity){
            return customers.FirstOrDefault(p=>p.Identity.Equals(identity));
        }

        public IEnumerable<BusinessModels.Customer> GetAll(){
           return customers;
        }

        public Boolean Delete(Int32 identity){
            customers.Remove(customers.Find(p => p.Identity.Equals(identity)));
            return true;
        }

        public Boolean Update(BusinessModels.Customer customer){
            customers.Remove(customers.Find(p => p.Identity.Equals(customer.Identity)));
            customers.Add(customer);
            return true;
        }

        public Boolean Insert(BusinessModels.Customer customer)
        {
            customers.Add(customer);
            return true;
        }

        public void TestData()
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
                    CustomerName = "John",
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
                    CustomerName = "John",
                    EmailID = "m@mail.com",
                    Identity = 3,
                    Location = "Mumbai",
                    Profession = "Engg",
                    Purpose = "Just So",
                    Quantity = "12"
                });
        }

    }


}
