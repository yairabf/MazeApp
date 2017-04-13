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
        private SimplePriorityQueue<State<T>, double> openList;

        public PriorityQueueSearcher()
        {
            openList = new SimplePriorityQueue<State<T>, double>();
        }
        protected State<T> popOpenList()
        {
            evaluatedNodes++;
            return openList.Dequeue();
        }

        protected void addToOpenList(State<T> s)
        {
            openList.Enqueue(s, s.getCost());
        }
        
        // a property of openList 
        public int OpenListSize { // it is a read-only property :) 
            get { return openList.Count; }
        }

        protected bool openContains(State<T> s)
        {
            return openList.Contains(s);
        }

        //protected abstract Solution<T> backTrace(State<T> n); 

        //public abstract Solution<T> Search(ISearchable<T> searchable);
    }
}
