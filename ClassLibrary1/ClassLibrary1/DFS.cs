using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Dfs<T> : Searcher<T>
    {
        public override Solution<T> Search(ISearchable<T> searchable)
        {
            Stack<State<T>> stack = new Stack<State<T>>();
            HashSet<State<T>> finished = new HashSet<State<T>>();
            stack.Push(searchable.GetInitialState());
            while (stack.Any())
            {
                State<T> current = stack.Pop();
                EvaluatedNodes++;
                if (current.Equals(searchable.GetGoalState()))
                {
                    return BackTrace(current);
                }
                if (!finished.Contains(current))
                {
                    finished.Add(current);
                    List<State<T>> succerssors = searchable.GetAllPossibleStates(current);
                    foreach (State<T> s in succerssors)
                    {
                        if (!stack.Contains(s) && !finished.Contains(s))
                        {
                            s.SetCameFrom(current);
                            stack.Push(s);
                        }
                    }
                }
            }
            Console.WriteLine("have not reached the goal");
            return null;
        }

        protected override Solution<T> BackTrace(State<T> n)
        {
            Solution<T> sol = new Solution<T>();
            sol.BuildSolution(n);
            return sol;
        }
    }
}
