using System;
using System.Threading;

namespace Demo_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(new ThreadStart(WorkThreadFunction));
            thread.Name = "My Test thread";
            thread.Priority = ThreadPriority.AboveNormal;

            Console.WriteLine("Is Background Thread" + thread.IsBackground);
            Console.WriteLine("Thread priority is "+thread.Priority);
            thread.Start();

            ThreadStart threadStart = new ThreadStart(ThreadStartMethodDemo);
            var myThreadStart = new Thread(threadStart);
            myThreadStart.Start();

            ParameterizedThreadStart start = new ParameterizedThreadStart(StartMethod);
            var parameterizedThreadStart = new Thread(start);
            parameterizedThreadStart.Start(10);

            var thread1 = new Thread(() => { Console.WriteLine("Hi"); });
            thread1.Start();

            var thread2 = new Thread(MethodGroupDemo);
            thread2.Start();

        }

        static void ThreadStartMethodDemo()
        {
            Console.WriteLine("ThreadStartMethodDemo");
        }

        static void MethodGroupDemo()
        {
            Console.WriteLine("I am from MethodGroup");
        }

        static void StartMethod(object info)
        {
            // This receives the value passed into the Thread.Start method.
            int value = (int)info;
            Console.WriteLine("I am from parameterized start " +value);
        }

        public static void WorkThreadFunction()
        {
            try
            {
                // do any background work
                Console.WriteLine("My name is " + Thread.CurrentThread.Name);
            }
            catch (Exception ex)
            {
                // log errors
            }
        }

    }
}
