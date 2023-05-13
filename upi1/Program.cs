using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace upi1
{
    class Program
    {
        static void Main(/*string[] args*/)
        {
            bool repeat = true;
            while(repeat)
            {
                Console.WriteLine("Введите номер задания [1 или 2]:");
                Console.WriteLine("#Выход -> '~'");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        work1();
                        Console.WriteLine("Задание завершено.");
                        break;
                    case "2":
                        work2();
                        Console.WriteLine("Задание завершено.");
                        break;
                    case "~":
                        repeat = false;
                        break;
                    case "test":
                        //test();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Работа завершена.");
            Console.ReadKey();
        }

        static int work1()
        {
            ///
            /// TODO: Написать функцию, которая объединяет два одномерных массива в один, состоящий только из уникальных элементов, входящие в оба массива
            /// 
            
            Console.WriteLine("Введите элементы массива 1 через пробел:");
            string[] arr1 = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Введите элементы массива 2 через пробел:");
            string[] arr2 = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (arr1.Length < 1 || arr2.Length < 1)
            {
                Console.WriteLine("#Ошибка: Обнаружен пустой массив.");
                return 1;
            }

            string[] result = arr1.Intersect(arr2).ToArray();
            Console.WriteLine(result.Length < 1 ? "Не найдены общие элементы." : "Общие элементы: " + string.Join(", ", result));
            
            return 0;
        }

        static int work2()
        {
            ///
            /// Составить список учебной группы, включающий Х человек. 
            /// Для каждого студента указать: фамилию и имя, дату рождения (год, месяц и число), также у каждого студента есть зачетка, в которой указаны: предмет (от трех до пяти), дата экзамена, ФИО преподавателя.
            /// TODO: Вывод виде таблицы ФИО тех студентов, у которых дата сдачи экзамена не раньше n
            /// 

            string fileName = "students.json";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("#Ошибка: Не найден файл students.json.");
                return 1;
            }
            
            string jsonString = File.ReadAllText(fileName);
            Students studs = JsonSerializer.Deserialize<Students>(jsonString);

            Console.WriteLine("Введите нижнюю границу даты экзамена в формате \"2000-01-01\":");

            string pattern = @"\d{4}[-]\d{2}[-]\d{2}";
            string input = Console.ReadLine(); ;
            if (!Regex.IsMatch(input, pattern))
            {
                Console.WriteLine("#Ошибка: Неверный формат даты.");
                return 1;
            }

            DateTime date = DateTime.Parse(input);
            List<string> result = new List<string>();
            result.Add(String.Format("|{0,20}|{1,20}|{2,20}|", "FirstName", "SecondName", "LastName"));
            result.Add(new string('-', result[0].Length));
            foreach (Student st in studs.Studs)
            {
                bool flag = false;
                foreach (Subjects subj in st.Recs)
                {
                    if (subj.Date > date)
                        flag = true;
                }

                if (flag)
                    result.Add(String.Format("|{0,20}|{1,20}|{2,20}|", st.FirstName, st.SecondName, st.LastName));
            }

            if (result.Count > 1)
            {
                foreach (string row in result)
                {
                    Console.WriteLine(row);
                }
            }
            else
            {
                Console.WriteLine("Подходящие студенты не найдены.");
            }

            return 0;
        }

        static void test()
        {
            Student student1 = new Student
            {
                FirstName = "Vladimir",
                SecondName = "Kuzmin",
                LastName = "Dmitrievich",
                Birthday = DateTime.Parse("2000-06-09"),
                Recs = new Subjects[] {
                    new Subjects { Subject = "Math", Date = DateTime.Parse("2022-01-01"), Mark = "5", Teacher = new Teacher { FirstName = "Leonid", SecondName = "Konobeev", LastName = "Sergeevich" } },
                    new Subjects { Subject = "Russian", Date = DateTime.Parse("2022-02-01"), Mark = "4", Teacher = new Teacher { FirstName = "Maria", SecondName = "Petrova", LastName = "Anatolievna" } }
                }
            };

            Student student2 = new Student
            {
                FirstName = "Pavel",
                SecondName = "Ivlev",
                LastName = "Igorevich",
                Birthday = DateTime.Parse("2001-03-19"),
                Recs = new Subjects[] {
                    new Subjects { Subject = "Math", Date = DateTime.Parse("2023-06-01"), Mark = "3", Teacher = new Teacher { FirstName = "Leonid", SecondName = "Konobeev", LastName = "Sergeevich" } },
                    new Subjects { Subject = "Russian", Date = DateTime.Parse("2023-06-21"), Mark = "passed", Teacher = new Teacher { FirstName = "Maria", SecondName = "Petrova", LastName = "Anatolievna" } }
                }
            };

            Student student3 = new Student
            {
                FirstName = "Pavel",
                SecondName = "Ivlev",
                LastName = "Igorevich",
                Birthday = DateTime.Parse("1999-02-11"),
                Recs = new Subjects[] {
                    new Subjects { Subject = "Math", Date = DateTime.Parse("2021-01-05"), Mark = "4", Teacher = new Teacher { FirstName = "Leonid", SecondName = "Konobeev", LastName = "Sergeevich" } },
                    new Subjects { Subject = "English", Date = DateTime.Parse("2021-01-09"), Mark = "passed", Teacher = new Teacher { FirstName = "Oksava", SecondName = "Galich", LastName = "Magomedovna" } }
                }
            };

            Students studs = new Students { Studs = new Student[] { student1, student2 } };
            string jsonString = JsonSerializer.Serialize(studs);
            //string jsonString = JsonSerializer.Serialize(student1);

            Console.WriteLine(jsonString);

            string fileName = "test_student.json";
            File.WriteAllText(fileName, jsonString);
        }
    }

    public class Man
    {
        public string FirstName     { get; set; }  // Имя
        public string SecondName    { get; set; }  // Фамилия
        public string LastName      { get; set; }  // Отчество
    }

    public class Student : Man
    {
        public DateTime Birthday    { get; set; }
        public Subjects[] Recs      { get; set; }
    }

    public class Teacher : Man
    {
    }

    public class Subjects
    {
        public string Subject   { get; set; }
        public DateTime Date    { get; set; }
        public string Mark      { get; set; }
        public Teacher Teacher  { get; set; }
    }

    public class Students
    {
        public Student[] Studs { get; set; }
    }
}
