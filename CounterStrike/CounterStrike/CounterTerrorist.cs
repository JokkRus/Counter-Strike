using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CounterStrike
{
    class CounterTerrorist:Person
    {
        public CounterTerrorist(int number, Location location) : base(number)
        {
            this.location = location;
        }
        public override void Buy(List<Gun> guns)
        {
            bool result = false;
            while (!result)
            {
                int num = new Random().Next(0, guns.Count);
                if (Money >= guns[num].Price)
                {
                    Money -= guns[num].Price;
                    gun = guns[num];
                    result = true;
                }
            }
        }
        public override void Move(List<Location> locations)
        {
            location = locations[new Random().Next(locations.Count)];
        }
    }
}
