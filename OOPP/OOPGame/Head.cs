using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;


namespace OOPGame
{
    public class Head : PartOfBody
    {
        Random r;
        ConsoleGraphics graphics;
        bool secondPartIsTurn = true;
        public Head(ConsoleGraphics graphics, int width, int height, Random r) : base(width, height)
        {
            this.r = r;
            this.graphics = graphics;
            startDir(r.Next(0, 2), r.Next(0, 2));
            p1 = new Point(r.Next(0, 460), r.Next(0, 370));
        }
        public Point GetXY()
        {
            return p1;
        }
        void startDir(int movOX, int moveOY)
        {
            if (movOX == 1 && moveOY == 1)
            {
                dir = new Direction(DirX.Right, DirY.Note);
            }
            else if (movOX == 1 && moveOY == 0)
            {
                dir = new Direction(DirX.Left, DirY.Note);
            }
            else if (movOX == 0 && moveOY == 1)
            {
                dir = new Direction(DirX.Note, DirY.Down);
            }
            else if (movOX == 0 && moveOY == 0)
            {
                dir = new Direction(DirX.Note, DirY.Up);
            }
        }
        void turnHead()
        {
            if (Input.IsKeyDown(Keys.LEFT) && dir.X != DirX.Right && secondPartIsTurn)
            {
                dir.X = DirX.Left;
                dir.Y = DirY.Note;
            }
            else if (Input.IsKeyDown(Keys.RIGHT) && dir.X != DirX.Left && secondPartIsTurn)
            {
                dir.X = DirX.Right;
                dir.Y = DirY.Note;
            }
            else if (Input.IsKeyDown(Keys.UP) && dir.Y != DirY.Down && secondPartIsTurn)
            {
                dir.X = DirX.Note;
                dir.Y = DirY.Up;
            }
            else if (Input.IsKeyDown(Keys.DOWN) && dir.Y != DirY.Up && secondPartIsTurn)
            {
                dir.X = DirX.Note;
                dir.Y = DirY.Down;
            }
        }
        bool headIsOne(int numberPart)
        {
            return numberPart != 1;
        }
        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(images[0], p1.x, p1.y);
        }
        public override void Update(GameEngine engine)
        {
            if (Apple.IsEaten)
            {
                engine.AddObject(new Body(engine.GetObjects().Last().p1, engine.GetObjects().Last().dir, 12, 12, 20, r) { xyHead = GetXY });
                Apple.IsEaten = false;
            }
            if (headIsOne(engine.GetObjects().Count()))
            {
                secondPartIsTurn = dir.Equals(engine.GetObjects().Skip(1).Take(1).Single().dir);
            }
            turnHead();
            p1.x += speed * (int)dir.X;
            p1.y += speed * (int)dir.Y;
        }
    }
}
