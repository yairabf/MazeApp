
namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// A class that implements the best first search algorithm
    /// on a searchable object.
    /// </summary>
    /// <typeparam name="T"> Is for the function to be generic</typeparam>
    public class Bfs<T> : PriorityQueueSearcher<T>
    {
        /// <summary>
        /// A function that performs the search itself.
        /// </summary>
        /// <param name="searchable"> Is the searchable object we search on</param>
        /// <returns>
        /// A solution from starting point to the end</returns>
        public override ISolution<T> Search(ISearchable<T> searchable)
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
                    BackTrace(n, searchable); // private method, back traces through the parents
                    // calling the delegated method, returns a list of states with n as a parent
                    return searchable.GetSolution();
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

        /// <summary>
        /// A private function that creates a backtrace from the solution
        /// </summary>
        /// <param name="n"> Is the goal state</param>
        /// <param name="s"> Is the object we are searching on</param>
        protected override void BackTrace(State<T> n, ISearchable<T> s)
        {
            s.GetSolution().BuildSolution(n, EvaluatedNodes);
            //Console.WriteLine(s.GetSolution().ToString());
        }
    }
        
}
