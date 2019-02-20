using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class EnquiryLevel
    {
        public EnquiryLevel()
        {
          
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        
        public string EnquiryLevelName
        {
            get;
            set;
        }



    }
}