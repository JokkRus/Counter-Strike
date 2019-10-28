using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike
{
    class CommandCT : Team
    {
        public CommandCT(int count, Location baseLocation)
        {
            commandName = "Counter-Terrorist";
            persons = new List<Person>();
            guns = new List<Gun>();
            guns.Add(new USP(commandName));
            guns.Add(new DesertEagle(commandName));
            this.count = count;
            for (int i = 0; i < count; i++)
            {
                persons.Add(new CounterTerrorist(i+1, baseLocation));
            }
        }
    }
}
