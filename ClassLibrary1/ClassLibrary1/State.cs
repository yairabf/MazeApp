using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class State<T>
    {
        private T state;    // the state represented by a string 
        private double cost;     // cost to reach this state (set by a setter) 
        private State<T> cameFrom;  // the state we came from to this state (setter)

        public State(T state)    // CTOR 
        {
            this.state = state;
        }

        public bool Equals(State<T> s) // we override Object's Equals method 
        {
            return state.Equals(s.state);
        } // ...

        public double getCost()
        {
            return this.cost;
        }

        public void setCost(double c)
        {
            this.cost = c;
        }

        public State<T> getCameFrom()
        {
            return this.cameFrom;
        }

        public void setCameFrom(State<T> s)
        {
            this.cameFrom = s;
        }

        public String ToString()
        {
            return state.ToString();
        }

        public T getState()
        {
            return this.state;
        }

        /*public static class StatePool
        {
            private static HashSet<State<T>> references = new HashSet<State<T>>();

            public static State<T> getState(State<T> s)
            {
                if(references.Contains(s))
            }
        }*/

    }
}
