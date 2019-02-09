using System;

namespace BusinessModels
{
    public class RoleType
    {
        public RoleType()
        {
           
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string RoletypeName
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