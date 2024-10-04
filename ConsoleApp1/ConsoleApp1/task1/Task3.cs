using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.task1
{
    internal class Task3:IBaseTask
    {      
        public void StartTask()
        {
            Random random = new Random();
             
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            
            
            Console.WriteLine("Введіть останню цифру у списку групи: ");
            int numList = Convert.ToInt32(Console.ReadLine());
            
            int size = 10 + numList;
            int[] arr = new int[size];
            
            for(int i = 0; i <size; i++)
            {
                arr[i] = random.Next(1, 50);
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{arr[i]}");
            }
            int max = arr[0];
            int min = arr[0];
            
            for(int i =0; i < size; i++)
            {
                if(arr[i]>max)
                {
                    max = arr[i];
                }
                if(arr[i]<min)
                {
                    min = arr[i];
                }
            }

            Console.WriteLine($"Максимальне число: {max}");
            Console.WriteLine($"Мінімальне число: {min}");
        }
    }
}
