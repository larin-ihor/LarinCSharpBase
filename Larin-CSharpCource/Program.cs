using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberHomeWork;
            do
            {
                Console.WriteLine("Введите номер занятия:\n");

                int.TryParse(Console.ReadLine(), out numberHomeWork);

                switch (numberHomeWork)
                {
                    case 5:
                        DZ5.Start();
                        continue;
                    case 6:
                        DZ6.Start();
                        continue;
                    case 7:
                        DZ7.Start();
                        continue;
                    case 8:
                        DZ8_dop.Start();
                        continue;

                    case 10:
                        DZ10.Start();
                        continue;

                    case 11:
                        HomeWork11.DZ11.Start();
                        continue;

                    default:
                        break;
                }

            } while (numberHomeWork != 0);
        }
    }
}