using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreProject.DAL
{
    public class ApplicationDbContext : IdentityDbContext
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
