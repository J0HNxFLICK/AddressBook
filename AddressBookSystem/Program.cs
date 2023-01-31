namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System Program");

            //UC1 Creating contact in address book.

            Console.WriteLine("Please Enter Contact Details\n");
            Console.Write("\nFirst Name : ");
            String firstName = Console.ReadLine();
            Console.Write("\nLast Name : ");
            String lastName = Console.ReadLine();
            Console.Write("\nPhone Number : ");
            int phoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEmail : ");
            String email = Console.ReadLine(); ;
            Console.Write("\nAddress : ");
            String address = Console.ReadLine();
            Console.Write("\nCity : ");
            String city = Console.ReadLine();
            Console.Write("\nState : ");
            String state = Console.ReadLine();
            Console.Write("\nZip : ");
            int zipCode = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Added contact.\n\n" + firstName + "  " + lastName + "  " + phoneNumber + "  " + email + "  " + address + "  " + city + "  " + state + "  " + zipCode);
        }
    }
}