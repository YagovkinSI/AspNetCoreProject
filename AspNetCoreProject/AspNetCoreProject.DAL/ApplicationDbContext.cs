using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreProject.DAL.Models;
using AspNetCoreProject.DAL.Initialisation.Formater;
using System.Reflection;

namespace AspNetCoreProject.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private static bool CreateNewDataBase = true;
        public DbSet<Province> Provinces { get; set; }
        public DbSet<User_Province> Users_Provinces { get; set; }

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CreateProvinceModel(modelBuilder);
            CreateUsersOrganisationsRelation(modelBuilder);
        }

        private void CreateProvinceModel(ModelBuilder modelBuilder)
        {
            var model = modelBuilder.Entity<Province>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "AspNetCoreProject.DAL.Initialisation.Source.Provinces.csv";
            var stream = assembly.GetManifestResourceStream(resourceName);
            var provinces = ProvinceFormatter.GetDataFrom(stream);
            model.HasData(provinces);
        }

        private void CreateUsersOrganisationsRelation(ModelBuilder modelBuilder)
        {
            var model = modelBuilder.Entity<User_Province>();
            model.HasKey(e => new { e.UserID, e.ProvinceID });
            model.HasOne(e => e.User)
                .WithOne(e => e.Users_Provinces)
                .OnDelete(DeleteBehavior.Cascade);
            model.HasOne(e => e.Province)
                .WithOne(e => e.Users_Provinces)
                .OnDelete(DeleteBehavior.Restrict);
            model.HasIndex(e => e.UserID).IsUnique();
            model.HasIndex(e => e.ProvinceID).IsUnique();
        }
    }
}
