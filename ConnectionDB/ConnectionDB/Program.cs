using ConnectionDB.Models;
using ConnectionDB.Repository;
using Npgsql;

namespace ConnectionDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = "Host=localhost;Database=dotnet-test;Username=postgres;Password=12345678";

            ICustomerRepository customerRepository = new CustomerRepository(connectionString);
            /*            customerRepository.Save(new Customer
                        {
                            Id = 1,
                            Name = "123",
                            PhoneNumber = "123"
                        });*/

            customerRepository.FindAll().ForEach(customer =>
            {
                Console.Write("id:" + customer.Id); Console.WriteLine();
                Console.Write("name:" + customer.Name); Console.WriteLine();
                Console.Write("phone number:" + customer.PhoneNumber); Console.WriteLine();
                Console.WriteLine();
            });

        }
    }
}
