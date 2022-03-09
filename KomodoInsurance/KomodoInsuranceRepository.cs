using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class KomodoInsuranceRepository
    {
        protected readonly List<Customer> _customerDirectory = new List<Customer>();
        protected int _id = 1;

        // Create
        public bool AddCustomerToDirectory(Customer customer)
        {
            int startingCount = _customerDirectory.Count();
            customer.Id = _id;
            if (customer.EnrollmentDate == default)
            {
                customer.EnrollmentDate = (new DateTime(2020, 01, 30));
            }
            _customerDirectory.Add(customer);
            _id++;
            bool wasAdded = (_customerDirectory.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        // Read
        public List<Customer> GetCustomers()
        {
            return _customerDirectory;
        }

        public Customer GetCustomerById(int id)
        {
            foreach (Customer customer in _customerDirectory)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }
        public Customer GetCustomerByLastName(string last)
        {
            foreach (Customer customer in _customerDirectory)
            {
                if (customer.LastName.ToLower() == last.ToLower())
                {
                    return customer;
                }
            }
            return null;
        }

        // Update
        public bool UpdateExistingCustomer(int originalId, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerById(originalId);
            if (oldCustomer != null)
            {
                if (newCustomer.EnrollmentDate != default)
                    oldCustomer.EnrollmentDate = newCustomer.EnrollmentDate;

                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.Age = newCustomer.Age;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool DeleteExistingCustomer(Customer existingCustomer)
        {
            bool deleteResult = _customerDirectory.Remove(existingCustomer);
            return deleteResult;
        }

    }
}
