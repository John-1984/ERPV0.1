using System;
using System.Collections.Generic;

namespace BusinessModels
{
    public class State
    {
        public State()
        {
            Identity = -1;
            StateName = string.Empty;
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string StateName
        {
            get;
            set;
        }

        public int CountryID
        {
            get;
            set;
        }

        public string CountryName
        {
            get;
            set;
        }

        public string RegionName
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

        public List<string> ErrorList
        {
            get;
            set;
        }

    }
}

