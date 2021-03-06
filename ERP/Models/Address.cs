﻿using System;
using System.ComponentModel;

namespace ERP.Models
{
    public class Address
    {
        public Address()
        {
            Identity = -1;
            Line1 = string.Empty;
            Line2 = string.Empty;
            Pincode = string.Empty;
        }
        public int Identity
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string Line1
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string Line2
        {
            get;
            set;
        }

        [DefaultValue("")]
        public string Pincode
        {
            get;
            set;
        }
    }
}
