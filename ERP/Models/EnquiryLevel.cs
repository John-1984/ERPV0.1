using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace ERP.Models
{
    public class EnquiryLevel
    {
        public EnquiryLevel()
        {
            Identity = -1;
            EnquiryLevelName = string.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string EnquiryLevelName
        {
            get;
            set;
        }



    }
}