using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class CompanyType
    {
        public CompanyType()
        {
           // Identity = -1;
           // TypeName = string.Empty;
        }

        public Int32 Identity
        {
            get;
            set;
        }

        public string TypeName
        {
            get;
            set;
        }
        public int CompanyID
        {
            get;
            set;
        }
        public string CompanyName
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
        public List<string> ErrorList
        {
            get;
            set;
        }

    }
}