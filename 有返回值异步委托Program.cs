using System;
using System.Threading;

namespace ConsoleTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //线程开启方式：异步委托
            /*有返回值的委托,Func<...>最后一个参数为方法返回值，其余是方法参数*/
            Func<string, int, string, int, double> myFunction = (name, age, nickName, salary) =>
                {
                    for (int i = 0; i < 300; i++)
                    {
                        Console.WriteLine("This is 异步委托线程：" + (i + 1));
                    }

                    return (double) salary / age;
                };
            myFunction.BeginInvoke("gao", 30, "little gao", 1000, (result =>
            {
                var res = myFunction.EndInvoke(result);
                Console.WriteLine("回调取得结果："+res);
            }), null);
            
            for (int i = 0; i < 300; i++)
            {
                Console.WriteLine("This is Main:"+(i+1));
            }
            Console.ReadKey();
        }
    }
}