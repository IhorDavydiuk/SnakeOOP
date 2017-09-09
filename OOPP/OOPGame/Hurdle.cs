using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    abstract public class Hurdle
    {
        protected Point p1;
        protected Head head;
        protected bool headWasOnSquare;
        public Hurdle(Random r, Head head)
        {
            AuxilClass.PointsOfStones.Add(new Point(10, 10));
            this.head = head;
            bool appleOnTheStone = true;
            do
            {
                int xr = r.Next(0, 400);
                int yr = r.Next(0, 400);
                foreach (var item in AuxilClass.PointsOfStones)
                {
                    if (!(xr > item.X - 30 && yr > item.Y - 30 && xr < item.X + Stone.Width + 100 && yr < item.Y + Stone.Height + 100))
                    {
                        p1 = new Point(xr, yr);
                        appleOnTheStone = false;
                    }
                }
            } while (appleOnTheStone);
        }
    }
}
