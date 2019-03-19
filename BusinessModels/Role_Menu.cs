using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModels
{
    public class Role_Menu
    {
        public Role_Menu()
        {
        }
       

        [System.ComponentModel.DataAnnotations.Key, Column(Order = 0)]
        public int RoleID { get; set; }
        [System.ComponentModel.DataAnnotations.Key, Column(Order = 1)]
        public int MenuID { get; set; }
        public string Active { get; set; }
    }
}