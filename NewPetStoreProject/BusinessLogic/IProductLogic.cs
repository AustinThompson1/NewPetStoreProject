using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewPetStoreProject;

namespace NewPetStoreProject
{
    public interface IProductLogic
    {
        public void AddProduct(Product product);

        public List<Product> GetAllProducts();

        //public DogLeash GetDogLeashByName(string Name);

        public decimal GetTotalPriceOfInventory();

        public List<string> GetOnlyInStockProducts();

        //public T GetProductByName<T>(string name) where T : Product;
    }
}
