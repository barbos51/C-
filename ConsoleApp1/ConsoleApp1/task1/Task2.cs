using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.task1
{
    internal class Task2 : IBaseTask
    {
        private double[] arr = new double[3];
        public void InputNum()
        {
            
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Введіть сторону трикутника {i+1}: ");
                arr[i] = double.Parse(Console.ReadLine());
            }
        }

        public bool CheckArr()
        {
            return arr[0] + arr[1] > arr[2] && arr[1] + arr[2] > arr[0] && arr[0] + arr[2] > arr[1];
        }
            
        public double Perimetr()
        {
            return arr[0] + arr[1] + arr[2];
        }

        public double Area()
        {
            double p = Perimetr()/2;
            return Math.Sqrt(p * (p - arr[0]) * (p - arr[1]) * (p - arr[2]));
        }
        public string View()
        {
            if(arr[0] == arr[1] && arr[1] == arr[2])
                return "Рівносторонній";
            else if (arr[0] == arr[1] || arr[1] == arr[2] || arr[0] == arr[2])
            {
                return "Рівнобедрений";
            }
            else
            {
                return "Різносторонній";
            }
        }
        public void Result()
        {
            if (!CheckArr())
            {
                Console.WriteLine("Неправильний трикутник");
                return;
            }

            Console.WriteLine($"Сторони трикутника: {arr[0]}, {arr[1]}, {arr[2]}");
            Console.WriteLine($"Периметр трикутника: {Perimetr()}");
            Console.WriteLine($"Площа трикутника: {Area()}");
            Console.WriteLine($"Вид трикутника: {View()}");
        }

    public void StartTask()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Task2 Utask = new Task2();
            Utask.InputNum();
            Utask.Result();
        }
    }
}
