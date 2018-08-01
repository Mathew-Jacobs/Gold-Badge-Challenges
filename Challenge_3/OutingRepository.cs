using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        private List<Outing> _outings = new List<Outing>();

        public List<Outing> GetOutings()
        {
            return _outings;
        }

        public void AddOutings(Outing outing)
        {
            _outings.Add(outing);
        }

        public void AddOutings(List<Outing> outings)
        {
            foreach (Outing outing in outings)
            {
                _outings.Add(outing);
            }
        }

        public decimal TotalCost(List<Outing> outings)
        {
            decimal total = new decimal();
            foreach (Outing outing in outings)
            {
                total += outing.TotalCost;
            }
            return total;
        }

        public decimal TotalCostByType(List<Outing> outings, EventTypes eventType)
        {
            decimal total = new decimal();
            foreach (Outing outing in outings)
            {
                if (outing.EventType == eventType)
                {
                    total += outing.TotalCost;
                }
            }
            return total;
        }

        public DateTime StringToDateTime(string MMddyyyy)
        {
            return DateTime.ParseExact(MMddyyyy, "M/d/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
