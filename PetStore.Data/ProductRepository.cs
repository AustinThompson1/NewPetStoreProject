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
        public void AddProductToDb(Product product)
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

    }
}
