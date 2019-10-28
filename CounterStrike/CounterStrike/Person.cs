using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike
{
    abstract class Person
    {
        public int number { get; protected set; }
        public int Hp { get; protected set; }
        public int Money { get; protected set; }
        public Gun gun { get; set; }
        public Location location { get; set; }
        public Person(int number)
        {
            this.number = number;
            Money = 800;
            Hp = 100;
        }
        public void TakeDamage(ref int damage)
        {
            if (damage >= Hp)
            {
                damage -= Hp;
                Hp = 0;
            }
            else
            {
                Hp -= damage;
                damage = 0;
            }
        }
        public void AddMoney(int money)
        {
            Money += money;
            if (Money > 16000)
            {
                Money = 16000;
            }
        }
        public void Recover()
        {
            Hp = 100;
        }
        public abstract void Buy(List<Gun> guns);
        public abstract void Move(List<Location> locations);
    }
}
