using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// An interface for the searchable items.
    /// </summary>
    /// <typeparam name="T"> Generics </typeparam>
    public interface ISearchable<T>
    {
        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The initial state.</returns>
        State<T> GetInitialState();

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The goal state </returns>
        State<T> GetGoalState();

        /// <summary>
        /// Getter.
        /// </summary>
        /// <param name="s"></param>
        /// <returns> 
        /// Gets all possible states </returns>
        List<State<T>> GetAllPossibleStates(State<T> s);

        /// <summary>
        /// Returns the solution.
        /// </summary>
        /// <returns>
        /// The solution </returns>
        Solution<T> GetSolution();

    }

}
