using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerStreetBakery
{
    public class ProgramUI
    {
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool runMenu = true;
            while (runMenu)
            {
                Console.Clear();
                Console.WriteLine("1. See all orders\n" +
                    "2. Add an order\n" +
                    "3. Remove an order\n" +
                    "4. See revenue\n" +
                    "5. Exit");
               
                switch (Console.ReadLine())
                {
                    case "1":
                        // SeeAllOrders();
                        break;
                    case "2":
                        // AddAnOrder();
                        break;
                    case "3":
                        // RemoveAnOrder();
                        break;
                    case "4":
                        // SeeAllRevenue();
                        break;
                    case "5":
                    case "exit":
                    case "e":
                        runMenu = false;
                        break;
                }
            }
        }

    }
}
