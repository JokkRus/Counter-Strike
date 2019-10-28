using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CounterStrike
{
    class Team
    {
        public int Score { get; set; }
        public List<Gun> guns;
        public List<Person> persons;
        protected int count;
        public string commandName { get; protected set; }
        public Team()
        {
            Score = 0;
        }
        public void Buy()
        {
            foreach(Person p in persons)
            {
                p.Buy(guns);
                Thread.Sleep(50);
            }
        }
        public void Move(List<Location> locations)
        {
            foreach(Person p in persons)
            {
                p.Move(locations);
                Thread.Sleep(50);
            }
        }
    }
}
