using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    public class SnakeGameEngine : GameEngine
    {
        public SnakeGameEngine(ConsoleGraphics graphics)
           : base(graphics)
        {
            Hurdle.LoadImage(graphics);
            PartOfBody.LoadImage(graphics);
            AddObject(new Head(graphics, 10, 10, r));
            for (int i = 0; i < 12; i++)
            {
                if (i < 3) AddObject(new Apple(graphics, r, DataXYHead));
                AddObject(new Stone(graphics, r, DataXYHead));
            }
        }
    }
}
