

namespace ClassLibrary1.Maze
{
    using System;
    using System.Collections.Generic;
    using MazeLib;

    /// <summary>
    /// An adapter between the "Searchable" interface to the maze class.
    /// </summary>
    public class MazeToSearchableAdapter : ISearchable<Position>
    {
        /// <summary>
        /// The maze itself.
        /// </summary>
        private Maze maze;
        
        /// <summary>
        /// The solution to the maze.
        /// </summary>
        private MazeSolution solution;

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeToSearchableAdapter"/> class. 
        /// Initializes it's solution
        /// </summary>
        /// <param name="m">
        /// The maze 
        /// </param>
        public MazeToSearchableAdapter(Maze m)
        {
            maze = m;
            solution = new MazeSolution();
        }

        /// <summary>
        /// Getter for the start position.
        /// </summary>
        /// <returns>
        /// The initial state</returns>
        public State<Position> GetInitialState()
        {
            State<Position> state = new State<Position>(maze.InitialPos);
            return state;
        }

        /// <summary>
        /// Getter goal position.
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
            
            // left neighbor
            if ((currentPos.Col > 0) && (maze[currentPos.Row, currentPos.Col - 1] == CellType.Free))
            {
                neighbour = new State<Position>(new Position(currentPos.Row, currentPos.Col - 1));
                list.Add(neighbour);
            }

            // top neighbor
            if ((currentPos.Row > 0) && (maze[currentPos.Row - 1, currentPos.Col] == CellType.Free))
            {
                neighbour = new State<Position>(new Position(currentPos.Row - 1, currentPos.Col));
                list.Add(neighbour);
            }
            
            // right neighbor
            if ((currentPos.Col < maze.Cols - 1) && (maze[currentPos.Row, currentPos.Col + 1] == CellType.Free))
            {
                neighbour = new State<Position>(new Position(currentPos.Row, currentPos.Col + 1));
                list.Add(neighbour);
            }
            
            // bottom neighbor
            if ((currentPos.Row < maze.Rows - 1) && (maze[currentPos.Row + 1, currentPos.Col] == CellType.Free))
            {
                neighbour = new State<Position>(new Position(currentPos.Row + 1, currentPos.Col));
                list.Add(neighbour);
            }
            return list;
        }

        /// <summary>
        /// Getter for the solution.
        /// </summary>
        /// <returns>
        /// The solution </returns>
        public Solution<Position> GetSolution()
        {
            return solution;
        }
    }
}
