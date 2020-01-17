using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index()
        {
            return View(presentationService.GetProvinceInfoList().Result);
        }
    }
}