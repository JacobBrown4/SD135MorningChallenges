using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascar_Challenge
{
    // When I wrote the challenge I forgot you can't use numbers so we need another stand in for just "1-6"
    public enum Gear { N, First = 1, Second, Third, Fourth, Fifth, Sixth, R = 10, P = 20 }
    public enum TirePosition { FD = 1, FP, RD, RP }
    public class Car
    {
        private double _fuel;

        public Car()
        {
            Fuel = 10; // Start them with 10 gallons
            FrontDriverTire = new Tire();
            FrontPassengerTire = new Tire();
            RearDriverTire = new Tire();
            RearPassengerTire = new Tire();
        }

        public Car(int number, string make, string model) : this()
        {
            Make = make;
            Model = model;
            Number = number;
        }

        public int Number { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool IsRunning { get; set; }
        public Gear Gear { get; set; }
        public Tire FrontDriverTire { get; set; }
        public Tire FrontPassengerTire { get; set; }
        public Tire RearDriverTire { get; set; }
        public Tire RearPassengerTire { get; set; }
        // I don't want fuel to go below 0 because that's unrealistic, so we'll need to use a backfield so I can assign the value elsewhere.
        public double Fuel
        {
            get { return _fuel; }
            set
            {
                if (value <= 0)
                {
                    _fuel = 0;
                    IsRunning = false;
                }
                else
                {
                    _fuel = value;
                }
            }
        }
        public void TurnOn()
        {
            if (IsRunning)
            {
                Console.WriteLine("The car is already running");
            }
            else if (Fuel > 0)
            {
                Gear = Gear.N;
                IsRunning = true;
                Console.WriteLine("You turn on the car and hear the rumble of the engine");
            }
            else
                Console.WriteLine("There's not enough fuel in the car");
        }
        public void TurnOff()
        {
            if (IsRunning)
            {
                IsRunning = false;
                Gear = Gear.P;
                Console.WriteLine("You turn off the car");
            }
            else
                Console.WriteLine("The car is already turned off");
        }

        public void ShiftUp()
        {
            if (IsRunning)
            {
                if (Gear == Gear.P)
                {
                    Gear = Gear.N;
                    Console.WriteLine("You shift from park to neutral");
                }
                else if (Gear == Gear.R)
                {
                    Gear = Gear.N;
                    Console.WriteLine("You shift from reverse to neutral");
                }
                else if (Gear == Gear.N)
                {
                    Gear = Gear.First;
                    Console.WriteLine("You shift from neutral into First! *vroom vroom*");
                }
                else
                {
                    Gear previous = Gear;
                    Gear++;
                    Console.WriteLine($"You shift up from {previous} into {Gear}");
                }
            }
            else
                Console.WriteLine("Can't shift, the car isn't on!");
        }
        public void ShiftDown()
        {
            if (IsRunning)
            {
                if (Gear == Gear.P)
                {
                    Console.WriteLine("Already in park, can't shift lower");
                }
                else if (Gear == Gear.R)
                {
                    Gear = Gear.P;
                    Console.WriteLine("You shift from reverse to park");
                }
                else if (Gear == Gear.N)
                {
                    Gear = Gear.P;
                    Console.WriteLine("You shift from neutral into park.");
                }
                else
                {
                    Console.WriteLine($"You shift down from {Gear} to {--Gear}");
                }
            }
            else
                Console.WriteLine("Can't shift, the car isn't on!");
        }
        public void Reverse()
        {
            if (IsRunning)
            {
                if (Gear == Gear.First || Gear == Gear.P)
                {
                    Console.WriteLine("You shift into neutral and then reverse");
                    Gear = Gear.R;
                }
                else if (Gear == Gear.N)
                {
                    Console.WriteLine("You shift into reverse");
                    Gear = Gear.R;
                }
                else
                {
                    Console.WriteLine("You need to be in a lower gear to reverse from here");
                }
            }
            else
                Console.WriteLine("Can't shift, the car isn't on!");

        }

        public void ChangeTire(TirePosition position, Tire newTire)
        {
            switch (position)
            {
                case TirePosition.FD:
                    FrontDriverTire = newTire;
                    Console.WriteLine("Putting a new tire on the front driver side *wrench noises*");
                    break;
                case TirePosition.RD:
                    RearDriverTire = newTire;
                    Console.WriteLine("Putting a new tire on the rear driver side *jack noises*");
                    break;
                case TirePosition.FP:
                    FrontPassengerTire = newTire;
                    Console.WriteLine("Putting a new tire on the front passenger side *air tool noises*");
                    break;
                case TirePosition.RP:
                    RearPassengerTire = newTire;
                    Console.WriteLine("Putting a new tire on the rear passenger side * more wrench noises*");
                    break;
            }
        }

        public void Refuel(double fuel)
        {
            Fuel += fuel;
            if (Fuel > 22) // Apparently the cap on a NASCAR
            {
                double loss = Fuel - 22;
                Console.WriteLine($"This tank was overfilled and you lost {loss} gallons of fuel");
                Fuel -= loss;
            }
            else if (Fuel == 22)
                Console.WriteLine("Full tank!");
            else Console.WriteLine($"You now have {Fuel} gallons of fuel");
        }
        public void PitStop(Tire tire1, Tire tire2, Tire tire3, Tire tire4, double fuel)
        {
            if(Fuel == 0)
            {
                Console.WriteLine("You coast to the pit stop with your empty gas tank");
            }
            Console.WriteLine("Shifting down");
            Gear = Gear.N;
            Console.WriteLine($"Adding {fuel} gallons to the fuel tank");
            Refuel(fuel);
            List<Tire> tires = new List<Tire> { tire1, tire2, tire3, tire4 };
            ReplaceAllTires(tires); // Setting all four at once is lame, so I made a helper method to cut down on code
            Console.WriteLine("Leaving the pitstop");
            Gear = Gear.First;
        }
        public void ReplaceAllTires(List<Tire> tires)
        {
            Console.WriteLine("Replacing all tires");
            int interval = 1;
            foreach (Tire tire in tires)
            {
                // Here this is casting, I'm converting the int into the enum which should match a value based on the index. We'll go over this in class
                ChangeTire((TirePosition)interval, new Tire());
                interval++;
            }
        }
        public void Drive(double miles)
        {
            // So just to make it easy, googling, I'm finding most races are 1 mile laps So I'll keep that in mind for my mock numbers.
            if (IsRunning)
            {   // Better make sure you got working tires first
                if (FrontDriverTire.Wear == Wear.Popped || FrontPassengerTire.Wear == Wear.Popped || RearPassengerTire.Wear == Wear.Popped || RearDriverTire.Wear == Wear.Popped)
                {
                    Console.WriteLine("One of your tires is popped, you aren't driving anywhere");
                }
                else
                {
                    if (Gear == Gear.N || Gear == Gear.P)
                    {
                        Console.WriteLine("You're not in a drivable gear");
                    }
                    else
                    {
                        FrontPassengerTire.Miles += miles;
                        FrontDriverTire.Miles += miles;
                        RearDriverTire.Miles += miles;
                        RearPassengerTire.Miles += miles;
                        double fuelConsumption = 0.05;
                        switch (Gear)
                        {
                            case Gear.R:
                            case Gear.First:
                                fuelConsumption = 0.055; // Around 18mpg, reported mpg when coasting
                                break;
                            case Gear.Second:
                                fuelConsumption = 0.085;
                                break;
                            case Gear.Third:
                                fuelConsumption = 0.115;
                                break;
                            case Gear.Fourth:
                                fuelConsumption = 0.145;
                                break;
                            case Gear.Fifth:
                                fuelConsumption = 0.175;
                                break;
                            case Gear.Sixth:
                                fuelConsumption = 0.2; // Around 5mpg, what google told me they do at top speeds, so I just smoothed the fuel consumption between the two 
                                break;

                        }
                        Fuel -= miles * fuelConsumption;
                        Console.WriteLine($"You drove {miles} miles in {Gear} gear");
                    }
                }
            }
            else
                Console.WriteLine("Car's not on...");
        }

        public void Diagnostic()
        {
            Console.WriteLine($"Fuel: {Fuel}\n" +
                $"Gear: {Gear}\n" +
                $"Runnning: {IsRunning}\n" +
                $"FD Tire: {FrontDriverTire.Wear}\n"+
                $"FP Tire: {FrontPassengerTire.Wear}\n"+
                $"RD Tire: {RearDriverTire.Wear}\n"+
                $"RP Tire: {RearPassengerTire.Wear}\n");


        }
        public void Vroom()
        {
            Console.WriteLine("*engine noises*");
        }
    }


    public enum Wear { Good, Ok, Bad, Popped }
    public class Tire
    {
        private double _miles;
        public double Miles
        {  // Prevent negatives
            get { return _miles; }
            set
            {
                if (value < 0)
                {
                    _miles = 0;
                }
                else
                    _miles = value;
            }
        }
        public Wear Wear // Remember this is NASCAR, they use a special tire that needs changed more often. I googled around for a rough estimate
        {
            get
            {
                if (Miles > 130)
                    return Wear.Popped;
                else if (Miles > 100 && Miles <= 130)
                    return Wear.Bad;
                else if (Miles > 70 && Miles <= 100)
                    return Wear.Ok;
                else
                    return Wear.Good;
            }
        }
    }
}
