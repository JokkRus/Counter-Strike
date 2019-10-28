using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike
{
    class Location
    {
        public string Name { get; private set; }
        public Location(string name)
        {
            Name = name;
        }
    }
}
