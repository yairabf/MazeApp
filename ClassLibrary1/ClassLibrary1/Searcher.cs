using ClassLibrary1;
using System;
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

        public abstract Solution<T> Search(ISearchable<T> searchable);

        protected abstract Solution<T> BackTrace(State<T> n);
    }
}
