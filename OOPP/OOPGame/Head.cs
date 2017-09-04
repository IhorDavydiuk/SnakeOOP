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
        int ClientHeight, ClientWidth;
        public Head(ConsoleGraphics graphics,int width,int height, Random r) : base (graphics)
        {
            this.height = height;
            this.width = width;
            startDir(r.Next(0,2), r.Next(0,2));
            p1.x = r.Next(0, 460);
            p1.y = r.Next(0, 370);
            ClientHeight = graphics.ClientHeight;
            ClientWidth = graphics.ClientWidth;
        }
        void startDir(int movOX,int moveOY)
        {
            if (movOX == 1 && moveOY == 1)
            {
                dir.Y = DirY.Note;
                dir.X = DirX.Right;
            }
            else if (movOX == 1 && moveOY == 0)
            {
                dir.Y = DirY.Note;
                dir.X = DirX.Left;
            }
            else if (movOX == 0 && moveOY == 1)
            {
                dir.Y = DirY.Down;
                dir.X = DirX.Note;
            }
            else if (movOX == 0 && moveOY == 0)
            {
                dir.Y = DirY.Up;
                dir.X = DirX.Note;
            }
        }
        bool uslov;
        public override void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(images[0],p1.x,p1.y);
        }
        public override void Update(GameEngine engine)
        {
            uslov = engine.GetCountObj();
            bool we = uslov? dir.X == engine.DataDirSecondary().X : true;
            bool re = uslov ? dir.Y == engine.DataDirSecondary().Y : true;
            if (Input.IsKeyDown(Keys.LEFT) && dir.X != DirX.Right && we)
            {
                dir.X = DirX.Left;
                dir.Y = DirY.Note;
            }
            else if (Input.IsKeyDown(Keys.RIGHT) && dir.X != DirX.Left && we)
            {
                dir.X = DirX.Right;
                dir.Y = DirY.Note;
            }
            else if (Input.IsKeyDown(Keys.UP) && dir.Y != DirY.Down && re)
            {
                dir.X = DirX.Note;
                dir.Y = DirY.Up;
            }
            else if (Input.IsKeyDown(Keys.DOWN) && dir.Y != DirY.Up && re)
            {
                dir.X = DirX.Note;
                dir.Y = DirY.Down;
            }
            p1.x += speed * (int)dir.X;
            p1.y += speed * (int)dir.Y;
        }
    }
}
