using Dapper;
using Npgsql;

namespace LearnDapper;

public class Program
{
    public static void Main(string[] args)
    {
        var connectionString = "Host=localhost;Database=dapper-test;Username=postgres;Password=12345678";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);

        DefaultTypeMap.MatchNamesWithUnderscores = true;

        try
        {

            /*        var createTable = @"
                             CREATE TABLE IF NOT EXISTS m_product
                             (
                                 id SERIAL PRIMARY KEY,
                                 product_name VARCHAR(100),
                                 product_price BIGINT,
                                 stock INT
                             )";*/

            /*var insertTable = " INSERT INTO m_product( product_name, product_price , stock) VALUES ('sepatu1', 1000, 10)";*/

            // menggunakan execute() dapper
            /*connection.Execute(insertTable);*/

            // menggunakan query() dapper
            var sql = "SELECT * FROM m_product";

            var products = connection.Query<Product>(sql).ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }


        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.ToString());
        }
        finally 
        {
            connection.Close();
        };


    }
}