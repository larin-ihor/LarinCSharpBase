using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public static class StringExtention
    {
        //позволяет отрезать первые слева символы до указанного индекса
        public static string CutLeft(this String str, int count)
        {
            string newString = "";

            if (count < str.Length - 1)
            {
                for (int i = 0; i <= count; i++)
                {
                    newString += str[i];
                }
            }
            else newString = str;

            return newString;
        }

        public static string CutLeft(this String str, int count, char charExeption)
        {
            string newString = "";

            for (int i = 0; i <= count; i++)
            {
                if (i < str.Length)
                {
                    if (str[i] != charExeption)
                    {
                        newString += str[i];
                    }
                }
            }

            return newString;
        }

        public static string CutLeft(this String str, int count, char[] charExeption)
        {
            string newString = "";

            for (int i = 0; i <= count; i++)
            {
                if (i < str.Length)
                {
                    if (charExeption.Contains(str[i]) == false)
                    {
                        newString += str[i];
                    }
                }
            }

            return newString;
        }

        //позволяет отрезать первые справа символы до указанного индекса
        public static string CutRight(this String str, int count)
        {
            string newString = "";

            for (int i = 0; i <= count; i++)
            {
                if (i < str.Length)
                {
                    newString = str[str.Length - 1 - i] + newString;
                }
            }

            return newString;
        }

        public static string CutRight(this String str, int count, char charExeption)
        {
            string newString = "";

            for (int i = 0; i <= count; i++)
            {
                if (str[str.Length - 1 - i] != charExeption)
                {
                    newString = str[str.Length - 1 - i] + newString;
                }
            }

            return newString;
        }

        public static string CutRight(this String str, int count, char[] charExeption)
        {
            string newString = "";

            for (int i = 0; i <= count; i++)
            {
                if (i < str.Length)
                {
                    if (charExeption.Contains(str[str.Length - 1 - i]) == false)
                    {
                        newString = str[str.Length - 1 - i] + newString;
                    }
                }

            }

            return newString;
        }

    }
}
