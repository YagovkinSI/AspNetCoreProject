using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCoreProject.DAL.Models
{
    public class User_Province
    {
        [Required]
        public string UserID { get; set; }
        public virtual User User { get; set; }
        public Guid ProvinceID { get; set; }
        public virtual Province Province { get; set; }
    }
}
