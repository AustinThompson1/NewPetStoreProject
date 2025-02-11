using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public interface IProductRepository
    {
        public void AddProductToDb(Product product);
        public Product GetProductById(int productId);
        public List<Product> GetAllProducts();
    }
}
