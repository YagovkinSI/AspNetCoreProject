using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreProject.DAL.Models
{
    public class User : IdentityUser
    {
        public virtual User_Province Users_Provinces { get; set; }
    }
}
