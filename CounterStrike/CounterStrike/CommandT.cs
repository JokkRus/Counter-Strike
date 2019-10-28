using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike
{
    class CommandT : Team
    {
        public CommandT(int count, Location baseLocation)
        {
            commandName = "Terrorist";
            persons = new List<Person>();
            guns = new List<Gun>();
            guns.Add(new Glock(commandName));
            guns.Add(new DesertEagle(commandName));
            this.count = count;
            for(int i = 0; i < count; i++)
            {
                persons.Add(new Terrorist(i+1, baseLocation));
            }
        }
    }
}
