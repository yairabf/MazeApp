
namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bfs<T> : PriorityQueueSearcher<T>
    {
        public override Solution<T> Search(ISearchable<T> searchable)
        {
            // Searcher's abstract method overriding
            AddToOpenList(searchable.GetInitialState()); // inherited from Searcher
            HashSet<State<T>> closed = new HashSet<State<T>>();
            while (this.OpenListSize > 0)
            {
                State<T> n = PopOpenList();  // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.GetGoalState()))
                {
                    return BackTrace(n); // private method, back traces through the parents
                    // calling the delegated method, returns a list of states with n as a parent
                }

                List<State<T>> succerssors = searchable.GetAllPossibleStates(n);
                foreach (State<T> s in succerssors)
                {
                    //State<T> cameFrom = s.getCameFrom();
                    if (!closed.Contains(s) && !OpenContains(s))
                    {
                        s.SetCameFrom(n); // already done by getSuccessors
                        AddToOpenList(s);
                    }
                    else if (!OpenContains(s))
                    {

                        //openList.UpdatePriority(s, 5);
                        if ((n.GetCost() + 1) < (s.GetCost()))
                        {
                            s.SetCameFrom(n);
                            //s.SetCost(n.GetCost() + 1);
                            openList.UpdatePriority(s, s.GetCost());
                        }
                    }
                }
            }
            Console.WriteLine("have not reached the goal");
            return null;
        }
        protected override Solution<T> BackTrace(State<T> n)
        {
            Solution<T> solution = new Solution<T>();
            solution.BuildSolution(n);
            return solution;
        }
    }
        
}
