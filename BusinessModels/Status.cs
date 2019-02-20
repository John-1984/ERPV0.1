using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Status
    {
        public Status()
        {
            Identity = -1;
            StatusName = string.Empty;
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string StatusName
        {
            get;
            set;
        }



    }
}