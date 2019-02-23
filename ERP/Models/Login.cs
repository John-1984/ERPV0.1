using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ERP.Models
{
    public class Login
    {
        public Login()
        {
            Identity = -1;
            UserName = string.Empty;
            UserPassword = String.Empty;
        }

        [Key]
        [DefaultValue(-1)]
        public Int32 Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string UserName
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string UserPassword
        {
            get;
            set;
        }


        public DateTime? LastLoginDate
        {
            get;
            set;
        }
        

    }
}