using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Address
    {
        public Address()
        {
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Identity
        {
            get;
            set;
        }
        public string Line1
        {
            get;
            set;
        }

        public string Line2
        {
            get;
            set;
        }

        public string Pincode
        {
            get;
            set;
        }
    }
}
