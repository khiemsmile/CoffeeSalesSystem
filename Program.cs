// See https://aka.ms/new-console-template for more information
using CoffeeSalesSystem;
public class Program
{
    public static void Main()
    {
        var proxyMenu = new MenuServiceProxy();
        proxyMenu.GetDrinks(CustomerType.Loyal);
        proxyMenu.GetToppings(CustomerType.Loyal);

        var cache = new DrinkCache();

        var latteToppings = new List<Topping> {
            new Topping("Milk", 5000),
            new Topping("Whipped Cream", 8000)
        };
        var mochaToppings = new List<Topping> {
            new Topping("Caramel", 10000)
        };

        var drink1 = cache.GetDrink("Latte", latteToppings);
        var drink2 = cache.GetDrink("Mocha", mochaToppings);

        var order = new Order(CustomerType.Loyal);
        order.AddItem(drink1);
        order.AddItem(drink2);

        var processor = new OrderProcessorFacade();
        processor.Process(order);
    }
}