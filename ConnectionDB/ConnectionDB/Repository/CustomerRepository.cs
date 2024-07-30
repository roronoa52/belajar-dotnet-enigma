using ConnectionDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Globalization;

namespace ConnectionDB.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NpgsqlConnection _connection;

        public CustomerRepository(string connection)
        {
            _connection = new NpgsqlConnection(connection);
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> FindAll()
        {
            var customers = new List<Customer>();

            try
            {
                _connection.Open();

                const string sql = "SELECT * FROM m_customers";

                var command = new NpgsqlCommand(sql, _connection);

                var reader = command.ExecuteReader();

                while (reader.Read()) {
                    customers.Add(new Customer
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name = reader["name"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        IsActive = Convert.ToBoolean(reader["is_active"]),
                    });
                
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return customers;
        }

        public Customer? FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void GenerateTable()
        {
            try
            {
                _connection.Open();

                string createTableQuery = @"
                            CREATE TABLE IF NOT EXISTS m_customers (
                                id SERIAL PRIMARY KEY,
                                name VARCHAR(100) NOT NULL,
                                phone_number VARCHAR(100) NOT NULL,
                                is_active BOOLEAN NOT NULL
                            )";

                using (var command = new NpgsqlCommand(createTableQuery, _connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table 'm_customers' created successfully.");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close(); 
            }
        }

        public void Save(Customer customer)
        {
            try
            {
                _connection.Open();

                const string sql = @"INSERT INTO m_customers (id, name, phone_number, is_active) VALUES(@id, @name, @phone_number, 'true')";

                var command = new NpgsqlCommand(sql, _connection);

                command.Parameters.AddWithValue("@id", customer.Id);
                command.Parameters.AddWithValue("@name", customer.Name);
                command.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);

                command.ExecuteNonQuery ();
                Console.WriteLine("Successfully created customer");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
