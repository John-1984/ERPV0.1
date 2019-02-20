using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace ERP.Models
{
    public class RoleEscalation
    {
        public RoleEscalation()
        {
            Identity = -1;
          //  CountryName = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

       

        public int RoleID
        {
            get;
            set;
        }

        public int RoleManagerID
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