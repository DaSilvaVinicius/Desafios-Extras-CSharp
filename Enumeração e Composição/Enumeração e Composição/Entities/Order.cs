using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Enumeração_e_Composição.Enums;


namespace Enumeração_e_Composição
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Orders { get; set; } = new List<OrderItem>();

        public Order(OrderStatus status)
        {
            Moment = DateTime.Now;
            Status = status;
        }

        public void AddItem(OrderItem order)
        {
            Orders.Add(order);
        }

        public void RemoveItem(OrderItem order)
        {
            Orders.Remove(order);
        }

        public double Total()
        {
            double total = 0;   
            foreach (OrderItem order in Orders)
            {
                total += order.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (OrderItem order in Orders)           
                sb.AppendLine(order.ToString());
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
