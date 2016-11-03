using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public ICollection<SkillInfo> SkillInfos { get; set; }
    }
}
