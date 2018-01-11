using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LING
{
    class laopaixu:IComparer<UserInfo>
    {
        public int Compare(UserInfo x, UserInfo y)
        {
            //return x.age.CompareTo(y.age);

            if (x.age > y.age)
                return 1;//反过来就是降序
            else if (x.age < y.age)
                return -1;
            else
                return 0;
        }
    }
}
