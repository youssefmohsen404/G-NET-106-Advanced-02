using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace G_NET_106_Advanced_02
{
    internal class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }


       

        public static List<Product> SearchProducts(List<Product> products , Func<Product , bool> filter)
        {   
            List<Product> newProducts = new List<Product>();
            foreach( Product p in products)
            {
                if (filter(p))
                {
                    newProducts.Add(p);
                }               
            }
            return newProducts;

        }
        public static void PrintProducts(List<Product> products) {
            foreach (Product p in products) {
                Console.WriteLine(p);
                
            }
        
        }

        //Custom Report Generator
        public static void PrintShortReport(List<Product> products)
        {
            foreach (Product p in products) {

                Console.WriteLine(string.Join("-" , p.Name , p.Price));
            }

        }
        public static void PrintDetailedReport(List<Product> products) {
            foreach (Product p in products)
            {
                Console.WriteLine(string.Join("|", $"[{p.Category}]", p.Name, $"price:{p.Price} ", $"stock:{p.Stock} "));

            }
            
        }
        public static List<string> TransformProducts(List<Product> products , Func<Product , string> transform)
        {
            List<string> newProducts = new();
            foreach (Product p in products) {
                newProducts.Add(transform(p));
            
            }
            return newProducts;
        }

        public static List<Product> FilterProducts(List<Product> products , Predicate<Product> cond){
            List<Product> newProducts = new();
            foreach (Product p in products) {
                if (cond(p)) {  newProducts.Add(p); 
                
                }
            
            }
            return newProducts;


        }
        public override string ToString() {
            return $"Id : {Id} , Name : {Name} , category : {Category}  , price : {Price}  , stock : {Stock}";
        
        
        }
        

    }
}
