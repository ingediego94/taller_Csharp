using System.Linq;
using System.Runtime.Intrinsics.Arm;

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
        private static List<string> historyProducts = new List<string>();
        private static List<double> historyTotals = new List<double>();
        public static void Run()
        {
            // PRODUCTS:
            List<Product> products = new List<Product>();

            products.Add(new Product() { Name = "Alfajor", Price = 2500, Stock = 55 });
            products.Add(new Product() { Name = "Revolcón", Price = 1500, Stock = 25 });
            products.Add(new Product() { Name = "Sandwich", Price = 21000, Stock = 17 });
            products.Add(new Product() { Name = "Trident", Price = 700, Stock = 40 });

            //Console.Clear();

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
            PrintingProducts(products);
        }

        
        // PRINTING PRODUCTS:
        public static void PrintingProducts(List<Product> products_x)
        {
            int count = 1;

            foreach (var product in products_x)
            {
                Console.WriteLine($"{count++,2}. {product.Name,-20}${product.Price,9:F2}{product.Stock,10}");
            }
            Console.WriteLine(new string('-', 44));

            Searching(products_x);
        }

        public static void Searching(List<Product> products_x)
        {
            // Searching for a product by name
            Console.WriteLine("\nIngrese el nombre del producto a buscar:");
            string productName = Console.ReadLine();
            SearchProduct(products_x, productName);
            Console.ResetColor();
        }
        
        // DISCOUNT:
        public static void Discount()
        {
            
        }
        
        // SEARCHING PRODUCTS BY NAME AND BUYING PROCESS:
        public static void SearchProduct(List<Product> products, string name)
        {
            string response = "no";
            // while (response == "si")
            // {
            //     
            // }// Use LINQ to search the product by name
            // it validates that the product name's and the name that write the user be the same it doesn't matter if they have words in mayusc or if they have spaces at the end of the begining.
            var product = products.FirstOrDefault(p => p.Name.Trim().Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));
            double subtotal = 0;
            
            if (product != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Producto encontrado: {product.Name}");
                Console.WriteLine($"Precio: ${product.Price:F2}");
                Console.WriteLine($"Cantidad: {product.Stock}");
                
                // ----------
                Console.WriteLine("Cuantas unidades desea? ");
                int units = Convert.ToInt32(Console.ReadLine());

                if (units > 0 && units <= product.Stock)
                {
                    product.Stock -= units;
                    subtotal += units * product.Price;
                    historyProducts.Add(product.Name);
                    historyTotals.Add(subtotal);
                    Console.WriteLine($"Total: $ {subtotal}");
                    Console.WriteLine($"Quedan {product.Stock} de {product.Name}(es). ");
                    Console.Write("\nDeseas seguir comprando? ");
                    response = Console.ReadLine().ToLower().Trim();
                    if (response != "si") return;
                    
                    Searching(products);
                } 
                else if (units > product.Stock)
                    Console.WriteLine("Su pedido excede la cantidad de stock actual. Intente de nuevo.");
                else
                    Console.WriteLine("La cantidad solicitada es cero o un número negativo. Revisa e intenta de nuevo.");

                
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Producto '{name}' no encontrado.");
                Console.ResetColor();
            }

            Console.WriteLine($"El historial de compra es: {string.Join(", ",historyProducts)}"); 
            Console.WriteLine($"El total de la compra es: {historyTotals.Sum()}"); 
            
            // DISCOUNT:
            
            
            
        }
    }
}
