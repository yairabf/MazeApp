

namespace ClassLibrary1
{
    /// <summary>
    /// An interface for the solutions of the searches.
    /// </summary>
    /// <typeparam name="T"> Generics solution </typeparam>
    public interface ISolution<T>
    {
        /// <summary>
        /// receives a goal state and builds the solution
        /// </summary>
        /// <param name="goal"> Where to get to </param>
        /// <param name="nodes"> Amount of nodes evaluated </param>
        void BuildSolution(State<T> goal, int nodes);

        /// <summary>
        /// Setter for the evaluated nodes.
        /// </summary>
        /// <param name="node"> Amount of nodes to set to </param>
        void SetNodeEvaluated(int node);

        /// <summary>
        /// Getter for the evaluated nodes.
        /// </summary>
        /// <returns>The amount of nodes evaluated </returns>
        int GetNodeEvaluated();

        /// <summary>
        /// Prints the solution.
        /// </summary>
        void PrintSolution();

        /// <summary>
        /// To string.
        /// </summary>
        /// <returns>
        /// The Solution as a string </returns>
        string ToString();

    }
}
