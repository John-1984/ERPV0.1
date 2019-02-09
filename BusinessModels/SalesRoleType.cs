using System;

namespace BusinessModels
{
    public class SalesRoleType
    {
        public SalesRoleType()
        {
           
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string TypeName
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