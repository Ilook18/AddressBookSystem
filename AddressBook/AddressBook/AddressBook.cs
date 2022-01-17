using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Contact> addressList = new List<Contact>();
        Dictionary<string, List<Contact>> dictionary = new Dictionary<string, List<Contact>>();
        public void AddContact(Contact contact)
        {
            addressList.Add(contact);
        }
        public void EditContact(string name)
        {
            foreach (var contact in addressList)
            {
                if (contact.FirstName == name || contact.LastName == name)
                {
                    Console.WriteLine("Choose the field you want to edit : \n 1. First name \n 2. Last name \n 3. Address \n 4. City \n 5. State \n 6. Zip code \n 7. Phone Number \n 8. Email");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter you want to edit");
                            string first = Console.ReadLine();
                            contact.FirstName = first;
                            break;
                        case 2:
                            Console.WriteLine("Enter you want to edit");
                            string last = Console.ReadLine();
                            contact.LastName = last;
                            break;
                        case 3:
                            Console.WriteLine("Enter you want to edit");
                            string address = Console.ReadLine();
                            contact.Address = address;
                            break;
                        case 4:
                            Console.WriteLine("Enter you want to edit");
                            string city = Console.ReadLine();
                            contact.City = city;
                            break;
                        case 5:
                            Console.WriteLine("Enter you want to edit");
                            string state = Console.ReadLine();
                            contact.State = state;
                            break;
                        case 6:
                            Console.WriteLine("Enter you want to edit");
                            string zip = Console.ReadLine();
                            contact.Zip = zip;
                            break;
                        case 7:
                            Console.WriteLine("Enter you want to edit");
                            string phone = Console.ReadLine();
                            contact.PhoneNumber = phone;
                            break;
                        case 8:
                            Console.WriteLine("Enter you want to edit");
                            string email = Console.ReadLine();
                            contact.Email = email;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void DeleteContact(string name)
        {
            Contact delete = new Contact();
            foreach (var contact in addressList)
            {
                if (contact.FirstName == name || contact.LastName == name)
                {
                    delete = contact;
                }
            }
            addressList.Remove(delete);
            Console.WriteLine(name + " contact is deleted from the Address Book");
        }
        public void Display()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Contacts in Your Device : ");
            foreach (var contact in addressList)
            {
                Console.WriteLine(contact.FirstName + "\t" + contact.LastName + "\t" + contact.Address + "\t" + contact.City + "\t" + contact.State + "\t" + contact.Zip + "\t" + contact.PhoneNumber + "\t" + contact.Email);
            }
        }
        public void AddUniqueContact()
        {
            foreach (var contact in addressList)
            {
                if (addressList.Contains(contact))
                {
                    string uniqueName = Console.ReadLine();
                    dictionary.Add(uniqueName, addressList);
                }
            }
        }
        public void DisplayUniqueContacts()
        {
            Console.WriteLine("Enter name in dictionary to display contact details");
            string name = Console.ReadLine();
            foreach (var contact in dictionary)
            {
                if (contact.Key == name)
                {
                    foreach (var data in contact.Value)
                    {
                        Console.WriteLine("The Contact details of " + data.FirstName + "are : \n" + data.FirstName + " " + data.LastName + " " + data.Address + " " + data.City + " " + data.State + " " + data.Zip + " " + data.PhoneNumber + " " + data.Email);
                    }
                }
            }
            Console.WriteLine("Sorry this contact is already exits");
            return;

        }
        public void CheckDuplicateEntry()
        {
            Console.WriteLine("Enter the Name to Check whether the name is Duplicate or not");
            string checkD = Console.ReadLine();
            var person = addressList.Find(e => e.FirstName.Equals(checkD));
            if (person == null)
            {
                Console.WriteLine("The Name you are trying to check is Not in the Address Book");
            }
            else
            {
                Console.WriteLine("The Name You are trying to search already exist", checkD);
            }
        }
        public void SearchPerson()
        {
            Console.WriteLine("Enter the City name to Check Persons");
            string City = Console.ReadLine();
            List<Contact> cityList = addressList.FindAll(e => e.City == City);
            foreach (var place in cityList)
            {
                Console.WriteLine("Found person {0} {1} in the Address Book, living in the City {2}", place.FirstName, place.LastName, place.City);
            }
            Console.WriteLine("Enter the State name to check Persons");
            string state = Console.ReadLine();
            List<Contact> stateList = addressList.FindAll(e => e.State == state);
            foreach (var sta in stateList)
            {
                Console.WriteLine("Found the name of {0} {1} in the Address Book, living in the City {2}", sta.FirstName, sta.LastName, sta.State);
            }
        }
        public void CountPersons()
        {
            Console.WriteLine("Enter the city name to check its count : ");
            string city = Console.ReadLine();
            List<Contact> cityList = addressList.FindAll(e => e.City == city);
            Console.WriteLine("The Number of contact persons in the city {0} are {1}", city, cityList.Count());

            Console.WriteLine("Enter the state name to check its count : ");
            string state = Console.ReadLine();
            List<Contact> stateList = addressList.FindAll(e => e.State == state);
            Console.WriteLine("The number of contact persons in the state {0} are {1}", state, stateList.Count());
        }
        public void AddressBookSorting()
        {
            Console.WriteLine("Enter the Address Book name that you want to sort : ");
            string addressBookName = Console.ReadLine();
            if (dictionary.ContainsKey(addressBookName))
            {
                dictionary[addressBookName].Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
                Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                Display();
            }
            else
            {
                Console.WriteLine("The {0} Addressbook does not exist. Please Enter a Valid Addressbook Name. ", addressBookName);
            }
        }
        public void Sorting()
        {

            Console.WriteLine("Enter the Address Book name that you want to sort : ");
            string addressBookName = Console.ReadLine();
            Console.WriteLine("How do you want the Sort the Addressbook : \n 1. Sort based on City \n 2. Sort based on State \n 3. Sort based on Zip");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    dictionary[addressBookName].Sort((x, y) => x.City.CompareTo(y.City));
                    Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                    Display();
                    break;
                case 2:
                    dictionary[addressBookName].Sort((x, y) => x.State.CompareTo(y.State));
                    Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                    Display();
                    break;
                case 3:
                    dictionary[addressBookName].Sort((x, y) => x.Zip.CompareTo(y.Zip));
                    Console.WriteLine("After Sorting alphabetically, The Address Book is arranged as : ");
                    Display();
                    break;
            }
        }
        public void ReadAndWriteFile()
        {
            Console.WriteLine("After reading the file");
            string FilePath = @"C:\Users\DELL\source\repos\AddressBook\Files\File.txt";
            string Text = File.ReadAllText(FilePath);
            Console.WriteLine(Text);

            Console.WriteLine("After Writing into the file");
            using (StreamWriter writer = File.AppendText(FilePath))
            {
                writer.WriteLine("Email: anirudhanand984@gmail.com");
                writer.Close();
                Console.WriteLine(File.ReadAllText(FilePath));
            }
        }
        public void implementCSVDataHandling()
        {
            string importFilePath = @"C:\Users\DELL\source\repos\AddressBook\Files\address.csv";
            string exportFilePath = @"C:\Users\DELL\source\repos\AddressBook\Files\export.csv";

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();
                Console.WriteLine("Read data successfully from adress csv.");
                foreach (Contact contact in records)
                {
                    Console.Write("\t" + contact.FirstName);
                    Console.Write("\t" + contact.LastName);
                    Console.Write("\t" + contact.Address);
                    Console.Write("\t" + contact.City);
                    Console.Write("\t" + contact.State);
                    Console.Write("\t" + contact.Zip);
                    Console.Write("\t" + contact.PhoneNumber);
                    Console.Write("\t" + contact.Email);
                    Console.Write("\t");
                }
                Console.WriteLine("\t************Now reading from csv file and writing to csv file");

                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }

        }
    }
}

               
    
    