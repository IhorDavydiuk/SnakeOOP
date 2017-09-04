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
            Head head = new Head(graphics, 10, 10, r);
            AddObject(head);
            for (int i = 0; i < 12; i++)
            {
                if (i < 3) AddObject(new Apple(graphics, r, head.GetXY));
                AddObject(new Stone( r, head.GetXY));
            }
        }
    }
}
