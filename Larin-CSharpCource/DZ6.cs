using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public static class DZ6
    {
        private static int steps = 0;
        private static int row = 3; //строка
        private static int col = 2; //колонка
        public static void Start()
        {
            int numberHomeWork;
            do
            {
                Console.WriteLine("Введите номер задания:\n" +
                    "1. Использование Стека\n" +
                    "2. Использование очереди.\n" +
                    "3. Очередь с приоритетом.\n" +
                    "4. Вычисление НОД двух чисел алгоритмами Евклида.\n" +
                    "5. Вычисление НОД двух чисел бинарным алгоритмом.\n" +
                    "6. Лабиринт.\n" +
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
                        PriorityQueue();
                        continue;
                    case 4:
                        EvkleedAlgorytm();
                        continue;
                    case 5:
                        BinarAlgorytm();
                        continue;
                    case 6:
                        ExitOfMatrix();
                        continue;
                    default:
                        return;
                }

            } while (numberHomeWork != 0);

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

        private static void PriorityQueue()
        {
            //очередь с приоритетом
            Queue qu = new Queue();
            qu.Enqueue("Ivanov A.");
            Console.WriteLine("Ivanov A. - поставлен в очередь");
            qu.Enqueue("Sidorov B.");
            Console.WriteLine("Sidorov B. - поставлен в очередь");
            qu.Enqueue("Petrov C.", true);
            Console.WriteLine("Petrov C. - поставлен в очередь");

            while (qu.Count > 0)
            {
                Console.WriteLine(qu.Dequeue());
            }
            Console.WriteLine(qu.Dequeue());
            Console.WriteLine("\n");
        }

        private static void EvkleedAlgorytm()
        {
            int firstNum = 0;
            int secondNum = 0;
            do
            {
                Console.WriteLine("Введите первое число:");
                int.TryParse(Console.ReadLine(), out firstNum);
                Console.WriteLine("Введите первое число:");
                int.TryParse(Console.ReadLine(), out secondNum);
                if (firstNum == 0 & secondNum == 0)
                {
                    Console.WriteLine("Числа введены не верно");
                }
            } while (firstNum == 0 & secondNum == 0);

            //выполнение алгоритма
            while (firstNum != 0 & secondNum !=0)
            {
                if (firstNum > secondNum)
                {
                    firstNum = firstNum % secondNum;
                }
                else
                {
                    secondNum = secondNum % firstNum;
                }
            }
            Console.WriteLine("Общий делитель: {0}\n", (firstNum + secondNum));
        }

        private static void BinarAlgorytm()
        {
            int firstNum = 0;
            int secondNum = 0;
            do
            {
                Console.WriteLine("Введите первое число:");
                int.TryParse(Console.ReadLine(), out firstNum);
                Console.WriteLine("Введите первое число:");
                int.TryParse(Console.ReadLine(), out secondNum);
                if (firstNum == 0 & secondNum == 0)
                {
                    Console.WriteLine("Числа введены не верно");
                }
            } while (firstNum == 0 & secondNum == 0);

            //алгоритм
            int nod = 0;
            int k = 1;
            while (firstNum != 0 & secondNum != 0)
            {

                //Добиваемся чтоб одно из чисел стало нечетным
                while (firstNum % 2 == 0 && secondNum % 2 == 0)
                {
                    firstNum /= 2;
                    secondNum /= 2;
                    k *= 2;
                }

                //если первое число четное делим его пока не станет нечетным
                while (firstNum % 2 == 0)
                {
                    firstNum /= 2;
                }

                //если второе число четное делим его пока не станет нечетным
                while (secondNum % 2 == 0)
                {
                    secondNum /= 2;
                }

                if (firstNum >= secondNum)
                    firstNum -= secondNum;
                else
                    secondNum -= firstNum;
            }

            nod = secondNum * k;

            Console.WriteLine("NOD = {0}\n", nod);

        }

        private static void ExitOfMatrix()
        {
            //зададим матрицу
            //1 1 1 1 1 1 1 1 1 1
            //1                 1
            //1                 1
            //1   x             1
            //1                 1
            //1                  /->
            //1           1  1  1
            //1                 1
            //1                 1
            //1 1 1 1 1 1 1 1 1 1

            //начальные координаты

            int[,] matrix = new int[10, 10];

            //заполнение матрицы
            int colums = matrix.GetUpperBound(0) + 1;
            int rows = matrix.Length / colums;
            //верхняя стенка
            for (int i = 0; i < colums; i++)
                matrix[0, i] = 1;
            //нижняя стенка
            for (int i = 0; i < colums; i++)
                matrix[9, i] = 1;
            //левая
            for (int i = 0; i < rows; i++)
                matrix[i, 0] = 1;
            //правая
            for (int i = 0; i < rows; i++)
                if(i != 5) matrix[i, 9] = 1;
            //препятствия
            matrix[6, 6] = 1;
            matrix[6, 7] = 1;
            matrix[6, 8] = 1;

            matrix[row, col] = 8; // это наша точка


            //Прижимаемся к ближайшей стенке
            int a = 0, w = 0, s = 0, d = 0;
            matrix[row, col] = 0;
            while (true) //может быть случай когда точка сразу на выход попадет
            {
                if (matrix[row, col + a] != 1)
                    a--;
                else
                {
                    col += a+1;
                    break;
                }

                if (matrix[row + w, col] != 1)
                    w--;
                else
                {
                    row += w+1;
                    break;
                }

                if (matrix[row + s, col] != 1)
                    s++;
                else
                {
                    row += s-1;
                    break;
                }

                if (matrix[row, col + d] != 1)
                    d++;
                else
                {
                    col += d-1;
                    break;
                }
                
                if (row > 9 || col > 9)
                {
                    Console.WriteLine("Нашли выход. Координаты: {0}:{1}", row, col);
                    return;
                }
            }
            matrix[row, col] = 8;

            //рисуем матрицу в консоле после того как прилипли к одной из стенок
            DrawTheMatrix(matrix);


            while (row < 9 & col < 9)
            {
                StepForward(matrix);
            }
            Console.WriteLine("Нашли выход. Координаты: {0}:{1}\n", row, col);


        }

        public static void DrawTheMatrix(int[,] arr)
        {
            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;

            //Выведем
            Console.Clear();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    switch (arr[i, j])
                    {
                        case 8 : Console.Write("X\t");
                            continue;
                        case 1:
                            Console.Write("*\t");
                            continue;
                        case 0:
                            Console.Write("\t");
                            continue;
                        default:
                            continue;
                    }
                    
                }
                Console.WriteLine();
            }
        }

        public static void StepForward(int[,] matrix)
        {
            matrix[row, col] = 0; // обнулим
            System.Threading.Thread.Sleep(500);

            if (steps > 19)
            {
                int a = 0;
            }

            if (row > 8 || col > 8)
            {
                matrix[row, col] = 8; // нарисуем
                DrawTheMatrix(matrix);

                return;
            }
            else if (matrix[row, col-1] == 1 
                & matrix[row + 1, col] != 1
                & matrix[row + 1, col - 1] == 1) //если внизу пусто
            {
                row++;
                matrix[row, col] = 8; // нарисуем
                DrawTheMatrix(matrix);
                steps++;
                //StepForward(matrix, row, col);
            }
            else if (matrix[row+1, col] == 1 
                & matrix[row, col + 1] != 1
                & matrix[row + 1, col + 1] == 1) //если справа пусто
            {
                col++;
                matrix[row, col] = 8; // нарисуем
                DrawTheMatrix(matrix);
                steps++;
                //StepForward(matrix, row, col);
            }
            else if (matrix[row, col+1] == 1 
                & matrix[row - 1, col] != 1
                & matrix[row - 1, col + 1] == 1) //если вверху пусто
            {
                row--;
                matrix[row, col] = 8; // нарисуем
                DrawTheMatrix(matrix);
                steps++;
                //StepForward(matrix, row, col);
            }
            else if (matrix[row-1, col] == 1 
                & matrix[row, col-1] != 1
                & matrix[row-1, col - 1] == 1) //если слева пусто
            {
                col--;
                matrix[row, col] = 8; // нарисуем
                DrawTheMatrix(matrix);
                steps++;
                //StepForward(matrix, row, col);
            }
            else if (matrix[row - 1, col] == 1 
                & matrix[row - 1, col - 1] != 1) // поворот наверх
            {
                col--;
                row--;
                matrix[row, col] = 8; // нарисуем
                DrawTheMatrix(matrix);
                steps++;
                //StepForward(matrix, row, col);
            }
            else if (matrix[row, col+1] == 1
                & matrix[row+1, col+1] != 1) //поворот направо
            {
                col++;
                row--;
                matrix[row, col] = 8; // нарисуем
                DrawTheMatrix(matrix);
                steps++;
                //StepForward(matrix, row, col);
            }
            else if (matrix[row+1, col] == 1
                & matrix[row - 1, col + 1] != 1) //поворот вниз
            {
                col++;
                row--;
                matrix[row, col] = 8; // нарисуем
                DrawTheMatrix(matrix);
                steps++;
                //StepForward(matrix, row, col);
            }
            else if (matrix[row, col-1] == 1
                & matrix[row - 1, col -1] != 1) //поворот налево
            {
                col--;
                row++;
                matrix[row, col] = 8; // нарисуем
                DrawTheMatrix(matrix);
                steps++;
                //StepForward(matrix, row, col);
            }

        }
    }

    class Queue
    {
        private Dictionary<string, bool> dict;

        private int count = 0;

        public int Count { get => count;}

        public Queue()
        {
            dict = new Dictionary<string, bool>();
        }
        

        //извлекает последний индекс
        public string Dequeue()
        {
            if (dict.Count > 0)
            {
                var pair = dict.Where(p => p.Value == true);
                if (pair.Count() > 0)
                {
                    var Names = pair.ToArray();
                    string name = Names[0].Key;
                    dict.Remove(name);
                    count--;
                    return "Вызван по очереди: "+name;
                }
                else
                {
                    string name = "";
                    foreach (var item in dict)
                    {
                        name = item.Key;
                        dict.Remove(name);
                        count--;
                        break;
                    }
                    return "Вызван по очереди: " + name;
                }
                
            }
            else
            {
                return "Очедерь пуста";
            }
        }

        public void Enqueue(string name, bool priority = false)
        {
            dict.Add(name, priority);
            count++;
        }
    }

}
