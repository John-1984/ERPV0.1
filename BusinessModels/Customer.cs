using System;
namespace BusinessModels
{
    public class Customer
    {
        public Customer()
        {
        }

        public Int32 Identity
        {
            get;
            set;
        }

        public string CustomerName
        {
            get;
            set;
        }

        public string Profession
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public Address Address
        {
            get;
            set;
        }

        public string EmailID
        {
            get;
            set;
        }

        public string Purpose
        {
            get;
            set;
        }

        public string Quantity
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }
    }
}
