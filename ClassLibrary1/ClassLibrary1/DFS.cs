using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class DFS<T> : Searcher<T>
    {
        public override Solution<T> search(ISearchable<T> searchable)
        {
            Stack<State<T> > stack = new Stack<State<T>>();
            HashSet<State<T>> finished = new HashSet<State<T>>();
            stack.Push(searchable.getInitialState());
            while(stack.Count() > 0)
            {
                State<T> current = stack.Pop();
                evaluatedNodes++;
                if(current.Equals(searchable.getGoalState()))
                {
                    return backTrace(current);
                }
                if (!finished.Contains(current))
                {
                    finished.Add(current);
                    List<State<T>> succerssors = searchable.getAllPossibleStates(current);
                    foreach (State<T> s in succerssors)
                    {
                        if (!stack.Contains(s) && finished.Contains(s))
                        {
                           s.setCameFrom(current);
                           stack.Push(s);
                        }
                    }
                }
            }
        }

        protected override Solution<T> backTrace(State<T> s)
        {
            Solution<State<T> > sol = new Solution<State<T>>();
            sol.buildSolution(s);
            return sol;
        }
    }
}
