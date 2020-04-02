using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindNegativeValueInArray();

            //RaplaceNumbersInArray();

            //FindNegativeValueInArrayOfArray();

            //CountVowelsInString();

            //ReplaceLittleByBigChar();

            //QuickSortOfInt();

            //QuickSortOfString();

            Console.Read();
        }

        //МАССИВЫ
        static void FindNegativeValueInArray()
        {
            int[] arr = { 5, -3, 4, 8, 5, -4, 7, 1 };
            bool negativeValueIsFound = false;
            for (int i = (arr.Length - 1); i > 0; i--)
            {
                if (arr[i] < 0)
                {
                    Console.WriteLine("Последнее отрицательное значение с конца массива: " + arr[i]);
                    negativeValueIsFound = true;
                    break;
                }
            }
            if (negativeValueIsFound == false) Console.WriteLine("Отрицательное значение не найдено!");
        }

        static void RaplaceNumbersInArray()
        {
            int[,] arr = { { 5, 6, 8, 0, 1, 2, 4, 1 }, { 6, 9, 1, 4, 3, 7, 6, 3 } };

            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;

            //Выведем до
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("" + arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nВывод результата\n");

            for (int i = 0; i < rows; i++)
            {
                int maxValue = 0;
                int maxIndexInRow = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (arr[i, j] >= maxValue)
                    {
                        maxValue = arr[i, j];
                        maxIndexInRow = j;
                    }
                }
                for (int k = maxIndexInRow + 1; k < columns; k++)
                {
                    arr[i, k] = 0;
                }
            }

            //Выведем После
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("" + arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.Read();
        }

        static void FindNegativeValueInArrayOfArray()
        {
            //Инициализация
            int[][] arr = new int[3][];
            for (int i = 0; i < arr.Length; i++)
            {
                //произвольная длина массива
                Random rnd1 = new Random();
                arr[i] = new int[rnd1.Next(5, 10)];

                //произвольное наполнение
                Random rnd2 = new Random();
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rnd2.Next(-10, 10);
                    //Вывод сразу же
                    Console.Write("" + arr[i][j] + "\t");
                }
                Console.WriteLine();
            }

            //найдем отрицательные значения
            for (int i = 0; i < arr.Length; i++)
            {
                bool negativeValueIsFound = false;
                for (int j = (arr[i].Length - 1); j >= 0; j--)
                {
                    if (arr[i][j] < 0)
                    {
                        Console.WriteLine("Первый отрицательный элемент в " + i + " массиве с конца: " + arr[i][j] + ", его индекс: " + j);
                        negativeValueIsFound = true;
                        break;
                    }
                }
                if (negativeValueIsFound == false) Console.WriteLine("Отрицательное значение в " + i + " массиве не найдено!");
            }
        }


        //СТРОКИ
        static void CountVowelsInString()
        {
            string str = "Вот такое предложение";
            char[] arrChar = { 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е' };

            int nextindex = 0;
            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                nextindex = str.IndexOfAny(arrChar, i);
                if (nextindex >= 0)
                {
                    count++;
                    i = nextindex;
                }
                else break;
            }
            Console.WriteLine("Количество гласных букв: " + count);
        }

        static void ReplaceLittleByBigChar()
        {
            string str = "На горе Арарат растет виноград";

            str = str.Replace('а', 'А');

            Console.WriteLine("Новая строка: " + str);
        }


        //СОРТИРОВКА
        static void QuickSortOfInt()
        {
            int[] arr = { 1, 0, 3, 2 };

            int firstElement = 0;
            int lastElement = arr.Length - 1;

            QuickSortArrayOfInt(arr, firstElement, lastElement);

            foreach (var item in arr)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }

        static void QuickSortArrayOfInt(int[] arr, int begin, int end)
        {
            int pivot = arr[end];
            int leftElement = begin;
            int rightElement = end;

            do
            {
                while (arr[leftElement] < pivot)
                    leftElement++;
                while (arr[rightElement] > pivot)
                    rightElement--;

                if (leftElement <= rightElement)
                {
                    int tmp = arr[leftElement];
                    arr[leftElement] = arr[rightElement];
                    arr[rightElement] = tmp;

                    leftElement++;
                    rightElement--;
                }
            } while (leftElement <= rightElement);

            if (rightElement > begin)
                QuickSortArrayOfInt(arr, begin, rightElement);
            if (leftElement < end)
                QuickSortArrayOfInt(arr, leftElement, end);
        }

        static void QuickSortOfString()
        {
            string str = "Переставить (сортировать) слова в строке в порядке длины слова – от самыых длинных до самых коротких";

            string[] arr = str.Split(' ');

            int firstElement = 0;
            int lastElement = arr.Length - 1;

            QuickSortArrayOfString(arr, firstElement, lastElement);

            arr = arr.Reverse().ToArray();

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void QuickSortArrayOfString(string[] arr, int begin, int end)
        {
            int pivot = arr[end].Length;
            int leftElement = begin;
            int rightElement = end;

            do
            {
                while (arr[leftElement].Length < pivot)
                    leftElement++;
                while (arr[rightElement].Length > pivot)
                    rightElement--;

                if (leftElement <= rightElement)
                {
                    string tmp = arr[leftElement];
                    arr[leftElement] = arr[rightElement];
                    arr[rightElement] = tmp;

                    leftElement++;
                    rightElement--;
                }
            } while (leftElement <= rightElement);

            if (begin < rightElement)
                QuickSortArrayOfString(arr, begin, rightElement);
            if (leftElement < end)
                QuickSortArrayOfString(arr, leftElement, end);
        }
    }
}