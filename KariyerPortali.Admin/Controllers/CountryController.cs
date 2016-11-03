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
        //public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        //{

        //    string sSearch = "";
        //    if (param.sSearch != null) sSearch = param.sSearch;
        //    var allCVs = new CountryService().GetAllForAdmin(sSearch);
        //    IEnumerable<Country> filteredCVs = allCVs;

        //    var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


        //    var sortDirection = Request["sSortDir_0"]; // asc or desc
        //    if (sortDirection == "asc")
        //    {
        //        switch (sortColumnIndex)
        //        {
        //            case 0:
        //                filteredCVs = filteredCountries.OrderBy(c => c.CountryId);
        //                break;
        //            case 1:
        //                filteredCVs = filteredCountryName.OrderBy(c => c.CountryName)
        //                break;
                   
        //            default:
        //                filteredCVs = filteredCVs.OrderBy(c => c.CountryId);
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        switch (sortColumnIndex)
        //        {
        //            case 0:
        //                filteredCVs = filteredCountries.OrderByDescending(c => c.CountryId);
        //                break;
        //            case 1:
        //                filteredCVs = filteredCountries.OrderByDescending(c => c.CountryName)
        //                break;
                   
        //            default:
        //                filteredCVs = filteredCountries.OrderByDescending(c => c.CountryId);
        //                break;
        //        }
        //    }

        //    var displayedCVs = filteredCVs.Skip(param.iDisplayStart).Take(param.iDisplayLength);
        //    var result = from c in displayedCVs
        //                 select new[] { c.PortalNo ?? string.Empty, c.FirstName + " " + c.LastName, c.Gender.ToString(), c.Expertise.ExpertiseName, c.Notes ?? string.Empty, c.Status.ToString(), c.ShowInList.ToString(), c.Location ?? string.Empty, c.CreateDate.ToShortDateString(), c.Teacher.FullName, c.CVFile, c.CVId.ToString() };
        //    return Json(new
        //    {
        //        sEcho = param.sEcho,
        //        iTotalRecords = allCVs.Count(),
        //        iTotalDisplayRecords = filteredCVs.Count(),
        //        aaData = result
        //    },
        //        JsonRequestBehavior.AllowGet);
        //}
    }
}