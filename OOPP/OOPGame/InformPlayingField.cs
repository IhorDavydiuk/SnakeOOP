using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    abstract class InformPlayingField
    {
        protected static int numberOfApplesEaten;
        protected ConsoleImage[] images = new ConsoleImage[10];
        protected void renderNumber(ConsoleGraphics graphics,int x , int y,int distanceBetweenNumber)
        {
            if (numberOfApplesEaten >= 10)
            {
                int firstDischarge = numberOfApplesEaten / 10;
                graphics.DrawImage(images[firstDischarge], x, y);
                graphics.DrawImage(images[numberOfApplesEaten - 10 * firstDischarge], x+distanceBetweenNumber, y);
            }
            else graphics.DrawImage(images[numberOfApplesEaten], x+distanceBetweenNumber, y);
        }
    }
}
