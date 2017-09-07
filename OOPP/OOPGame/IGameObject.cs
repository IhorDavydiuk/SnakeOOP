using NConsoleGraphics;

namespace OOPGame {

  public interface IGameObject {
    void Render(ConsoleGraphics graphics);
    void Update(GameEngine engine);
  }
    public interface ILoadImages{
        void Load(ConsoleGraphics graphics);
    }
}