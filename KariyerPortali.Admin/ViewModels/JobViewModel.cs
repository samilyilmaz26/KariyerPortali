using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KariyerPortali.Admin.ViewModels
{
    public class JobViewModel
    {
        public int JobId { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public JobType JobType { get; set; }

        public DateTime Createdate { get; set; }
    }
}