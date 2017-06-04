using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTracker.WpfApplication
{
    public class DieRoller
    {
        private static DieRoller _instance;
        public static DieRoller Instance
        {
            get
            {
                if (_instance == null) _instance = new DieRoller();
                return _instance;
            }
        }

        private readonly Random _random;

        private DieRoller()
        {
            _random = new Random();
        }

        public int Roll(int count, int sides, int modifier)
        {
            var total = 0;
            for (var i = 0; i < count; i++)
            {
                total += _random.Next(sides) + 1;
            }
            total += modifier;
            return total;
        }
    }
}
