namespace HW_2_6
{
    using System;
    using System.Collections.Generic;

    public class ElectricalAppliance
    {
        public string Name { get; set; }
        public int Power { get; set; }

        public ElectricalAppliance(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }

    public class Fridge : ElectricalAppliance
    {
        public int FreezerPower { get; set; }

        public Fridge(string name, int power, int freezerPower) : base(name, power)
        {
            FreezerPower = freezerPower;
        }
    }

    public static class ElectricalApplianceExtensions
    {
        public static ElectricalAppliance[] SortByPower(this ElectricalAppliance[] appliances)
        {
            Array.Sort(appliances, (a, b) => a.Power.CompareTo(b.Power));
            return appliances;
        }

        public static ElectricalAppliance[] FindByPowerRange(this ElectricalAppliance[] appliances, int minPower, int maxPower)
        {
            List<ElectricalAppliance> foundAppliances = new List<ElectricalAppliance>();
            foreach (var appliance in appliances)
            {
                if (appliance.Power >= minPower && appliance.Power <= maxPower)
                {
                    foundAppliances.Add(appliance);
                }
            }
            return foundAppliances.ToArray();
        }
    }

    public class Apartment
    {
        private ElectricalAppliance[] Appliances { get; }

        public Apartment(ElectricalAppliance[] appliances)
        {
            Appliances = appliances;
        }

        public int CalculateTotalPower()
        {
            int totalPower = 0;
            foreach (var appliance in Appliances)
            {
                totalPower += appliance.Power;
            }
            return totalPower;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Создание объектов электроприборов
            ElectricalAppliance fridge = new Fridge("Холодильник", 200, 100);
            ElectricalAppliance tv = new ElectricalAppliance("Телевизор", 150);
            ElectricalAppliance kettle = new ElectricalAppliance("Чайник", 1800);

            // Создание массива с электроприборами в квартире
            ElectricalAppliance[] appliances = { fridge, tv, kettle };
            Apartment apartment = new Apartment(appliances);

            // Рассчет потребляемой мощности
            int totalPower = apartment.CalculateTotalPower();
            Console.WriteLine($"Потребляемая мощность в квартире: {totalPower} Вт");

            // Сортировка и поиск устройств по параметрам
            ElectricalAppliance[] sortedByPower = appliances.SortByPower();
            ElectricalAppliance[] foundByPowerRange = appliances.FindByPowerRange(150, 250);
        }
    }

}