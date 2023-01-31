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

        public static void Prompt()
        {
            Console.WriteLine("Do you want to perform other operations y/n ?");
            char promptChoice = Convert.ToChar(Console.ReadLine());

            if(promptChoice == 'y')
            {
                Console.WriteLine("\n1 - Add Contact\n2 - Edit Existing Contact\n");
                int promptUserChoice = Convert.ToInt32(Console.ReadLine());

                switch(promptUserChoice)
                {
                    case 1:
                        AddContact();
                        break;

                    case 2:
                        if (contacts.Count != 0)
                        {
                            EditContact();
                        }
                        else
                        {
                            Console.WriteLine("Address Book is empty.");
                            Prompt();
                        }
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

                contacts.Add(new Contact { firstName = first, lastName= last, email = emailId, phone = phoneNumber, city = cityName, state = stateName, zipcode = zipcodeNumb } );

                Console.WriteLine("Contact Successfully created !\n");

                Console.WriteLine(first + " " + last + " " + emailId + " " + phoneNumber + " " + cityName + " " + stateName + " " + zipcodeNumb + " \n");

                Console.WriteLine("Do you want to create another contact y/n ?");
                userChoice = Convert.ToChar(Console.ReadLine());
            } 
            while (userChoice == 'y'); // UC2 Multiple contacts

            Console.WriteLine("Available contacts ...\n");
            AddressBook.Display();

            Prompt();
            
        }

        public static void EditContact() // UC3 Editing a contact based on first name
        {
            Console.Write("Enter First Name of the contact you want to edit : \n");
            string nameInput = Console.ReadLine();

            foreach (Contact contact in contacts)
            {
                if(contact.firstName == nameInput)
                {
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
            }
        }

        public static void DeleteContact() // UC4 Delete contact based on first name
        {
            Console.Write("Enter First Name of contact that you want to delete : ");
            string deleteReference = Console.ReadLine();

            if(contacts.Count != 0)
            {
                foreach (Contact contact in contacts)
                {
                    if (contact.firstName == deleteReference)
                    {
                        Console.WriteLine("Contact to be deleted : {0} {1} {2} {3} {4} {5} {6}\n", contact.firstName, contact.lastName, contact.email, contact.phone.ToString(), contact.city, contact.state, contact.zipcode);

                        Console.WriteLine("Ar you sure you want to delete y/n ?");
                        char confirmation = Convert.ToChar(Console.ReadLine());

                        if (confirmation == 'y')
                        {
                            contacts.Remove(contact);
                        }
                        else
                            Prompt();

                        Console.WriteLine("Contact has been removed");
                    }
                    else
                        Console.WriteLine("Contact not found !");
                }
            }

            else { Console.WriteLine("Address Book is empty."); }
            
        }
    }
}
