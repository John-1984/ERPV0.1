using System;
using System.Collections.Generic;
namespace BusinessModels
{
    public class Brand
    {
        public Brand()
        {
            
        }
       
        public Int32 Identity
        {
            get;
            set;
        }

       
        public string BrandName
        {
            get;
            set;
        }

        public int VendorName
        {
            get;
            set;
        }
        public int VendorID
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public List<string> ErrorList
        {
            get;
            set;
        }


    }
}