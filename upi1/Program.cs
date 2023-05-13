using System;
using System.Collections.Generic;
using System.Linq;

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
            /// TODO: Вывод виде таблицы ФИО тех студентов, у которых дата сдачи экзамена не раньше n
            /// 

            return 0;
        }
    }
}
