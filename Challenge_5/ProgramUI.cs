using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    class ProgramUI
    {
        CustomerRepository _customerRepo = new CustomerRepository();

        public void Run()
        {
            List<Customer> customers = _customerRepo.GetCustomers();
            bool loop = true;

            while (loop)
            {
                string input = ConsoleMenu();
                switch (input)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        Console.WriteLine("Enter the last name of the customer you would like to edit\n");
                        string lastName1 = Console.ReadLine();
                        EditCustomer(lastName1);
                        break;
                    case "3":
                        Console.WriteLine("\nEnter the last name of the customer you would like to view\n");
                        string lastName = Console.ReadLine();
                        GetCustomer(lastName);
                        break;
                    case "4":
                        ViewCustomers();
                        break;
                    case "X":
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private string ConsoleMenu()
        {
            Console.WriteLine($"\r\nWhat would you like to do?\r\n" +
                $"\r\n" +
                $"[1] Add new Customer\r\n" +
                $"[2] Edit existing Customer information\n" +
                $"[3] Find Customer" +
                $"[4] View all Customers\n" +
                $"[X] Exit\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            return input.KeyChar.ToString();
        }

        private void GetCustomer(string lastName)
        {
            Console.Clear();
            int count = 0;
            List<Customer> allcustomers = _customerRepo.GetCustomers();
            List<Customer> foundCustomers = new List<Customer>();
            foreach (Customer customer in allcustomers)
            {
                if (customer.LastName == lastName)
                {
                    count++;
                    foundCustomers.Add(customer);
                }
            }
            if (count == 1)
            {
                Console.WriteLine($"Last Name\tFirst Name\ttype\t\temail\n");
                Console.WriteLine(foundCustomers[0]);
                Console.WriteLine("\n\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Multiple Customers Found:\n" +
                    "\n");
                Console.WriteLine($"Last Name\tFirst Name\ttype\t\temail\n");
                foreach (Customer customer in foundCustomers)
                {
                    Console.WriteLine(customer);
                }
                Console.WriteLine("\n\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private string GetEmail(CustomerType type)
        {
            switch (type)
            {
                case CustomerType.Potential:
                    return "We currently have the lowest rates on Helicopter Insurance!";
                case CustomerType.Current:
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                case CustomerType.Past:
                    return "It's been a long time since we've heard from you, we want you back.";
                default:
                    return "ERROR";
            }
        }

        private void AddCustomer()
        {
            Console.Clear();
            bool trying = true;
            Console.WriteLine("\nEnter the Customer's First Name:\t");
            string firstName = Console.ReadLine();
            Console.WriteLine("\nEnter the Customer's Last Name:\t");
            string lastName = Console.ReadLine();
            while (trying)
            {
                Console.WriteLine("\nSelect the Customer's status:\n" +
                    "[1] Potential\n" +
                    "[2] Current\n" +
                    "[3] Past\n");

                System.ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                string response = key.KeyChar.ToString();
                CustomerType type;
                string email = "";
                Customer customer;
                switch (response)
                {
                    case "1":
                        type = CustomerType.Potential;
                        trying = false;
                        email = GetEmail(type);
                        customer = new Customer(firstName, lastName, type, email);
                        _customerRepo.AddToList(customer);
                        Console.Clear();
                        break;
                    case "2":
                        type = CustomerType.Current;
                        trying = false;
                        email = GetEmail(type);
                        customer = new Customer(firstName, lastName, type, email);
                        _customerRepo.AddToList(customer);
                        Console.Clear();
                        break;
                    case "3":
                        type = CustomerType.Past;
                        trying = false;
                        email = GetEmail(type);
                        customer = new Customer(firstName, lastName, type, email);
                        _customerRepo.AddToList(customer);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Error: Select defined option");
                        break;
                }
            }

        }

        private void ViewCustomers()
        {
            Console.Clear();
            Console.WriteLine($"Last Name\tFirst Name\ttype\t\t\temail");
            foreach (Customer customer in _customerRepo.GetCustomers())
            {
                Console.WriteLine(customer);
            }
        }

        private void EditCustomer(string lastName)
        {
            Console.Clear();
            int count = 0;
            List<Customer> allcustomers = _customerRepo.GetCustomers();
            List<Customer> foundCustomers = new List<Customer>();
            foreach (Customer customer in allcustomers)
            {
                if (customer.LastName == lastName)
                {
                    count++;
                    foundCustomers.Add(customer);
                }
            }
            if (count == 1)
            {
                Console.WriteLine($"Last Name\tFirst Name\ttype\t\temail\n");
                Console.WriteLine(foundCustomers[0]);
                Console.WriteLine("\n\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Multiple Customers Found:\n" +
                    "\n");
                Console.WriteLine($"Last Name\tFirst Name\ttype\t\temail\n");
                foreach (Customer customer in foundCustomers)
                {
                    Console.WriteLine(customer);
                }
                Console.WriteLine("Enter the first name of the customer you would like to edit");
                count = 0;
                string firstName = Console.ReadLine();
                foreach (Customer customer in foundCustomers)
                {
                    if (customer.FirstName == firstName)
                    {
                        //Menu for editing
                        Console.WriteLine($"\r\nWhat would you like to do?\r\n" +
                            $"\r\n" +
                            $"[1] Change customer status\r\n" +
                            $"[2] Delete customer\n" +
                            $"[3] Cancel\n");
                        System.ConsoleKeyInfo input = Console.ReadKey();
                        Console.Clear();
                        string answer = input.KeyChar.ToString();
                    }
                }
            }
        }
    }
}
