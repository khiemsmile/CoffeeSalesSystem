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

        var drink1 = cache.GetDrink(new Milk(new Sugar(new Cappuccino())));
        var drink2 = cache.GetDrink(new WhippedCream(new Milk(new Latte())));
        var drink3 = cache.GetDrink(new WhippedCream(new Milk(new Latte())));
        var order = new Order(CustomerType.Loyal);
        order.AddItem(drink1);
        order.AddItem(drink2);
        order.AddItem(drink3);

        var processor = new OrderProcessorFacade();
        processor.Process(order);
    }
}