using System;
using System.Collections.Generic;

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
            return customers[0];
        }

        public IEnumerable<BusinessModels.Customer> GetAll(){
           return customers;
        }

        public Boolean Delete(){
            return true;
        }

        public Boolean Update(BusinessModels.Customer customer){
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
                    Identity = 1,
                    Location = "Mumbai",
                    Profession = "Engg",
                    Purpose = "Just So",
                    Quantity = "12"
                });
        }

    }


}
