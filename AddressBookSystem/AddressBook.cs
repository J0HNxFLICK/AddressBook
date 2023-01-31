using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AddressBookSystem
{
    internal class AddressBook
    {
        public static List<Contact> contacts = new List<Contact>();

        public static void Display()
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.firstName + " " +contact.lastName + " " + contact.email + " " + contact.phone + " " + contact.city + " " + contact.state + " " + contact.zipcode + "\n");
            }
        }
        public static void AddContact ()
        {
            char userChoice;
            do
            {
                Console.WriteLine("Enter contact details.\n");

                Console.Write("Enter First Name : ");
                string first = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Enter Last Name : ");
                string last = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Enter email ID : ");
                string emailId = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Enter Phone Number : ");
                long phoneNumber = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("");

                Console.Write("Enter City : ");
                string cityName = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Enter State : ");
                string stateName = Console.ReadLine();
                Console.WriteLine("");

                Console.Write("Enter zipcode : ");
                int zipcodeNumb = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                //list.Add(new Customer { Id = 10, Name = "test" });

                contacts.Add(new Contact { firstName = first, lastName= last, email = emailId, phone = phoneNumber, city = cityName, state = stateName, zipcode = zipcodeNumb } );

                Console.WriteLine("Contact Successfully created !\n");

                Console.WriteLine(first + " " + last + " " + emailId + " " + phoneNumber + " " + cityName + " " + stateName + " " + zipcodeNumb + " \n");

                Console.WriteLine("Do you want to create another contact y/n ?");
                userChoice = Convert.ToChar(Console.ReadLine());
            } 
            while (userChoice == 'y'); // UC2 Multiple contacts

            Console.WriteLine("Available contacts ...\n");
            AddressBook.Display();
            
        }
    }
}
