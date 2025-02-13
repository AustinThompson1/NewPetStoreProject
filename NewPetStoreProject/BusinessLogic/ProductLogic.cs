using FluentValidation;
using NewPetStoreProject;
using NewPetStoreProject.Validators;
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
       
        public void AddProduct(Product product)
        {

            var validator = new AddProductValidator();
            if (validator.Validate(product).IsValid)
            {
                _productRepo.AddProduct(product);
            }

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

