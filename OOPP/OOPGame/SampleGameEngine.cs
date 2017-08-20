using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    public class SampleGameEngine : GameEngine
    {
        
        public SampleGameEngine(ConsoleGraphics graphics)
           : base(graphics)
        {
            AddObject(new Head(graphics,10,10, r));
            AddObject(new Apple(graphics,r, DataXYHead));
            AddObject(new Apple(graphics, r, DataXYHead));
            AddObject(new Apple(graphics,r,DataXYHead));

            for (int i = 0; i < 12; i++)
            {
            AddObject(new Stone(graphics,r, DataXYHead));

            }
           
            
        }
    }
    
}
