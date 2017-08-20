using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
   abstract public class PartOfBody : IGameObject
    {
      
       protected ConsoleImage image;
        public Point p1;
        public Direction dir;
        protected int width, height;
        public static int speed = 1;
        public PartOfBody(ConsoleGraphics graphics)
        {
            
        }
        public virtual void Render(ConsoleGraphics graphics)
        {
        }
        public virtual void Update(GameEngine engine)
        {
            
        }
       

    }
}
