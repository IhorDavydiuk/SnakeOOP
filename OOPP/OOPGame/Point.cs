using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    public struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    public struct Direction
    {
        public DirX X;
        public DirY Y;
        public Direction(DirX x, DirY y)
        {
            this.X = x;
            this.Y = y;
        }
        public override bool Equals(object obj)
        {
            if (obj is Direction)
            {
                if (((Direction)obj).X == X && ((Direction)obj).Y == Y) return true;
                else return false;
            }
            else return false;
        }
    }
    public enum DirY
    {
        Up = -1,
        Down = 1,
        Note = 0
    }
    public enum DirX
    {
        Left = -1,
        Right = 1,
        Note = 0
    }
}
