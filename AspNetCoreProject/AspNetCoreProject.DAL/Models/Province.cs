using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProject.DAL.Models
{
    public class Province
    {
        public int Id { get; set; }
        public virtual User_Province Users_Provinces { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
