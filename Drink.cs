using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoffeeSalesSystem
{
    public interface IDrink
    {
        string GetDescription();
        int GetPrice();
    }

    public class Latte : IDrink
    {
        public string GetDescription() => "Latte";
        public int GetPrice() => MenuPrices.BaseDrinkPrices["Latte"];
    }

    public class Espresso : IDrink
    {
        public string GetDescription() => "Espresso";
        public int GetPrice() => MenuPrices.BaseDrinkPrices["Espresso"];
    }

    public class Mocha : IDrink
    {
        public string GetDescription() => "Mocha";
        public int GetPrice() => MenuPrices.BaseDrinkPrices["Espresso"];
    }

    public class Cappuccino : IDrink
    {
        public string GetDescription() => "Cappuccino";
        public int GetPrice() => MenuPrices.BaseDrinkPrices["Espresso"];
    }
    public class Americano : IDrink
    {
        public string GetDescription() => "Americano";
        public int GetPrice() => MenuPrices.BaseDrinkPrices["Espresso"];
    }

    public abstract class ToppingDecorator : IDrink
    {
        protected IDrink coffee;

        public ToppingDecorator(IDrink coffee)
        {
            this.coffee = coffee;
        }

        public abstract string GetDescription();
        public abstract int GetPrice();
    }

    public class Milk : ToppingDecorator
    {
        public Milk(IDrink coffee) : base(coffee) { }
        public override string GetDescription() => coffee.GetDescription() + ", Milk";
        public override int GetPrice() => coffee.GetPrice() + MenuPrices.ToppingPrices["Milk"];
    }

    public class WhippedCream : ToppingDecorator
    {
        public WhippedCream(IDrink coffee) : base(coffee) { }
        public override string GetDescription() => coffee.GetDescription() + ", Whipped Cream";
        public override int GetPrice() => coffee.GetPrice() + MenuPrices.ToppingPrices["Whipped Cream"];
    }

    public class Caramel : ToppingDecorator
    {
        public Caramel(IDrink coffee) : base(coffee) { }
        public override string GetDescription() => coffee.GetDescription() + ", Caramel";
        public override int GetPrice() => coffee.GetPrice() + MenuPrices.ToppingPrices["Caramel"];
    }

    public class Sugar : ToppingDecorator
    {
        public Sugar(IDrink coffee) : base(coffee) { }
        public override string GetDescription() => coffee.GetDescription() + ", Sugar";
        public override int GetPrice() => coffee.GetPrice() + MenuPrices.ToppingPrices["Sugar"];
    }
    public class Vanilla : ToppingDecorator
    {
        public Vanilla(IDrink coffee) : base(coffee) { }
        public override string GetDescription() => coffee.GetDescription() + ", Vanilla";
        public override int GetPrice() => coffee.GetPrice() + MenuPrices.ToppingPrices["Vanilla"];
    }


    public class DrinkCache
    {
        private Dictionary<string, IDrink> _drinkCache = new();

        public IDrink GetDrink(IDrink drink)
        {
            string key = drink.GetDescription();

            if (!_drinkCache.ContainsKey(key))
            {
                _drinkCache[key] = drink;
                Console.WriteLine($"[CACHE MISS] Tạo mới và lưu: {key}");
            }
            else
            {
                Console.WriteLine($"[CACHE HIT] Dùng lại: {key}");
            }

            return _drinkCache[key];
        }
    }

}
