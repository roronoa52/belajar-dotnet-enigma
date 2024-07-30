using ConnectionDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDB.Repository
{
    public interface ICustomerRepository
    {
        void GenerateTable();
        void Save(Customer customer);
        Customer? FindById(int id);
        List<Customer> FindAll();
        void Update(Customer customer);
        void DeleteById(int id);
    }
}
