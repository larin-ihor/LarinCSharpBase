using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15
{
    class DZ15
    {
        public static void Start()
        {
            FibonachiNumbers();

            InvertNumber();

            InvertArray();

            ShowBiggerNumbersInArray();

            MathProgress(true);
            MathProgress(false);

            Console.ReadLine();
        } 

        
        private static void InvertArray()
        {
            int[] inArray = { 1, 5, -3, 4, -9, -1 };
            Console.WriteLine("Инвертирование знаков в массиве.\nМассив входных чисел:");
            Console.WriteLine(string.Join(", ", inArray));

            for (int i = 0; i < inArray.Length; i++)
            {
                inArray[i] = -inArray[i];
            }

            Console.WriteLine("Результат инвертирования:");
            Console.WriteLine(string.Join(", ", inArray));
        }

        private static void FibonachiNumbers()
        {
            Console.WriteLine("Числа фибоначи.\nВведите число больше чем 2");
            int countNumbers;
            int.TryParse(Console.ReadLine(), out countNumbers);

            if (countNumbers == 0)
            {
                return;
            }

            int[] fnumbers = new int[countNumbers];
            fnumbers[0] = 0;
            fnumbers[1] = 1;

            for (int i = 2; i < countNumbers; i++)
            {
                fnumbers[i] = fnumbers[i - 1] + fnumbers[i - 2];
            }

            Console.WriteLine(string.Join(", ", fnumbers));
            Console.WriteLine("\n");
        }

        private static void InvertNumber()
        {
            Console.WriteLine("Инвертирование числа.\nВведите любое число");
            string inStringNumber = Console.ReadLine();

            string outStringNumber = "";
            for (int i = inStringNumber.Length-1; i >= 0; i--)
            {
                outStringNumber += inStringNumber[i];
            }

            Console.WriteLine(outStringNumber + "\n");

        }

        private static void ShowBiggerNumbersInArray()
        {
            int[] inArray = { 1, 5, -3, 4, -9, -1 };
            Console.WriteLine("Выбор цифр в массиве где последующее больше предыдущего.\nМассив входных чисел:");
            Console.WriteLine(string.Join(", ", inArray));

            Console.WriteLine("Результат выборки:");
            for (int i = 1; i < inArray.Length; i++)
            {
                if (inArray[i] > inArray[i - 1])
                {
                    Console.Write(inArray[i] + "\t");
                }
            }
        }

        private static void MathProgress(bool isArithmetic)
        {
            if (isArithmetic)
                Console.WriteLine("Арифметическая прогрессия.\nВведите начальное число");
            else
                Console.WriteLine("Геометрическая прогрессия.\nВведите начальное число");

            int startNumber;
            int.TryParse(Console.ReadLine(), out startNumber);

            Console.WriteLine("Введите инкремент");
            int increment;
            int.TryParse(Console.ReadLine(), out increment);

            Console.WriteLine("Введите количество элементов");
            int count;
            int.TryParse(Console.ReadLine(), out count);

            int[] arithmeticArr = new int[count];
            arithmeticArr[0] = startNumber;
            for (int i = 1; i < count; i++)
            {
                if (isArithmetic)
                    arithmeticArr[i] = arithmeticArr[i - 1] + i * increment;
                else
                    arithmeticArr[i] = arithmeticArr[i - 1] * increment;
            }

            Console.WriteLine(String.Join(", ", arithmeticArr));
        }
    }
}
