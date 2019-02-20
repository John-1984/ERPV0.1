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
        public string DistrictName
        {
            get;
            set;
        }

        public string RegionName
        {
            get;
            set;
        }
        public string CountryName
        {
            get;
            set;
        }
        public string StateName
        {
            get;
            set;
        }
        public int RegionID
        {
            get;
            set;
        }
        public int CountryID
        {
            get;
            set;
        }
        public int StateID
        {
            get;
            set;
        }


    }
}