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
        
        Func<Point> PrevXY;
        Func<Direction> PrevDir;
        int turnX, turnY;
        DirX courseX;
        DirY courseY;
        public Func<Point> xyHead { get; set; }

        
        public Body(ConsoleGraphics graphics, Func<Point> PrevXY, Func<Direction> PrevDir, int width, int height, int shag, Random r) : base(graphics)
        {
            image = images[r.Next(1,10)];
            this.height = height;
            this.width = width;
            this.PrevXY = PrevXY;
            this.PrevDir = PrevDir;
            if (PrevDir().Y == DirY.Down)
            {
                p1.x = PrevXY().x;
                p1.y = PrevXY().y - shag;
            }
            else if (PrevDir().Y == DirY.Up)
            {
                p1.x = PrevXY().x;
                p1.y = PrevXY().y + shag;
            }
            else if (PrevDir().X == DirX.Left)
            {
                p1.x = PrevXY().x + shag;
                p1.y = PrevXY().y;
            }
            else if (PrevDir().X == DirX.Right)
            {
                p1.x = PrevXY().x - shag;
                p1.y = PrevXY().y;
            }
            dir.Y = PrevDir().Y;
            dir.X = PrevDir().X;
        }
        void setData()
        {
            turnX = PrevXY().x;
            turnY = PrevXY().y;
            courseX = PrevDir().X;
            courseY = PrevDir().Y;
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
        public override void Update(GameEngine engine)
        {
            if (engine.ChangeCourse(engine.numPartOfBody))
            {
                setData();
            }
            if (AuxilClass.HeadOnHurdle(xyHead, p1, width, height)) engine.end = true;
            control();
            p1.x += speed * (int)dir.X;
            p1.y += speed * (int)dir.Y;
        }
    }
}
