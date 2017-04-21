using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Algorithms
{
    /// <summary>
    /// A class that implements the depth first search algorithm
    /// on a searchable object
    /// </summary>
    /// <typeparam name="T"> Is for the function to be generic</typeparam>
    public class Dfs<T> : Searcher<T>
    {
        public override ISolution<T> Search(ISearchable<T> searchable)
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
                    BackTrace(current, searchable);
                    return searchable.GetSolution();
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

        /// <summary>
        /// A private function that creates a backtrace from the solution
        /// </summary>
        /// <param name="n"> Is the goal state</param>
        /// <param name="s"> Is the object we are searching on</param>
        protected override void BackTrace(State<T> n, ISearchable<T> searchable)
        {
            searchable.GetSolution().BuildSolution(n, EvaluatedNodes);
        }
    }
}
