using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbcontext;
        public ProductRepository()
        {
            _dbcontext = new ProductContext();
        }
        public void AddProduct(Product product)
        {
            _dbcontext.Products.Add(product);
            _dbcontext.SaveChanges();
        }
        public Product GetProductById(int productId)
        {
            return _dbcontext.Products.SingleOrDefault(x => x.ProductId == productId);
        }
        public List<Product> GetAllProducts()
        {
            return _dbcontext.Products.ToList();
        }
        public List<string> GetOnlyInStockProducts()
        {
            return _dbcontext.Products
                .Where(x => x.Quantity > 0)
                .Select(x => x.Name)
                .ToList();
        }
        public decimal GetTotalPriceOfInventory()
        {
            return _dbcontext.Products
                .Where(x => x.Quantity > 0)
                .Select(x => x.Price)
                .Sum();
        }
    }
}
