using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.AccessControl;


namespace tasks
{
    public enum GrumpinessLevel
    {
        Low,
        Medium,
        High
    }
    public struct Ded
    {
        public string name;
        public string[] curses;
        public int strokes = 0;
        public GrumpinessLevel level;
        public Ded(string name, GrumpinessLevel level,string[] curses)
        {
            this.name = name;
            this.level = level;
            this.curses = curses;
        }
        public int CountStrokes(params string[] suggstedCurses)
        {
            int k = 0;
            for (int i = 0; i <= suggstedCurses.Length-1; i++)
            {
                for (int n = 0; n <= curses.Length-1; n++)
                {
                    if (suggstedCurses[i] == curses[n]) k++;
                }
            }
            strokes += k;
            return k;
        }
    }

    class Program
    {
        
        static void DrawNumber(int? number)
        {
            switch (number)
            {
                case 0:
                    Console.WriteLine("  ###  \n #   # \n #   # \n #   # \n   #  ");
                    break;
                case 1:
                    Console.WriteLine("   #   \n  ##   \n   #   \n   #   \n  ###  ");
                    break;
                case 2:
                    Console.WriteLine("  ###  \n #   # \n    #  \n  #    \n ###### ");
                    break;
                case 3:
                    Console.WriteLine("  ###  \n #   # \n    #  \n #   # \n  ###  ");
                    break;
                case 4:
                    Console.WriteLine(" #   # \n #   # \n ##### \n     # \n     # ");
                    break;
                case 5:
                    Console.WriteLine(" ##### \n #      \n #####  \n     #  \n #####");
                    break;
                case 6:
                    Console.WriteLine("   ##  \n  #     \n #####  \n #   #  \n  ###   ");
                    break;
                case 7:
                    Console.WriteLine(" ###### \n     #  \n    #   \n    #   \n    #   ");
                    break;
                case 8:
                    Console.WriteLine("  ###  \n #   # \n  ###  \n #   # \n  ###  ");
                    break;
                case 9:
                    Console.WriteLine("  ###  \n #   # \n  ####  \n     #  \n  ###   ");
                    break;
                default:
                    break;
            }
        }

        static int ArraySum(ref int multArray, out int middleArray, params int[] array)
        {
            int sum = 0;
            Span<int> spanArray = new Span<int>(array);
            foreach (ref int num in spanArray)
            {
                sum += num;
                multArray *= num;

            }
            middleArray = sum / array.Length;
            return sum;
        }
        static void NumsSwap(int[] array, int firstNum, int secondNum)
        {
            sbyte pos1 = 0, pos2 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == firstNum) pos1 = (sbyte)i;
                else if (array[i] == secondNum) pos2 = (sbyte)i;
            }
            (array[pos1], array[pos2]) = (array[pos2], array[pos1]);
        }

        static void Task1()
        {
            int[] arr = new int[20];
            Random rand = new Random();
            for (int i = 0; i < 20; i++) arr[i] = rand.Next(100);
            Console.WriteLine($"{string.Join(' ', arr)}\nвведите 2 разных числа, которые хотите заменить:");
            bool flagArr;
            int firstNum = 0, secondNum = 0;
            do
            {
                bool checkFirstNum = int.TryParse(Console.ReadLine(), out firstNum);
                bool cheackSecondNum = int.TryParse(Console.ReadLine(), out secondNum);
                flagArr = (checkFirstNum && cheackSecondNum && (firstNum != secondNum));
                if (flagArr == false) Console.WriteLine("введите 2 разных числа");
            }
            while (flagArr == false);
            NumsSwap(arr, firstNum, secondNum);
            Console.WriteLine(string.Join(' ', arr));
        }
        static void Task2()
        {
            Console.WriteLine("задание 2");
            int multArray = 1;

            int[] array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray<int>();
            Console.WriteLine($"сумма масива {ArraySum(ref multArray, out int middleArray, array)} ,произведение массива {multArray}, среднее арифметическое {middleArray}");
        }
        static void Task3()
        {
            Console.WriteLine("задание 3");
            string input = String.Empty;
            int? number = null;
            bool flagNum = true;
            while (flagNum)
            {
                try
                {
                    input = Console.ReadLine();
                    number = int.Parse(input);
                }
                catch (FormatException)
                {
                    if (input == "exit" || input == "закрыть") flagNum = false;
                    else Console.WriteLine("вы ввели не число");
                    continue;
                }
                if (number > 9 || number < 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    System.Threading.Thread.Sleep(3000);
                    Console.ResetColor();
                    Console.Clear();
                    Console.WriteLine("Ошибка: число должно быть от 0 до 9.");
                }
                else DrawNumber(number);
            }
        }
        static void Task4()
        {
            Console.WriteLine("задание 4");
 
            Ded[] deds = new Ded[5];

            deds[0] = new Ded("Дед Василий", GrumpinessLevel.Low, new string[] {"Гады", "Твари", "Бабки" });
            deds[1] = new Ded("Дед Петр", GrumpinessLevel.Medium, new string[] { "Проститутки", "Карабас" });
            deds[2] = new Ded("Дед Гриша", GrumpinessLevel.High, new string[] { "Гнили", "Скотина", "Наркоман" });
            deds[3] = new Ded("Дед Федор", GrumpinessLevel.Medium, new string[] { "Ублюдки", "Нафиг" });
            deds[4] = new Ded("Драма", GrumpinessLevel.High, new string[] { "Боров", "Пакостник", "Чурка" });

            string[] testCurses = new string[] { "Чурка", "Проститутки", "Ублюдки", "Карабас" };

            foreach (Ded ded in deds)
            {
                Console.WriteLine($"{ded.name} получил {ded.CountStrokes(testCurses)} синяков");
            }

        }

        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }
    }
}

