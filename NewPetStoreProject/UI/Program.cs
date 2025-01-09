using System.ComponentModel;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace NewPetStoreProject
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var services = CreateServiceCollection();
            var productLogic = services.GetService<IProductLogic>();

            productLogic.AddProduct(new DogLeash() { Name = "Cool Dog Leash", Price = 2.99m, Description = "Super Durable", Quantity = 1 });
            productLogic.AddProduct(new DogLeash() { Name = "Dope Dog Leash", Price = 5.99m, Description = "It's Dope!", Quantity = 10 });
            productLogic.AddProduct(new DogLeash() { Name = "Superb Dog Leash", Price = 0.99m, Description = "It's the best", Quantity = 5 });


            Console.WriteLine("Press 1 to add a product.\nPress 2 to view all products.\nPress 3 to view a DogLeash by name.\nPress 4 to view all in stock products.\nPress 5 to get total inventory price\nType 'exit' to quit.");
            string userInput = Console.ReadLine();


            while (userInput.ToLower() != "exit")
            {
                if (userInput.ToLower() == "1")
                {
                    Console.WriteLine("Would you like to add a DogLeash or CatFood?");
                    string addProductInput = Console.ReadLine();
                    if (addProductInput.Contains("Dog"))
                    {
                        Console.WriteLine("Adding DogLeash");
                        Console.WriteLine("Please enter DogLeash in JSON format. For example { \"Price\": 58.89, \"Name\": \"Special dog leash\", \"Quantity\": 23, \"Description\": \"Magical leash that will help your dog not pull hard when going on walks\", \"Material\": \"Classified\", \"LengthInches\": 12 }");
                        var input = Console.ReadLine();
                        var dogLeash = JsonSerializer.Deserialize<DogLeash>(input);
                        productLogic.AddProduct(dogLeash);
                        //var DogLeash = new DogLeash();
                        //DogLeash.Name = Console.ReadLine();
                        //Console.WriteLine("How many would you like to create?");
                        //DogLeash.Quantity = int.Parse(Console.ReadLine());
                        //Console.WriteLine("What is the price");
                        //DogLeash.Price = decimal.Parse(Console.ReadLine());
                        //Console.WriteLine("What is the length in inches?");
                        //DogLeash.LengthInInches = int.Parse(Console.ReadLine());
                        //productLogic.AddProduct(DogLeash);
                        Console.WriteLine("DogLeash was added.");

                    }
                    else if (addProductInput.Contains("Cat"))
                    {
                        Console.WriteLine("Adding CatFood");
                        Console.WriteLine("Please enter CatFood in JSON format. For example { \"Price\": 58.89, \"Name\": \"Special dog leash\", \"Quantity\": 23, \"Description\": \"Magical leash that will help your dog not pull hard when going on walks\", \"Material\": \"Classified\", \"LengthInches\": 12 }");
                        var input = Console.ReadLine();
                        var catFood = JsonSerializer.Deserialize<CatFood>(input);
                        productLogic.AddProduct(catFood);
                        //Console.WriteLine("What is the name of the CatFood?");
                        //var CatFood = new CatFood();
                        //CatFood.Name = Console.ReadLine();
                        //Console.WriteLine("How many would you like to create?");
                        //CatFood.Quantity = int.Parse(Console.ReadLine());
                        //Console.WriteLine("What is the price");
                        //CatFood.Price = decimal.Parse(Console.ReadLine());
                        //Console.WriteLine("What is the weight in pounds?");
                        //CatFood.WeightPounds = double.Parse(Console.ReadLine());
                        //productLogic.AddProduct(CatFood);
                        Console.WriteLine("CatFood was added.");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input");
                        Environment.Exit(0);
                    }
                }
                else if (userInput == "2")
                {
                    List<Product> listOfProducts = productLogic.GetAllProducts();
                    foreach (var item in listOfProducts)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Enter the name of the Product you would like to view");
                    string productName = Console.ReadLine();
                    Product product = productLogic.GetProductByName(productName);
                    if (product != null)
                    {
                        Console.WriteLine(JsonSerializer.Serialize(product));
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Name");
                    }
                }
                else if (userInput.ToLower() == "4")
                {
                    Console.WriteLine("The following items are in stock:");
                    var inStock = productLogic.GetOnlyInStockProducts();
                    foreach (var item in inStock)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadLine();
                }
                else if (userInput.ToLower() == "5")
                {
                    Console.WriteLine($"The total inventory price:{productLogic.GetTotalPriceOfInventory()}");

                    Console.ReadLine();
                }

                Console.WriteLine("Press 1 to add a product.\nPress 2 to view all products.\nPress 3 to view a DogLeash by name.\nPress 4 to view all in stock products.\nPress 5 to get total inventory price.\nType 'exit' to quit.");
                userInput = Console.ReadLine();
            }



        }
       static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
                .AddTransient<IProductLogic,ProductLogic>()
                .BuildServiceProvider();
        }
    }
}


