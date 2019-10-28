using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike
{
    abstract class Gun
    {
        public int Damage { get; protected set; }
        public int Price { get; protected set; }
        public string Owner { get; protected set; }
        public string Name { get; protected set; }
        public Gun(string owner)
        {
            Owner = owner;
        }
        public abstract int Shot(int round);
    }
}
