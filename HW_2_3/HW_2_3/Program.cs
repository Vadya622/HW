namespace HW_2_3
{
    using System;
    using System.Linq;

    // Базовый класс для всех сладостей
    public abstract class Sweet
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }

        public Sweet(string name, double weight, decimal price)
        {
            Name = name;
            Weight = weight;
            Price = price;
        }

        public abstract void Display();
    }

    // Класс для конфет
    public class Candy : Sweet
    {
        public string Flavor { get; set; }

        public Candy(string name, double weight, decimal price, string flavor)
            : base(name, weight, price)
        {
            Flavor = flavor;
        }

        public override void Display()
        {
            Console.WriteLine($"Конфеты \"{Name}\", вес: {Weight} г, цена: {Price} руб, вкус: {Flavor}");
        }
    }

    // Класс для печенья
    public class Cookie : Sweet
    {
        public string Shape { get; set; }

        public Cookie(string name, double weight, decimal price, string shape)
            : base(name, weight, price)
        {
            Shape = shape;
        }

        public override void Display()
        {
            Console.WriteLine($"Печенье \"{Name}\", вес: {Weight} г, цена: {Price} руб, форма: {Shape}");
        }
    }

    // Класс для тортов
    public class Cake : Sweet
    {
        public int Layers { get; set; }

        public Cake(string name, double weight, decimal price, int layers)
            : base(name, weight, price)
        {
            Layers = layers;
        }

        public override void Display()
        {
            Console.WriteLine($"Торт \"{Name}\", вес: {Weight} г, цена: {Price} руб, слои: {Layers}");
        }
    }

    // Класс для подарка
    public class GiftBox
    {
        private Sweet[] sweets;
        private int currentIndex = 0;

        public GiftBox(int size)
        {
            sweets = new Sweet[size];
        }

        public void AddSweet(Sweet sweet)
        {
            if (currentIndex < sweets.Length)
            {
                sweets[currentIndex] = sweet;
                currentIndex++;
            }
            else
            {
                Console.WriteLine("Подарок уже заполнен. Нельзя добавить больше сладостей.");
            }
        }

        public double CalculateTotalWeight()
        {
            return sweets.Sum(sweet => sweet?.Weight ?? 0);
        }

        public void SortByPrice()
        {
            Array.Sort(sweets, (s1, s2) => (s1?.Price ?? 0).CompareTo(s2?.Price ?? 0));
        }

        public void DisplayGiftContents()
        {
            Console.WriteLine("Содержимое подарка:");
            foreach (var sweet in sweets)
            {
                if (sweet != null)
                {
                    sweet.Display();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GiftBox gift = new GiftBox(5);

            Candy candy1 = new Candy("Карамелька", 20, 10, "Фруктовая");
            Candy candy2 = new Candy("Шоколадка", 30, 15, "Шоколадная");
            Cookie cookie1 = new Cookie("Песочное", 40, 8, "Круглое");
            Cake cake1 = new Cake("Тортик", 300, 400, 3);

            gift.AddSweet(candy1);
            gift.AddSweet(candy2);
            gift.AddSweet(cookie1);
            gift.AddSweet(cake1);

            Console.WriteLine($"Общий вес подарка: {gift.CalculateTotalWeight()} г");

            Console.WriteLine("Отсортированный по цене подарок:");
            gift.SortByPrice();
            gift.DisplayGiftContents();
        }
    }

}