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
    public class ApplicationsController : Controller
    {
        // GET: Applications
        private readonly IJobApplicationService jobApplicationService;

        public ApplicationsController(IJobApplicationService jobApplicationService)
        {
            this.jobApplicationService = jobApplicationService;
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
            var allJobsAplications = jobApplicationService.Search(sSearch);
            IEnumerable<JobApplication> filteredJobApplications = allJobsAplications;

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.Candidate.FirstName);
                        break;
                    case 1:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.Candidate.LastName);
                        break;
                    case 2:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.Employer.EmployerName);
                        break;
                    case 3:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.Job.Title);
                        break;

                    case 4:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.ApplicationDate);
                        break;
                    case 5:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.UpdateDate);
                        break;

                    default:
                        filteredJobApplications = filteredJobApplications.OrderBy(j => j.Candidate.FirstName);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.Candidate.FirstName);
                        break;
                    case 1:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.Candidate.LastName);
                        break;
                    case 2:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.Employer.EmployerName);
                        break;
                    case 3:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.Job.Title);
                        break;
                    case 4:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.ApplicationDate);
                        break;
                    case 5:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.UpdateDate);
                        break;

                    default:
                        filteredJobApplications = filteredJobApplications.OrderByDescending(j => j.Candidate.FirstName);
                        break;
                }
            }

            var displayedJobApplications = filteredJobApplications.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from j in displayedJobApplications
                         select new[] {j.Candidate.FirstName, j.Candidate.LastName, j.Employer.EmployerName,
                             j.Job.Title, j.ApplicationDate.ToShortDateString(),
                             j.UpdateDate.ToShortTimeString()};
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = filteredJobApplications.Count(),
                iTotalDisplayRecords = filteredJobApplications.Count(),
                aaData = result
            },
                JsonRequestBehavior.AllowGet);
        }


    }
}