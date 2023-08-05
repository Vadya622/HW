namespace HW_2_4
{
    using System;
    using System.Linq;

    // Базовый класс для всех овощей
    public abstract class Vegetable
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Calories { get; set; }

        public Vegetable(string name, double weight, int calories)
        {
            Name = name;
            Weight = weight;
            Calories = calories;
        }

        public abstract void Display();
    }

    // Класс для корнеплодов
    public class RootVegetable : Vegetable
    {
        public string Color { get; set; }

        public RootVegetable(string name, double weight, int calories, string color)
            : base(name, weight, calories)
        {
            Color = color;
        }

        public override void Display()
        {
            Console.WriteLine($"Корнеплод \"{Name}\", вес: {Weight} г, калорий: {Calories}, цвет: {Color}");
        }
    }

    // Класс для листовых овощей
    public class LeafyVegetable : Vegetable
    {
        public string LeafType { get; set; }

        public LeafyVegetable(string name, double weight, int calories, string leafType)
            : base(name, weight, calories)
        {
            LeafType = leafType;
        }

        public override void Display()
        {
            Console.WriteLine($"Листовой овощ \"{Name}\", вес: {Weight} г, калорий: {Calories}, тип листьев: {LeafType}");
        }
    }

    // Класс для плодовых овощей
    public class FruitVegetable : Vegetable
    {
        public string FruitType { get; set; }

        public FruitVegetable(string name, double weight, int calories, string fruitType)
            : base(name, weight, calories)
        {
            FruitType = fruitType;
        }

        public override void Display()
        {
            Console.WriteLine($"Плодовый овощ \"{Name}\", вес: {Weight} г, калорий: {Calories}, тип плода: {FruitType}");
        }
    }

    // Класс для салата
    public class Salad
    {
        private Vegetable[] vegetables;
        private int currentIndex = 0;

        public Salad(int size)
        {
            vegetables = new Vegetable[size];
        }

        public void AddVegetable(Vegetable vegetable)
        {
            if (currentIndex < vegetables.Length)
            {
                vegetables[currentIndex] = vegetable;
                currentIndex++;
            }
            else
            {
                Console.WriteLine("Салат уже заполнен. Нельзя добавить больше овощей.");
            }
        }

        public int CalculateTotalCalories()
        {
            return vegetables.Sum(vegetable => vegetable?.Calories ?? 0);
        }

        public void SortByWeight()
        {
            Array.Sort(vegetables, (v1, v2) => (v1?.Weight ?? 0).CompareTo(v2?.Weight ?? 0));
        }

        public void DisplaySaladContents()
        {
            Console.WriteLine("Содержимое салата:");
            foreach (var vegetable in vegetables)
            {
                if (vegetable != null)
                {
                    vegetable.Display();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Salad salad = new Salad(5);

            RootVegetable carrot = new RootVegetable("Морковь", 100, 35, "Оранжевый");
            LeafyVegetable lettuce = new LeafyVegetable("Салат", 50, 10, "Листовой");
            FruitVegetable tomato = new FruitVegetable("Помидор", 70, 20, "Плодовой");

            salad.AddVegetable(carrot);
            salad.AddVegetable(lettuce);
            salad.AddVegetable(tomato);

            Console.WriteLine($"Общее количество калорий в салате: {salad.CalculateTotalCalories()}");

            Console.WriteLine("Отсортированный по весу салат:");
            salad.SortByWeight();
            salad.DisplaySaladContents();
        }
    }


}