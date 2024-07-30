using LearnEntityFramework.Entities;
using LearnEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEntityFramework.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repository;
        private readonly IPersistance persistance;

        public ProductService(IRepository<Product> repository, IPersistance persistance)
        {
            this.repository = repository;
            this.persistance = persistance;
        }

        public Product CreateNewCustomer(Product product)
        {
            try
            {
                var newProduct = repository.Save(product);
                persistance.SaveChanges();
                return newProduct;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Product GetById(string id)
        {
            try
            {
                var product = repository.FindById(Guid.Parse(id));
                if (product is null) throw new Exception("product not found");
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
