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
            IEnumerable<JobViewModel> viewModelJob;
            IEnumerable<Job> jb;

            jb = jobService.GetJobs().ToList();

            viewModelJob = Mapper.Map<IEnumerable<Job>, IEnumerable<JobViewModel>>(jb);

            return View(viewModelJob);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Liste()
        {
            return View();
        }
    }
}