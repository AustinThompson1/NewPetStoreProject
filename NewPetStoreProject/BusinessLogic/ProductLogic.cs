using FluentValidation;
using NewPetStoreProject;
using PetStore.Data;

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
            //_productRepo.AddProduct;

           
        }

        public List<Product> GetAllProducts()
        {

            return _products;


        }
       
        public List<string> GetOnlyInStockProducts()
        {
            return _products
                .Where(x => x.Quantity > 0)
                .Select(x => x.Name)
                .ToList();
        }

        public decimal GetTotalPriceOfInventory()
        {
            return _products
                .InStock()
                .Select(x => x.Price)
                .Sum();
        }
        public Product GetProductById (Int32 id)
        {
            return _productRepo.GetProductById(id);
        }
        //public T GetProductByName<T>(string name) where T : Product
        //{
        //    try
        //    {
        //        if (typeof(T) == typeof(DogLeash))
        //        {
        //            return _dogLeash[name] as T;
        //        }
        //        else if (typeof(T) == typeof(CatFood))
        //        {
        //            return _catFood[name] as T;
        //        }
        //        else
        //        {
                    
        //            return  _products.Find(x => x.Name == name) as T;
        //        }
        //    }
        //    catch (Exception)
        //    { return null; }
        //}
    }
}

