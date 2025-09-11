using System.Linq;

namespace chsarp_ana
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }

    public class Store
    {
        public static void Run()
        {
            // PRODUCTS:
            List<Product> products = new List<Product>();

            products.Add(new Product() { Name = "Alfajor", Price = 2500, Stock = 10 });
            products.Add(new Product() { Name = "Revolcón", Price = 500, Stock = 20 });
            products.Add(new Product() { Name = "Barrilete", Price = 400, Stock = 15 });
            products.Add(new Product() { Name = "Galletica", Price = 500, Stock = 30 });

            Console.Clear();

            // TITLE:
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 44));
            Console.WriteLine($"{"ANO'S STORE",27}");
            Console.WriteLine(new string('=', 44));
            Console.ResetColor();

            Console.Write("\x1b[1m");
            Console.WriteLine($"{"#",2}  {"PRODUCTO",-20}{"PRECIO",10}{"CANTIDAD",10}");
            Console.Write("\x1b[0m");

            // PRINTING PRODUCTS:
            int count = 1;

            foreach (var product in products)
            {
                Console.WriteLine($"{count++,2}. {product.Name,-20}${product.Price,9:F2}{product.Stock,10}");
            }
            Console.WriteLine(new string('-', 44));

            // Searching for a product by name
            Console.WriteLine("\nIngrese el nombre del producto a buscar:");
            string productName = Console.ReadLine();
            SearchProduct(products, productName);
            Console.ResetColor();
        }

        // SEARCHING PRODUCTS BY NAME:
        public static void SearchProduct(List<Product> products, string name)
        {
            // Use LINQ to search the product by name
            // it validates that the product name's and the name that write the user be the same it doesn't matter if they have words in mayusc or if they have spaces at the end of the begining.
            var product = products.FirstOrDefault(p => p.Name.Trim().Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Producto encontrado: {product.Name}");
                Console.WriteLine($"Precio: ${product.Price:F2}");
                Console.WriteLine($"Cantidad: {product.Stock}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Producto '{name}' no encontrado.");
                Console.ResetColor();
            }
        }
    }
}
