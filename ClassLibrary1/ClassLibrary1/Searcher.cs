using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace ClassLibrary1
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        private SimplePriorityQueue<State<T>, double> openList;
        private int evaluatedNodes;

        public Searcher()
        {
            openList = new SimplePriorityQueue<State<T>, double>();
            evaluatedNodes = 0;
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
        
        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        public abstract Solution search(ISearchable<T> searchable);
    }
}
