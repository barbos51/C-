using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.task1
{
    internal class Task4:IBaseTask
    {
        public void StartTask()
        {
            Random random = new Random();


            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            Console.WriteLine("Введіть останню цифру у списку групи: ");
            int numList = Convert.ToInt32(Console.ReadLine());

            int size = 10 + numList;
            int[] X = new int[size];

            for (int i = 0; i < size; i++)
            {
                X[i] = random.Next(-50, 50);
            }

            Console.WriteLine("Масив X:");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{X[i]}");
            }

            int[] Y = new int[size];

            Console.WriteLine("Введіть якесь ціле число: ");
            int M = Convert.ToInt32(Console.ReadLine());
            int newSize = 0;

            for(int i = 0; i<size;i++)
            {
                if (Math.Abs(X[i])>Math.Abs(M))
                {
                    Y[newSize] = X[i];
                    newSize++;
                }
            }

            Console.WriteLine("Масив Y (елементи більші за модулем ніж M):");
            for (int i = 0; i < newSize; i++)
            {
                Console.WriteLine(Y[i]);
            }
        }
    }
}
