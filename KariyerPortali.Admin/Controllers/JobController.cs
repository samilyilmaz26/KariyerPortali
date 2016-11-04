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
    public class JobController : Controller
    {
        private readonly IJobService jobService;

        public JobController(IJobService jobService)
        {
            this.jobService = jobService;
        }
        // GET: Job
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Liste()
        {
            return View();
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var allJobs = jobService.Search(sSearch);
            IEnumerable<Job> filteredJobs = allJobs;

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredJobs = filteredJobs.OrderBy(c => c.Employer.EmployerName);
                        break;
                    case 1:
                        filteredJobs = filteredJobs.OrderBy(c => c.Description);
                        break;
                    case 2:
                        filteredJobs = filteredJobs.OrderBy(c => c.Employer.City.CityName);
                        break;
                    case 3:
                        filteredJobs = filteredJobs.OrderBy(c => c.JobType);
                        break;
                    case 4:
                        filteredJobs = filteredJobs.OrderBy(c => c.Createdate);
                        break;
                    case 5:
                        filteredJobs = filteredJobs.OrderBy(c => c.Title);
                        break;
                    default:
                        filteredJobs = filteredJobs.OrderBy(c => c.Employer.EmployerName);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Employer.EmployerName);
                        break;
                    case 1:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Description);
                        break;
                    case 2:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Employer.City.CityName);
                        break;
                    case 3:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.JobType);
                        break;
                    case 4:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Createdate);
                        break;
                    case 5:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Title);
                        break;
                    default:
                        filteredJobs = filteredJobs.OrderByDescending(c => c.Employer.EmployerName);
                        break;
                }
            }

            var displayedJobs = filteredJobs.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedJobs
                         select new[] { c.Title.ToString(), c.Description.ToString(), c.Employer.EmployerName.ToString(), c.Employer.City.CityName.ToString(), c.JobType.ToString(), c.Experience.ExperienceName.ToString(), c.Responsibilities.ToString(), c.Qualifications.ToString(), c.Createdate.ToShortDateString(), c.CreatedBy.ToString(), c.UpdateDate.ToShortDateString(), c.UpdatedBy.ToString() };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = filteredJobs.Count(),
                iTotalDisplayRecords = filteredJobs.Count(),
                aaData = result
            },
                JsonRequestBehavior.AllowGet);
        }

    }
}