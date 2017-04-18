using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace ClassLibrary1
{
    public abstract class PriorityQueueSearcher<T> : Searcher<T>
    {
        protected SimplePriorityQueue<State<T>, double> openList;

        public PriorityQueueSearcher()
        {
            openList = new SimplePriorityQueue<State<T>, double>();
        }
        protected State<T> PopOpenList()
        {
            EvaluatedNodes++;
            return openList.Dequeue();
        }

        protected void AddToOpenList(State<T> s)
        {
            openList.Enqueue(s, s.GetCost());
        }
        
        // a property of openList 
        public int OpenListSize { // it is a read-only property :) 
            get { return openList.Count; }
        }

        protected bool OpenContains(State<T> s)
        {
            return openList.Contains(s);
        }
    }
}
