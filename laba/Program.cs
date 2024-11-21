using System;
using System.Globalization;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace laba
{
    class Program
    {
        /// <summary>
        /// поиск max
        /// </summary>
        static int Max(int num1, int num2)
        {
            return num1 > num2 ? num1 : num2;
        }

        /// <summary>
        /// меняет переменные местами
        /// </summary>
        static void SwapOptions(ref string first, ref string second) 
        {
            (first, second) = (second, first);
        }

        /// <summary>
        /// считает факториал в цикле
        /// </summary>

        static bool LoopFactorial(uint num, out long resoult)
        {
            resoult = 1;
            try
            {
                for (int i = 1; i <= num; i++)
                {
                    checked
                    {
                        resoult *= i;
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                return false; 
            }

        }

        /// <summary>
        /// считает факториал рекурсией
        /// </summary>
        static long RecursionFactorial(uint num)
        {

            if (num < 1) return 1;
            else return (num * RecursionFactorial(num - 1));
        }

        /// <summary>
        /// нод 2 чисел
        /// </summary>
        static int Nod(int num1, int num2)
        {
            while (num1 != 0 && num2 != 0)
            {
                if (num1 > num2) num1 = num1% num2;
                else num2 = num2% num1;
            }
            return (num1 + num2);
        }

        /// <summary>
        /// нод 3 чисел
        /// </summary>
        static int Nod(int num1, int num2, int num3)
        {
            return (Nod(Nod(num1, num2), num3));
        }

        /// <summary>
        /// считает n-ное число Фибоначчи
        /// </summary>
        static int FibonacciSeq(uint n)
        {
            if (n <= 1) return 0;
            if (n == 2) return 1;
            else return (FibonacciSeq(n - 1) + FibonacciSeq(n - 2));
        }

//        Упражнение 5.1 Написать метод, возвращающий наибольшее из двух чисел.Входные
//параметры метода – два целых числа.Протестировать метод.
        static void Task1()
        {
            Console.WriteLine("задание 5.1");
            bool checkFirst, checkSecond;
            int num1, num2;
            do
            {
                Console.Write("введите 1е число:");
                checkFirst = int.TryParse(Console.ReadLine(), out num1);
                Console.Write("введите 2е число:");
                checkSecond = int.TryParse(Console.ReadLine(), out num2);
            }
            while (!(checkFirst && checkSecond));
            Console.WriteLine($"максимальное число: {Max(num1, num2)}");     
        }

//        Упражнение 5.2 Написать метод, который меняет местами значения двух передаваемых
//параметров.Параметры передавать по ссылке.Протестировать метод.
        static void Task2()
        {
            Console.WriteLine("задание 5.2");
            Console.Write("введите 1 параметр: ");
            string firstOpt = Console.ReadLine();
            Console.Write("введите 2 параметр: ");
            string secondOpt = Console.ReadLine();
            SwapOptions(ref firstOpt, ref secondOpt);
            Console.WriteLine($"{firstOpt} {secondOpt}");
        }


//        Упражнение 5.3 Написать метод вычисления факториала числа, результат вычислений
//передавать в выходном параметре.Если метод отработал успешно, то вернуть значение true;
//        если в процессе вычисления возникло переполнение, то вернуть значение false. Для
//        отслеживания переполнения значения использовать блок checked.
        static void Task3()
        {
            Console.WriteLine("задание 5.3");
            uint numLoop;
            do
            {
                Console.Write("введите число >0: ");
            }
            while (!uint.TryParse(Console.ReadLine(), out numLoop));
            if (LoopFactorial(numLoop, out long resoult)) Console.WriteLine($"факториал равен {resoult}");
            else Console.WriteLine("не обработано");
        }
        static void Task4()
        {
            Console.WriteLine("задание 5.4");
            uint num;
            do
            {
                Console.Write("введите число > 0: ");
            }
            while (!uint.TryParse(Console.ReadLine(), out num));
            Console.WriteLine(RecursionFactorial(num));
        }
//        Домашнее задание 5.1 Написать метод, который вычисляет НОД двух натуральных чисел
//(алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех
//натуральных чисел.
        static void Task5()
        {
            Console.WriteLine("Домашнее задание 5.1");
            bool flag = true;
            int[] nums = new int[0];
            do
            {
                flag = true;
                try
                {
                    Console.Write("Введите 2 или 3 числа, НОД которых вы хотите найти: ");
                    nums = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray<int>();
                }
                catch (FormatException) {}
                finally
                {
                    if (nums.Length < 2 || nums.Length > 3)
                    {
                        Console.WriteLine("допускается ввод 2 или 3 целых чисел");
                        flag = false;
                    }

                }
            }
            while (!flag) ;
            if (nums.Length == 2) Console.WriteLine($"НОД равен {Nod(nums[0], nums[1])}");
            else Console.WriteLine($"НОД равен {Nod(nums[0], nums[1], nums[2])}");
        }

//        Домашнее задание 5.2 Написать рекурсивный метод, вычисляющий значение n-го числа
//ряда Фибоначчи.Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8,
//13... Для таких чисел верно соотношение Fk = Fk - 1 + Fk - 2.
        static void Task6()
        {
            Console.WriteLine("домашнее задание 5.2");
            uint n;
            do
            {
                Console.Write("введите n член ряда Фибоначи (>0)");
            }
            while (!uint.TryParse(Console.ReadLine(), out n));
            Console.WriteLine(FibonacciSeq(n));

        }
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();     
            
        }       
    }
}