using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ERP.Models
{
    public class RoleMaster
    {
        public RoleMaster()
        {
            Identity = -1;
            RoleName = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Required(ErrorMessage ="Please specify role name")]
        public string RoleName
        {
            get;
            set;
        }

        public int? RoleTypeID
        {
            get;
            set;
        }

       

        public int? ModuleID
        {
            get;
            set;
        }

        public int? RegionID
        {
            get;
            set;
        }

       
        public DateTime? CreatedDate
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public int? CreatedBy
        {
            get;
            set;
        }

        public SelectList RegionList
        {
            get;
            set;
        }

        public SelectList RoleTypeList
        {
            get;
            set;
        }

        public SelectList ModuleList
        {
            get;
            set;
        }

        public List<string> ErrorList
        {
            get;
            set;
        }

        public RoleType RoleType
        {
            get;
            set;
        }

        public Modules Modules
        {
            get;
            set;
        }

        public Region Region
        {
            get;
            set;
        }

        public string strRegionName = String.Empty;
        public string RegionName
        {
            get
            {
                if (this.Region == null)
                   return  strRegionName;
                else
                    return this.Region.RegionName;
            }
            set
            {

                if (this.Region == null)
                    strRegionName = "";
                else
                    strRegionName = this.Region.RegionName;
            }

        }

        public string strRoleTypeName =String.Empty;
        public string RoleTypeName
        {
            get
            {
                if (this.RoleType == null)
                    return strRoleTypeName ;
                else
                    return this.RoleType.RoletypeName;

               }
            set
            {

                if (this.RoleType == null)
                    strRoleTypeName = "";
                else
                    strRoleTypeName = this.RoleType.RoletypeName;
            }

        }

        public string strModulesName = String.Empty;
        public string ModulesName
        {
            get
            {

                if (this.Modules == null)
                    return strModulesName;
                else
                    return  this.Modules.ModuleName;

            }
            set
            {

                if (this.Modules == null)
                    strModulesName = "";
                else
                    strModulesName = this.Modules.ModuleName;
            }

        }

    }
}