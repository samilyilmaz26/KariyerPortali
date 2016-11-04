using AutoMapper;
using KariyerPortali.Admin.Models;
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
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.Message = "Your application create page.";

            return View();
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

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var allCities = cityService.Search(sSearch);
            IEnumerable<City> filteredCities = allCities;

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredCities = filteredCities.OrderBy(c => c.CityId);
                        break;
                    case 1:
                        filteredCities = filteredCities.OrderBy(c => c.CityName);
                        break;
                    case 2:
                        filteredCities = filteredCities.OrderBy(c => c.Country.CountryName);
                        break;


                    default:
                        filteredCities = filteredCities.OrderBy(c => c.CityId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredCities = filteredCities.OrderByDescending(c => c.CityId);
                        break;
                    case 1:
                        filteredCities = filteredCities.OrderByDescending(c => c.CityName);
                        break;
                    case 2:
                        filteredCities = filteredCities.OrderByDescending(c => c.Country.CountryName);
                        break;
                    default:
                        filteredCities = filteredCities.OrderByDescending(c => c.CityId);
                        break;
                }
            }

            var displayedCities = filteredCities.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCities
                         select new[] { c.CityId.ToString() , c.CityName.ToString() , (c.Country != null? c.Country.CountryName.ToString(): string.Empty)};
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = filteredCities.Count(),
                iTotalDisplayRecords = filteredCities.Count(),
                aaData = result
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}