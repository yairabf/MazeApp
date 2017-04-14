using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace ConsoleApp1
{
    class TestSearchable<T> : ISearchable<T>
    {
        private State<T> from, to;
        Dictionary<State<T>, List<State<T>>> adj;

        public TestSearchable(State<T> from, State<T> to, Dictionary<State<T>, List<State<T>>> adj)
        {
            this.from = from;
            this.to = to;
            this.adj = adj;
        }

        public State<T> GetInitialState()
        {
            return from;
        }

        public State<T> GetGoalState()
        {
            return to;
        }

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

        public Solution<T> GetSolution()
        {
            throw new NotImplementedException();
        }
    }
}