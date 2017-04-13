using ClassLibrary1;
using System;
namespace ClassLibrary1
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        protected int evaluatedNodes = 0;
        
        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        public abstract Solution<T> Search(ISearchable<T> searchable);

        protected abstract Solution<T> backTrace(State<T> n);
    }
}
