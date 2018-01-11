using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LING
{
    class LINQ
    {
        /// <summary>
        /// 显示方法
        /// </summary>
        /// <param name="slist"></param>
        public static void Show(List<string> slist)
        {
            foreach (var item in slist)
            {
                Console.WriteLine(item);
            }

        }
        /// <summary>
        /// 显示方法--类
        /// </summary>
        /// <param name="slist"></param>
        public static void Showlei(List<UserInfo> slist)
        {
            foreach (var item in slist)
            {
                Console.WriteLine("名：{0},年龄：{1},点：{2}", item.Username, item.age, item.address);
            }
        }

        /// <summary>
        /// LINQ输出
        /// </summary>
        /// <param name="args"></param>
        static void Main1(string[] args)
        {

            //语法： Var 变量名= 值 //Var 可用于指代任何数据类型，并可直接运用
            //作用：在定义变量的时候不需要明确指定类型
            //例子：
            var a = 1;
            int sum = a + 2;
            Console.WriteLine(sum);

            //也可用于遍历（通用所有类型）
            Dictionary<string, string> div = new Dictionary<string, string>();
            div.Add("aa", "a");
            div.Add("bb", "b");
            foreach (var item in div)//直接用var
            {
                Console.WriteLine(item.Key + "  " + item.Value);
            }

            //可用GetType().Name方法来得知变量的数据类型
            Console.WriteLine(a.GetType().Name);
            Console.WriteLine(div.GetType().Name);

            //匿名类型--对象---不进行数据传输
            var duixiang = new { name = "张三", age = "19" };

            //输出匿名对象
            Console.WriteLine(duixiang.name);
            Console.WriteLine(duixiang.age);

            Console.ReadLine();
        }

        /// <summary>
        /// LINQ输入查询
        /// </summary>
        /// <param name="args"></param>
        static void Main2(string[] args)
        {
            //对象集合初始化
            List<string> slist = new List<string>() { "0", "3", "1", "2" };

            //接受用户输入的值
            string shuru = Console.ReadLine();

            //老方法
            //foreach (var item in slist)
            //{
            //    if (item.Contains(shuru))
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            //Linq方法
            var result = from suiyi in slist
                         where suiyi == shuru
                         select suiyi;
            Show(result.ToList());

            Console.ReadLine();
        }

        /// <summary>
        /// LINQ升序降序
        /// </summary>
        /// <param name="args"></param>
        static void Main3(string[] args)
        {
            //对象集合初始化
            List<string> slist = new List<string>() { "0", "3", "1", "2" };

            Console.WriteLine("-----------------升序排序---------------------");
            //Linq方法
            var result = from suiyi in slist
                         orderby suiyi
                         select suiyi;

            Show(result.ToList());

            Console.WriteLine("-----------------降序排序---------------------");
            //Linq方法
            var result1 = from suiyi in slist
                          orderby suiyi descending
                          select suiyi;

            Show(result1.ToList());
            Console.ReadLine();
        }

        /// <summary>
        /// LINQ多条件输入查询 类
        /// </summary>
        /// <param name="args"></param>
        static void Main4(string[] args)
        {
            List<UserInfo> ulist = new List<UserInfo>() {
               new UserInfo(){Username="诸葛亮",age=22,address="三国"},
               new UserInfo(){Username="黄月英",age=11,address="三国"},
               new UserInfo(){Username="郭嘉",age=3,address="三国"},
               new UserInfo(){Username="黄忠",age=44,address="三国"},
               new UserInfo(){Username="李白",age=11,address="唐"}
            };
            ulist.Add(new UserInfo() { Username = "杜甫", age = 33, address = "宋" });

            //原样输出
            Showlei(ulist);

            //接收
            Console.WriteLine("请输入用户名");
            string name = Console.ReadLine();
            Console.WriteLine("请输入地址");
            string dizhi = Console.ReadLine();
            Console.WriteLine("请输入年龄");//可以先用string类型接收，后面再转成int,这种只是为了讲int空的 Nullable<int>为数据类型也可以;
            int? age = null;
            string agestr = Console.ReadLine();
            if (!string.IsNullOrEmpty(agestr))
                age = Convert.ToInt32(agestr);

            //判断（输入查询）IsNullOrEmpty()可以实现null和""判断
            var result = from suiyi in ulist
                         where (string.IsNullOrEmpty(name) || suiyi.Username == name) &&
                             (string.IsNullOrEmpty(dizhi) || suiyi.address == dizhi) &&
                             (string.IsNullOrEmpty(age.ToString()) || suiyi.age == age)
                         select suiyi;
            Showlei(result.ToList());
            Console.ReadLine();
        }

        /// <summary>
        /// LINQ多字段排序（前面先排，后面再按前面排好的排（不影响前面的））
        /// </summary>
        /// <param name="args"></param>
        static void Main5(string[] args)
        {
            List<UserInfo> ulist = new List<UserInfo>() {
               new UserInfo(){Username="诸葛亮",age=22,address="三国"},
               new UserInfo(){Username="黄月英",age=11,address="三国"},
               new UserInfo(){Username="郭嘉",age=3,address="三国"},
               new UserInfo(){Username="黄忠",age=44,address="三国"},
               new UserInfo(){Username="李白",age=11,address="唐"}
            };
            ulist.Add(new UserInfo() { Username = "杜甫", age = 33, address = "宋" });

            //原样输出
            Showlei(ulist);

            //根据年龄排序
            //接口排序输出
            ulist.Sort(new laopaixu());
            Console.WriteLine("接口排序输出");
            Showlei(ulist);

            //LINQ多字段排序(先按最前面的排，再依次按后面的排下去，并且不影响前面的)
            Console.WriteLine("LINQ年龄降序,姓名升序输出");
            var res = from suiyi in ulist
                      orderby suiyi.age descending, suiyi.Username ascending
                      select suiyi;

            Showlei(res.ToList());

            Console.ReadLine();
        }

        /// <summary>
        /// 多对多比较
        /// 查询条件是一个集合，数据源也是一个集合
        /// 使用复合子句把数据源集合变成一个个字符串
        /// 还有查询出多个字段
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<UserInfo> ulist = new List<UserInfo>() {
               new UserInfo(){Username="诸葛亮",age=22,address="三国",aihao="谋略",jineng=new List<string>(){"火计","空城","神算"}},
               new UserInfo(){Username="黄月英",age=11,address="三国",aihao="诸葛亮",jineng=new List<string>(){"万箭","木造","神算"}},
               new UserInfo(){Username="郭嘉",age=3,address="三国",aihao="谋略",jineng=new List<string>(){"火计","遗囊","神算"}},
               new UserInfo(){Username="黄忠",age=44,address="三国",aihao="战斗",jineng=new List<string>(){"万箭","遗囊","不屈"}},
               new UserInfo(){Username="李白",age=11,address="唐",aihao="诗歌",jineng=new List<string>(){"赋诗","魅惑","不屈"}}
            };
            ulist.Add(new UserInfo() { Username = "杜甫", age = 33, address = "宋", aihao = "诗歌", jineng = new List<string>() { "赋诗", "国志", "不屈" } });

            //原样输出
            Showlei(ulist);

            //根据爱好显示
            Console.WriteLine("请输入爱好");
            string aihao = Console.ReadLine();

            List<string> lovelist = aihao.Split(',').ToList();//将用户输入的用list装

            var aihaoa = from q in ulist
                         where lovelist.Contains(q.aihao)
                         select q;
            Showlei(aihaoa.ToList());

            Console.WriteLine("请输入技能");
            string jineng = Console.ReadLine();
            List<string> lovejineng = jineng.Split(',').ToList();//将用户输入的用list装

            //select suiyi.Username from ulist where alljineng in ('','','')
            //缺点：多个查询字段时会重复信息(可以解决)
            var res = from suiyi in ulist
                      from alljineng in suiyi.jineng
                      where lovejineng.Contains(alljineng)//多对多比较
                      //select suiyi.Username;
                      select new
                      {
                          sname = suiyi.Username,
                          sage = suiyi.age
                      };

            //List<string> strlist = res.ToList();
            var strlist = res.ToList();//如果不知道用什么数据接收，也可以用var接收

            foreach (var item in strlist)
            {
                Console.WriteLine("名：{0},年龄：{1}", item.sname, item.sage);
            }

            Console.ReadLine();
        }
    }
}
