using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Location
    {
        public Location()
        {
            Identity = -1;
            LocationName = string.Empty;
        }

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Identity
        {
            get;
            set;
        }

        public string LocationName
        {
            get;
            set;
        }

        [ForeignKey("District")]
        public int DistrictID
        {
            get;
            set;
        }


        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
       

        public District District
        {
            get;
            set;
        }

    }
}