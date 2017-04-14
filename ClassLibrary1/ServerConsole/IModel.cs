
namespace ServerConsole
{
    using MazeLib;

    public interface IModel
    {
        Maze Generate(string name, int rows, int cols);
    }
}
