using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace ClassLibrary1
{
    /// <summary>
    /// An adapter between the Isearchable interface to the maze class.
    /// </summary>
    public class MazeToSearchableAdapter : ISearchable<Position>
    {
        /// <summary>
        /// The maze itself.
        /// </summary>
        private Maze maze;
        /// <summary>
        /// Te solution to the maze.
        /// </summary>
        private MazeSolution solution;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="m"> The maze </param>
        public MazeToSearchableAdapter(Maze m)
        {
            maze = m;
            solution = new MazeSolution();
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The initial state</returns>
        public State<Position> GetInitialState()
        {
            State<Position> state = new State<Position>(maze.InitialPos);
            return state;
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The goal state </returns>
        public State<Position> GetGoalState()
        {
            State<Position> state = new State<Position>(maze.GoalPos);
            return state;
        }
        
        /// <summary>
        /// Returns all the possible states to go to from current state.
        /// </summary>
        /// <param name="currentState"> The state we are currently at</param>
        /// <returns>
        /// A list of states</returns>
        public List<State<Position>> GetAllPossibleStates(State<Position> currentState)
        {
            List <State<Position>> list = new List<State<Position>>();
            Position currentPos = currentState.GetState();
            State<Position> neighbour;
            //left neighbour
            if ((currentPos.Col > 0) && (maze[currentPos.Row, currentPos.Col - 1] == CellType.Free))
            {
                neighbour = new State<Position>(new Position(currentPos.Row, currentPos.Col - 1));
                list.Add(neighbour);
            }
            //top neighbour
            if ((currentPos.Row > 0) && (maze[currentPos.Row - 1, currentPos.Col] == CellType.Free))
            {
                neighbour = new State<Position>(new Position(currentPos.Row - 1, currentPos.Col));
                list.Add(neighbour);
            }
            //right neighbour
            if ((currentPos.Col < maze.Cols - 1) && (maze[currentPos.Row, currentPos.Col + 1] == CellType.Free))
            {
                neighbour = new State<Position>(new Position(currentPos.Row, currentPos.Col + 1));
                list.Add(neighbour);
            }
            //bottom neighbour
            if ((currentPos.Row < maze.Rows - 1) && (maze[currentPos.Row + 1, currentPos.Col] == CellType.Free))
            {
                neighbour = new State<Position>(new Position(currentPos.Row + 1, currentPos.Col));
                list.Add(neighbour);
            }
            return list;

        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The solution </returns>
        public Solution<Position> GetSolution()
        {
            return solution;
        }
    }
}
