using System;

namespace BusinessModels
{
    public class Header
    {
        public Header()
        {
            
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string LogoURL
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


    }
}