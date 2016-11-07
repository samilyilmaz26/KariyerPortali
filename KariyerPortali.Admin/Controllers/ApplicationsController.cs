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
        

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedJobsAplications = jobApplicationService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);
            

            var result = from j in displayedJobsAplications
                         select new[] {j.Candidate.FirstName, j.Candidate.LastName, j.Employer.EmployerName,
                             j.Job.Title, j.ApplicationDate.ToShortDateString(),
                             j.UpdateDate.ToShortTimeString()};
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result
            },
                JsonRequestBehavior.AllowGet);

        }


    }
}


            