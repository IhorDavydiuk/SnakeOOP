using NConsoleGraphics;
using System;

namespace OOPGame {
    
  public class Program {

    static void Main(string[] args) {

      Console.WindowWidth = 60;
      Console.WindowHeight = 33;
      Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
      Console.BackgroundColor = ConsoleColor.DarkGray;
      Console.CursorVisible = false;
      Console.Clear();

      ConsoleGraphics graphics = new ConsoleGraphics();

      GameEngine engine = new SampleGameEngine(graphics);
      engine.Start();
    }
  }
}
