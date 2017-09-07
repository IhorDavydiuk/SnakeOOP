using NConsoleGraphics;
using System.Collections.Generic;
using System.Threading;
using System;
using System.Linq;

namespace OOPGame
{
    public abstract class GameEngine
    {
        protected ConsoleImage image;
        protected Random r = new Random();
        private ConsoleGraphics graphics;
        public GameEngine(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }
        protected List<IGameObject> objects = new List<IGameObject>();
        public void AddObject(IGameObject tempObj)
        {
            objects.Add(tempObj);
        }
        public void RemObject(IGameObject obj)
        {
            objects.Remove(obj);
        }
        public void Start()
        {
            while (true)
            {
                foreach (var obj in objects.ToArray()) obj.Update(this);
                graphics.DrawImage(image, 0, 0);
                foreach (var obj in objects) obj.Render(graphics);
                graphics.FlipPages();
                Thread.Sleep(10);
            }
        }
    }
}
