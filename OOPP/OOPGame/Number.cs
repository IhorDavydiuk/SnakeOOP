using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class Number : InformPlayingField, IGameObject, ILoadImages
    {
        int clientWidth;
        Point p1;
        public Head Head { get; set; }
        bool isLeftCorner;
        public Number(ConsoleGraphics graphics, int x, int y)
        {
            isLeftCorner = true;
            clientWidth = graphics.ClientWidth;
            p1.X = x;
            p1.Y = y;
        }
        public void Load(ConsoleGraphics graphics)
        {
            images[0] = graphics.LoadImage("n0.png");
            images[1] = graphics.LoadImage("n1.png");
            images[2] = graphics.LoadImage("n2.png");
            images[3] = graphics.LoadImage("n3.png");
            images[4] = graphics.LoadImage("n4.png");
            images[5] = graphics.LoadImage("n5.png");
            images[6] = graphics.LoadImage("n6.png");
            images[7] = graphics.LoadImage("n7.png");
            images[8] = graphics.LoadImage("n8.png");
            images[9] = graphics.LoadImage("n9.png");
        }
        public void Render(ConsoleGraphics graphics)
        {
            renderNumber(graphics, p1.X, p1.Y, 7);
        }
        public void Update(GameEngine engine)
        {
            if (AuxilClass.HeadOnHurdle(Head, p1, 20, 15))
            {
                p1.X = isLeftCorner ? clientWidth - p1.X - 20 : p1.X;
                isLeftCorner = !isLeftCorner;
            }
            numberOfApplesEaten = ((SnakeGameEngine)engine).GetObjects().OfType<Body>().Count();
        }
    }
}
