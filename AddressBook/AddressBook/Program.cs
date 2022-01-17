using System;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            Contact contact = new Contact();
            AddressBook addressBook = new AddressBook();
            while (flag)
            {
                Console.WriteLine("Welcome to the Address Book Program");
                Console.WriteLine("Enter what you want to do : \n 1. Create Contacts \n 2. Add Contacts \n 3. Edit Contacts \n 4. Delete Contact\n 5. Multiple Contacts\n 6. Add Unique Contacts\n 7. Check Duplicate Entry\n 8. Search Persons\n 9.View Persons\n 10.Count Persons\n 11.Sort by name\n 12.Sorting\n 13.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the Contact details of FirstName, LastName, Address, City, State, Zip, Ph.no, Email : ");
                        contact = new Contact()
                        {
                            FirstName = Console.ReadLine(),
                            LastName = Console.ReadLine(),
                            Address = Console.ReadLine(),
                            City = Console.ReadLine(),
                            State = Console.ReadLine(),
                            Zip = Console.ReadLine(),
                            PhoneNumber = Console.ReadLine(),
                            Email = Console.ReadLine(),
                        };
                        break;
                    case 2:
                        Console.WriteLine("Enter the Contact Information to Add, in form of FirstName, LastName, Addr, City, State, Zip, Ph.No, Email.");
                        contact = new Contact()
                        {
                            FirstName = Console.ReadLine(),
                            LastName = Console.ReadLine(),
                            Address = Console.ReadLine(),
                            City = Console.ReadLine(),
                            State = Console.ReadLine(),
                            Zip = Console.ReadLine(),
                            PhoneNumber = Console.ReadLine(),
                            Email = Console.ReadLine(),
                        };
                        addressBook.AddContact(contact);
                        addressBook.Display();
                        break;
                    case 3:
                        Console.WriteLine("Enter the Contact Name to  Edit: ");
                        string name = Console.ReadLine();
                        addressBook.EditContact(name);
                        Console.WriteLine("Contact is Edited Sucsessfully");
                        addressBook.Display();
                        break;
                    case 4:
                        Console.WriteLine("Enter the Contact Name to  delete: ");
                        string detail = Console.ReadLine();
                        addressBook.EditContact(detail);
                        Console.WriteLine("Contact is deleted Sucsessfully");
                        addressBook.Display();
                        break;
                    case 5:
                        Console.WriteLine("Enter the Contact Information to Add, in form of FirstName, LastName, Addr, City, State, Zip, Ph.No, Email.");
                        contact = new Contact()
                        {
                            FirstName = Console.ReadLine(),
                            LastName = Console.ReadLine(),
                            Address = Console.ReadLine(),
                            City = Console.ReadLine(),
                            State = Console.ReadLine(),
                            Zip = Console.ReadLine(),
                            PhoneNumber = Console.ReadLine(),
                            Email = Console.ReadLine(),
                        };
                        addressBook.AddContact(contact);
                        addressBook.Display();
                        break;
                    case 6:
                        addressBook.AddUniqueContact();
                        addressBook.DisplayUniqueContacts();
                        break;
                    case 7:
                        addressBook.CheckDuplicateEntry();
                        break;
                    case 8:
                        addressBook.SearchPerson();
                        break;
                    case 9:
                        addressBook.SearchPerson();
                        break;
                    case 10:
                        addressBook.CountPersons();
                        break;
                    case 11:
                        addressBook.AddressBookSorting();
                        break;
                    case 12:
                        addressBook.Sorting();
                        break;
                    case 13:
                        flag = false;
                        break;
                    
                }
            }
        }
    }
}