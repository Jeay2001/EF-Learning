using EF_Learning.Models;
using EF_Learning.DAL;


namespace EF_Learning
{
    public class Program
    {
        static void Main(string[] args)
        {
            using ContosoPizzaContext contex = new ContosoPizzaContext();

            //Add a new product to the database
            Product VeggieSpecial = new Product()
            {
                Name = "Veggie Special Pizza",
                Price = 9.99M
            };
            contex.Products.Add(VeggieSpecial);

            Product deluxeMeat = new Product()
            {
                Name = "Deluxe Meat Pizza",
                Price = 12.99M
            };
            contex.Products.Add(deluxeMeat);
            contex.SaveChanges();


            var veggieSpecial = contex.Products
                                .Where(p => p.ProductId == 1)
                                .FirstOrDefault();

            //Update the price of the product
            if (veggieSpecial is Product)
            {
                veggieSpecial.Price = 11.99M;
            }

            //Remove the product from the database
            if (veggieSpecial is Product)
            {
                contex.Remove(veggieSpecial);
            }
            contex.SaveChanges();

            var products = from product in contex.Products
                           where product.Price > 10.00M
                           orderby product.Name
                           select product;


            foreach (Product p in products)
            {
                Console.WriteLine($"Id:     {p.ProductId}");
                Console.WriteLine($"Name:   {p.Name}");
                Console.WriteLine($"Price:  {p.Price}");
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}
