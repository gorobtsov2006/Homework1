using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            /*Даны координаты поля шахматной доски x, y (целые числа, лежащие в диапазоне 1–8). Учитывая, что  
           левое нижнее поле доски(1, 1) является черным, вывести, какой цвет имеет поле с данными координатами*/
            Console.WriteLine("Задание 2");
            Console.WriteLine("Введите координаты (x, y) поля шахматной доски (от 1 до 8)");
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine($"Данное поле имеет {BlackOrWhite(x, y)} цвет");
            Console.WriteLine();

            //Даны числа A, B, C (число A не равно 0).Вернуть количество вещественных корней квадратного уравнения
            Console.WriteLine("Задание 3");
            Console.WriteLine("Введите значения коэффицентов квадратного уравнения (Число A не равно 0)");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine($"Количество корней данного уравнения = {CountRoots(a, b, c)}");
            Console.WriteLine();

            //Создать функцию, которая возвращает минимум из двух переданных вещественных чисел
            Console.WriteLine("Задание 4");
            Console.WriteLine("Введите 2 вещественных числа");
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            Console.WriteLine($"Минимум из этих двух чисел = {Min(num1, num2)}");
            Console.WriteLine();

            //Даны целые числа A и B. Найти произведение всех чётных целых чисел от A до B включительно
            Console.WriteLine("Задание 5");
            Console.WriteLine("Введите целые числа A и B (A < B)");
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            Console.WriteLine($"Произведение всех чётных целых чисел от A до B включительно = {ProductEven(first, second)}");
            Console.WriteLine();

            /*Дано целое число K и набор ненулевых целых чисел; признак его завершения — число 0. Вычислить количество
           чисел в наборе, меньших K, а также количество чисел, делящихся на K нацело*/
            Console.WriteLine("Задание 6");
            int less = 0;
            int div = 0;
            Console.WriteLine("Введите целое число K (K не равно 0)");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Вводите набор чисел, концом вашего набора будет число 0");
            int numOfSet = int.Parse(Console.ReadLine());
            CountLessAndDiv(ref k, ref numOfSet, out less, out div);
            Console.WriteLine($"Количество чисел в наборе меньших {k} = {less}");
            Console.WriteLine($"Количество чисел, делящихся на {k} нацело = {div}");
            Console.WriteLine();

            //Описать перечислимый тип Seasons (времена года). Создать метод, который по номеру месяца [1..12] возвращает время года
            Console.WriteLine("Задание 7");
            Console.WriteLine("Введите номер месяца (1-12)");
            int month = int.Parse(Console.ReadLine());
            Season(month);
            Console.WriteLine();
            Console.WriteLine();

            /*Описать метод, выводящий на консоль N строк "Месяц №<номер месяца>, его сезон: <сезон для этого месяца>". Номера месяцев  
            генерируются случайно*/
            Console.WriteLine("Задание 8");
            Console.WriteLine("Введите желаемое количество строк");
            int stringCount = int.Parse(Console.ReadLine());
            RandomNumbOfMonth(ref stringCount);
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

        /** <summary> Определение цвета поля шахматной доски </summary>*/
        static string BlackOrWhite(int x, int y)
        {
            if ((x < 1) || (x > 8) || (y < 1) || (y > 8))
            {
                throw new Exception("Координаты не принадлежат заданному диапозону");
            }

            //Если сумма значений координат x и y чётная, то поле имеет чёрный цвет, иначе белый
            if ((x + y) % 2 == 0)
                return "чёрный";
            else
                return "белый";
        }

        /** <summary> Определение количества вещественных корней квадратного уравнения </summary>*/
        static int CountRoots(double a, double b, double c)
        {
            if (a == 0)
            {
                throw new ArgumentException("Число A не равно нулю");
            }

            if (b * b - 4 * a * c > 0)
                return 2;
            else if (b * b - 4 * a * c == 0)
                return 1;
            else
                return 0;
        }

        /** <summary> Минимум из двух переданных вещественных чисел </summary>*/
        static double Min(double a, double b) => a < b ? a : b;

        /** <summary> Вычисление произведения всех чётных целых чисел от A до B включительно </summary>*/
        static double ProductEven(int a, int b)
        {
            if (a >= b)
            {
                throw new ArgumentException("A должно быть меньше B");
            }

            double prod = 1;
            //Так как разумнее идти с шагом 2, то необходимо начинать с чётного числа  
            for (int i = a % 2 == 0 ? a : a + 1; i <= b; i += 2)
            {
                prod *= i;
            }
            return prod;
        }

        /** <summary> Вычисление количества чисел в наборе, меньших K, а также количества чисел, делящихся на K нацело </summary>*/
        static void CountLessAndDiv(ref int k, ref int num, out int less, out int div)
        {
            if (k == 0)
            {
                throw new ArgumentException("K не должно быть равно нулю");
            }

            //Переменная, хранящая количество чисел, меньших K
            less = 0;
            //Переменная, хранящая количество чисел, делящихся на K нацело
            div = 0;
            while (num != 0)
            {
                if (num < k)
                    less++;
                if (num % k == 0)
                    div++;
                num = int.Parse(Console.ReadLine());
            }
        }
        
        enum Seasons { Winter, Spring, Summer, Autumn }

        /** <summary> Определение времени года по номеру месяца </summary>*/
        static void Season(int numOfMonth)
        {
            switch (numOfMonth)
            {
                case 12 or 1 or 2:
                    Console.Write(Seasons.Winter);
                    break;
                case >= 3 and < 6:
                    Console.Write(Seasons.Spring);
                    break;
                case >= 6 and < 9:
                    Console.Write(Seasons.Summer);
                    break;
                case >= 9 and < 12:
                    Console.Write(Seasons.Autumn);
                    break;
                default:
                    Console.WriteLine("Нет месяца с таким номером");
                    break;
            }
        }

        /** <summary> Вывод на консоль N строк "Месяц №(номер месяца), его сезон: (сезон для этого месяца) </summary>*/
        static void RandomNumbOfMonth(ref int n)
        {
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                var m = r.Next(1, 13);
                Console.Write($"Месяц №{m}, его сезон: ");
                Season(m);
                Console.WriteLine(".");
            }
        }
    }
}
/*Задание 1
Введите трёхзначное число
794
После обнуления разряда десятков: 704

Задание 2
Введите координаты (x, y) поля шахматной доски (от 1 до 8)
1
2
Данное поле имеет белый цвет

Задание 3
Введите значения коэффицентов квадратного уравнения (Число A не равно 0)
3
5
0
Количество корней данного уравнения = 2

Задание 4
Введите 2 вещественных числа
6,6
6,7
Минимум из этих двух чисел = 6,6

Задание 5
Введите целые числа A и B (A < B)
5
9
Произведение всех чётных целых чисел от A до B включительно = 48

Задание 6
Введите целое число K (K не равно 0)
5
Вводите набор чисел, концом вашего набора будет число 0
25
5
7
3
0
Количество чисел в наборе меньших 5 = 1
Количество чисел, делящихся на 5 нацело = 2

Задание 7
Введите номер месяца (1-12)
9
Autumn

Задание 8
Введите желаемое количество строк
3
Месяц №8, его сезон: Summer.
Месяц №9, его сезон: Autumn.
Месяц №3, его сезон: Spring.*/

/*Задание 1
Введите трёхзначное число
687
После обнуления разряда десятков: 607

Задание 2
Введите координаты (x, y) поля шахматной доски (от 1 до 8)
8
8
Данное поле имеет чёрный цвет

Задание 3
Введите значения коэффицентов квадратного уравнения (Число A не равно 0)
1
1
6
Количество корней данного уравнения = 0

Задание 4
Введите 2 вещественных числа
3,7
3,7
Минимум из этих двух чисел = 3,7

Задание 5
Введите целые числа A и B (A < B)
6
11
Произведение всех чётных целых чисел от A до B включительно = 480

Задание 6
Введите целое число K (K не равно 0)
6
Вводите набор чисел, концом вашего набора будет число 0
18
4
2
60
1
0
Количество чисел в наборе меньших 6 = 3
Количество чисел, делящихся на 6 нацело = 2

Задание 7
Введите номер месяца (1-12)
5
Spring

Задание 8
Введите желаемое количество строк
4
Месяц №9, его сезон: Autumn.
Месяц №11, его сезон: Autumn.
Месяц №4, его сезон: Spring.
Месяц №4, его сезон: Spring.*/