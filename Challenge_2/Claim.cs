using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public enum ClaimTypes
    {
        Car, Home, Theft, NULL
    }
    public class Claim
    {
        public Claim(int claimID, ClaimTypes claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

        public int ClaimID { get; set; }
        public ClaimTypes ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public override string ToString()
        {
            return $"{ClaimID}\t{ClaimType}\t{Description}\t\t{ClaimAmmount}\t\t{DateOfIncident.Month}/{DateOfIncident.Day}/{DateOfIncident.Year}\t\t{DateOfClaim.Month}/{DateOfClaim.Day}/{DateOfClaim.Year}\t\t{IsValid}";
        }
    }
}
