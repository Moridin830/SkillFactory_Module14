using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task1
{
    public static class Program
    {
        static void Main()
        {
            var phoneBook = new PhoneBook();

            // устанавливаем порядок сортировки: 0 - по возрастанию; 1 - по убыванию
            phoneBook.SortingOrder = 0;

            phoneBook.ViewContacts();

            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}