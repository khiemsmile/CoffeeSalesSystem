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
            new Topping("Milk"),
            new Topping("Whipped Cream")
        };
        var mochaToppings = new List<Topping> {
            new Topping("Caramel")
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