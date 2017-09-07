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
            image = graphics.LoadImage("fonj.jpg");
            Head head = new Head(graphics, 10, 10, r);
            AddObject(head);
            for (int i = 0; i < 12; i++)
            {
                AddObject(new Stone(r, head,30,20));
                if (i < 3) AddObject(new Apple(graphics, r, head,15,15));
                if (i == 11)
                {
                    AddObject(new TheEnd());
                    AddObject(new Number(graphics, 10, 10) { Head = head });
                }
            }
            foreach (ILoadImages objWithPic in objects.Where(q => q is ILoadImages).ToArray())
            {
                objWithPic.Load(graphics);
            }
            Apple.Load(graphics);
            Body.Load(graphics);
        }
        public IEnumerable<PartOfBody> GetObjects()
        {
            return objects.OfType<PartOfBody>();
        }
    }
}
