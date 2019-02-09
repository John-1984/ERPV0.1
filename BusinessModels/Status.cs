using System;


namespace BusinessModels
{
    public class Status
    {
        public Status()
        {
            Identity = -1;
            StatusName = string.Empty;
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string StatusName
        {
            get;
            set;
        }



    }
}