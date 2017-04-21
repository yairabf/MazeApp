

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A class representing a state.
    /// </summary>
    /// <typeparam name="T"> Generics</typeparam>
    public class State<T>
    {
        /// <summary>
        /// The state represented by a string
        /// </summary>
        private T _state;
        
        /// <summary>
        /// cost to reach this state (set by a setter)
        /// </summary>
        private double _cost;
       
        /// <summary>
        /// the state we came from to this state (setter)
        /// </summary>
        private State<T> _cameFrom;  

        /// <summary>
        /// Initializes a new instance of the <see cref="State{T}"/> class. 
        /// </summary>
        /// <param name="state">
        /// </param>
        public State(T state)    
        {
            this._state = state;
        }

        /// <summary>
        /// Equals, override.
        /// </summary>
        /// <param name="obj"> The object to compare with.</param>
        /// <returns>
        /// True if equal, otherwise false</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as State<T>);
        }


        /// <summary>
        /// The equals method.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(State<T> s)
        {
            if (s == null)
            {
                return false;
            }
            return _state.Equals(s._state);
        } 

        /// <summary>
        /// Getter for the hash code.
        /// </summary>
        /// <returns> The hash code </returns>
        public override int GetHashCode()
        {
            return _state.GetHashCode();
        }

        /// <summary>
        /// Getter for the cost.
        /// </summary>
        /// <returns>
        /// The cost</returns>
        public double GetCost()
        {
            return this._cost;
        }

        /// <summary>
        /// Setter for the cost.
        /// </summary>
        /// <param name="c"> The new cost </param>
        public void SetCost(double c)
        {
            this._cost = c;
        }

        /// <summary>
        /// Getter for the state that point to current state.
        /// </summary>
        /// <returns>
        /// Gets the father state </returns>
        public State<T> GetCameFrom()
        {
            return this._cameFrom;
        }

        /// <summary>
        /// Setter for the state.
        /// </summary>
        /// <param name="s">
        /// Sets the father state </param>
        public void SetCameFrom(State<T> s)
        { 
            this._cameFrom = s;
        }

        /// <summary>
        /// To string 
        /// </summary>
        /// <returns>
        /// The state as a string </returns>
        public override string ToString()
        {
            return _state.ToString();
        }

        /// <summary>
        /// Getter for the state.
        /// </summary>
        /// <returns>
        /// The state </returns>
        public T GetState()
        {
            return this._state;
        }
    }
}
