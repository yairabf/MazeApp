

namespace ClassLibrary1
{
    /// <summary>
    /// The solution object represent a route between of two nodes.
    /// </summary>
    /// <typeparam name="T">
    /// The Type of the State inside the solution
    /// </typeparam>
    public abstract class Solution<T> : ISolution<T>
    {
        /// <summary>
        /// The nodes evaluated.
        /// </summary>
        protected int NodesEvaluated;

        /// <summary>
        /// Initializes a new instance of the <see cref="Solution{T}"/> class.
        /// </summary>
        public Solution()
        {
            NodesEvaluated = 0;
        }

        /// <summary>
        /// The build solution.
        /// </summary>
        /// <param name="goal">
        /// The goal.
        /// </param>
        /// <param name="nodes">
        /// The nodes.
        /// </param>
        public abstract void BuildSolution(State<T> goal, int nodes);

        /// <summary>
        /// The set node evaluated.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        public void SetNodeEvaluated(int node)
        {
            this.NodesEvaluated = node;
        }

        /// <summary>
        /// The get node evaluated.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetNodeEvaluated()
        {
            return this.NodesEvaluated;
        }

        /// <summary>
        /// The print solution.
        /// </summary>
        public abstract void PrintSolution();

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public abstract override string ToString();


    }
}
