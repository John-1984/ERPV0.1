using System;

namespace BusinessModels
{
    public class Location
    {
        public Location()
        {
            Identity = -1;
            LocationName = string.Empty;
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string LocationName
        {
            get;
            set;
        }

        public int DistrictID
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