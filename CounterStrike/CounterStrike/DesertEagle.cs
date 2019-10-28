using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike
{
    class DesertEagle:Gun
    {
        public DesertEagle(string owner) : base(owner)
        {
            Name = "Desert Eagle";
            Damage = 50;
            Price = 700;
        }
        public override int Shot(int firstRound)
        {
            Random rand = new Random();
            if (Owner == "Terrorist")
            {
                if (firstRound == 1)
                {
                    return rand.Next(0, Damage + 1);
                }
                else
                {
                    return Damage;
                }
            }
            else if (Owner == "Counter-Terrorist")
            {
                if (firstRound == 1)
                {
                    return Damage;
                }
                else
                {
                    return rand.Next(0, Damage + 1);
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
