 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// An interface for the searching objects.
    /// </summary>
    /// <typeparam name="T"> Generics </typeparam>
    public interface ISearcher<T>
    {
        /// <summary>
        /// A class that implements the depth first search algorithm
        /// on a searchable object
        /// </summary>
        /// <typeparam name="T"> Is for the function to be generic</typeparam>
        ISolution<T> Search (ISearchable<T> searchable);

        /// <summary>
        /// A private function that creates a backtrace from the solution
        /// </summary>
        /// <param name="n"> Is the goal state</param>
        /// <param name="s"> Is the object we are searching on</param>
        int GetNumberOfNodesEvaluated();
    }
}
