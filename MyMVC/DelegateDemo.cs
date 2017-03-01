using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVC
{
    public class DelegateDemo
    {
        #region 三種內置delegate demo
        /// <summary>
        /// 三種內置delegate demo
        /// </summary>
        private void Demo()
        {
            Action<int> a = delegate (int val)
           {
               Console.WriteLine(val);
           };
            Action<int> a2 = (val) => Console.WriteLine(val);
            a(1);
            a2(1);
            Predicate<int> p = delegate (int pre)
            {
                return pre > 0;
            };

            Predicate<int> p2 = (pre) => pre > 0;
            Console.WriteLine((p(1)));
            Console.WriteLine((p2(1)));
            Func<int, bool> func = delegate (int fun)
             {
                 return fun > 0;
             };
            Func<int, bool> func2 = (fun) => fun > 0;
        } 
        #endregion
    }
}