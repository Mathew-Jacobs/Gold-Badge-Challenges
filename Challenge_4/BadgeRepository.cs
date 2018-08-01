using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgePairs = new Dictionary<int, List<string>>();


        public void NewBadge(Badge badge)
        {
            _badgePairs.Add(badge.BadgeID, badge.Door);
        }

        public void NewBadge(List<Badge> badges)
        {
            foreach (Badge badge in badges)
            {
                _badgePairs.Add(badge.BadgeID, badge.Door);
            }
        }

        public Dictionary<int, List<string>> GetBadges()
        {
            return _badgePairs;
        }
    }
}
