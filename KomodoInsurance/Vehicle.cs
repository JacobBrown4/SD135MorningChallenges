using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class SUV : IVehicle
    {
        public SUV() { }
        public SUV (string make,string model, string color)
        {
            Make = make;
            Model = model;
            Color = color;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool IsRunning { get; private set; }
        public void Drive()
        {
            if (IsRunning)
                Console.WriteLine("You drive your SUV.");
            else
                Console.WriteLine("You need to turn on the SUV first");
        }

        public void TurnOff()
        {
            if (IsRunning)
            {
                Console.WriteLine("You turn off your SUV");
                IsRunning = false;
            }
            else
                Console.WriteLine("The SUV is already off");
        }

        public void TurnOn()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                Console.WriteLine("You turn on your SUV");
            }
            else
                Console.WriteLine("Your SUV is already off");
                
        }
    }
    public class Motorcyle : IVehicle
    {
        public Motorcyle() { }
        public Motorcyle(string make, string model, string color)
        {
            Make = make;
            Model = model;
            Color = color;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool IsRunning { get; private set; }
        public void Drive()
        {
            if (IsRunning)
                Console.WriteLine("You drive your motorcycle.");
            else
                Console.WriteLine("You need to turn on the bike first");
        }

        public void TurnOff()
        {
            if (IsRunning)
            {
                IsRunning = false;
                Console.WriteLine("You turn off your motorcycle");
            }
            else
                Console.WriteLine("The motorcycle is already off");
        }

        public void TurnOn()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                Console.WriteLine("You turn on your motorcycle");
            }
            else
                Console.WriteLine("Your motorcycle is already off");

        }
    }
    public class Sedan : IVehicle
    {
        public Sedan() { }
        public Sedan(string make, string model, string color)
        {
            Make = make;
            Model = model;
            Color = color;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool IsRunning { get; private set; }
        public void Drive()
        {
            if (IsRunning)
                Console.WriteLine($"You drive your {GetType().Name.ToLower()}."); // You drive your Sedan.
            else
                Console.WriteLine($"You need to turn on the {GetType().Name.ToLower()} first");
        }

        public void TurnOff()
        {
            if (IsRunning)
            {
                IsRunning = false;
                Console.WriteLine($"You turn off your {GetType().Name.ToLower()}");
            }
            else
                Console.WriteLine($"The {GetType().Name.ToLower()} is already off");
        }

        public void TurnOn()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                Console.WriteLine($"You turn on your {GetType().Name.ToLower()}");
            }
            else
                Console.WriteLine($"Your {GetType().Name.ToLower()} is already off");

        }
    }
}
