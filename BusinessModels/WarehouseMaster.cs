using System;

namespace BusinessModels
{
    public class WarehouseMaster
    {
        public WarehouseMaster()
        {
           
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string WarehouseName
        {
            get;
            set;
        }

        public int LocationID
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