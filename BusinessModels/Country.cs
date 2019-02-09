using System;


namespace BusinessModels
{
    public class Country
    {

        public Country()
        {
           
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string CountryName
        {
            get;
            set;
        }

        public int RegionID
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