using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimQueue = new Queue<Claim>();

        public Queue<Claim> GetClaims()
        {
            return _claimQueue;
        }

        public DateTime StringToDateTime(string MMddyyyy)
        {
            return DateTime.ParseExact(MMddyyyy, "M/d/yyyy", CultureInfo.InvariantCulture);
        }

        public void AddToClaims(Claim claim)
        {
            _claimQueue.Enqueue(claim);
        }

        public void RemoveClaim()
        {
            _claimQueue.Dequeue();
        }

        public Queue<Claim> AddToClaims(List<Claim> claims)
        {
            foreach (Claim claim in claims)
            {
                _claimQueue.Enqueue(claim);
            }
            return _claimQueue;
        }


    }
}
