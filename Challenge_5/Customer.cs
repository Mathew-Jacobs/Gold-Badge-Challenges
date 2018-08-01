using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public enum CustomerType
    {
        Potential, Current, Past
    }
    public class Customer
    {
        public Customer(string firstName, string lastName, CustomerType type, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{LastName}\t\t{FirstName}\t\t{Type}\t\t{Email}\n";
        }
    }
}
