using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class BadgeUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();
        bool loop = true;

        public void Run()
        {
            while (loop)
            {
                int badgeID;
                string input = ConsoleMenu();
                Dictionary<int, List<string>> badges = _badgeRepo.GetBadges();
                switch (input)
                {
                    case "1":
                        bool y = true;
                        List<string> doorValue = new List<string>();
                        Console.WriteLine("\nWhat is the number on the badge:");
                        badgeID = int.Parse(Console.ReadLine());
                        while (y)
                        {
                            Console.WriteLine("\nList a door that it needs access to:");
                            doorValue.Add(Console.ReadLine());
                            bool looping = true;
                            while (looping)
                            {
                                Console.WriteLine("\nAny other doors(y/n)?");
                                System.ConsoleKeyInfo ans = Console.ReadKey();
                                string answer = ans.KeyChar.ToString();
                                switch (answer)
                                {
                                    case "y":
                                        looping = false;
                                        y = true;
                                        Console.Clear();
                                        break;
                                    case "n":
                                        looping = false;
                                        y = false;
                                        Badge badge = new Badge(badgeID, doorValue);
                                        _badgeRepo.NewBadge(badge);
                                        Console.Clear();
                                        break;
                                    default:
                                        looping = true;
                                        Console.Clear();
                                        break;
                                }
                            }

                        }
                        break;
                    case "2":
                        Console.WriteLine("\nWhat is the badge number to update?");
                        badgeID = int.Parse(Console.ReadLine());

                        if (badges.Keys.Contains(badgeID))
                        {
                            bool t = true;
                            while (t)
                            {
                                Console.WriteLine($"\nBadge number {badgeID} has acsess to doors: ");
                                badges[badgeID].ForEach(i => Console.Write("\t{0}", i));
                                Console.WriteLine("\n\nWhat would you like to do?\n" +
                                    "[1] Remove a door\n" +
                                    "[2] Add a door\n" +
                                    "[3] Cancel\n");
                                System.ConsoleKeyInfo pushed = Console.ReadKey();
                                string push = pushed.KeyChar.ToString();
                                switch (push)
                                {
                                    case "1":
                                        t = false;
                                        Console.WriteLine("\nWhich door would you like to remove?");
                                        string remove = Console.ReadLine();
                                        badges[badgeID].Remove(remove);
                                        Console.Clear();
                                        break;
                                    case "2":
                                        t = false;
                                        Console.WriteLine("\nWhich door would you like to add?");
                                        string add = Console.ReadLine();
                                        badges[badgeID].Add(add);
                                        Console.Clear();
                                        break;
                                    case "3":
                                        t = false;
                                        Console.Clear();
                                        break;
                                    default:
                                        Console.Clear();
                                        break;
                                }
                            }
                            break;
                        }
                        break;

                    case "3":

                        Console.WriteLine("\nBadge#\t\tDoorAccess\n");
                        foreach (int id in badges.Keys)
                        {
                            string listDoor = "";
                            foreach (string door in badges[id])
                            {
                                listDoor += door + "\t";
                            }
                            Console.WriteLine($"{id}\t\t{listDoor}");
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
            Console.WriteLine($"\r\nHello Security Admin, What would you like to do?\r\n" +
                $"\r\n" +
                $"[1] Add new Badge\r\n" +
                $"[2] Edit existing Badge\n" +
                $"[3] View all Badges\n" +
                $"[X] Exit\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            return input.KeyChar.ToString();
        }
    }


}
