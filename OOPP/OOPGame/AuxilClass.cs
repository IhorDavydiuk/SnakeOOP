using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    static class AuxilClass
    {
        public static bool HeadOnHurdle(Func<Point> xyHead, Point p1,int widthHurdle,int heightHurdle)
        {
            if (xyHead().x + 6 >= p1.x && xyHead().y + 6 >= p1.y && xyHead().x + 6 <= p1.x + widthHurdle && xyHead().y + 6 <= p1.y + heightHurdle) return true;
            else return false;
        }
    }
}
