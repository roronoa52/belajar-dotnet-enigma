using LearnEntityFramework.Entities;
using LearnEntityFramework.Repositories;
using LearnEntityFramework.Services;

namespace LearnEntityFramework
{
    public class Program
    {

        static void Main(string[] args)
        {

            AppDbContext appDbContext = new AppDbContext();

            IRepository<Purchase> repository = new Repository<Purchase>(appDbContext);
            IRepository<Product> repositoryProduct = new Repository<Product>(appDbContext);
            IPersistance persistance = new DbPersistence(appDbContext);
            IProductService productService = new ProductService(repositoryProduct, persistance);
            IPurchaseService purchaseService = new PurchaseService(repository,persistance, productService);

            var purchase = new Purchase
            {
                TransDate = DateTime.UtcNow,
                CustomerId = Guid.Parse("07701a1b-c91d-413b-a703-1d7411216be1"),
                PurchaseDetails = new List<PurchaseDetail>
                    {
                        new PurchaseDetail(){ProductId = Guid.Parse("24f14cd6-8348-48fe-9478-c271b85da666"), Qty = 10},
                        new PurchaseDetail(){ProductId = Guid.Parse("4e6cb68a-7c8d-4ee6-b444-c3f92279f83a"), Qty = 10},
                    }
            };

            purchaseService.CreateNewTransaction(purchase);


            /*IRepository<Customer> repository = new Repository<Customer>(appDbContext);
            IRepository<Product> productrepository = new Repository<Product>(appDbContext);

            var transaction = appDbContext.Database.BeginTransaction();
            try
            {
                var purchase = new Purchase
                {
                    TransDate = DateTime.UtcNow,
                    CustomerId = Guid.Parse("07701a1b-c91d-413b-a703-1d7411216be1"),
                    PurchaseDetails = new List<PurchaseDetail>
                    {
                        new PurchaseDetail(){ProductId = Guid.Parse("24f14cd6-8348-48fe-9478-c271b85da666"), Qty = 10},
                        new PurchaseDetail(){ProductId = Guid.Parse("4e6cb68a-7c8d-4ee6-b444-c3f92279f83a"), Qty = 10},
                    }
                };

                appDbContext.Purchases.Add(purchase);
                appDbContext.SaveChanges();

                foreach (var item in purchase.PurchaseDetails)
                {
                    if(item != null)
                    {
                        var product = appDbContext.Products.FirstOrDefault(p => p.Id.Equals(item.ProductId));
                        if (product != null) product.Stock = product.Stock - item.Qty;
                        appDbContext.Products.Update(product);

                    }
                    
                }

                appDbContext.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
            }*/



            /*Customer customer = new Customer()
            {
                CustomerName = "tes1",
                Address = "tes1",
                Email = "tes1",
                MobilePhone = "tes1"
            };

            var ResultCustomer = repository.FindBy(c => c.CustomerName.Equals("tes1"));
            Console.WriteLine(customer.CustomerName);*/


            // Create
            /*            Customer customer = new Customer()
                        {
                            CustomerName = "tes1",
                            Address = "tes1",
                            Email = "tes1",
                            MobilePhone = "tes1"

                        };

                        appDbContext.Customers.Add(customer);
                        appDbContext.SaveChanges();*/

            // Select
            //var customer = appDbContext.Customers.FirstOrDefault(customer => customer.Id.Equals(1));

            // Update
            /*customer.CustomerName = "yp";
            appDbContext.Update(customer);
            appDbContext.SaveChanges();*/

            /*appDbContext.Remove(customer);
            appDbContext.SaveChanges();

            Console.WriteLine($"Customer id =: {customer.Id}, name = {customer.CustomerName}");
*/
        }
    }
}