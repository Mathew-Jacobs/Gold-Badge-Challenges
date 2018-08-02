using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    public class Premium
    {
        public Premium(Car carData)
        {
            BasePremium = 500.00m;
            CalcPremium = BasePremium + (100.00m * carData.TotalRisk);
        }

        public decimal BasePremium { get; set; }
        public decimal CalcPremium { get; set; }
    }
}
