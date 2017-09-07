using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;


namespace OOPGame
{
    public class Body : PartOfBody,IGameObject
    {
        static public bool EndGame { get; private set; }
        static ConsoleImage[] images;
        int turnX, turnY;
        DirX courseX;
        DirY courseY;
        public Head head { get; set; }
        public Body(Point PrevXY, Direction PrevDir, int width, int height, int shag, Random r) : base(width,height)
        {
            image = images[r.Next(1,10)];
            if (PrevDir.Y == DirY.Down)
            {
                p1 = new Point(PrevXY.X, PrevXY.Y - shag);
            }
            else if (PrevDir.Y == DirY.Up)
            {
                p1 = new Point(PrevXY.X, PrevXY.Y + shag);
            }
            else if (PrevDir.X == DirX.Left)
            {
                p1 = new Point(PrevXY.X + shag, PrevXY.Y);
            }
            else if (PrevDir.X == DirX.Right)
            {
                p1 = new Point(PrevXY.X - shag, PrevXY.Y);
            }
            Dir = new Direction(PrevDir.X, PrevDir.Y);
        }
        void setData(Point lastPartXY,Direction lastPartDir)
        {
            turnX = lastPartXY.X;
            turnY = lastPartXY.Y;
            courseX = lastPartDir.X;
            courseY = lastPartDir.Y;
        }
        protected override void checDirection()
        {
            if (p1.Y == turnY && courseX == DirX.Left)
            {
                Dir.X = DirX.Left;
                Dir.Y = DirY.Note;
            }
            else if (p1.Y == turnY && courseX == DirX.Right)
            {
                Dir.X = DirX.Right;
                Dir.Y = DirY.Note;
            }
            else if (p1.X == turnX && courseY == DirY.Up)
            {
                Dir.X = DirX.Note;
                Dir.Y = DirY.Up;
            }
            else if (p1.X == turnX && courseY == DirY.Down)
            {
                Dir.X = DirX.Note;
                Dir.Y = DirY.Down;
            }
        }
        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image, p1.X, p1.Y);
        }
        bool changeDir(IEnumerable<PartOfBody> lastPart)
        {
            if (lastPart.TakeWhile(q=>q != this).Last().Dir.X != Dir.X) return true;
            else if (lastPart.TakeWhile(q => q != this).Last().Dir.Y != Dir.Y) return true;
            else return false;
        }
        public void Update(GameEngine engine)
        {
            if (changeDir(((SnakeGameEngine)engine).GetObjects()))
            {
                setData(((SnakeGameEngine)engine).GetObjects().TakeWhile(q => q != this).Last().GetP1, ((SnakeGameEngine)engine).GetObjects().TakeWhile(q => q != this).Last().Dir);
            }
            if (AuxilClass.HeadOnHurdle(head, p1, width, height)) Speed = 0;
            checDirection();
            changeCoordinates();
        }
        public static void Load(ConsoleGraphics graphics)
        {
            images = new ConsoleImage[] {
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
