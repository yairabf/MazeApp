using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class State<T>
    {
        private T _state;    // the state represented by a string
        private double _cost;     // cost to reach this state (set by a setter)
        private State<T> _cameFrom;  // the state we came from to this state (setter)

        public State(T state)    // CTOR 
        {
            this._state = state;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as State<T>);
        }

        public bool Equals(State<T> s) // we override Object's Equals method 
        {
            if (s == null)
                return false;
            return _state.Equals(s._state);
        } // ...

        public override int GetHashCode()
        {
            return _state.GetHashCode();
        }

        public double GetCost()
        {
            return this._cost;
        }

        public void SetCost(double c)
        {
            this._cost = c;
        }

        public State<T> GetCameFrom()
        {
            return this._cameFrom;
        }

        public void SetCameFrom(State<T> s)
        {
            this._cameFrom = s;
        }

        public String ToString()
        {
            return _state.ToString();
        }

        public T GetState()
        {
            return this._state;
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
