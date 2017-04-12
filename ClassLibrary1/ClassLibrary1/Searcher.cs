﻿using System;

public abstract class Searcher<T> : ISearcher<T>
{
    private int evaluatedNodes = 0;
    // ISearcher’s methods:
        int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        protected abstract Solution backTrace(State<T> n); 

        public abstract Solution search(ISearchable<T> searchable);
}