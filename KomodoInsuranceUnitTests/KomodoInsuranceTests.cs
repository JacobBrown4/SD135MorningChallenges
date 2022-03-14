using KomodoInsurance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoInsuranceUnitTests
{
    [TestClass]
    public class KomodoInsuranceTests
    {
        KomodoInsuranceRepository _repo;
        Customer _customer;
        [TestInitialize]
        public void Initiliaze()
        {
            _repo = new KomodoInsuranceRepository();
            _customer = new Customer();
        }

        [TestMethod]
        public void AddCustomer_ShouldAddToRepoWithUniqueId()
        {
            _customer.Id = 20;
            _repo.AddCustomerToDirectory(_customer);
            _repo.AddCustomerToDirectory(new Customer());
            _repo.AddCustomerToDirectory(new Customer());
            List<Customer> customers = _repo.GetCustomers();
            Assert.IsTrue(customers.Contains(_customer));
            Console.WriteLine(customers[0].Id);
            Console.WriteLine(customers[2].Id);
            Console.WriteLine(customers[1].Id);

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.ThankYou());
            }
        }

        [TestMethod]
        public void MakingIVehicleTypes_ShouldWorkTogether()
        {
            Motorcyle motorcyle = new Motorcyle();
            SUV suv = new SUV();
            Sedan sedan = new Sedan();
            List<IVehicle> vehicles = new List<IVehicle>() { suv,sedan,motorcyle};
            vehicles[1].TurnOn();
            vehicles[1].Drive();

        }
    }
}
