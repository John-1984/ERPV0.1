﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class State
    {
        public State()
        {
            Identity = -1;
            StateName = string.Empty;
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [ForeignKey("Country")]
        public int CountryID
        {
            get;
            set;
        }

        //public string CountryName
        //{
        //    get;
        //    set;
        //}

        //public string RegionName
        //{
        //    get;
        //    set;
        //}

        //public int RegionID
        //{
        //    get;
        //    set;
        //}

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

        //public Region Region
        //{
        //    get;
        //    set;
        //}

        public Country Country
        {
            get;
            set;
        }


    }
}

