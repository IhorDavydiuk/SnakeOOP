using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class TheEnd : InformPlayingField, IGameObject, ILoadImages
    {
        int yCoordinate = 0;
        ConsoleImage imageTheEnd { get; set; }
        ConsoleImage imageApple { get; set; }
        public void Load(ConsoleGraphics graphics)
        {
            imageTheEnd = graphics.LoadImage("end.png");
            imageApple = graphics.LoadImage("yy2.png");
            images[0] = graphics.LoadImage("nn0.png");
            images[1] = graphics.LoadImage("nn1.png");
            images[2] = graphics.LoadImage("nn2.png");
            images[3] = graphics.LoadImage("nn3.png");
            images[4] = graphics.LoadImage("nn4.png");
            images[5] = graphics.LoadImage("nn5.png");
            images[6] = graphics.LoadImage("nn6.png");
            images[7] = graphics.LoadImage("nn7.png");
            images[8] = graphics.LoadImage("nn8.png");
            images[9] = graphics.LoadImage("nn9.png");
        }
        public void Render(ConsoleGraphics graphics)
        {
            if (Head.Speed == 0)
            {
                graphics.DrawImage(imageTheEnd, graphics.ClientWidth / 3, yCoordinate);
                renderNumber(graphics, graphics.ClientWidth / 3 + 166, yCoordinate + 3, 10);
                graphics.DrawImage(imageApple, graphics.ClientWidth / 3 + 194, yCoordinate);
                yCoordinate += yCoordinate < graphics.ClientHeight / 2 - 50 ? 1 : 0;
            }
        }
        public void Update(GameEngine engine)
        {
        }
    }
}
