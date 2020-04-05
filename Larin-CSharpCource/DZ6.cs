using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public static class DZ6
    {
        public static void Start()
        {
            int numberHomeWork;
            do
            {
                Console.WriteLine("Введите номер задания:\n" +
                    "1. Использование Стека\n" +
                    "2. Использование очереди.\n" +
                    "3. Дополнительно по Очереди.\n" +
                    "");

                int.TryParse(Console.ReadLine(), out numberHomeWork);

                switch (numberHomeWork)
                {
                    case 1:
                        UsingStack();
                        continue;
                    case 2:
                        UsingQueue();
                        continue;
                    case 3:
                        AdditionHomeWork();
                        continue;
                    default:
                        break;
                }

            } while (numberHomeWork != 0);

            UsingStack();

            UsingQueue();

        }

        private static void UsingQueue()
        {
            //*****************************************************
            //Queue
            Console.WriteLine("\nQueue\n");

            Queue<string> studentsCoffeQueue = new Queue<string>();

            //наполнение стека
            for (int i = 1; i <= 5; i++)
            {
                studentsCoffeQueue.Enqueue("Student" + i);
                Console.WriteLine("Task from Student {0} > is received", i);
            }

            int studentsInStackQ = studentsCoffeQueue.Count;
            for (int i = 1; i <= studentsInStackQ; i++)
            {
                Console.WriteLine("{0} got a cup of coffee", studentsCoffeQueue.Dequeue());
            }
            Console.WriteLine("\n");
        }

        private static void UsingStack()
        {
            //*******************************************************
            //Stack
            Console.WriteLine("\nStack\n");
            Stack<string> studentsCoffeStack = new Stack<string>();
            //наполнение стека
            for (int i = 1; i <= 5; i++)
            {
                studentsCoffeStack.Push("Student" + i);
                Console.WriteLine("Task from Student {0} > is received", i);
            }

            int studentsInStack = studentsCoffeStack.Count;
            for (int i = 1; i <= studentsInStack; i++)
            {
                Console.WriteLine("{0} got a cup of coffee", studentsCoffeStack.Pop());
            }
            Console.WriteLine("\n");
        }

        private static void AdditionHomeWork()
        {

        }
    }

}
