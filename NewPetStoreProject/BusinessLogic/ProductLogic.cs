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
        private readonly IOrderRepository _OrderRepo;
        public ProductLogic(IProductRepository ProductRepository, IOrderRepository orderRepo)
        {
            _productRepo = ProductRepository;
            _OrderRepo = orderRepo;
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
        public Product GetProductById(Int32 id)
        {
            return _productRepo.GetProductById(id);
        }
        public void AddOrder(Order order)
        {
            _OrderRepo.AddOrder(order);
        }
        public void GetOrder(int Id)
        {
            _OrderRepo.GetOrder(Id);
        }


    }
}

