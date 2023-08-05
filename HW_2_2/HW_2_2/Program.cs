namespace HW_2_2
{

    using System;
    using System.Collections.Generic;

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class ShoppingCart
    {
        private List<Product> products = new List<Product>();

        public void AddToCart(Product product)
        {
            products.Add(product);
        }

        public void ClearCart()
        {
            products.Clear();
        }

        public List<Product> GetCartItems()
        {
            return products;
        }
    }

    public class OrderService
    {
        private static int orderNumber = 1;

        public void PlaceOrder(ShoppingCart cart)
        {
            Console.WriteLine("Заказ сформирован:");
            foreach (var product in cart.GetCartItems())
            {
                Console.WriteLine($"- {product.Name}, Цена: {product.Price}");
            }

            Console.WriteLine($"Заказ с номером {orderNumber} оформлен.");
            orderNumber++;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ShoppingCart cart = CreateShoppingCart();

                OrderService orderService = new OrderService();
                orderService.PlaceOrder(cart);

                Console.WriteLine("Хотите сделать еще один заказ? (yes/no)");
                string answer = Console.ReadLine();

                if (answer.ToLower() != "yes")
                    break;
            }

            Console.WriteLine("Спасибо за покупки! Приходите еще.");
        }

        static ShoppingCart CreateShoppingCart()
        {
            ShoppingCart cart = new ShoppingCart();

            while (true)
            {
                Console.WriteLine("Введите название продукта (или 'exit' для завершения):");
                string name = Console.ReadLine();

                if (name.ToLower() == "exit")
                    break;

                Console.WriteLine("Введите цену продукта:");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                Product product = new Product(name, price);
                cart.AddToCart(product);
            }

            return cart;
        }
    }


}