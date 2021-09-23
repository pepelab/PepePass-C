// Created by PepeLab 2021

using System;
using System.Text;

namespace PepePass_C
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n\t\t\t\t\t\tPASSWORD GENERATOR TOOL", Console.ForegroundColor);

            for (; ; )//ввод количества и длинны паролей
            {
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("\n\t\t\t\t\t\tPassword Length: ", Console.ForegroundColor);
                int length = Convert.ToInt32(Console.ReadLine()); //вводим количество символов (длина пароля)

                Console.Write("\t\t\t\t\t\tUse symbols (y/n): ", Console.ForegroundColor);
                string use_spec_chars = Console.ReadLine(); //использовать символы?

                Console.Write("\t\t\t\t\t\tNumber of passwords: ", Console.ForegroundColor);
                int number_of_passwords = Convert.ToInt32(Console.ReadLine()); //вводим количество паролей


                for (; number_of_passwords > 0;)//пароли
                {
                    if (length <= 6)
                    {

                        string pass = generatePass(length, use_spec_chars); // создаём переменную с паролем, и присваиваем ей метод "генерации пароля" с параметром "количества символов"
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"\t\t\t\t\t\t{pass}", Console.ForegroundColor); //выводим конечный пароль
                    }
                    else if (length <= 9)
                    {
                        string pass = generatePass(length, use_spec_chars);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\t\t\t\t\t\t{pass}", Console.ForegroundColor);
                    }
                    else
                    {
                        string pass = generatePass(length, use_spec_chars);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"\t\t\t\t\t\t{pass}", Console.ForegroundColor);
                    }

                    number_of_passwords--;
                }
            }

            Console.ReadKey();
        }

        static string generatePass(int length, string use_spec_chars) //метод "генерации пароля" с параметром "количество символов"
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ11223344556677889900"; //константа с символами 
            const string spec_chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~~!!@@##$$%%^^&&**(())??";
            StringBuilder str = new StringBuilder(); //создании строки "str"                           
            Random rnd = new Random(); //создание объекта для генерации чисел                             

            if (use_spec_chars == "y")
            {
                while (0 < length) //цикл: пока 0 меньше "количество символов"
                {
                    str.Append(spec_chars[rnd.Next(spec_chars.Length)]); //к строке "str" прибавить случайный символ из константы "spec_chars"
                    length--; //"количество символов" - 1
                }
            }
            else
            {
                while (0 < length) //цикл: пока 0 меньше "количество символов"
                {
                    str.Append(chars[rnd.Next(chars.Length)]); //к строке "str" прибавить случайный символ из константы "chars"
                    length--; //"количество символов" - 1
                }
            }
            
            return str.ToString(); //вернуть готовую строку с паролем
        }
    }
}