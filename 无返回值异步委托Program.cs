using System;
using System.Threading;

namespace ConsoleTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //线程开启方式：异步委托
            /*无返回值的委托*/
            Action<int, string> myAction = (int i, string str) =>
            {
                for (int j = 0; j < 300; j++)
                {
                    Thread.Sleep(50);
                    Console.WriteLine(str + " : " + i);
                }
            };
            
            myAction.BeginInvoke(6, "我是异步线程", null, null);
            for (int i = 0; i < 300; i++)
            {
                Console.WriteLine("-------" + Thread.CurrentThread.Name);
            }

            Console.ReadKey();
        }
    }
}