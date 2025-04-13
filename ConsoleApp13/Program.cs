using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    //5
    public class RestaurantAddressValidator
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введіть адресу ресторану:");
            string address = Console.ReadLine();

            string pattern = @"^[a-zA-Z0-9\s\.,/#-]+$";
            string restaurantNamePattern = @"^[a-zA-Z0-9]+$";


            string[] addressParts = address.Split(new char[] { ',', ' ', '#', '/' }, StringSplitOptions.RemoveEmptyEntries);

            bool isValid = true;
            bool nameFound = false;

            foreach (string part in addressParts)
            {

                if (!nameFound && Regex.IsMatch(part, restaurantNamePattern))
                {
                    Console.WriteLine($"Знайдено можливу назву ресторану: '{part}'");
                    nameFound = true;

                }


                if (!Regex.IsMatch(address, pattern))
                {
                    isValid = false;
                    Console.WriteLine($"Помилка: Адреса містить недопустимі символи (дозволені: літери англійського алфавіту, цифри, пробіли, ., /, #, -).");
                    break;
                }


            }

            if (isValid && nameFound)
            {
                Console.WriteLine("Адреса ресторану виглядає коректно (назва містить лише букви англійського алфавіту та цифри).");
            }
            else if (isValid && !nameFound)
            {
                Console.WriteLine("Адреса ресторану не містить назви, що складається лише з букв англійського алфавіту та цифр.");
            }


            Console.WriteLine("Введіть назву кухні ресторану:");
            string cuisineName = Console.ReadLine();

            if (string.IsNullOrEmpty(cuisineName))
            {
                isValid = false;
            }
            else
            {
                foreach (char c in cuisineName)
                {
                    if (!char.IsLetter(c))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            if (isValid)
            {
                Console.WriteLine($"Назва кухні '{cuisineName}' є дійсною (містить лише літери англійського алфавіту).");
            }
            else
            {
                Console.WriteLine($"Помилка: Назва кухні '{cuisineName}' є недійсною. Будь ласка, використовуйте лише літери англійського алфавіту.");
            }


        }
    


    }



}
