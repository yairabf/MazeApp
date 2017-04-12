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
                        if (!closed.Contains(s) && !openContains(s))
                        {
                            // s.setCameFrom(n);  // already done by getSuccessors
                            addToOpenList(s);
                        }
                        State<T> cameFrom = s.getCameFrom();
                    }
            }
        }

        protected override Solution<T> backTrace(State<T> s)
        {
            
        }
    }
}
