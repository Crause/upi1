using System;

namespace upi1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания [1 или 2]:");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    work1();
                    break;
                case "2":
                    work2();
                    break;
                default:
                    break;
            }
            Console.WriteLine("Работа завершена.");
            Console.ReadKey();

        }

        static void work1()
        {

        }

        static void work2()
        {

        }
    }
}
