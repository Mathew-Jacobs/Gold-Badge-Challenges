using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class CustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();

        public List<Customer> GetCustomers()
        {
            return _customerList;
        }

        public void AddToList(Customer customer)
        {
            _customerList.Add(customer);
        }

        public void AddToList(List<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                _customerList.Add(customer);
            }
        }

        public List<Customer> SortedCustomers()
        {
            List<Customer> OrderedList = new List<Customer>();

            OrderedList = _customerList.OrderBy(o => o.LastName).ToList();

            return OrderedList;
        }
    }
}