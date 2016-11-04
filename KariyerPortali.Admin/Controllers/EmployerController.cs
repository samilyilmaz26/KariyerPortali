﻿using AutoMapper;
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
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var allEmployers = employerService.Search(sSearch).ToList();
            IEnumerable<Employer> filteredEmployers = allEmployers;

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.EmployerId);
                        break;
                    case 1:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.EmployerName);
                        break;

                    default:
                        filteredEmployers = filteredEmployers.OrderBy(c => c.EmployerId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.EmployerId);
                        break;
                    case 1:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.EmployerName);
                        break;

                    default:
                        filteredEmployers = filteredEmployers.OrderByDescending(c => c.EmployerId);
                        break;
                }
            }

            var displayedCVs = filteredEmployers.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCVs
                         select new[] { c.Logo, c.EmployerName, c.City.CityName,c.Email.ToString() };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allEmployers.Count(),
                iTotalDisplayRecords = filteredEmployers.Count(),
                aaData = result
            },
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}