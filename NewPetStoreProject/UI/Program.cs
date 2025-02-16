using System.Text.Json;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using PetStore.Data;


namespace NewPetStoreProject
{
    class Program
    {


        static void Main(string[] args)
        {
            var services = CreateServiceCollection();
            var productLogic = services.GetService<IProductLogic>();

            Console.WriteLine("Press 1 to add a product.\nPress 2 to view all products.\nPress 3 to view all in stock products.\nPress 4 to get total inventory price\nPress 5 to get Product by ID\nPress 6 to add an order\nType 'exit' to quit.");
            string userInput = Console.ReadLine();


            while (userInput.ToLower() != "exit")
            {
                if (userInput.ToLower() == "1")
                {

                    Console.WriteLine("Please enter Product in JSON format. For example { \"Price\": 58.89, \"Name\": \"Special dog leash\", \"Quantity\": 23, \"Description\": \"Magical leash that will help your dog not pull hard when going on walks\", \"Material\": \"Classified\", \"LengthInches\": 12 }");
                    var input = Console.ReadLine();
                    var product = JsonSerializer.Deserialize<Product>(input);
                    productLogic.AddProduct(product);
                    Console.WriteLine("Product was added.");
                }
                else if (userInput == "2")
                {
                    List<Product> listOfProducts = productLogic.GetAllProducts();
                    foreach (var item in listOfProducts)
                    {
                        Console.WriteLine(item.Name);
                    }
                }

                else if (userInput.ToLower() == "3")
                {
                    Console.WriteLine("The following items are in stock:");
                    var inStock = productLogic.GetOnlyInStockProducts();
                    foreach (var item in inStock)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadLine();
                }
                else if (userInput.ToLower() == "4")
                {
                    Console.WriteLine($"The total inventory price:{productLogic.GetTotalPriceOfInventory()}");

                    Console.ReadLine();
                }
                else if (userInput.ToLower() == "5")
                {
                    Console.WriteLine("What is the ID of your product?");
                    int id = int.Parse(Console.ReadLine());
                    productLogic.GetProductById(id);
                    Console.ReadLine();
                }
                else if (userInput.ToLower() == "6")
                {

                    Console.WriteLine("Please enter Order in JSON format. For example { \"Products\": [ {\"ProductId\": 2, \"Name\": \"Dog bowl\", \"Description\": \"A thing that holds food\", \"Price\": 8.99}, {\"ProductId\": 2, \"Name\": \"Chew toy\", \"Description\": \"A thing that dogs chew\", \"Price\": 2.89} }");
                    var input = Console.ReadLine();
                    var order = JsonSerializer.Deserialize<Order>(input);
                    productLogic.AddOrder(order);
                    Console.WriteLine("Order was added.");

                }
                else if (userInput.ToLower() == "7")
                {
                    Console.WriteLine("What is the ID of your order?");
                    int id = int.Parse(Console.ReadLine());
                    productLogic.GetOrder(id);
                    Console.ReadLine();
                }


                Console.WriteLine("Press 1 to add a product.\nPress 2 to view all products.\nPress 3 to view all in stock products.\nPress 4 to get total inventory price\nPress 5 to get Product by ID\nPress 6 to add an order\nType 'exit' to quit.");
                userInput = Console.ReadLine();
            }



        }
        static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
                .AddTransient<IProductLogic, ProductLogic>()
                .AddTransient<IProductRepository, ProductRepository>()
                .BuildServiceProvider();
        }
    }
}


