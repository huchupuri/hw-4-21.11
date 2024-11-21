using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Xml.Linq;


namespace tasks
{
    /// <summary>
    /// перечисление уровней нахальности деда
    /// </summary>
    public enum GrumpinessLevel
    {
        Low,
        Medium,
        High
    }

    /// <summary>
    /// структура деда
    /// </summary>
    public struct Ded
    {
        public string name;
        public string[] curses;
        public int strokes;
        public GrumpinessLevel level;
        public Ded(string name, GrumpinessLevel level, string[] curses)
        {
            this.name = name;
            this.level = level;
            this.curses = curses;
        }
        /// <summary>
        /// подсчет фингалов
        /// </summary>
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

            return strokes;
        }
    }

    class Program
    {
        /// <summary>
        /// отрисовка цифры
        /// </summary>
        static void DrawNumber(uint? number)
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

        /// <summary>
        /// сумма, произведение и ср.арифметическое массива
        /// </summary>
        static int ArraySum(ref int multArray, out double middleArray, params int[] array)
        {
            int sum = 0;
            Span<int> spanArray = new Span<int>(array);
            foreach (ref int num in spanArray)
            {
                sum += num;
                multArray *= num;

            }
            middleArray = (double)sum / array.Length;
            return sum;
        }

        /// <summary>
        /// смена мест элементов массива
        /// </summary>
        static void NumsSwap(int[] array, int firstNum, int secondNum)
        {
            int pos1 = -1; 
            int pos2 = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == firstNum) pos1 = i;
                else if (array[i] == secondNum) pos2 = i;
            }
            if (pos1 != -1 && pos2 != -1)
            {
                (array[pos1], array[pos2]) = (array[pos2], array[pos1]);
            }
            else
            {
                Console.WriteLine("Одно или оба числа не найдены в массиве.");
            }
        }


//        Вывести на экран массив из 20 случайных чисел.Ввести два числа из этого массива,
//которые нужно поменять местами. Вывести на экран получившийся массив.
        static void Task1()
        {
            Console.WriteLine("Задание 1");
            int[] arr = new int[20];
            Random rand = new Random();
            for (int i = 0; i < 20; i++) arr[i] = rand.Next(100);
            Console.WriteLine($"массив: {string.Join(' ', arr)}\nвведите 2 разных числа, которые хотите заменить:");
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

//        Написать метод, где в качества аргумента будет передан массив(ключевое слово
//params). Вывести сумму элементов массива(вернуть). Вывести(ref) произведение
//массива.Вывести(out) среднее арифметическое в массиве.
        static void Task2()
        {
            Console.WriteLine("задание 2");
            int multArray = 1;
            bool flag;
            int[] array = new int[0];


            do
            {
                flag = true;
                try
                {
                    Console.WriteLine("допускается набор чисел через пробел");
                    array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray<int>();
                }
                catch (FormatException) 
                {     
                    flag = false;
                    Console.WriteLine("вы ввели не число");
                }
            }
            while(!flag);

            Console.WriteLine($"сумма масива {ArraySum(ref multArray, out double middleArray, array)} ,произведение массива {multArray}, среднее арифметическое {middleArray}");
        }

//        3. Пользователь вводит числа.Если числа от 0 до 9, то необходимо в консоли нарисовать
//изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
//должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке.Если
//пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
//завершает работу, если пользователь введёт слово: exit или закрыть (оба варианта
//должны сработать) - консоль закроется.
        static void Task3()
        {
            Console.WriteLine("задание 3");
            string input = String.Empty;
            uint? number = null;
            bool flagNum = true;

            while (flagNum)
            {
                try
                {
                    Console.Write("введите число от 1 до 9");
                    input = Console.ReadLine();
                    number = uint.Parse(input);
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

//        4. Создать структуру Дед.У деда есть имя, уровень ворчливости(перечисление), массив
//фраз для ворчания(прим.: “Проститутки!”, “Гады!”), количество синяков от ударов
//бабки = 0 по умолчанию.Создать 5 дедов.У каждого деда - разное количество фраз для
//ворчания.Напишите метод (внутри структуры), который на вход принимает деда,
//список матерных слов (params). Если дед содержит в своей лексике матерные слова из
//списка, то бабка ставит фингал за каждое слово.Вернуть количество фингалов.
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
            for (int i = 0; i < 5; i++) { Console.WriteLine($"{deds[i].name} получил {deds[i].CountStrokes(testCurses)} синяков"); }



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

