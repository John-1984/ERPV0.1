using System;
using System.Collections.Generic;

namespace BusinessModels
{
    public partial class User
    {
        public User()
        {
        }

        public int  ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int LocationID { get; set; }

    }
}
