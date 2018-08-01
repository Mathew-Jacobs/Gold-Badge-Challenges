using System;
using System.Collections.Generic;
using Challenge_5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_5_Tests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        [TestMethod]
        public void CustomerRepository_GetCustomers_ShouldReturnListOfCustomers()
        {
            //--Arrange
            CustomerRepository _customerRepo = new CustomerRepository();

            //--Act
            int actual = _customerRepo.GetCustomers().Count;
            int expected = 0;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CustomerRepository_AddToList_ShouldAddCustomerToList()
        {
            //--Arrange
            CustomerRepository _customerRepo = new CustomerRepository();
            Customer customer = new Customer("Tom", "Hardy", CustomerType.Current, "Hi Tom");
            _customerRepo.AddToList(customer);

            //--Act
            int actual = _customerRepo.GetCustomers().Count;
            int expected = 1;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CustomerRepository_AddToList_ShouldAddCustomerListToList()
        {
            //--Arrange
            CustomerRepository _customerRepo = new CustomerRepository();
            Customer customer = new Customer("Tom", "Hardy", CustomerType.Current, "Hi Tom");
            Customer customer2 = new Customer("Tom", "Hardy", CustomerType.Current, "Hi Tom");
            List<Customer> customers = new List<Customer>();
            customers.Add(customer); customers.Add(customer2);
            _customerRepo.AddToList(customers);

            //--Act
            int actual = _customerRepo.GetCustomers().Count;
            int expected = 2;

            //--Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CustomerRepository_SortedCustomers_ShouldListCustomerByLastName()
        {
            //--Arrange
            CustomerRepository _customerRepo = new CustomerRepository();
            Customer customer = new Customer("Tom", "Hardy", CustomerType.Current, "Hi Tom");
            Customer customer2 = new Customer("Tom", "Anders", CustomerType.Current, "Hi Tom");
            List<Customer> customers = new List<Customer>();
            customers.Add(customer); customers.Add(customer2);
            _customerRepo.AddToList(customers);
            List<Customer> sortedCustomers = _customerRepo.SortedCustomers();

            //--Act
            string actual = sortedCustomers[0].LastName;
            string expected = "Anders";

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
