using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class RoleType
    {
        public RoleType()
        {
            Identity = -1;
            RoletypeName = string.Empty;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string RoletypeName
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