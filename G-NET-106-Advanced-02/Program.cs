namespace G_NET_106_Advanced_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new()
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }

            };

            List<Product> electronics = Product.SearchProducts(catalog, catalog => catalog.Category == "Electronics");
            List<Product> under50 = Product.SearchProducts(catalog, catalog => catalog.Price < 50);
            List<Product> inStock = Product.SearchProducts(catalog, catalog => catalog.Stock > 0);
            List<Product> under100 = Product.SearchProducts(catalog, catalog => catalog.Price < 100);
            
            
            Console.WriteLine("Electronics ");
            Product.PrintProducts(electronics);
            Console.WriteLine("");
            Console.WriteLine("Under $50");
            Product.PrintProducts(under50);
            Console.WriteLine("");
            Console.WriteLine("In Stock");
            Product.PrintProducts(inStock);
            Console.WriteLine("");
            Console.WriteLine("Under 100 ");
            Product.PrintProducts(under100);
            Console.WriteLine("");

            //Custom Report Generator
            Console.WriteLine("short report");
            Product.PrintShortReport(under100);
            Console.WriteLine("");
            Console.WriteLine("Detailed report");
            Product.PrintDetailedReport(under100);
            Console.WriteLine("");


            var priceLabels = Product.TransformProducts(catalog, p => p.Price > 100 ? string.Join(" ", $"{p.Name} : expesive") : string.Join(" ", $"{p.Name} : affordable"));
           
            var summaryList = Product.TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            Console.WriteLine("summary list");
            foreach( var s in summaryList)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("");
            Console.WriteLine("price list");
            foreach(var price in priceLabels)
            {
                Console.WriteLine(price);
            }
            Console.WriteLine();
            Console.WriteLine("----low stock alert---");
            // Filter Products 
            var lowStockFilter = Product.FilterProducts(catalog, p => p.Stock < 20);
            foreach( var s in lowStockFilter)
            {
                Console.WriteLine($"[low stock] {s.Name} : only {s.Stock} left");
            }





        }
    }
}
