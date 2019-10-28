using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike
{
    class Terrorist : Person
    {
        public Terrorist(int number, Location location) : base(number)
        {
            this.location = location;
        }
        public override void Move(List<Location> locations)
        {
            bool result = false;
            while (!result)
            {
                Console.Clear();
                Console.WriteLine("Уважаемый Террорист №" + number + "!");
                Console.WriteLine("Выберите локацию: ");
                int i;
                for (i = 0; i < locations.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {locations[i].Name}");
                }
                string input = Console.ReadLine();
                result = int.TryParse(input, out int numb);
                if (result)
                {
                    if (numb > 0 && numb <= locations.Count)
                    {
                        location = locations[numb-1];
                    }
                    else
                    {
                        Console.WriteLine("Такой локации нет.");
                        result = false;
                    }
                }
                else
                {
                    Console.WriteLine("Введите номер!");
                }
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
            }
        }
        public override void Buy(List<Gun> guns)
        {
            bool result = false;
            while (!result)
            {
                Console.Clear();
                Console.WriteLine("Уважаемый Террорист №"+number+"!\t\t\tДеньги: "+Money);
                Console.WriteLine("Напишите номер покупаемого оружия:");
                for(int i = 0; i < guns.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {guns[i].Name} Price: {guns[i].Price}");
                }
                Console.Write("Buy: ");
                string input = Console.ReadLine();
                result = int.TryParse(input, out int numb);
                if (result)
                {
                    if (numb > 0 && numb <= guns.Count)
                    {
                        if (guns[numb - 1].Price <= Money)
                        {
                            Money -= guns[numb - 1].Price;
                            gun = guns[numb - 1];
                        }
                        else
                        {
                            Console.WriteLine("Не хватает денег!");
                            result = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такого номера нет.");
                        result = false;
                    }
                }
                else
                {
                    Console.WriteLine("Введите номер!");
                }
                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
            }
        }
    }
}
