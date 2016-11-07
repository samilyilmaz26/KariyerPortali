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
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;

         public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        // GET: Country
        public ActionResult Index()
        {
            
            return View();
           
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var allCountries = countryService.Search(sSearch).ToList();
            IEnumerable<Country> filteredCountries = allCountries;

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredCountries = filteredCountries.OrderBy(c => c.CountryId);
                        break;
                    case 1:
                        filteredCountries = filteredCountries.OrderBy(c => c.CountryName);
                        break;

                    default:
                        filteredCountries = filteredCountries.OrderBy(c => c.CountryId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredCountries = filteredCountries.OrderByDescending(c => c.CountryId);
                        break;
                    case 1:
                        filteredCountries = filteredCountries.OrderByDescending(c => c.CountryName);
                        break;

                    default:
                        filteredCountries = filteredCountries.OrderByDescending(c => c.CountryId);
                        break;
                }
            }

            var displayedCountries = filteredCountries.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCountries
                         select new[] { string.Empty, c.CountryId.ToString(), c.CountryName, string.Empty, };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allCountries.Count(),
                iTotalDisplayRecords = filteredCountries.Count(),
                aaData = result
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}