using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
    public class Setting
    {
        public int SettingId { get; set; }
        //string length 100 olucak
        public string Name{ get; set; }
        //string length max olucak
        public string Value { get; set; }
    }
}
