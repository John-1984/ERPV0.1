using System;

namespace BusinessModels
{
    public class RoleEscalation
    {
        public RoleEscalation()
        {
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

       

        public int RoleID
        {
            get;
            set;
        }

        public int RoleManagerID
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