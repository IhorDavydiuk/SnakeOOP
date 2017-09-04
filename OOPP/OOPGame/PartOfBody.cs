using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    abstract public class PartOfBody : IGameObject
    {
        protected static ConsoleImage[] images;
        protected ConsoleImage image;
        public Point p1;
        public Direction dir;
        protected int width, height;
        protected static int speed = 1;
        public PartOfBody(int width, int height)
        {
            this.height = height;
            this.width = width;
        }
        public virtual void Render(ConsoleGraphics graphics)
        {
        }
        public virtual void Update(GameEngine engine)
        {
        }
        public static void LoadImage(ConsoleGraphics graphics)
        {
            images = new ConsoleImage[] {
                graphics.LoadImage("0.png"),
                graphics.LoadImage("3.png"),
                graphics.LoadImage("4.png"),
                graphics.LoadImage("5.png"),
                graphics.LoadImage("6.png"),
                graphics.LoadImage("7.png"),
                graphics.LoadImage("8.png"),
                graphics.LoadImage("9.png"),
                graphics.LoadImage("10.png"),
                graphics.LoadImage("11.png"),
                graphics.LoadImage("12.png")
            };
        }
    }
}
