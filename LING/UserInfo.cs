using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LING
{
    public partial class UserInfo//partial 一个类，可以分成几个类写，最终合并到一起
    {
        public string Username { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        //爱好
        public string aihao { get; set; }
        public List<string> jineng = new List<string>();
    }
}
