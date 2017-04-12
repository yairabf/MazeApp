using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class BFS : Pr
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
                    return backTrace(n); // private method, back traces through the parents
                                        // calling the delegated method, returns a list of states with n as a parent
                List<State<T> > succerssors = searchable.getAllPossibleStates(n);
                foreach (State<T> s in succerssors) {
                    State<T> cameFrom = s.getCameFrom();
                    if (!closed.Contains(s) && !openContains(s))
                    {
                        // s.setCameFrom(n);  // already done by getSuccessors
                        addToOpenList(s);
                    }
                    else if(!openContains(s))
                    {
                        addToOpenList(s);
                    }
                    //openList.UpdatePriority(s, 5);
                    if((n.getCost() + 1) < (s.getCost()))
                    {
                       s.setCost(n.getCost() + 1);
                       open
                       
                    }
                } 
            }
            Console.WriteLine("have not reached the goal");
            return null;
        }
    }

    private override Solution backTrace(State<T> n)
    {
        Solution solution = new Solution();
        solution.buildSolution(n);
        return solution;
    } 
}
