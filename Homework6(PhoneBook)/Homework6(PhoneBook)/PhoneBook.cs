using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Homework6_PhoneBook_
{
    internal class PhoneBook
    {
        private List<PersonData> _listOfPersons = new List<PersonData>();

        private PersonData GetPersonData()
        {
            Console.WriteLine("=========================================");
            Console.Write("Enter person name: ");
            string personName = Console.ReadLine();
            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.WriteLine("=========================================");

            PersonData personData = new PersonData(personName, phoneNumber, address);

            return personData;
        }

        private void DisplayAllPersonData ()
        {
            Console.WriteLine("=========================================");
            foreach (var  person in _listOfPersons)
            {
                Console.WriteLine("Name: " + person.GetPersonName());
                Console.WriteLine("Phone Number: " + person.GetPhoneNumber());
                Console.WriteLine("Address: "+ person.GetAddress());
                Console.WriteLine("=========================================");
            }
        }

        private void SearchByNumber()
        {
            Console.Write("Enter Name for search: ");
            var searchPersonNumber = Console.ReadLine();
            Console.WriteLine("Search Result:\n");
            var searchResult = _listOfPersons.Find(x => x._phoneNumber == searchPersonNumber);
            if (searchResult != null)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("Name: " + searchResult.GetPersonName());
                Console.WriteLine("Phone Number: " + searchResult.GetPhoneNumber());
                Console.WriteLine("Address: " + searchResult.GetAddress());
                Console.WriteLine("=========================================");
            }
            else
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("There's no such person in Phone Book");
                Console.WriteLine("=========================================");
            }

        }

        private void SearchByName()
        {
            Console.Write("Enter Name for search: ");
            var searchPersonName = Console.ReadLine();
            Console.WriteLine("Search Result:\n");
            var searchResult = _listOfPersons.Find(x => x._name == searchPersonName);
            if (searchResult != null)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("Name: " + searchResult.GetPersonName());
                Console.WriteLine("Phone Number: " + searchResult.GetPhoneNumber());
                Console.WriteLine("Address: " + searchResult.GetAddress());
                Console.WriteLine("=========================================");
            }
            else
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("There's no such person in Phone Book");
                Console.WriteLine("=========================================");
            } 
                

        }
        public void Menu() 
        {
            while (true) 
            {
                Console.WriteLine("===================MENU==================");
                Console.WriteLine("1 - Add new Person Data");
                Console.WriteLine("2 - Show all Phone Book Data");
                Console.WriteLine("3 - Search in PhoneBook by Name");
                Console.WriteLine("4 - Search in PhoneBook by Phone Number");
                Console.WriteLine("=========================================");
                Console.Write("\nWrite choosen menu option: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        _listOfPersons.Add(GetPersonData());
                        break;
                    case 2:
                        DisplayAllPersonData();
                        break;
                    case 3:
                        SearchByName();
                        break;
                    case 4:
                        SearchByNumber();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
