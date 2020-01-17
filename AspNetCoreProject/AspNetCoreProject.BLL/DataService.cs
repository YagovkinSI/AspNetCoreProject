using AspNetCoreProject.BLL.Repositories;
using AspNetCoreProject.BLL.Repositories.Interfaces;
using AspNetCoreProject.DAL;
using System;

namespace AspNetCoreProject.BLL
{
    public class DataService
    {
        public IProvincesRepository ProvincesRepository { get; }

        public DataService(ApplicationDbContext dbContext)
        {
            ProvincesRepository = new ProvincesRepository(dbContext);
        }
    }
}
