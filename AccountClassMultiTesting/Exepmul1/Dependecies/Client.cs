using bank.TestDoubles;
using System;
using System.Collections.Generic;
using System.Text;

namespace bank.Dependecies
{
    public class Client : IClient
    {
        string firstName;
        string lastName;
        string address;
        int age;
        //a lot of other info could be employed, company...

        public Client(string _firstName, string _lastName, string _address, int _age)
        {
            firstName = _firstName;
            lastName = _lastName;
            address = _address;
            age = _age;
        }
    }
}
