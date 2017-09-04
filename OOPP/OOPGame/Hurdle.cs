using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    abstract public class Hurdle : IGameObject
    {
        protected static ConsoleImage[] images;
        protected int width, height;
        protected Point p1;
        protected Func<Point> xyHead;
        protected bool headWasOnSquare;
        public Hurdle(int weigh, int high, Random r, Func<Point> xyHead)
        {
            this.width = weigh;
            this.height = high;
            this.xyHead = xyHead;
            p1 = new Point(r.Next(1, 400), r.Next(1, 400));
        }
        public virtual void Render(ConsoleGraphics graphics)
        {
        }
        public virtual void Update(GameEngine engine)
        {
        }
        public static void LoadImage(ConsoleGraphics graphics)
        {
            images = new ConsoleImage[]
            {
                graphics.LoadImage("y2.png"),
                graphics.LoadImage("k2.png")
            };
        }
    }
}
