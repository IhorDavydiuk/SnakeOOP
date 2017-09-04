using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class Apple : Hurdle
    {
        int i;
        public Apple(ConsoleGraphics graphics,  Random r, Func<Point> xyHead) :base (15,15 ,r,xyHead)
        {
        }
        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(images[0],p1.x,p1.y);
        }
        public override void Update(GameEngine engine)
        {
            if (AuxilClass.HeadOnHurdle(xyHead, p1, width, height) && !headWasOnSquare) engine.EatApple(this, true);
            headWasOnSquare = AuxilClass.HeadOnHurdle(xyHead, p1, width, height);
        }
    }
}
