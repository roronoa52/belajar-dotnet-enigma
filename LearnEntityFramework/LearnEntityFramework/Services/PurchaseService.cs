using LearnEntityFramework.Entities;
using LearnEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEntityFramework.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IRepository<Purchase> repository;
        private readonly IPersistance persistance;
        private readonly IProductService productService;

        public PurchaseService(IRepository<Purchase> repository, IPersistance persistance, IProductService productService)
        {
            this.repository = repository;
            this.persistance = persistance;
            this.productService = productService;
        }

        public Purchase CreateNewTransaction(Purchase purchase)
        {
            persistance.BeginTransaction();

            try
            {
                var newPurchase = repository.Save(purchase);
                persistance.SaveChanges();

                foreach (var item in newPurchase.PurchaseDetails)
                {
                    var product = productService.GetById(item.ProductId.ToString());
                    product.Stock = item.Qty;
                }

                persistance.SaveChanges();

                persistance.Commit();

                return newPurchase;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                persistance.Rollback();
                throw;
            }
        }
    }
}
