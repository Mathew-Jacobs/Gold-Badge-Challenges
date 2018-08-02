using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public class ProgramUI
    {
        private PartyRepository _partyRepo = new PartyRepository();

        public void Run()
        {
            InitParty();
            bool loop = true;
            while (loop)
            {
                string menu = ConsoleMenu();
                switch (menu)
                {
                    case "1":
                        ViewAll();
                        break;
                    case "2":
                        AddNewParty();
                        break;
                    case "3":
                        ViewOne();
                        break;
                    case "4":
                        RemoveAParty();
                        break;
                    case "X":
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void InitParty()
        {
            List<Food> burgfoods = new List<Food>()
            {
                new Food("Burger",2.99m,34),
                new Food("Hotdogs",1.99m,25),
                new Food("Veggie",3.99m,13)
            };
            List<Food> sweetsFood = new List<Food>()
            {
                new Food("Cupcake",1.99m,34),
                new Food("Cookie", 0.99m,25)
            };
            List<Booth> booths = new List<Booth>()
            {
                new Booth("Burger Shack", burgfoods, 0.5m),
                new Booth("Sweet Stuff", sweetsFood, 0.6m)
            };
            Party party = new Party(1001, booths);
            _partyRepo.AddParty(party);
        }

        private string ConsoleMenu()
        {
            Console.WriteLine($"\r\nWhat would you like to do?\r\n" +
                $"\r\n" +
                $"[1] View All Parties\r\n" +
                $"[2] Add New Party\n" +
                $"[3] View Specific Party Data\n" +
                $"[4] Delete Party Data\n" +
                $"[X] Exit\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            return input.KeyChar.ToString();
        }

        private void ViewAll()
        {
            Console.Clear();
            List<Party> parties = _partyRepo.GetParties();
            Console.WriteLine("\nPartyID\t\tBooths\t\tTotal Cost\tTotal Tickets Used\n" +
                "----------------------------------------------------------------------------");

            for (int i = 0; i < parties.Count; i++)
            {
                Console.WriteLine($"{parties[i].PartyID}\t\t-All Booths-\t{parties[i].TotalCost}\t\t{parties[i].TotalTickets}\n");
                foreach (Booth booth in parties[i].Booths)
                {
                    Console.WriteLine($"\t\t{booth.BoothName}\t{booth.TotalCost}\t\t{booth.TotalTickets}");
                }
            Console.WriteLine("----------------------------------------------------------------------------" +
                "\n");
            }
            Console.WriteLine("Press Any Key to Continue:");
            Console.ReadKey();
            Console.Clear();
        }

        private void ViewOne()
        {
            Console.Clear();
            List<Party> parties = _partyRepo.GetParties();
            Console.WriteLine("Enter the party ID:");
            int partyID = int.Parse(Console.ReadLine());
            foreach (Party party in parties)
            {
                if (partyID == party.PartyID)
                {
                    Console.WriteLine("\nPartyID\t\tBooths\t\tTotal Cost\tTotal Tickets Used\n" +
                        "----------------------------------------------------------------------------");
                    Console.WriteLine($"{party.PartyID}\t\t-All Booths-\t{party.TotalCost}\t\t{party.TotalTickets}\n");
                    foreach (Booth booth in party.Booths)
                    {
                        Console.WriteLine($"\t\t{booth.BoothName}\t{booth.TotalCost}\t\t{booth.TotalTickets}");
                    }
                    Console.WriteLine("----------------------------------------------------------------------------" +
                        "\n" +
                        "\nMore Info on Booths");
                    Console.WriteLine("\nBooth Name\tFood\t\tTotal Cost\tTotal Tickets\tTotal Misc Cost\n" +
                        "----------------------------------------------------------------------------");

                    foreach (Booth booth in party.Booths)
                    {
                        Console.WriteLine($"{booth.BoothName}\t-All Food-\t{booth.TotalCost}\t\t{booth.TotalTickets}\t\t{booth.MiscCosts}\n");
                        foreach (Food food in booth.Foods)
                        {
                            Console.WriteLine($"\t\t{food.Name}\t\t{food.TotalCost}\t\t{food.UsedTickets}");
                        }
                        Console.WriteLine("----------------------------------------------------------------------------");
                    }
                    Console.WriteLine("\nPress any key to continue:");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
        }

        private void AddNewParty()
        {
            Console.Clear();
            List<Food> foods = new List<Food>();
            List<Booth> booths = new List<Booth>();
            Console.WriteLine("\nEnter the Party ID:");
            int partyID = int.Parse(Console.ReadLine());
            Console.WriteLine("How many booths does this party have?");
            int boothNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < boothNum; i++)
            {
                Console.WriteLine($"\nName of booth {i+1} of {boothNum}:");
                string boothName = Console.ReadLine();
                Console.WriteLine($"\nHow many menu items does booth {i} have?");
                int foodNum = int.Parse(Console.ReadLine());
                for (int t = 0; t < foodNum; t++)
                {
                    Console.WriteLine($"\nName of food {t+1} of {foodNum}");
                    string foodName = Console.ReadLine();
                    Console.WriteLine($"\nPrice of {foodName}");
                    decimal foodPrice = decimal.Parse(Console.ReadLine());
                    Console.WriteLine($"\nNumber of tickets used on {foodName}");
                    int foodTickets = int.Parse(Console.ReadLine());
                    Food food = new Food(foodName, foodPrice, foodTickets);
                    foods.Add(food);
                }
                Console.WriteLine($"Estimated cost of misc product per person for {boothName}:");
                decimal miscCost = decimal.Parse(Console.ReadLine());
                Booth booth = new Booth(boothName, foods, miscCost);
                booths.Add(booth);
                Console.Clear();
            }
            Party party = new Party(partyID, booths);
            _partyRepo.AddParty(party);
            Console.Clear();
        }

        private void RemoveAParty()
        {
            List<Party> parties = _partyRepo.GetParties();
            Console.WriteLine("Enter the Party ID:");
            int partyID = int.Parse(Console.ReadLine());
            foreach (Party party in parties)
            {
                if (party.PartyID == partyID)
                {
                    _partyRepo.RemoveParty(party);
                }
            }
        }
    }
}
