using LearnEntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEntityFramework.Services
{
    public interface ICustomerService
    {
        Customer CreateNewCustomer (Customer customer);
        Customer GetById (string id);
    }
}
