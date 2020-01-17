using AspNetCoreProject.BLL;
using AspNetCoreProject.DAL.Models;
using AspNetCoreProject.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreProject.PL
{
    public class PresentationService
    {
        private readonly DataService dataService;
        public PresentationService(DataService dataService)
        {
            this.dataService = dataService;
        }

        public async Task<List<ProvinceInfo>> GetProvinceInfoList()
        {
            return await Task.Run(() =>
            {
                return dataService.ProvincesRepository
                    .GetAllProvincesAsync()
                    .Result
                    .Select(p => GetProvinceInfo(p))
                    .ToList();
            });                
        }

        private ProvinceInfo GetProvinceInfo(Province province)
        {
            var provinceInfo = new ProvinceInfo
            {
                ProvinceID = province.Id,
                Name = province.Name,
            };          

            var availableForPlay = province.Users_Provinces == null;
            provinceInfo.AvailableForPlay = availableForPlay;
            provinceInfo.User = availableForPlay
                ? "-"
                : province.Users_Provinces.User.UserName;

            return provinceInfo;
        }
    }
}
