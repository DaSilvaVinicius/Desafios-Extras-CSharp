using Enumeração_e_Composição.Enums;
using System.Globalization;

namespace Enumeração_e_Composição
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateOnly birthDate = DateOnly.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            Order order = new Order(status);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string nameOfProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quant = int.Parse(Console.ReadLine());

                Product product = new Product(nameOfProduct, price);

                OrderItem item = new OrderItem(quant, product);
                order.AddItem(item);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine("Order moment: " + DateTime.Now);
            Console.WriteLine("Order status: " + status);
            Console.WriteLine("Client: " + client);
            Console.WriteLine("Order items:");
            Console.WriteLine(order);
        }
    }
}