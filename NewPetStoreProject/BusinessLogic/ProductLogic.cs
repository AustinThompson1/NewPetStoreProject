using FluentValidation;
using NewPetStoreProject;

namespace NewPetStoreProject
{
    public class ProductLogic : IProductLogic
    {

        private List<Product> _products = new List<Product>();

        public Dictionary<string, DogLeash> _dogLeash = new Dictionary<string, DogLeash>();
        public Dictionary<string, CatFood> _catFood = new Dictionary<string, CatFood>();
        /// <summary>
        /// Adds product to correct dictionary and list.
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {


            if (product is DogLeash)
            {
                DogLeashValidator validator = new DogLeashValidator();
                if (validator.Validate(product as DogLeash).IsValid)
                {
                    _products.Add(product);
                    _dogLeash.Add(product.Name, product as DogLeash);
                }
                else
                {
                    throw new ValidationException("DogLeash Is Not Valid!");
                }


            }
            else if (product is CatFood)
            {
                _products.Add(product);
                _catFood.Add(product.Name, product as CatFood);

            }
            else
            {
                Console.WriteLine("Invalid Product, Product was not added.");
            }
        }

        public List<Product> GetAllProducts()
        {

            return _products;


        }
        

        //public DogLeash GetDogLeashByName(string Name)
        //{
        //    try
        //    {
        //        return _dogLeash[Name];
        //    }
        //    catch (NullReferenceException)
        //    {
        //        Console.WriteLine("Invalid DogLeashName");
        //        return null;
        //    }
        //}
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
    }
}

