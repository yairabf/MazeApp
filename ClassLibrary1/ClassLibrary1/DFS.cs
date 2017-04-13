using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DFS<T> : Searcher<T>
    {
        public override Solution<T> Search(ISearchable<T> searchable)
        {
            Stack<State<T>> stack = new Stack<State<T>>();
            HashSet<State<T>> finished = new HashSet<State<T>>();
            stack.Push(searchable.getInitialState());
            while (stack.Count() > 0)
            {
                State<T> current = stack.Pop();
                evaluatedNodes++;
                if (current.Equals(searchable.getGoalState()))
                {
                    return backTrace(current);
                }
                if (!finished.Contains(current))
                {
                    finished.Add(current);
                    List<State<T>> succerssors = searchable.getAllPossibleStates(current);
                    foreach (State<T> s in succerssors)
                    {
                        if (!stack.Contains(s) && !finished.Contains(s))
                        {
                            s.setCameFrom(current);
                            stack.Push(s);
                        }
                    }
                }
            }
            Console.WriteLine("have not reached the goal");
            return null;
        }

        protected override Solution<T> backTrace(State<T> n)
        {
            Solution<T> sol = new Solution<T>();
            sol.buildSolution(n);
            return sol;
        }
    }
}
