using System;
using System.Globalization;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace laba
{
    class Program
    {
        static int Max(int num1, int num2)
        {
            return num1 > num2 ? num1 : num2;
        }
        static void SwapOptions(ref string first, ref string second) 
        {
            (first, second) = (second, first);
        }

        static bool LoopFactorial(int num, out int resoult)
        {
            resoult = 1;
            bool flag = false;
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
        static int RecursionFactorial(int num)
        {

            if (num < 1) return 1;
            else return (num * RecursionFactorial(num - 1));
        }
        static int Nod(int num1, int num2)
        {
            while (num1 != 0 && num2 != 0)
            {
                if (num1 > num2) num1 = num1% num2;
                else num2 = num2% num1;
            }
            return (num1 + num2);
        }
        static int Nod(int num1, int num2, int num3)
        {
            return (Nod(Nod(num1, num2), num3));
        }
        static int FibonacciSeq(uint n)
        {
            if (n <= 1) return 0;
            if (n == 2) return 1;
            else return (FibonacciSeq(n - 1) + FibonacciSeq(n - 2));
        }

        static void Task1()
        { 
            bool checkFirst, checkSecond;
            int num1, num2;
            do
            {
                Console.Write("введите 2 числа");
                checkFirst = int.TryParse(Console.ReadLine(), out num1);
                checkSecond = int.TryParse(Console.ReadLine(), out num2);
            }
            while (!(checkFirst && checkSecond));
            Console.WriteLine($"максимальное число: {Max(num1, num2)}");
            
        }
        static void Task2()
        {
            Console.Write("введите 1 параметр: ");
            string firstOpt = Console.ReadLine();
            Console.Write("введите 2 параметр: ");
            string secondOpt = Console.ReadLine();
            SwapOptions(ref firstOpt, ref secondOpt);
            Console.WriteLine($"{firstOpt} {secondOpt}");
        }

        static void Task3()
        {
            Console.WriteLine("задание 5.3");
            int numLoop;
            do
            {
                Console.Write("введите число >0: ");
            }
            while (!int.TryParse(Console.ReadLine(), out numLoop) && (numLoop > 0));
            if (LoopFactorial(numLoop, out int resoult)) Console.WriteLine($"факториал равен {resoult}");
            else Console.WriteLine("не обработано");
        }
        static void Task4()
        {
            int num;
            do
            {
                Console.Write("введите число > 0: ");
            }
            while (!int.TryParse(Console.ReadLine(), out num) && (num > 0));
            Console.WriteLine(RecursionFactorial(num));
        }
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