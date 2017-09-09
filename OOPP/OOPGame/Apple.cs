using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class Apple : Hurdle, IGameObject
    {
        int height, width;
        static ConsoleImage image;
        Random r;
        ConsoleGraphics graphics;
        public static bool IsEaten { get; set; }
        public Apple(ConsoleGraphics graphics, Random r, Head head, int weight, int height) : base(r, head)
        {
            this.width = weight;
            this.height = height;
            this.graphics = graphics;
            this.r = r;
        }
        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image, p1.X, p1.Y);
        }
        public void Update(GameEngine engine)
        {
            if (AuxilClass.HeadOnHurdle(head, p1, width, height) && !headWasOnSquare)
            {
                IsEaten = true;
                ((SnakeGameEngine)engine).RemObject(this);
                engine.AddObject(new Apple(graphics, r, head, 15, 15));
            }
            headWasOnSquare = AuxilClass.HeadOnHurdle(head, p1, width, height);
        }
        public static void Load(ConsoleGraphics graphics)
        {
            image = graphics.LoadImage("y2.png");
        }
    }
}
