using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BusinessModels;
using X.PagedList;

namespace ERP.Models
{
    public class FloorMaster
    {
        public FloorMaster()
        {
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }
        [Required(ErrorMessage ="Please enter floor name")]
        public string FloorName
        { get; set; }

        public int CompanyTypeID
        { get; set; }



        public int CompanyID
        { get; set; }

        public string CompanyName
        { get; set; }

        public string TypeName
        { get; set; }

        public List<string> ErrorList
        {
            get;
            set;
        }

        public SelectList CompanyTypeList
        {
            get;
            set;
        }

        public SelectList CompanyList
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