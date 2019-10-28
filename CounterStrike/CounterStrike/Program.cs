using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController controller = new GameController(5,5,16);
            controller.AddLocation();
            while (!controller.EndGame)
            {
                controller.ShowScore();
                controller.StartBuy();
                controller.StartMove();
                controller.StartRound();
                if (!controller.IsEndRound())
                {
                    controller.StartRoundTwo();
                }
                controller.WhoWin();
                Console.ReadLine();
            }
            controller.ShowWinner();
            Console.ReadLine();
        }
    }
}
