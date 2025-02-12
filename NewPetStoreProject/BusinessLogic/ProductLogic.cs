using FluentValidation;
using NewPetStoreProject;
using PetStore.Data;
using System.ComponentModel.DataAnnotations;

namespace NewPetStoreProject
{
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _productRepo;
        public ProductLogic(IProductRepository ProductRepository)
        {
            _productRepo = ProductRepository;
        }
        //private List<Product> _products = new List<Product>();

        //public Dictionary<string, DogLeash> _dogLeash = new Dictionary<string, DogLeash>();
        //public Dictionary<string, CatFood> _catFood = new Dictionary<string, CatFood>();
        /// <summary>
        /// Adds product to correct dictionary and list.
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            
            
                _productRepo.AddProduct(product);


        }

        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        public List<string> GetOnlyInStockProducts()
        {
            return _productRepo.GetOnlyInStockProducts();
        }

        public decimal GetTotalPriceOfInventory()
        {
            return _productRepo.GetTotalPriceOfInventory();
        }
        public Product GetProductById (Int32 id)
        {
            return _productRepo.GetProductById(id);
        }
       
    }
}

