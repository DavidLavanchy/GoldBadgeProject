using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreetings_POCOs
{
    public class Greetings
    {
        public enum TypeOfGreeting { Potential, Current, Past }
        public Greetings(){}
        public Greetings(string firstName, string lastName, TypeOfGreeting typeOfCustomer, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = typeOfCustomer;
            Email = email;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeOfGreeting TypeOfCustomer { get; set; }
        public string Email { get; set; }
    }
}
