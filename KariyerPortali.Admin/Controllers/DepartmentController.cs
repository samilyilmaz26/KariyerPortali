using KariyerPortali.Admin.Models;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
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
            var allDepartments = departmentService.Search(sSearch).ToList();
            IEnumerable<Department> filteredDepartments = allDepartments;

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);


            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
            {
                switch (sortColumnIndex)
                {
                    case 0:
                        filteredDepartments = filteredDepartments.OrderBy(c => c.DepartmentId);
                        break;
                    case 1:
                        filteredDepartments = filteredDepartments.OrderBy(c => c.DepartmentName);
                        break;
                    default:
                        filteredDepartments = filteredDepartments.OrderBy(c => c.DepartmentId);
                        break;
                }
            }
            else
            {
                switch (sortColumnIndex)
                {

                    case 0:
                        filteredDepartments = filteredDepartments.OrderByDescending(c => c.DepartmentId);
                        break;
                    case 1:
                        filteredDepartments = filteredDepartments.OrderByDescending(c => c.DepartmentName);
                        break;
                    
                    default:
                        filteredDepartments = filteredDepartments.OrderByDescending(c => c.DepartmentId);
                        break;
                }
            }

            var displayedDepartments = filteredDepartments.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedDepartments
                         select new[] { c.DepartmentId.ToString(), c.DepartmentName.ToString()  };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = filteredDepartments.Count(),
                iTotalDisplayRecords = filteredDepartments.Count(),
                aaData = result
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}