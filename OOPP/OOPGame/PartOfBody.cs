using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    abstract public class PartOfBody 
    {
        protected int heighPlayingField, widthPlayingField;
        protected ConsoleImage image;
        protected abstract void checDirection();
        protected Point p1;
        public Direction Dir;
        protected int width, height;
        public static int Speed{ get;protected set; }
        public PartOfBody(int width, int height)
        {
            this.height = height;
            this.width = width;
        }
        public Point GetP1
        {
            get { return p1; }
        }
        protected void changeCoordinates()
        {
           p1.X += Speed * (int)Dir.X;
           p1.Y += Speed * (int)Dir.Y;
        }
    }
}
