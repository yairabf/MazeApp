namespace ClassLibrary1.Algorithms
{
    /// <summary>
    /// An abstract class for all searchers.
    /// </summary>
    /// <typeparam name="T"> Generics</typeparam>
    public abstract class Searcher<T> : ISearcher<T>
    {
        /// <summary>
        /// The num of nodes evaluated in a search.
        /// </summary>
        protected int EvaluatedNodes = 0;
        
        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The number of nodes evaluated</returns>
        public int GetNumberOfNodesEvaluated()
        {
            return EvaluatedNodes;
        }

        /// <summary>
        /// Abstract method, searches a searchable.
        /// </summary>
        /// <param name="searchable"> The object to search on </param>
        /// <returns>
        /// A solution path </returns>
        public abstract ISolution<T> Search(ISearchable<T> searchable);


        /// <summary>
        /// Backs the trace.
        /// </summary>
        /// <param name="n">The n.</param>
        protected abstract void BackTrace(State<T> n, ISearchable<T> searchable);
    }
}
