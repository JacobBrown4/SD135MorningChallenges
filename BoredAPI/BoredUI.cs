using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoredAPI
{
    public class BoredUI
    {
        private readonly BoredService _service = new BoredService();
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
                Console.WriteLine("Bored API Console App\n" +
                    "1. Get a random activity\n" +
                    "2. Get an activity by type\n" +
                    "3. Get an activity by participants\n" +
                    "4. Get an activity by price range\n" +
                    "5. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RandomActivity();
                        break;
                    case "2":
                        ActivityByType();
                        break;
                    case "3":
                        ActivityByParticipants();
                        break;
                    case "4":
                        ActivityByPriceRange();
                        break;
                    case "5":
                        runMenu = false;
                        break;

                }
            }
        }
        private void RandomActivity()
        {
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                DisplayActivity(_service.GetRandomActivityAsync().Result);
                Console.WriteLine("Press space for another or any key to exit");
                if (Console.ReadKey().Key != ConsoleKey.Spacebar)
                {
                    repeat = false;
                }
            }
        }
        private void ActivityByType()
        {
            Console.Clear();
            Console.WriteLine("What activity type do you want?");
            //["education", "recreational", "social", "diy", "charity", "cooking", "relaxation", "music", "busywork"]
            Console.WriteLine("1. Education\n" +
                "2. Recreational\n" +
                "3. Social\n" +
                "4. DIY\n" +
                "5. Charity\n" +
                "6. Cooking\n" +
                "7. Relaxation\n" +
                "8. Music\n" +
                "9. Busywork");
            string choice;
            switch (Console.ReadLine())
            {
                case "1":
                    choice = "education";
                    break;
                case "2":
                    choice = "recreational";
                    break;
                case "3":
                    choice = "social";
                    break;
                case "4":
                    choice = "diy";
                    break;
                case "5":
                    choice = "charity";
                    break;
                case "6":
                    choice = "cooking";
                    break;
                case "7":
                    choice = "relaxation";
                    break;
                case "8":
                    choice = "music";
                    break;
                case "9":
                    choice = "busywork";
                    break;
                default:
                    choice = "social";
                    break;
            }
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                DisplayActivity(_service.GetActivityByTypeAsync(choice).Result);
                Console.WriteLine("Press space for another or any key to exit");
                if (Console.ReadKey().Key != ConsoleKey.Spacebar)
                {
                    repeat = false;
                }
            }
        }
        private void ActivityByParticipants()
        {
            Console.Clear();
            Console.Write("How many participants?: ");
            var input = Console.ReadLine();
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                DisplayActivity(_service.GetActivityByParticipantsAsync(input).Result);
                Console.WriteLine("Press space for another or any key to exit");
                if (Console.ReadKey().Key != ConsoleKey.Spacebar)
                {
                    repeat = false;
                }
            }
        }
        private void ActivityByPriceRange()
        {
            Console.Clear();
            Console.Write("Minimum cost: ");
            var min = Console.ReadLine();
            Console.Write("Maximum cost: ");
            var max = Console.ReadLine();
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                DisplayActivity(_service.GetActivityByPriceRangeAsync(min,max).Result);
                Console.WriteLine("Press space for another or any key to exit");
                if (Console.ReadKey().Key != ConsoleKey.Spacebar)
                {
                    repeat = false;
                }
            }
        }
        private void DisplayActivity(Event activity)
        {
            Console.WriteLine($"Activity: {activity.Activity}\n" +
                $"Accessibility: {activity.Accessibility}\n" +
                $"Type: {activity.Type}\n" +
                $"Participants: {activity.Participants}\n" +
                $"Price: {activity.Price.ToString("C")}\n" +
                $"Link: {activity.Link}\n" +
                $"Key: {activity.Key}");
        }
    }
}
