﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string ExperienceName { get; set; }
        public ICollection<Job> Jobs { get; set; }

    }
}
