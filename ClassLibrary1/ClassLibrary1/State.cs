﻿using System;
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
        }


        public double getCost()
        {
            return cost;
        }
    }

}
