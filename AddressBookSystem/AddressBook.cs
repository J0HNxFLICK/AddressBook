using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AddressBookSystem
{
    internal class AddressBook
    {
        //public static List<Contact> contacts = new List<Contact>();

        public static Dictionary<string, List<Contact>> addressBooks = new Dictionary<string, List<Contact>>(); // UC6 Refactored to add multiple addressbooks 

        public static void CreateAddressBooks()
        {
            Console.Write("How many Address Books you want to create : ");
            int booksCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            for (int i = 1; i <= booksCount; i++)
            {
                Console.Write("Enter {0} Address book name : ", i);
                string key = Console.ReadLine();

                if (!addressBooks.ContainsKey(key))
                {
                    addressBooks.Add(key, new List<Contact>());
                }
                else
                    Console.WriteLine("Already contains an Address Book with entered name.");
            }

            Prompt();
        }
        public static void Prompt()
        {
            Console.WriteLine("Do you want to perform other operations y/n ?");
            char promptChoice = Convert.ToChar(Console.ReadLine());

            if (promptChoice == 'y')
            {
                Console.WriteLine("\n1 - Create AddressBooks\n2 - List all AddressBooks\n3 - Add Contact\n4 - Edit Existing Contact\n5 - Delete Contact\n");
                int promptUserChoice = Convert.ToInt32(Console.ReadLine());

                switch (promptUserChoice)
                {
                    case 1:
                        CreateAddressBooks();
                        break;

                    case 2:
                        ListAddressBooks();
                        break;

                    case 3:
                        AddContact();
                        break;

                    case 4:
                        EditContact();
                        break;

                    case 5:
                        DeleteContact();
                        break;

                    default:
                        Console.WriteLine("Choose appropriate option.");
                        Prompt();
                        break;
                }
            }

            else
                Console.WriteLine("Thank you for using Address Book program");
        }

        public static void Display(string addressBookName)
        {
            if (!addressBooks.ContainsKey(addressBookName))
            {
                Console.WriteLine("Address book does not exist.");
                return;
            }

            List<Contact> contacts = addressBooks[addressBookName];

            if (contacts.Count == 0)
            {
                Console.WriteLine("Address book is empty.");
                return;
            }

            Console.WriteLine("Contacts in {0} address book:\n", addressBookName);

            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.firstName + " " + contact.lastName + " " + contact.email + " " + contact.phone + " " + contact.city + " " + contact.state + " " + contact.zipcode + " \n");
            }
        }

        public static void ListAddressBooks()
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No address books created yet.");
                return;
            }

            Console.WriteLine("Available address books:\n");
            foreach (string key in addressBooks.Keys)
            {
                Console.WriteLine(key);
            }

            Prompt();
        }

        public static void AddressBookDisplayer()
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No address books created yet.");
                return;
            }

            Console.WriteLine("Available address books:\n");
            foreach (string key in addressBooks.Keys)
            {
                Console.WriteLine(key);
            }
        }

        public static void AddContact() //UC2 Adding Contacts
        {
            AddressBookDisplayer();
            Console.WriteLine("");
            Console.Write("Which address book you want to add in : ");
            string keyChoice = Console.ReadLine();
            Console.WriteLine("");

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

                //contacts.Add(new Contact { firstName = first, lastName= last, email = emailId, phone = phoneNumber, city = cityName, state = stateName, zipcode = zipcodeNumb } );

                addressBooks[keyChoice].Add(new Contact { firstName = first, lastName = last, email = emailId, phone = phoneNumber, city = cityName, state = stateName, zipcode = zipcodeNumb });

                Console.WriteLine("Contact Successfully created in {0} address book !\n", keyChoice);

                Console.WriteLine(first + " " + last + " " + emailId + " " + phoneNumber + " " + cityName + " " + stateName + " " + zipcodeNumb + " \n");

                Console.WriteLine("Do you want to create another contact in the same address book y/n ?");
                userChoice = Convert.ToChar(Console.ReadLine());
            }
            while (userChoice == 'y'); // UC5 Multiple contacts

            //Console.WriteLine("Available contacts ...\n");
            //AddressBook.Display();

            Prompt();

        }

        public static void EditContact() // UC3 Editing a contact based on first name
        {
            AddressBookDisplayer();
            Console.WriteLine("");
            Console.Write("Which address book you want to edit contact in : ");
            string keyChoiceEdit = Console.ReadLine();
            Console.WriteLine("");

            Display(keyChoiceEdit);

            Console.Write("Enter First Name of the contact you want to edit : \n");
            string nameInput = Console.ReadLine();

            Contact contact = null;
            foreach (var c in addressBooks[keyChoiceEdit])
            {
                if (c.firstName.ToLower() == nameInput.ToLower())
                {
                    contact = c;

                    char choice;

                    Console.WriteLine("First Name : " + contact.firstName);
                    Console.WriteLine("Last Name : " + contact.lastName);
                    Console.WriteLine("Email ID : " + contact.email);
                    Console.WriteLine("Phone Number : " + contact.phone);
                    Console.WriteLine("City : " + contact.city);
                    Console.WriteLine("State : " + contact.state);
                    Console.WriteLine("Zipcode : " + contact.zipcode);

                    do
                    {

                        Console.WriteLine("Which field you want to edit ? Choose a number.");
                        Console.WriteLine("\n1 - First Name\n2 - Last Name\n3 - Email ID\n4 - Phone Number\n5 - City\n6 - State\n7 - Zipcode\n8 - All fields at once\n");
                        int action = Convert.ToInt32(Console.ReadLine());

                        switch (action)
                        {
                            case 1:

                                Console.Write("Enter new First Name : ");
                                string newFirstName = Console.ReadLine();
                                Console.WriteLine("First name is now changed from {0} to {1}", contact.firstName, newFirstName);

                                contact.firstName = newFirstName;
                                break;

                            case 2:

                                Console.Write("Enter new Last Name : ");
                                string newLastName = Console.ReadLine();
                                Console.WriteLine("Last name is now changed from {0} to {1}", contact.lastName, newLastName);

                                contact.lastName = newLastName;
                                break;

                            case 3:

                                Console.Write("Enter new Email ID : ");
                                string newEmailAddress = Console.ReadLine();
                                Console.WriteLine("Email ID is now changed from {0} to {1}", contact.email, newEmailAddress);

                                contact.email = newEmailAddress;
                                break;

                            case 4:

                                Console.Write("Enter new Phone Number : ");
                                long newPhoneNumber = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Phone Number is now changed from {0} to {1}", contact.phone, newPhoneNumber);

                                contact.phone = newPhoneNumber;
                                break;

                            case 5:

                                Console.Write("Enter new City : ");
                                string newCity = Console.ReadLine();
                                Console.WriteLine("City is now changed from {0} to {1}", contact.city, newCity);

                                contact.city = newCity;
                                break;

                            case 6:

                                Console.Write("Enter new State : ");
                                string newState = Console.ReadLine();
                                Console.WriteLine("State is now changed from {0} to {1}", contact.state, newState);

                                contact.state = newState;
                                break;

                            case 7:

                                Console.Write("Enter new Zipcode : ");
                                int newZipcode = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Zipcode is now changed from {0} to {1}", contact.zipcode, newZipcode);

                                contact.zipcode = newZipcode;
                                break;

                            case 8:

                                Console.Write("Enter First Name : ");
                                string newfirst = Console.ReadLine();
                                Console.WriteLine("");

                                Console.Write("Enter Last Name : ");
                                string newlast = Console.ReadLine();
                                Console.WriteLine("");

                                Console.Write("Enter email ID : ");
                                string newEmailId = Console.ReadLine();
                                Console.WriteLine("");

                                Console.Write("Enter Phone Number : ");
                                long newPhone = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("");

                                Console.Write("Enter City : ");
                                string newCityName = Console.ReadLine();
                                Console.WriteLine("");

                                Console.Write("Enter State : ");
                                string newStateName = Console.ReadLine();
                                Console.WriteLine("");

                                Console.Write("Enter zipcode : ");
                                int newZipcodeNumb = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("");

                                Console.WriteLine("Old contact : {0} {1} {2} {3} {4} {5} {6}\n", contact.firstName, contact.lastName, contact.email, contact.phone.ToString(), contact.city, contact.state, contact.zipcode);

                                Console.WriteLine("New contact : {0} {1} {2} {3} {4} {5} {6}\n", newfirst, newlast, newEmailId, newPhone, newCityName, newStateName, newZipcodeNumb);

                                contact.firstName = newfirst;
                                contact.lastName = newlast;
                                contact.email = newEmailId;
                                contact.phone = newPhone;
                                contact.city = newCityName;
                                contact.state = newStateName;
                                contact.zipcode = newZipcodeNumb;

                                Console.WriteLine("Contacted updated successfully !");
                                break;

                            default:

                                Console.WriteLine("Choose appropriate choice.");
                                break;
                        }

                        Console.WriteLine("First Name : " + contact.firstName);
                        Console.WriteLine("Last Name : " + contact.lastName);
                        Console.WriteLine("Email ID : " + contact.email);
                        Console.WriteLine("Phone Number : " + contact.phone);
                        Console.WriteLine("City : " + contact.city);
                        Console.WriteLine("State : " + contact.state);
                        Console.WriteLine("Zipcode : " + contact.zipcode);

                        Console.WriteLine("Do you want to edit the same contact again y/n ?");
                        choice = Convert.ToChar(Console.ReadLine());

                    } while (choice == 'y');

                    Prompt();

                }

                else
                {
                    Console.WriteLine("No contact with such name exists.");
                    Prompt();
                }
            }
        }

        public static void DeleteContact() // UC4 Delete contact based on first name
        {
            AddressBookDisplayer();
            Console.WriteLine("");
            Console.Write("Which address book you want to edit contact in : ");
            string keyChoiceDelete = Console.ReadLine();
            Console.WriteLine("");

            Display(keyChoiceDelete);

            Console.Write("Enter the first name of the contact to delete: ");
            string firstName = Console.ReadLine();

            Contact contact = null;

            foreach (Contact c in addressBooks[keyChoiceDelete])
            {
                if (c.firstName.ToLower() == firstName.ToLower())
                {
                    contact = c;
                    break;
                }
            }

            if (contact != null)
            {
                addressBooks[keyChoiceDelete].Remove(contact);
                Console.WriteLine("Contact successfully deleted from the address book.\n");
                Prompt();
            }
            else
            {
                Console.WriteLine("Contact not found. Please try again.\n");
                Prompt();
            }


        }

    }
}
