using NConsoleGraphics;
using System.Collections.Generic;
using System.Threading;
using System;
using System.Linq;

namespace OOPGame
{
    public abstract class GameEngine
    {
        public bool end;
        ConsoleImage image;
        protected Random r = new Random();
        private ConsoleGraphics graphics;
        public GameEngine(ConsoleGraphics graphics)
        {
            image = graphics.LoadImage("fonj.jpg");
            this.graphics = graphics;
        }
        private List<IGameObject> objects = new List<IGameObject>();
        private List<IGameObject> tempObjects = new List<IGameObject>();
        private List<IGameObject> apples = new List<IGameObject>();
        public IEnumerable<PartOfBody> GetObjects()
        {
            return objects.OfType<PartOfBody>();
        }
        public void AddObject(IGameObject obj)
        {
            tempObjects.Add(obj);
        }
        public void RemApple(Apple apple)
        {
            apples.Remove(apple);
        }
        public void AddToObjects(List<IGameObject> tempObj)
        {
            foreach (var item in tempObj)
            {
                if (item is PartOfBody) objects.Add(item);
                else if (item is Hurdle) apples.Add(item);
            }
        }
        public void Start()
        {
            while (true)
            {
                foreach (var obj in objects.Concat(apples).ToArray()) obj.Update(this);
                AddToObjects(tempObjects);
                tempObjects.Clear();
                graphics.DrawImage(image, 0, 0);
                foreach (var obj in objects.Concat(apples)) obj.Render(graphics);
                graphics.FlipPages();
                if (end) Console.ReadLine();
                Thread.Sleep(10);
            }
        }
    }
}
