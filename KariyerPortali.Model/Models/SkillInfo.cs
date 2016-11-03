using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class SkillInfo
    {

        public int SkillInfoId { get; set; }
        
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public float Point { get; set; }
    }
}
