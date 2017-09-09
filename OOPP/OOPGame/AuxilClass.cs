using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    static class AuxilClass
    {
        public static bool HeadOnHurdle(Head head, Point p1, int widthHurdle, int heightHurdle)
        {
            if (head.GetP1.X + 6 >= p1.X && head.GetP1.Y + 6 >= p1.Y && head.GetP1.X + 6 <= p1.X + widthHurdle && head.GetP1.Y + 6 <= p1.Y + heightHurdle) return true;
            else return false;
        }
        public static List<Point> PointsOfStones = new List<Point>();
    }
}
