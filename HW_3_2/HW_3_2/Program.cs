namespace HW_3_2
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }

    public class ContactCollection
    {
        private List<Contact> contacts = new List<Contact>();
        private Dictionary<string, List<Contact>> groupedContacts = new Dictionary<string, List<Contact>>();
        private readonly CultureInfo defaultCulture = new CultureInfo("en-US");
        private CultureInfo currentCulture;

        public ContactCollection(CultureInfo culture = null)
        {
            currentCulture = culture ?? defaultCulture;
        }

        public void Add(Contact contact)
        {
            contacts.Add(contact);
            GroupContacts();
        }

        public IEnumerable<KeyValuePair<string, List<Contact>>> GetGroupedContacts()
        {
            return groupedContacts;
        }

        private void GroupContacts()
        {
            groupedContacts.Clear();

            var sortedContacts = contacts.OrderBy(c => c.Name).ToList();

            foreach (var contact in sortedContacts)
            {
                char firstChar = contact.Name.ToUpper(currentCulture)[0];

                if (char.IsDigit(firstChar))
                {
                    firstChar = '0';
                }
                else if (!char.IsLetter(firstChar))
                {
                    firstChar = '#';
                }

                if (!groupedContacts.ContainsKey(firstChar.ToString()))
                {
                    groupedContacts[firstChar.ToString()] = new List<Contact>();
                }

                groupedContacts[firstChar.ToString()].Add(contact);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var contactCollection = new ContactCollection(new CultureInfo("uk-UA"));

            var contact1 = new Contact("John Smith", "123456789");
            var contact2 = new Contact("Анна Иванова", "987654321");
            var contact3 = new Contact("Вася Пупкин", "456789123");

            contactCollection.Add(contact1);
            contactCollection.Add(contact2);
            contactCollection.Add(contact3);

            foreach (var group in contactCollection.GetGroupedContacts())
            {
                Console.WriteLine(group.Key);
                foreach (var contact in group.Value)
                {
                    Console.WriteLine($"- {contact.Name}: {contact.PhoneNumber}");
                }
            }
        }
    }

}