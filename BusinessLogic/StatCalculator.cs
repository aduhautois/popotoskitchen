using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class StatCalculator
    {
        public static string CalcMyStat(int stack, decimal perc, int userStat)
        {
            string stat = null;

            decimal increment = 0;
            decimal incrementStack = 0;

            increment = userStat * perc;
            incrementStack = increment * stack;
            userStat += (int)(incrementStack);

            stat = userStat.ToString();

            return stat;
        }
    }
}
