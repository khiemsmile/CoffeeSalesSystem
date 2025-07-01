using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSalesSystem
{
    public enum CustomerType
    {
        Normal,
        Loyal
    }
    public interface IMenuService
    {
        List<string> GetDrinks(CustomerType type);
        List<string> GetToppings(CustomerType type);
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

    public class RealMenuService : IMenuService
    {
        public List<string> GetDrinks(CustomerType type)
        {
            var drinks = new List<string> { "Espresso", "Americano", "Latte" };
            if (type == CustomerType.Loyal)
                drinks.AddRange(new[] { "Cappuccino", "Mocha" });
            return drinks;
        }

        public List<string> GetToppings(CustomerType type)
        {
            var toppings = new List<string> { "Milk", "Sugar", "Whipped Cream" };
            if (type == CustomerType.Loyal)
                toppings.AddRange(new[] { "Caramel", "Vanilla" });
            return toppings;
        }
    }

    public class MenuServiceProxy : IMenuService
    {
        private readonly RealMenuService _realMenu = new();
        public List<string> GetDrinks(CustomerType type)
        {
            Console.WriteLine($"[MENU ACCESS] {type} checked drinks.");
            return _realMenu.GetDrinks(type);
        }

        public List<string> GetToppings(CustomerType type)
        {
            Console.WriteLine($"[MENU ACCESS] {type} checked toppings.");
            return _realMenu.GetToppings(type);
        }
    }
}
