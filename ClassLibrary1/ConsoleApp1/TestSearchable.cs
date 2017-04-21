
namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using ClassLibrary1;

    /// <summary>
    /// The test searchable.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the searchable
    /// </typeparam>
    public class TestSearchable<T> : ISearchable<T>
    {
        /// <summary>
        /// The from.
        /// </summary>
        private State<T> from, to;

        /// <summary>
        /// The adj.
        /// </summary>
        Dictionary<State<T>, List<State<T>>> adj;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestSearchable{T}"/> class.
        /// </summary>
        /// <param name="from">
        /// The from. the start node
        /// </param>
        /// <param name="to">
        /// The to. the destination node 
        /// </param>
        /// <param name="adj">
        /// The list of neighbors
        /// </param>
        public TestSearchable(State<T> from, State<T> to, Dictionary<State<T>, List<State<T>>> adj)
        {
            this.from = from;
            this.to = to;
            this.adj = adj;
        }

        /// <summary>
        /// The get initial state.
        /// </summary>
        /// <returns>
        /// The <see cref="State"/>.
        /// </returns>
        public State<T> GetInitialState()
        {
            return from;
        }

        /// <summary>
        /// The get goal state.
        /// </summary>
        /// <returns>
        /// The <see cref="State"/>.
        /// </returns>
        public State<T> GetGoalState()
        {
            return to;
        }

        /// <summary>
        /// The get all possible states.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<State<T>> GetAllPossibleStates(State<T> s)
        {
            List<State<T>> states = null;
            
            // if found the vertex
            if (adj.ContainsKey(s))
            {
                states = adj[s];
            }

            // if vertex does not exist or no neighbors found
            return states ?? (new List<State<T>>());
        }

        /// <summary>
        /// The get solution.
        /// </summary>
        /// <returns>
        /// The <see cref="Solution"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Solution<T> GetSolution()
        {
            throw new NotImplementedException();
        }
    }
}