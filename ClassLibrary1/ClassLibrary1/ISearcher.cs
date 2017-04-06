using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ISearcher<T>
    {
        // the search method 
        Solution search (ISearchable<T> searchable);
        
        // get how many nodes were evaluated by the algorithm 
        int getNumberOfNodesEvaluated();
    }
}
