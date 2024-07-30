using LearnEntityFramework.Entities;
using LearnEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEntityFramework.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly IRepository<Customer> repository;
        private readonly IPersistance persistance;

        public CustomerService(IRepository<Customer> repository, IPersistance persistance)
        {
            this.repository = repository;
            this.persistance = persistance;
        }

        public Customer CreateNewCustomer(Customer customer)
        {
            try
            {
                var newCustomer = repository.Save(customer);
                persistance.SaveChanges();
                return newCustomer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Customer GetById(string id)
        {
            try
            {
                var customer = repository.FindById(Guid.Parse(id));
                if (customer is null) throw new Exception("customer not found");
                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
