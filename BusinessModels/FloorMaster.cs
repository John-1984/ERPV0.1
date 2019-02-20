using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessModels
{
    public class FloorMaster
    {
        public FloorMaster()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }
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