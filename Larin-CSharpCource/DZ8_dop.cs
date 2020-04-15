using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class DZ8_dop
    {
        public static void Start()
        {
            //string str = "ЗаполнитьЗначенияСвойств(НовыйЗаказ, МассивЗаказов[0],,'Номер,Ответственный,Проведен');";
            string str = "{{}})";
            Console.WriteLine("Исходная строка:\n" + str);
            bool isBalanced = Balance(str);
            Console.WriteLine($"В данной строке {(isBalanced ? "" : "не")} соблюдается баланс скобок\n");
        }

        private static bool Balance(string str)
        {
            //служит для сравнения парных скобок
            var parityQuotes = new Dictionary<char, char>()
            {
                { ')', '('},
                { '}', '{'},
                { ']', '['},
            };

            for (int i = 0; i < str.Length;)
            {
                if (NextCharIsClosed(str, i))
                {
                    return false;
                }
                int j;
                for (j = i + 1; j < str.Length; j++)
                {
                    if (NextCharIsOpened(str, j))
                    {
                        i = j - 1;
                        break;
                    }
                    if (NextCharIsClosed(str, j))
                    {
                        if (str[i] == parityQuotes[str[j]])
                        {
                            str = str.Remove(i, 1).Insert(i, "_");
                            str = str.Remove(j, 1).Insert(j, "_");
                            //сбрасываем и начинаем с 0
                            i = -1;
                        }
                        j++;
                        break;
                    }     
                }
                i++;
            }

            //проверка после удаления скобок
            var arrBrackets = new[] { '(', '{', '[', ')', '}', ']' };
            int indexOfAnyBrackets = str.IndexOfAny(arrBrackets);
            if (indexOfAnyBrackets >= 0)
                return false;
            else
                return true;
            
        }

        private static bool NextCharIsOpened(string str, int index)
        {
            var arrOpened = new[] { '(', '{', '[',  };
            for (int i = 0; i < arrOpened.Length; i++)
            {
                if (str[index] == arrOpened[i])
                {
                    return true;
                }
            }

            return false;
        }

        private static bool NextCharIsClosed(string str, int index)
        {
            var arrClosed = new[] { ')', '}', ']' };
            for (int i = 0; i < arrClosed.Length; i++)
            {
                if (str[index] == arrClosed[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
