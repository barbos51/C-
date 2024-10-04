using System;
using ConsoleApp1.task1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBaseTask task1 = new Task1();
            IBaseTask task2 = new Task2();
            IBaseTask task3 = new Task3();
            IBaseTask task4 = new Task4();

            //task1.StartTask();
            //task2.StartTask();
            //task3.StartTask();
            //task4.StartTask();

            IBaseTask[] baseTasks = { task1, task2, task3, task4 };

            foreach (var task in baseTasks)
            {
                task.StartTask();
            }
        }
    }
}
