using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public static class DZ7
    {
        public static void Start()
        {
            int numberHomeWork;
            do
            {
                Console.WriteLine("Введите номер задания:\n" +
                    "1. Создать класс Student\n" +
                    "2. Создать класс Group.\n" +
                    "3. HR managment.\n" +
                    "");

                int.TryParse(Console.ReadLine(), out numberHomeWork);

                switch (numberHomeWork)
                {
                    case 1:
                        UsingClassStudent();
                        continue;
                    case 2:
                        UsingClassStudentGroup();
                        continue;
                    case 3:
                        HR();
                        continue;

                    default:
                        return;
                }

            } while (numberHomeWork != 0);
        }

        private static void UsingClassStudent()
        {
            Student std1 = new Student("Вася", "Пяточкин");
            std1.AddRate(5);
            std1.AddRate(3);
            std1.AddRate(7);
            std1.AddRate(10);
            std1.AddRate(4);

            std1.CalculateAverageRate();
        }

        private static void UsingClassStudentGroup()
        {
            StudentGroup group1 = new StudentGroup();


            Student std1 = new Student("Василий", "Пяточкин");
            group1.AddStudent(std1);
            GenerateRates(std1);

            Student std2 = new Student("Аркадий", "Лампочкин");
            group1.AddStudent(std2);
            GenerateRates(std2);

            Student std3 = new Student("Петр", "Самоделкин");
            group1.AddStudent(std3);
            GenerateRates(std3);

            Student std4 = new Student("Михаил", "Корягин");
            group1.AddStudent(std4);
            GenerateRates(std4);

            Student std5 = new Student("Наталия", "Скакалкина");
            group1.AddStudent(std5);
            GenerateRates(std5);

            group1.RemoveStudent(std5);

            //ошибка
            Student std6 = new Student("Ольга", "Кузнецова");
            group1.AddStudent(std6);
            GenerateRates(std6);

            //средняя оценка по каждому из студентов
            group1.PrintAverageRateEachStudent();

            group1.PrintAverageRateByGroup();


            Console.WriteLine("\n");
        }

        private static void GenerateRates(Student std)
        {
            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                System.Threading.Thread.Sleep(50);
                std.AddRate(rand.Next(5, 10));
            }
        }

        private static void HR()
        {
            DZ7_dop.HR_management();
        }
    }

    public class Student
    {
        string name;
        string lastName;
        List<int> rates;

        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FullName { get => lastName +" "+ name;}
        public List<int> Rates { get => rates;}

        public Student(string studentName, string studentLastName)
        {
            name = studentName;
            lastName = studentLastName;

            rates = new List<int>();

            Console.WriteLine("Создан студент: {0}", FullName);
        }

        public Student(string studentName)
        {
            name = studentName;
            lastName = "";

            rates = new List<int>();

            Console.WriteLine("Создан студент: {0}\n", name);
        }

        public void AddRate(int rate)
        {
            if(rate > 0)
            Rates.Add(rate);
            Console.WriteLine("Выставлена оцена: {0}", rate);
        }

        public void CalculateAverageRate()
        {
            int averageRate = 0;
            if (Rates.Count == 0)
            {
                averageRate = 0;
            }
            else
            {
                foreach (var item in Rates)
                {
                    if (item > 0)
                        averageRate += item;
                }
                averageRate /= Rates.Count;
            }
            Console.WriteLine("Средняя оценка студента ({0}): {1}\n", FullName, averageRate);
        }

        public void PrintRates()
        {
            Console.WriteLine("Оценки студента: {0}", FullName);
            int k = 1;
            foreach (var item in Rates)
            {
                Console.WriteLine("{0}. оценка: {1}", k, item);
            }
            Console.WriteLine("\n");
        }
    }

    public class StudentGroup
    {
        //ПОЛЯ
        public static int groupNumber;

        int maxCapacity = 5;

        public string groupName;

        List<Student> group;

        //МЕТОДЫ
        public StudentGroup()
        {
            group = new List<Student>();
            groupNumber++;
            groupName = "Группа-" + groupNumber;
            Console.WriteLine("Создана {0}\n", groupName);
        }

        public void AddStudent(Student student)
        {
            if (group.Count < maxCapacity)
            {
                group.Add(student);
                Console.WriteLine("Студент {0} зачислен в группу {1}\n", student.FullName, groupName);
            }
            else Console.WriteLine("Невозможно добавить студента {0} в {1}, она заполнена. Зачислите другую группу\n", student.FullName, groupName);
        }

        public void RemoveStudent(Student student)
        {
            if (group.Contains(student))
            {
                group.Remove(student);
                Console.WriteLine("Студент {0} был успешно исключен из группы {1}\n", student.FullName, groupName);
            }
            else Console.WriteLine("Невозможно удалить студента {0}. Такой студент не найден в группе {1}\n", student.FullName, groupName);
        }

        public void PrintAverageRateEachStudent()
        {
            foreach (Student student in group)
            {
                student.CalculateAverageRate();
            }
        }

        public void PrintAverageRateByGroup()
        {
            if (group.Count == 0)
            {
                Console.WriteLine("Невозможно посчитать средний бал по группе, т.к. в греппе 0 студентов\n");
                return;
            }

            double allRates = 0;
            double countRates = 0;
            
            foreach (Student student in group)
            {
                countRates += student.Rates.Count;

                foreach (double rate in student.Rates)
                {
                    allRates += rate;
                }
            }

            double averageRateByGroup = allRates / countRates;

            Console.WriteLine("Средний бал по группе: {0}\n", averageRateByGroup);

        }
    }
}
