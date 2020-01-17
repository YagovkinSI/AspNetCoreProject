using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreProject.DAL.Models;

namespace AspNetCoreProject.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private static bool CreateNewDataBase = true;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            if (CreateNewDataBase)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
                CreateNewDataBase = false;
            }
        }
    }
}
