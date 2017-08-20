using NConsoleGraphics;
using System.Collections.Generic;
using System.Threading;
using System;

namespace OOPGame
{

    public abstract class GameEngine
    {
        ConsoleImage image;
        protected Random r = new Random();
        Apple delApple;
        internal bool delet = false;
        public int numPartOfBody = 0;
        private ConsoleGraphics graphics;
        private List<IGameObject> objects = new List<IGameObject>();
        private List<IGameObject> tempObjects = new List<IGameObject>();
        private List<IGameObject> squares = new List<IGameObject>();
        public bool end;

        public GameEngine(ConsoleGraphics graphics)
        {
            image = graphics.LoadImage("fonj.jpg");
            this.graphics = graphics;
        }
        public bool ChangeCourse(int n)
        {
            if (((PartOfBody)objects[n - 1]).dir.X != ((PartOfBody)objects[n]).dir.X) return true;
            else if (((PartOfBody)objects[n - 1]).dir.Y != ((PartOfBody)objects[n]).dir.Y) return true;
            else return false;
            
        }
        public Point StartXY()
        {
            return ((PartOfBody)tempObjects[tempObjects.Count - 1]).p1;
        }
        public Direction StartDir()
        {
            return ((PartOfBody)tempObjects[tempObjects.Count - 1]).dir;
        }
        public bool GetCountObj()
        {
            return objects.Count > 1;
        }
        public Point DataXY(int n)
        {
            return ((PartOfBody)objects[n - 1]).p1;
        }
        public Point DataXYPrewPart()
        {
            return DataXY(numPartOfBody);
        }
        public Point DataXYHead()
        {
          return DataXY(1);
        }
        public Direction DataDirSecondary()
        {
           return DataDir(2);
        }
        public Direction DataDir(int n)
        {
            return ((PartOfBody)objects[n - 1]).dir;
        }
        public Direction DataDirPrewPart()
        {
            return DataDir(numPartOfBody);
        }
        public void AddObject(IGameObject obj)
        {
            tempObjects.Add(obj);
        }
        public void EatApple(Apple obj, bool _delet)
        {
            delet = _delet;
            delApple = obj;
        }
        public void RemFromSquare(Apple sq)
        {
            squares.Remove(sq);
        }
        public void AddToObjects(List<IGameObject> tempObj)
        {
            foreach (var item in tempObj)
            {
                if (item is PartOfBody) objects.Add(item);
                else if (item is Hurdle) squares.Add(item);
            }
        }
        public void Start()
        {
            while (true)
            {
                foreach (var obj in objects)
                {
                    obj.Update(this);
                    numPartOfBody++;
                }
                foreach (var obj in squares)
                {
                    obj.Update(this);
                }
                if (delet)
                {
                  if(delApple != null)  RemFromSquare(delApple);
                    AddObject(new Apple(graphics , r, DataXYHead));
                    AddObject(new Body(graphics, DataXYPrewPart, DataDirPrewPart, 12, 12, 20,r) { xyHead = DataXYHead });
                    delet = false;
                }
                AddToObjects(tempObjects);
                tempObjects.Clear();
                numPartOfBody = 0;
                graphics.DrawImage(image,0,0);
                foreach (var obj in objects)
                    obj.Render(graphics);
                foreach (var obj in squares)
                    obj.Render(graphics);
                graphics.FlipPages();
                if(end) Console.ReadLine();
                Thread.Sleep(10);
            }
        }
    }
}
