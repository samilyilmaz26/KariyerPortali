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
            IEnumerable<CountryViewModel> viewModelCountry;

            IEnumerable<Country> country;

            country = countryService.GetCountries().ToList();

            viewModelCountry = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(country);

            return View(viewModelCountry);
           
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}