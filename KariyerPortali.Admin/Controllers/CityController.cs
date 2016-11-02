using AutoMapper;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace KariyerPortali.Admin.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        private readonly ICityService cvService;

        public CityController(ICityService CityService)
        {
            this.cvService = CityService;
        }

        public ActionResult Index()
        {
            IEnumerable<CityViewModel> viewModelCvs;
            IEnumerable<City> cvs;

            cvs = cvService.GetCities().ToList();

            viewModelCvs = Mapper.Map<IEnumerable<City>, IEnumerable<CityViewModel>>(cvs);

            return View(viewModelCvs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}