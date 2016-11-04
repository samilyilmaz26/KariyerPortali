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
    public class EmployerController : Controller
    {
        private readonly IEmployerService employerService;

        public EmployerController(IEmployerService employerService)
        {
            this.employerService = employerService;
        }
        // GET: Employer
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
            var allEmployers = employerService.Search(sSearch);
            IEnumerable<Employer> filteredEmployers = allEmployers;

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);

            
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.Logo);
                        break;
                    case 1:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.EmployerName);
                        break;
                    case 2:
                        filteredEmployers = filteredEmployers.OrderBy(c =>c.City.CityName );
                        break;
                    case 3:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.Email);
                        break;
          
                    default:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.EmployerName);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.Logo);
                        break;
                    case 1:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.EmployerName);
                        break;
                    case 2:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.City.CityName);
                        break;
                    case 3:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.Email);
                        break;

                    default:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.EmployerName);
                        break;
                }
            }

            var displayedEmployers = filteredEmployers.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedEmployers
                         select new[] { c.Logo, c.EmployerName, (c.City != null ? c.City.CityName.ToString() : string.Empty), c.Email.ToString() };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allEmployers.Count(),
                iTotalDisplayRecords = filteredEmployers.Count(),
                aaData = result.ToList()
        },
                JsonRequestBehavior.AllowGet);
        }
    }
}