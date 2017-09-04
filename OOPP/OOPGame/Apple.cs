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
        Random r;
        ConsoleGraphics graphics;
        public static bool IsEaten { get; set; }
        public Apple(ConsoleGraphics graphics,  Random r, Func<Point> xyHead) :base (15,15 ,r,xyHead)
        {
            this.graphics = graphics;
            this.r = r;
        }
        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(images[0],p1.x,p1.y);
        }
        public override void Update(GameEngine engine)
        {
            if (AuxilClass.HeadOnHurdle(xyHead, p1, width, height) && !headWasOnSquare)
            {
                IsEaten = true;
                engine.RemApple(this);
                engine.AddObject(new Apple(graphics, r, xyHead));
            }
            headWasOnSquare = AuxilClass.HeadOnHurdle(xyHead, p1, width, height);
        }
    }
}
