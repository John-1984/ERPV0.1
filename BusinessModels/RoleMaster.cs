using System;

namespace BusinessModels
{
    public class RoleMaster
    {
        public RoleMaster()
        {
            Identity = -1;
            RoleName = string.Empty;
        }

        public Int32 Identity
        {
            get;
            set;
        }

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

        public string RoleTypeName
        {
            get;
            set;
        }

        public string RegionName
        {
            get;
            set;
        }

        public int ModuleID
        {
            get;
            set;
        }

        public int RegionID
        {
            get;
            set;
        }

        public string ModuleName
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