using System;

namespace BusinessModels
{
    public class Modules
    {
        public Modules()
        {
            
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string ModuleName
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