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
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public ActionResult Index()
        {
            IEnumerable<CityViewModel> viewModelCity;
            IEnumerable<City> cty;

            cty = cityService.GetCities().ToList();

            viewModelCity= Mapper.Map<IEnumerable<City>, IEnumerable<CityViewModel>>(cty);

            return View(viewModelCity);
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