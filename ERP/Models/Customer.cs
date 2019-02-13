using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BusinessModels;
using X.PagedList;

namespace ERP.Models
{
    public class Customer 
    {
        public Customer()
        {
            Identity = -1;
            CustomerName = string.Empty;
            Profession = string.Empty;
            Location = string.Empty;
            Address = new Address();
            EmailID = string.Empty;
            Purpose = string.Empty;
            Comments = string.Empty;
            Quantity = string.Empty;
            CreatedDate = DateTime.Now;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string CustomerName
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string Profession
        {
            get;
            set;
        }

        [DefaultValue("")]
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

		[DefaultValue("")]
        public string EmailID
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string Purpose
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string Comments
        {
            get;
            set;
        }

        [DefaultValue("0")]
        public string Quantity
        {
            get;
            set;
        }

        public DateTime CreatedDate{
            get;
            set;
        }
    }
}
