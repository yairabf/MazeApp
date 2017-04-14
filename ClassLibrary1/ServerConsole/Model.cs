using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{  
    using MazeGeneratorLib;
    using MazeLib;

    class Model : IModel
    {
        public Maze Generate(string name, int rows, int cols)
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(rows, cols);
            return maze;
        }
    }
}
