using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Login
    {
        public Login()
        {
           
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string UserName
        {
            get;
            set;
        }

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