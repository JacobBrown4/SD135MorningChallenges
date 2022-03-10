using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerStreetBakery.Classes
{
    public class OrderRepository
    {
        protected readonly List<Order> _orders = new List<Order>();

        public bool AddOrderToDirectory(Order order)
        {
            int startingCount = _orders.Count();
            if (!OrderNumberAlreadyExist(order.OrderNumber))
            {
                _orders.Add(order);
            }
            bool wasAdded = (_orders.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        public bool OrderNumberAlreadyExist(int id)
        {
            foreach (var existingOrders in _orders)
            {
                if (existingOrders.OrderNumber == id)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }
        public Order GetOrderByOrderNumber(int id)
        {
            foreach (var order in _orders)
            {
                if (order.OrderNumber == id)
                {
                    return order;
                }
            }
            return null;
        }
        public bool RemoveOrder(Order order)
        {
            bool result = _orders.Remove(order);
            return result;
        }
        public bool RemoveOrderById(int id)
        {
            var order = GetOrderByOrderNumber(id);
            if (order != null)
            {
                bool deleteResult = _orders.Remove(order);
                return deleteResult;
            }
            else
                return false;
        }

    }
}
