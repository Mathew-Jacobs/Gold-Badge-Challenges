using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public class PartyRepository
    { 
        private List<Party> _partyList = new List<Party>();
        private List<Booth> _boothList = new List<Booth>();

        public List<Party> GetParties()
        {
            return _partyList;
        }

        public void AddParty(Party party)
        {
            _partyList.Add(party);
        }

        public void RemoveParty(Party party)
        {
            _partyList.Remove(party);
        }
    }
}
