﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ISearchable<T>
    {
        State<T> getInitialState();

        State<T> getGoalState();

        List<State<T>> getAllPossibleStates(State<T> s);

    }

}
