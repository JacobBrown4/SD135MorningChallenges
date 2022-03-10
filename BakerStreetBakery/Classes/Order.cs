using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerStreetBakery.Classes
{
    public class Order
    {
        public Order(Product product)
        {
            Product = product;
            Batches = 1;
        }
        public Order(Product product, int batches) : this(product)
        {
            Batches = batches;
        }
        public Order(Product product, int batches,int orderNumber):this(product, batches)
        {
            OrderNumber = orderNumber;
        }
        public Order(Product product, int batches,int orderNumber, string customer) : this(product, batches, orderNumber)
        {
            CustomerName = customer;
        }
        public Product Product { get; set; }
        public int Batches { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalCost //Readonly
        {
            get
            {
                decimal initialCost = Product.Price * Batches;
                decimal upcharge = initialCost + 100;
                return upcharge;
            }
        }
    }
}
