using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesAndLINQ
{
    class Program
    {
        public delegate int CalculationDelegate(int a, int b);
        public static event CalculationDelegate CalculationEvent;

        static void Main(string[] args)
        {
            CalculationDelegate sumDelegate = Sum;
            CalculationEvent += sumDelegate;
            CalculationEvent += sumDelegate;

            // Рассчитаем сумму результатов расчетов методов
            CalculateSum(5, 3);

            // Пример работы с LINQ
            List<Contact> contacts = new List<Contact>
            {
                new Contact("John Doe", "john.doe@example.com"),
                new Contact("Jane Smith", "jane.smith@example.com"),
                new Contact("Michael Johnson", "michael.johnson@example.com"),
                new Contact("Emily Williams", "emily.williams@example.com")
            };

            var firstContact = contacts.FirstOrDefault();
            var specificContact = contacts.Where(c => c.Email.Contains("john")).ToList();
            var names = contacts.Select(c => c.Name).ToList();

            Console.WriteLine($"First contact: {firstContact}");
            Console.WriteLine("Contacts with 'john' in email:");
            foreach (var contact in specificContact)
            {
                Console.WriteLine($"{contact.Name} - {contact.Email}");
            }
            Console.WriteLine("Contact names:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static int Sum(int a, int b)
        {
            return a + b;
        }

        public static void CalculateSum(int a, int b)
        {
            try
            {
                CalculationEvent?.Invoke(a, b);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Contact(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
