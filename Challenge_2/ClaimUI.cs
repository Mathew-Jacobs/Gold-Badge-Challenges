using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    class ClaimUI
    {
        ClaimRepository _claimRepo = new ClaimRepository();
        bool loop = true;

        public void Run()
        {
            var initClaims = new List<Claim>()
            {
                new Claim(1,ClaimTypes.Car,"Crash on 1st",300.00m,_claimRepo.StringToDateTime("7/15/2018"),_claimRepo.StringToDateTime("7/24/2018"),true),
                new Claim(2,ClaimTypes.Home,"Broken window",120.00m,_claimRepo.StringToDateTime("7/03/2018"),_claimRepo.StringToDateTime("7/14/2018"),true),
                new Claim(3,ClaimTypes.Theft,"Cheese stolen",1.00m,_claimRepo.StringToDateTime("6/5/2018"),_claimRepo.StringToDateTime("6/24/2018"),false),
            };
            _claimRepo.AddToClaims(initClaims);

            while (loop)
            {
                string menuInput = ConsoleMenu();
                Queue<Claim> claims = _claimRepo.GetClaims();
                switch (menuInput)
                {
                    case "1":
                        Console.WriteLine($"\r\nClaimID\tType\tDescription\t\tAmount\t\tDateOfAccident\t\tDateOfClaim\t\tIsValid");
                        foreach (Claim claim in claims)
                        {
                            Console.WriteLine(claim);
                        }
                        Console.WriteLine($"\r\n" +
                            $"Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("\r\nHere are the details for the next claim to be handled:\r\n" +
                            "\r\n" +
                            "Claim ID: " + claims.Peek().ClaimID + "\r\n" +
                            "Type: " + claims.Peek().ClaimType + "\r\n" +
                            "Description: " + claims.Peek().Description + "\r\n" +
                            "Ammount: " + claims.Peek().ClaimAmmount + "\r\n" +
                            "Date of Incident: " + claims.Peek().DateOfIncident + "\r\n" +
                            "Date of Claim: " + claims.Peek().DateOfClaim + "\r\n" +
                            "Is this case Valid: " + claims.Peek().IsValid + "\r\n" +
                            "\r\n" +
                            "Do you want to deal with this claim now? (y/n)");
                        System.ConsoleKeyInfo response = Console.ReadKey();
                        Console.Clear();
                        string input = response.KeyChar.ToString();
                        switch (input)
                        {
                            case "y":
                                _claimRepo.RemoveClaim();
                                break;
                            case "n":
                                break;
                            default:
                                Console.WriteLine("Unknown input\r\n" +
                                    "Press any key to return to main menu");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                        }
                        break;
                    case "3":
                        Claim newClaim = NewClaim();
                        _claimRepo.AddToClaims(newClaim);
                        Console.WriteLine($"\r\n" +
                            $"Press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
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
                $"[1] See all claims\r\n" +
                $"[2] Take care of next claim\n" +
                $"[3] Enter a new claim\n" +
                $"[X] Exit\n");
            System.ConsoleKeyInfo input = Console.ReadKey();
            Console.Clear();
            return input.KeyChar.ToString();
        }

        public Claim NewClaim()
        {
            Console.WriteLine("Enter the claim id: ");
            int claimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the claim type:");
            ClaimTypes claimType = StringToClaimType(Console.ReadLine());
            Console.WriteLine("Enter a claim description:");
            string description = Console.ReadLine();
            Console.WriteLine("Amount of Damage:");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Date of Accident:");
            DateTime dateOfAccident = _claimRepo.StringToDateTime(Console.ReadLine());
            Console.WriteLine("Date of Claim:");
            DateTime dateOfClaim = _claimRepo.StringToDateTime(Console.ReadLine());
            if ((dateOfClaim - dateOfAccident).TotalDays <= 30)
            {
                bool isValid = true;
                Console.WriteLine("This claim is valid.");
                Claim newClaim = new Claim(claimID, claimType, description, claimAmount, dateOfAccident, dateOfClaim, isValid);
                return newClaim;
            }
            else
            {
                bool isValid = false;
                Console.WriteLine("This claim is not valid.");
                Claim newClaim = new Claim(claimID, claimType, description, claimAmount, dateOfAccident, dateOfClaim, isValid);
                return newClaim;
            }
        }

        public ClaimTypes StringToClaimType(string claimType)
        {
            ClaimTypes claimTypeFix;
            switch (claimType)
            {
                case "Car":
                    claimTypeFix = ClaimTypes.Car;
                    break;

                case "Home":
                    claimTypeFix = ClaimTypes.Home;
                    break;

                case "Theft":
                    claimTypeFix = ClaimTypes.Theft;
                    break;

                default:
                    claimTypeFix = ClaimTypes.NULL;
                    break;
            }
            return claimTypeFix;
        }
    }
}
