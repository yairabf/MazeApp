using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace ServerConsole
{
    class Game
    {
        private string name;
        private Maze maze;
        private Player playerOne;
        private Player playerTwo;

        public Game(Maze m, Player pOne)
        {
            this.name = m.Name;
            this.maze = m;
            this.playerOne = pOne;
        }

        public void SetPlayerTwo(Player pTwo)
        {
            this.playerTwo = pTwo;
        }

        public string ToJSON()
        {
            return maze.ToJSON();
        }
    }
}
