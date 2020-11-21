using System;
using System.Globalization;
using System.Collections.Generic;
using Course.Entities; //Habilitando as classes da pasta Entities.


namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nProduct #{0} data:", i + 1);
                Console.Write("Common, used or imported (c/u/i)?");
                char c = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (c == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    products.Add(new ImportedProduct(name, price, customsFee));
                }

                if (c == 'u')
                {
                    Console.Write("Manufature date: ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    products.Add(new UsedProduct(name, price, date));
                }
                else
                {
                    products.Add(new Product(name, price));
                }
            }
                Console.WriteLine();
                Console.WriteLine("PRICE TAGS:");
                foreach (Product prod in products)
                {
                    Console.WriteLine(prod.PriceTag());
                }
            

            Console.Read();
        }
    }
}
