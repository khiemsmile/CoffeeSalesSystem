using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSalesSystem
{
    public class Order
    {
        public List<IDrink> Items { get; } = new();
        public CustomerType CustomerType { get; }

        public Order(CustomerType type)
        {
            CustomerType = type;
        }

        public void AddItem(IDrink drink)
        {
            Items.Add(drink);
        }
    }

    public class OrderProcessorFacade
    {
        private readonly PaymentService _payment = new();
        private readonly DiscountService _discount = new();

        public void Process(Order order)
        {
            int total = order.Items.Sum(i => i.GetPrice());
            int finalAmount = _discount.ApplyDiscount(total, order.CustomerType);

            Console.WriteLine("=== Chi tiết đơn hàng ===");
            foreach (var item in order.Items)
            {
                Console.WriteLine($"- {item.GetDescription()} - {item.GetPrice():N0} VND");
            }

            Console.WriteLine($"Tổng: {total:N0} VND");
            Console.WriteLine($"Sau giảm giá: {finalAmount:N0} VND");
            _payment.Pay(finalAmount);
        }
    }

    public class PaymentService
    {
        public void Pay(int amount)
        {
            Console.WriteLine($"Đã thanh toán {amount:N0} VND thành công!");
        }
    }

    public class DiscountService
    {
        public int ApplyDiscount(int total, CustomerType type)
        {
            if (type == CustomerType.Loyal)
                return (int)(total * 0.9);
            return total;
        }
    }
}
