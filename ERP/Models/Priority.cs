using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace ERP.Models
{
    public class Priority
    {
        public Priority()
        {
            Identity = -1;
           // CountryName = string.Empty;
        }

        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        public int PriorityValue
        {
            get;
            set;
        }


    }
}