using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class RoleMaster
    {
        public RoleMaster()
        {
            Identity = -1;
            RoleName = string.Empty;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string RoleName
        {
            get;
            set;
        }

        public int RoleTypeID
        {
            get;
            set;
        }

        public int RegionID
        {
            get;
            set;
        }

        public int ModuleID
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