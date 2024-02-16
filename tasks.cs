using System;

namespace Homework1
{
    internal class tasks
    {
        static void Main(string[] args)
        {
            //Дано трехзначное число. Обнулить в нем разряд десятков
            Console.WriteLine("Задание 1");
            Console.WriteLine("Введите трёхзначное число");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"После обнуления разряда десятков: {Zeroing(num)}");
            Console.WriteLine();
        }

        /** <summary> Обнуление разряда десятков </summary>*/
        static int Zeroing(int a)
        {
            if ((a < 100) || (a > 999))
            {
                throw new Exception("Число не трёхзначое");
            }
            return a - ((a / 10) % 10) * 10;
        }
    }
}