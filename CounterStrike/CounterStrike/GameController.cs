using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CounterStrike
{
    class GameController
    {
        bool[] locStatus;
        Team T, CT;
        public bool isTDead, isCTDead;
        List<Location> locations = new List<Location>();
        public bool EndGame
        {
            get
            {
                return T.Score == RoundsCount || CT.Score == RoundsCount;
            }
        }
        public int Round { get; private set; }
        public int RoundsCount { get; private set; }
        public GameController(int Tcount, int CTcount, int rounds)
        {
            RoundsCount = rounds;
            Round = 1;
            locations.Add(new Location("TSpawn"));
            locations.Add(new Location("CTSpawn"));
            T = new CommandT(Tcount, locations[0]);
            CT = new CommandCT(CTcount, locations[1]);
        }
        public void AddLocation()
        {
            Console.Clear();
            Console.WriteLine("Напишите название локации для добавления.");
            Console.WriteLine("Для завершения добавления напишите 'Выход'");
            string location = Console.ReadLine();
            if (location != "Выход")
            {
                if (location != "")
                {
                    locations.Add(new Location(location));
                }
                AddLocation();
            }
        }
        public void ShowScore()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("Для начала раунда нажмите Enter...");
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("====================================================================");
            Console.WriteLine($"{T.commandName}: {T.Score}\t\t\t\t\t{CT.commandName}: {CT.Score}");
            Console.ReadLine();
        }
        public void StartBuy()
        {
            T.Buy();
            CT.Buy();
        }
        public void StartMove()
        {
            T.Move(locations);
            CT.Move(locations);
        }
        public void StartRound()
        {
            locStatus = new bool[locations.Count];
            bool status = false;
            while (!status)
            {
                Console.Clear();
                Console.WriteLine("Round: " + Round);
                Console.WriteLine();
                for (int i = 0; i < locations.Count; i++)
                {
                    Console.WriteLine(locations[i].Name + ":");
                    foreach (Person p in T.persons)
                    {
                        if (p.location == locations[i])
                        {
                            Console.WriteLine($"{T.commandName} № {p.number} | Gun: {p.gun.Name} | Hp: {p.Hp}");
                        }
                    }
                    foreach (Person p in CT.persons)
                    {
                        if (p.location == locations[i])
                        {
                            Console.WriteLine($"{CT.commandName} № {p.number} | Gun: {p.gun.Name} | Hp: {p.Hp}");
                        }
                    }
                }
                Apocalypsis();
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                for (int i = 0; i < locStatus.Length; i++)
                {
                    status = true;
                    if (locStatus[i] == false)
                    {
                        status = false;
                        break;
                    }
                }
            }
            Console.WriteLine("Для продолжения нажмите Enter...");
            Console.ReadLine();
        }
        void Apocalypsis()
        {
            for (int i = 0; i < locations.Count; i++)
            {
                List<Person> t = new List<Person>();
                List<Person> ct = new List<Person>();
                int Tdamage = 0, CTdamage = 0;
                foreach (Person p in T.persons)
                {
                    if (p.location == locations[i] && p.Hp > 0)
                    {
                        Thread.Sleep(40);
                        Tdamage += p.gun.Shot(Round);
                        t.Add(p);
                    }
                }
                foreach (Person p in CT.persons)
                {
                    if (p.location == locations[i] && p.Hp > 0)
                    {
                        Thread.Sleep(40);
                        CTdamage += p.gun.Shot(Round);
                        ct.Add(p);
                    }
                }
                if (Tdamage == 0 || CTdamage == 0)
                {
                    locStatus[i] = true;
                }
                foreach (Person p in t)
                {
                    if (p.location == locations[i])
                    {
                        p.TakeDamage(ref CTdamage);
                    }
                }
                foreach (Person p in ct)
                {
                    if (p.location == locations[i])
                    {
                        p.TakeDamage(ref Tdamage);
                    }
                }
            }
        }
        public bool IsEndRound()
        {
            isTDead = true;
            isCTDead = true;
            foreach (Person p in T.persons)
            {
                if (p.Hp > 0)
                {
                    isTDead = false;
                }
            }
            foreach (Person p in CT.persons)
            {
                if (p.Hp > 0)
                {
                    isCTDead = false;
                }
            }
            return isTDead || isCTDead;
        }
        public void StartRoundTwo()
        {
            Round = 2;
            while (!IsEndRound())
            {
                Console.Clear();
                Console.WriteLine("Round: " + Round);
                Console.WriteLine();
                foreach(Person p in T.persons)
                {
                    p.location = locations[0];
                    Console.WriteLine($"{T.commandName} № {p.number} | Gun: {p.gun.Name} | Hp: {p.Hp}");
                }
                foreach (Person p in CT.persons)
                {
                    p.location = locations[0];
                    Console.WriteLine($"{CT.commandName} № {p.number} | Gun: {p.gun.Name} | Hp: {p.Hp}");
                }
                Apocalypsis();
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);

            }
        }
        public void WhoWin()
        {
            Console.Write("Победила команда ");
            if (isTDead)
            {
                Console.WriteLine(CT.commandName);
                CT.Score++;
            }
            else
            {
                Console.WriteLine(T.commandName);
                T.Score++;
            }
            TakeMoney();
            Recover();
        }
        void TakeMoney()
        {
            foreach(Person p in T.persons)
            {
                if (!isTDead)
                {
                    p.AddMoney(1400);
                }
                else
                {
                    p.AddMoney(1000);
                }
            }
            foreach (Person p in CT.persons)
            {
                if (!isCTDead)
                {
                    p.AddMoney(1400);
                }
                else
                {
                    p.AddMoney(1000);
                }
            }
        }
        void Recover()
        {
            foreach(Person p in T.persons)
            {
                p.Recover();
            }
            foreach (Person p in CT.persons)
            {
                p.Recover();
            }
        }
        public void ShowWinner()
        {
            Console.Clear();
            Console.Write("Поздравляем команда ");
            if (T.Score > 15)
            {
                Console.Write(T.commandName);
            }
            else
            {
                Console.Write(CT.commandName);
            }
            Console.Write("!\nВы одолели врага!");
        }
    }
}
