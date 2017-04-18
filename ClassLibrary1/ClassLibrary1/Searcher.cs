using ClassLibrary1;
using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        protected int EvaluatedNodes = 0;
        
        // ISearcher’s methods:
        public int GetNumberOfNodesEvaluated()
        {
            return EvaluatedNodes;
        }

        public abstract ISolution<T> Search(ISearchable<T> searchable);


        /// <summary>
        /// Backs the trace.
        /// </summary>
        /// <param name="n">The n.</param>
        protected abstract void BackTrace(State<T> n, ISearchable<T> searchable);
    }
}
