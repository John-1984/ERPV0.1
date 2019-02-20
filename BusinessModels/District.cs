using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class District
    {
        public District()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        //public string RegionName
        //{
        //    get;
        //    set;
        //}
        //public string CountryName
        //{
        //    get;
        //    set;
        //}
        //public string StateName
        //{
        //    get;
        //    set;
        //}
        //public int RegionID
        //{
        //    get;
        //    set;
        //}
        //public int CountryID
        //{
        //    get;
        //    set;
        //}
        public List<string> ErrorList
        {
            get;
            set;
        }
    }
}