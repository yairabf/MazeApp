﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class BFS<T> : Searcher<T>
    {
        public override Solution search(ISearchable<T> searchable)
        { 
            // Searcher's abstract method overriding
            addToOpenList(searchable.getInitialState()); // inherited from Searcher
            HashSet<State<T> > closed = new HashSet<State<T> >();
            while (OpenListSize > 0) {
                    State<T> n = popOpenList();  // inherited from Searcher, removes the best state
                closed.Add(n);
                if (n.Equals(searchable.getGoalState() ))
                    return backTrace(); // private method, back traces through the parents
                                        // calling the delegated method, returns a list of states with n as a parent
                List<State<T> > succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors) {
                    if (!closed.Contains(s) && !openContains(s))
                    {
                        // s.setCameFrom(n);  // already done by getSuccessors
                        addToOpenList(s);
                    }
                    State<T> cameFrom = s.getCameFrom();
                    if(!openContains(s))
                    {
                        addToOpenList(s);
                    }
                    if((n.getCost() + s.getCost()) < (cameFrom.getCost() + s.getCost()));
                    {
                       s.setCost(n.getCost() + s.getCost());
                    }
                    
                } 
            }
            Console.WriteLine("have not reached the goal");
            return ;
        }
    }

    public override Solution backTrace()
    {
        return 
    } 
}
