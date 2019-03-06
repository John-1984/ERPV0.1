using System;
using System.Runtime;
using System.Web.Mvc;

namespace ERP.Models.Workflow
{
    public class Workflow
    {
        public Workflow()
        {
            Identity = -1;
            Description = string.Empty;
            Name = string.Empty;
            CreatedDate = string.Empty;
            CreatedBy = string.Empty;
        }

        public int Identity { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int LocationID { get; set; }
        public int CompanyTypeID { get; set; }
        public int CompanyID { get; set; }
        public int ItemType { get; set; }

       
        public Location Location
        { get; set; }

        public CompanyType CompanyType
        { get; set; }

        public Company Company
        { get; set; }

        public Menu Menu
        { get; set; }

        public SelectList RegionList
        {
            get;
            set;
        }

        public SelectList CountryList
        {
            get;
            set;
        }

        public SelectList StateList
        {
            get;
            set;
        }

        public SelectList DistrictList
        {
            get;
            set;
        }

        public SelectList LocationList
        {
            get;
            set;
        }

        public SelectList CompanyList
        {
            get;
            set;
        }

        public SelectList CompanyTypeList
        {
            get;
            set;
        }

        public SelectList ModulesList
        {
            get;
            set;
        }

        public SelectList MenuList
        {
            get;
            set;
        }

    }
}
