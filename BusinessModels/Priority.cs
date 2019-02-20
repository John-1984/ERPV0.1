using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Priority
    {
        public Priority()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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