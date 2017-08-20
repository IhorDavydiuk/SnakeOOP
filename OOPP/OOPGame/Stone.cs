using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class Stone : Hurdle
    {
        public Stone(ConsoleGraphics graphics,  Random r, Func<Point> xyHead) :base (30,20,r,xyHead)
        {
            int d = graphics.ClientHeight;
            int z = graphics.ClientWidth;
            image = graphics.LoadImage("k2.png");
        }
        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image,p1.x,p1.y);
        }
        public override void Update(GameEngine engine)
        {
            if (AuxilClass.headOnHurdle(xyHead, p1, width, height))
            {
                engine.end = true;
            }
        }
    }
}
