using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class PhoneBook
    {
        public List<Contact> Contacts { get; set; }

        public byte SortingOrder { get; set; }

        public PhoneBook()
        {
            Contacts = new List<Contact>();

            // добавляем контакты
            Contacts.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            Contacts.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            Contacts.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            Contacts.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            Contacts.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            Contacts.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
        }

        public void ViewContacts()
        {
            while (true)
            {
                // Читаем введенный с консоли символ
                var input = Console.ReadKey().KeyChar;

                // проверяем, число ли это
                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                if (pageNumber == 0) { return; }

                // если не соответствует критериям - показываем ошибку
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");

                    continue;
                }

                string functionName = "OrderBy";

                // сортируем список
                var sortedList = Contacts.OrderBy(c => c.Name).ThenBy(c => c.LastName);
                
                if (SortingOrder == 1)
                {
                    sortedList = Contacts.OrderByDescending(c => c.Name).ThenByDescending(c => c.LastName);
                }

                
                // если соответствует - запускаем вывод
                // пропускаем нужное количество элементов и берем 2 для показа на странице
                var pageContent = sortedList.Skip((pageNumber - 1) * 2).Take(2);
                
                Console.WriteLine();

                // выводим результат
                foreach (var entry in pageContent)
                    Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                Console.WriteLine();
            }
        }
    }
}
