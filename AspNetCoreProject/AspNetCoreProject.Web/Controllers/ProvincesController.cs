using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreProject.BLL;
using AspNetCoreProject.PL;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProject.Web.Controllers
{
    public class ProvincesController : Controller
    {
        private readonly DataService dataService;
        private readonly PresentationService presentationService;

        public ProvincesController(DataService dataService, PresentationService presentationService)
        {
            this.dataService = dataService;
            this.presentationService = presentationService;
        }

        // GET: Provinces
        public async Task<IActionResult> IndexAsync()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.HaveNotProvince = userId == null
                ? false
                : dataService.ProvincesRepository.GetProvinceByUserIdAsync(userId.Value).Result == null;
            return View(await presentationService.GetProvinceInfoList());
        }

        // GET: Provinces/Select/5
        public IActionResult Select(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userId == null)
                return NotFound();
            
            var success = dataService.ProvincesRepository.LinkProvinceAndUserAsync(userId.Value, id.Value);
            
            return success.Result.Success
                ? (IActionResult)RedirectToAction("Index")
                : NotFound();
        }

        // GET: Provinces/Details/5
        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            return View(await presentationService.GetProvinceInfo(id.Value));
        }
    }
}