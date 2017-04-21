using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace ClassLibrary1
{
    /// <summary>
    /// An abstract class for a searcher that uses a priority queue.
    /// </summary>
    /// <typeparam name="T"> To be generic </typeparam>
    public abstract class PriorityQueueSearcher<T> : Searcher<T>
    {
        /// <summary>
        /// The priority queue used for the algorithm.
        /// </summary>
        protected SimplePriorityQueue<State<T>, double> openList;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected PriorityQueueSearcher()
        {
            openList = new SimplePriorityQueue<State<T>, double>();
        }

        /// <summary>
        /// Pops from the open list.
        /// </summary>
        /// <returns>
        /// Returns a state </returns>
        protected State<T> PopOpenList()
        {
            EvaluatedNodes++;
            return openList.Dequeue();
        }

        /// <summary>
        /// Adds to the open list.
        /// </summary>
        /// <param name="s"> The state to be added </param>
        protected void AddToOpenList(State<T> s)
        {
            openList.Enqueue(s, s.GetCost());
        }
        
        // a property of openList 
        public int OpenListSize { // it is a read-only property :) 
            get { return openList.Count; }
        }

        /// <summary>
        /// Checks if the open list contains a state.
        /// </summary>
        /// <param name="s"> The state we are checking </param>
        /// <returns>
        /// True or false</returns>
        protected bool OpenContains(State<T> s)
        {
            return openList.Contains(s);
        }
    }
}
