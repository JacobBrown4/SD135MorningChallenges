using BakerStreetBakery.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerStreetBakery
{
    public class ProgramUI
    {
        private readonly OrderRepository _repo = new OrderRepository();
        public void Run()
        {
            Seed();
            Menu();
        }

        private void Menu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("1. See all orders\n" +
                    "2. See an order\n" +
                    "3. Add an order\n" +
                    "4. Remove an order\n" +
                    "5. See revenue\n" +
                    "6. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        SeeAllOrders();
                        break;
                    case "2":
                        SeeAnOrder();
                        break;
                    case "3":
                        AddAnOrder();
                        break;
                    case "4":
                        RemoveAnOrder();
                        break;
                    case "5":
                        SeeAllRevenue();
                        break;
                    case "6":
                    case "exit":
                    case "e":
                        runMenu = false;
                        break;
                }
            }
        }


        private void AddAnOrder()
        {
            Console.Clear();
            Order order;
            // Product
            Console.WriteLine("Which Product are you ordering?\n" +
                "1. Bread\n" +
                "2. Cake\n" +
                "3. Pastry\n" +
                "4. Pies\n" +
                "5. Donut");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "1":
                case "bread":
                default:
                    order = new Order(new Bread());
                    break;
                case "2": // else if (input == "2" || input == "cake")
                case "cake":
                    order = new Order(new Cake());
                    break;
                case "3":
                case "pastry":
                    order = new Order(new Pastry());
                    break;
                case "4":
                case "pies":
                    order = new Order(new Pies());
                    break;
                case "5":
                case "donut":
                    order = new Order(new Donut());
                    break;
            }
            // Batches
            Console.Write("How many?: ");
            string batch = Console.ReadLine();
            if (batch != "" || batch != "0")
            {
                order.Batches = Convert.ToInt32(batch);
            }
            else
                order.Batches = 1;

            // CustomerName
            Console.Write("Customer name: ");
            string customer = Console.ReadLine();
            order.CustomerName = customer;

            // OrderNumber
            bool orderIdGood = false;
            while (!orderIdGood)
            {
                Console.Write("Order Number: ");
                int orderNumber = int.Parse(Console.ReadLine());
                if (!_repo.OrderNumberAlreadyExist(orderNumber))
                {
                    orderIdGood = true;
                    order.OrderNumber = orderNumber;
                    if (_repo.AddOrderToDirectory(order))
                    {
                        Console.WriteLine("Order successfully added!");
                    }
                    else
                    {
                        Console.WriteLine("Order not added, something went wrong.");
                    }
                }
                else
                {
                    Console.WriteLine("Order number already exists, try again.");
                }
            }

            AnyKey();

        }

        private void SeeAllOrders()
        {
            Console.Clear();
            DisplayOrderList();
            AnyKey();
        }
        private void SeeAnOrder()
        {
            Console.Clear();
            DisplayOrderList();
            Console.Write("What order do you want to view?\n" +
                "OrderNumber: ");
            var order = _repo.GetOrderByOrderNumber(int.Parse(Console.ReadLine()));
            Console.Clear();
            DisplayOrderDetail(order);
            AnyKey();
        }
        private void SeeAllRevenue()
        {
            Console.Clear();
            decimal revenue = 0;
            List<Order> orders = _repo.GetOrders();
            foreach (Order order in orders)
            {
                revenue += order.TotalCost;
            }
            Console.WriteLine($"Revenue: {revenue:C}\n" +
                $"From {orders.Count()} orders.");
            AnyKey();
        }

        private void RemoveAnOrder()
        {
            Console.Clear();
            DisplayOrderList();
            Console.WriteLine("Please enter the order number of the order you'd like to delete");
            Console.Write("Order Number: ");
            if (_repo.RemoveOrderById(int.Parse(Console.ReadLine())))
            {
                Console.WriteLine("Successfully deleted!");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            AnyKey();

        }
        private void DisplayOrderList()
        {
            List<Order> orders = _repo.GetOrders();
            foreach (Order order in orders)
            {
                Console.WriteLine($"Order Number: {order.OrderNumber}\n" +
                    $"Order: {order.Product.GetType().Name} x {order.Batches} batches\n");
            }
        }
        private void DisplayOrderListDetailed()
        {
            List<Order> orders = _repo.GetOrders();
            foreach(Order order in orders)
            {
                DisplayOrderDetail(order);
            }
        }
        private void DisplayOrderDetail(Order order)
        {
            Console.WriteLine($"Order Number: {order.OrderNumber}\n" +
                $"Product: {order.Product.GetType().Name}\n" +
                $"Batches: {order.Batches}\n" +
                $"Total Cost: {order.TotalCost:C}\n" +
                $"Customer: {order.CustomerName}\n");
        }
        private void AnyKey()
        {
            Console.WriteLine("Press anykey to continue");
            Console.ReadKey();
        }
        private void Seed()
        {
            var order1 = new Order(new Bread(), 1, 1001, "John Bender");
            var order2 = new Order(new Pastry(), 3, 1020, "Billy Zoidberg");
            var order3 = new Order(new Donut(), 10, 1200, "Homer Castellaneta");
            _repo.AddOrderToDirectory(order1);
            _repo.AddOrderToDirectory(order2);
            _repo.AddOrderToDirectory(order3);
        }
    }
}
