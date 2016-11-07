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
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedEmployers = employerService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            
            var result = from c in displayedEmployers
                         select new[] { string.Empty, c.Logo, c.EmployerName, (c.City != null ? c.City.CityName.ToString() : string.Empty), c.Email.ToString(), string.Empty };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result.ToList()
        },
                JsonRequestBehavior.AllowGet);
        }
    }
}