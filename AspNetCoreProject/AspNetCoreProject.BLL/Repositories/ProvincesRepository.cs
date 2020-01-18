using AspNetCoreProject.BLL.Repositories.Interfaces;
using AspNetCoreProject.DAL;
using AspNetCoreProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreProject.BLL.Repositories
{
    internal class ProvincesRepository : IProvincesRepository
    {
        private readonly ApplicationDbContext dbContext;
        public ProvincesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Province>> GetAllProvincesAsync()
        {
            return await dbContext.Provinces
                .Include(p => p.Users_Provinces)
                .Include("Users_Provinces.User")
                .ToListAsync();
        }

        public async Task<Province> GetProvinceByUserIdAsync(string userId)
        {
            var user_province = await dbContext.Users_Provinces
                .Include(l => l.Province)
                .FirstOrDefaultAsync(p => p.UserID == userId);
            return user_province?.Province;
        }

        public async Task<Response> LinkProvinceAndUserAsync(string userId, int provinceId)
        {
            await foreach(var currLink in dbContext.Users_Provinces.AsAsyncEnumerable())
            {               
                if (currLink.UserID == userId && currLink.ProvinceID == provinceId)
                    return new Response(true);
                if (currLink.UserID == userId)
                    return new Response(false, "Пользователь уже имеет одну провинцию");
                if (currLink.ProvinceID == provinceId)
                    return new Response(false, "Пользователь занята другим пользователем");
            }

            var link = new User_Province
            {
                ProvinceID = provinceId,
                UserID = userId
            };
            dbContext.Add(link);
            var result = dbContext.SaveChanges();
            return result == 0
                ? new Response(false, "Непредвиденная ошибка при сохранении изменений в БД")
                : new Response(true);
        }
    }
}
