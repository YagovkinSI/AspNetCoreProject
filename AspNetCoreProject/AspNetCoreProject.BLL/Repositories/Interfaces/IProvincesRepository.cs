using AspNetCoreProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreProject.BLL.Repositories.Interfaces
{
    public interface IProvincesRepository
    {
        Task<List<Province>> GetAllProvincesAsync();
        Task<Province> GetProvinceByUserIdAsync(string userId);
        Task<Response> LinkProvinceAndUserAsync(string userId, int provinceId);
    }
}
