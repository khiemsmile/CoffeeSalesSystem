using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSalesSystem
{
    public interface IDrink
    {
        string GetDescription();
        int GetPrice();
    }

    public class Coffee : IDrink
    {
        public string Name { get; }
        public int BasePrice { get; }
        public List<Topping> Toppings { get; } = new();

        public Coffee(string name, int price)
        {
            Name = name;
            BasePrice = price;
        }

        public void AddTopping(Topping topping)
        {
            Toppings.Add(topping);
        }

        public string GetDescription()
        {
            if (!Toppings.Any()) return Name;
            return $"{Name} with {string.Join(", ", Toppings.Select(t => t.Name))}";
        }

        public int GetPrice()
        {
            return BasePrice + Toppings.Sum(t => t.Price);
        }
    }

    public class Topping
    {
        public string Name { get; }
        public int Price { get; }

        public Topping(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    public class DrinkCache
    {
        private Dictionary<string, IDrink> _drinkCache = new();

        public IDrink GetDrink(string baseName, List<Topping> toppings)
        {
            string key = baseName + "-" + string.Join("+", toppings.Select(t => t.Name));
            if (!_drinkCache.ContainsKey(key))
            {
                var coffee = new Coffee(baseName, MenuPrices.BaseDrinkPrices[baseName]);
                foreach (var t in toppings)
                    coffee.AddTopping(t);
                _drinkCache[key] = coffee;
            }
            return _drinkCache[key];
        }
    }

    public static class MenuPrices
    {
        public static Dictionary<string, int> BaseDrinkPrices = new()
        {
            {"Espresso", 25000},
            {"Americano", 30000},
            {"Latte", 35000},
            {"Cappuccino", 40000},
            {"Mocha", 45000}
        };

        public static Dictionary<string, int> ToppingPrices = new()
        {
            {"Milk", 5000},
            {"Sugar", 2000},
            {"Whipped Cream", 8000},
            {"Caramel", 10000},
            {"Vanilla", 8000}
        };
    }

}
