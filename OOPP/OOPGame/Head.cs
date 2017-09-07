using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;


namespace OOPGame
{
    public class Head : PartOfBody, ILoadImages, IGameObject
    {
        Random r;
        ConsoleGraphics graphics;
        bool secondPartIsTurn = true;
        public Head(ConsoleGraphics graphics, int width, int height, Random r) : base(width, height)
        {
            Speed = 1; 
            this.r = r;
            this.graphics = graphics;
            startDir(r.Next(0, 2), r.Next(0, 2));
            p1 = new Point(r.Next(0, 460), r.Next(0, 370));
            heighPlayingField = graphics.ClientHeight;
            widthPlayingField = graphics.ClientWidth;
        }
        void startDir(int movOX, int moveOY)
        {
            if (movOX == 1 && moveOY == 1)
            {
                Dir = new Direction(DirX.Right, DirY.Note);
            }
            else if (movOX == 1 && moveOY == 0)
            {
                Dir = new Direction(DirX.Left, DirY.Note);
            }
            else if (movOX == 0 && moveOY == 1)
            {
                Dir = new Direction(DirX.Note, DirY.Down);
            }
            else if (movOX == 0 && moveOY == 0)
            {
                Dir = new Direction(DirX.Note, DirY.Up);
            }
        }
        protected override void checDirection()
        {
            if (Input.IsKeyDown(Keys.LEFT) && Dir.X != DirX.Right && secondPartIsTurn && p1.X != 0)
            {
                Dir.X = DirX.Left;
                Dir.Y = DirY.Note;
            }
            else if (Input.IsKeyDown(Keys.RIGHT) && Dir.X != DirX.Left && secondPartIsTurn && p1.X != widthPlayingField - 15)
            {
                Dir.X = DirX.Right;
                Dir.Y = DirY.Note;
            }
            else if (Input.IsKeyDown(Keys.UP) && Dir.Y != DirY.Down && secondPartIsTurn && p1.Y != 0)
            {
                Dir.X = DirX.Note;
                Dir.Y = DirY.Up;
            }
            else if (Input.IsKeyDown(Keys.DOWN) && Dir.Y != DirY.Up && secondPartIsTurn && p1.Y != heighPlayingField - 15)
            {
                Dir.X = DirX.Note;
                Dir.Y = DirY.Down;
            }
        }
        bool headIsNotOne(int numberOfPart)
        {
            return numberOfPart != 1;
        }
        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image, p1.X, p1.Y);
        }
        protected void checDirectionn()
        {
            if (p1.Y == heighPlayingField  - 15 && Dir.Y== DirY.Down)
            {
                    Dir.X = DirX.Right;
                    Dir.Y = DirY.Note;
            }
            
            else if (p1.Y == 0 && Dir.Y == DirY.Up)
            {
                    Dir.X = DirX.Left;
                    Dir.Y = DirY.Note;
            }
            else if (p1.X == 0 && Dir.X == DirX.Left)
            {
                Dir.X = DirX.Note;
                Dir.Y = DirY.Down;
            }
            else if (p1.X == widthPlayingField-15 && Dir.X == DirX.Right)
            {
                    Dir.X = DirX.Note;
                    Dir.Y = DirY.Up;
            }
        }
        public void Update(GameEngine engine)
        {
            if (Apple.IsEaten)
            {
                engine.AddObject(new Body(((SnakeGameEngine)engine).GetObjects().Last().GetP1, ((SnakeGameEngine)engine).GetObjects().Last().Dir, 12, 12, 20, r) { head = (Head)((SnakeGameEngine)engine).GetObjects().First() });
                Apple.IsEaten = false;
            }
            if (headIsNotOne(((SnakeGameEngine)engine).GetObjects().Count()))
            {
                secondPartIsTurn = Dir.Equals(((SnakeGameEngine)engine).GetObjects().Skip(1).Take(1).Single().Dir);
            }
            //if (headGoesOut())
            //{
            //    dir.Y = DirY.Down;
            //    dir.X = DirX.Note;
            //}
            checDirectionn();
            checDirection();
            changeCoordinates();
        }
        public void Load(ConsoleGraphics graphics)
        {
            image = graphics.LoadImage("0.png");
        }
        public static void StopHead()
        {
            Speed = 0;
        }
    }
}
