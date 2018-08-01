using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class Badge
    {
        public Badge() { }
        public Badge(int badgeID, List<string> door)
        {
            BadgeID = badgeID;
            Door = door;
        }

        public int BadgeID { get; set; }
        public List<string> Door { get; set; }
    }
}
