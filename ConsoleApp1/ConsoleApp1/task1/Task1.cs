using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.task1
{
   internal class Task1: IBaseTask
    {
        public void StartTask()
        {
            int[] staticArr = new int[3];
            int[] arr = new int[3];
            int index = 0;
            
            Console.WriteLine("Enter number with your list: ");
            int num = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter number: ");
                staticArr[i] = Convert.ToInt32(Console.ReadLine());

                if (staticArr[i] < (10 + num) && staticArr[i] > 0)
                {
                    arr[index] = staticArr[i];
                    index++;
                }
            }

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

    }
}

