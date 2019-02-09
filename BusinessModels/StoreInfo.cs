﻿using System;


namespace BusinessModels
{
    public class StoreInfo
    {
        public StoreInfo()
        {
            Identity = -1;
            StoreName = string.Empty;
        }

        
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string StoreName
        {
            get;
            set;
        }

        
        public int Storetype
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