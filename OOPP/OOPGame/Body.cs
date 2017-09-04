using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;


namespace OOPGame
{
    public class Body : PartOfBody
    {
        int turnX, turnY;
        DirX courseX;
        DirY courseY;
        public Func<Point> xyHead { get; set; }
        public Body(Point PrevXY, Direction PrevDir, int width, int height, int shag, Random r) : base(width,height)
        {
            image = images[r.Next(1,10)];
            if (PrevDir.Y == DirY.Down)
            {
                p1 = new Point(PrevXY.x, PrevXY.y - shag);
            }
            else if (PrevDir.Y == DirY.Up)
            {
                p1 = new Point(PrevXY.x, PrevXY.y + shag);
            }
            else if (PrevDir.X == DirX.Left)
            {
                p1 = new Point(PrevXY.x + shag, PrevXY.y);
            }
            else if (PrevDir.X == DirX.Right)
            {
                p1 = new Point(PrevXY.x - shag, PrevXY.y);
            }
            dir = new Direction(PrevDir.X, PrevDir.Y);
        }
        void setData(Point lastPartXY,Direction lastPartDir)
        {
            turnX = lastPartXY.x;
            turnY = lastPartXY.y;
            courseX = lastPartDir.X;
            courseY = lastPartDir.Y;
        }
        void control()
        {
            if (p1.y == turnY && courseX == DirX.Left)
            {
                dir.X = DirX.Left;
                dir.Y = DirY.Note;
            }
            else if (p1.y == turnY && courseX == DirX.Right)
            {
                dir.X = DirX.Right;
                dir.Y = DirY.Note;
            }
            else if (p1.x == turnX && courseY == DirY.Up)
            {
                dir.X = DirX.Note;
                dir.Y = DirY.Up;
            }
            else if (p1.x == turnX && courseY == DirY.Down)
            {
                dir.X = DirX.Note;
                dir.Y = DirY.Down;
            }
        }
        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image, p1.x, p1.y);
        }
        bool changeDir(IEnumerable<PartOfBody> lastPart)
        {
            if (lastPart.TakeWhile(q=>q != this).Last().dir.X != dir.X) return true;
            else if (lastPart.TakeWhile(q => q != this).Last().dir.Y != dir.Y) return true;
            else return false;
        }
        public override void Update(GameEngine engine)
        {
            if (changeDir(engine.GetObjects()))
            {
                setData(engine.GetObjects().TakeWhile(q => q != this).Last().p1, engine.GetObjects().TakeWhile(q => q != this).Last().dir);
            }
            if (AuxilClass.HeadOnHurdle(xyHead, p1, width, height)) engine.end = true;
            control();
            p1.x += speed * (int)dir.X;
            p1.y += speed * (int)dir.Y;
        }
    }
}
