using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class Stone : Hurdle , ILoadImages,IGameObject
    {
        static public int Height { get;private set; }
        static public int Width { get;private set; }
        static public bool EndGame { get; private set; }
        ConsoleImage image;
        public Stone(Random r, Head head,int Width,int Hight) :base (r,head)
        {
            Height = Hight;
            Stone.Width = Width;
            AuxilClass.PointsOfStones.Add(p1);
        }
        public void Load(ConsoleGraphics graphics)
        {
            image = graphics.LoadImage("k2.png");
        }
        public int ReturnWidthStone()
        {
            return Width;
        }
        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image,p1.X,p1.Y);
        }
        public void Update(GameEngine engine)
        {
            if (AuxilClass.HeadOnHurdle(head, p1, Width, Height))
            {
                Head.StopHead(); 
            }
        }
    }
}
