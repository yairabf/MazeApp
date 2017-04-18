using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace ClassLibrary1
{
    public class MazeToSearchableAdapter : ISearchable<Position>
    {
        private Maze maze;
        private MazeSolution solution;

        public MazeToSearchableAdapter(Maze m)
        {
            maze = m;
            solution = new MazeSolution();
        }

        public State<Position> GetInitialState()
        {
            State<Position> state = new State<Position>(maze.InitialPos);
            return state;
        }

        public State<Position> GetGoalState()
        {
            State<Position> state = new State<Position>(maze.GoalPos);
            return state;
        }
        
        // returns all neighbours of the state
        
        // *******************************************************************need to check if columns and rows start from 0
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

        public Solution<Position> GetSolution()
        {
            return solution;
        }
    }
}
