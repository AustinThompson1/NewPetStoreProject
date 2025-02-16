using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPetStoreProject;
using PetStore.Data;

namespace NewPetStoreProject
{
    public interface IProductLogic
    {
        public void AddProduct(Product product);

        public List<Product> GetAllProducts();

        public decimal GetTotalPriceOfInventory();

        public List<string> GetOnlyInStockProducts();

        public Product GetProductById(Int32 ProductId);
        public void AddOrder(Order order);
        public void GetOrder(int Id);
    }
}
