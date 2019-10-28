using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike
{
    class USP:Gun
    {
        public USP(string owner) : base(owner)
        {
            Name = "USP";
            Damage = 20;
            Price = 300;
        }
        public override int Shot(int firstRound)
        {
            Random rand = new Random();
            if (Owner == "Terrorist")
            {
                if (firstRound == 1)
                {
                    return rand.Next(Damage/2, Damage+1);
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
                    return rand.Next(Damage/2, Damage + 1);
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
