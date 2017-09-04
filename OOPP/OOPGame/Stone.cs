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
        public Stone(Random r, Func<Point> xyHead) :base (30,20,r,xyHead)
        {
        }
        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(images[1],p1.x,p1.y);
        }
        public override void Update(GameEngine engine)
        {
            if (AuxilClass.HeadOnHurdle(xyHead, p1, width, height))
            {
                engine.end = true;
            }
        }
    }
}
