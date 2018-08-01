using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class OutingUI
    {
        OutingRepository _outingRepo = new OutingRepository();
        bool loop = true;

        public void Run()
        {
            var initOuting = new List<Outing>()
            {
                new Outing(EventTypes.Park,30,_outingRepo.StringToDateTime("6/5/2018"),400.00m),
                new Outing(EventTypes.Bowling,12,_outingRepo.StringToDateTime("2/15/2018"),120.00m),
                new Outing(EventTypes.Concert,67,_outingRepo.StringToDateTime("4/20/2018"),700.00m),
                new Outing(EventTypes.Golf,1,_outingRepo.StringToDateTime("12/25/2018"),50.00m)
            };
            _outingRepo.AddOutings(initOuting);

            while (loop)
            {
                string input = ConsoleMenu();
                List<Outing> outings = _outingRepo.GetOutings();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Event Type\t" +
                            "Atendees\t" +
                            "Date\t\t" +
                            "Total Cost\t" +
                            "Cost per Person");
                        foreach (Outing outing in outings)
                        {
                            Console.WriteLine(outing);
                        }
                        break;
                    case "2":
                        Outing _outing = AddOuting();
                        _outingRepo.AddOutings(_outing);
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("What would you like to calculate?\n" +
                            "[1] Total Cost across all outings\n" +
                            "[2] Total Cost of each outing type\n");
                        System.ConsoleKeyInfo key = Console.ReadKey();
                        Console.Clear();
                        string answer = key.KeyChar.ToString();
                        switch (answer)
                        {
                            case "1":
                                decimal total = _outingRepo.TotalCost(outings);
                                Console.WriteLine("The total cost of all outings is: " + total);
                                Console.WriteLine("\nPress any key to continue");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case "2":
                                bool trying = true;
                                EventTypes eventType = new EventTypes();
                                while (trying)
                                {
                                    Console.WriteLine("Select Event Type\n" +
                                        "[1] Golf\n" +
                                        "[2] Bowling\n" +
                                        "[3] Amusement Park\n" +
                                        "[4] Concert\n");
                                    System.ConsoleKeyInfo kep = Console.ReadKey();
                                    Console.Clear();
                                    string response = kep.KeyChar.ToString();
                                    switch (response)
                                    {
                                        case "1":
                                            eventType = EventTypes.Golf;
                                            trying = false;
                                            Console.Clear();
                                            break;
                                        case "2":
                                            eventType = EventTypes.Bowling;
                                            trying = false;
                                            Console.Clear();
                                            break;
                                        case "3":
                                            eventType = EventTypes.Park;
                                            trying = false;
                                            Console.Clear();
                                            break;
                                        case "4":
                                            eventType = EventTypes.Concert;
                                            trying = false;
                                            Console.Clear();
                                            break;
                                        default:
                                            Console.WriteLine("Error: Select defined option");
                                            break;
                                    }
                                }
                                decimal totalt = _outingRepo.TotalCostByType(outings, eventType);
                                Console.WriteLine("The total cost of all " + eventType + " outings is: " + totalt);
                                Console.WriteLine("\nPress any key to continue");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "X":
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public string ConsoleMenu()
        {
            Console.WriteLine($"\r\nSelect an option:\r\n" +
                $"\r\n" +
                $"[1] See all outings\r\n" +
                $"[2] Add another outing to list\n" +
                $"[3] Cost calculations\n" +
                $"[X] Exit\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            return input.KeyChar.ToString();
        }

        public Outing AddOuting()
        {
            EventTypes eventType = new EventTypes();
            bool trying = true;
            while (trying)
            {
                Console.WriteLine("Select Event Type\n" +
                    "[1] Golf\n" +
                    "[2] Bowling\n" +
                    "[3] Amusement Park\n" +
                    "[4] Concert\n");
                System.ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();
                string answer = input.KeyChar.ToString();
                switch (answer)
                {
                    case "1":
                        eventType = EventTypes.Golf;
                        trying = false;
                        Console.Clear();
                        break;
                    case "2":
                        eventType = EventTypes.Bowling;
                        trying = false;
                        Console.Clear();
                        break;
                    case "3":
                        eventType = EventTypes.Park;
                        trying = false;
                        Console.Clear();
                        break;
                    case "4":
                        eventType = EventTypes.Concert;
                        trying = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Error: Select defined option");
                        break;
                }
            }
            Console.WriteLine("Enter the number of atendees:");
            int numPeople = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the date of the outing: (MM/dd/yyyy)");
            DateTime date = _outingRepo.StringToDateTime(Console.ReadLine());
            Console.WriteLine("\nEnter the total cost:");
            decimal totalCost = decimal.Parse(Console.ReadLine());
            Outing outing = new Outing(eventType, numPeople, date, totalCost);
            return outing;
        }
    }
}
