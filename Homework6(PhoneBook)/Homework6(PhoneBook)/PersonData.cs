using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6_PhoneBook_
{
    internal class PersonData
    {
        public string _name;
        public string _phoneNumber;
        private string _address;
        public PersonData(string name, string phoneNumber,  string address) 
        { 
            _name = name;
            _phoneNumber = phoneNumber;
            _address = address;
        }
        public string GetPersonName()
        {
            return _name;
        }
        public string GetPhoneNumber()
        {
            return _phoneNumber;
        }
        public string GetAddress() 
        {
            return _address;
        }
    }
}
