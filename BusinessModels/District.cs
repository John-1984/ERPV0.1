using System;


namespace BusinessModels
{
    public class District
    {
        public District()
        {
            
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string DistrictName
        {
            get;
            set;
        }

        public int StateID
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