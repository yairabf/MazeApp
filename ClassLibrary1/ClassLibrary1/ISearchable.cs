using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface ISearchable<T>
    {
        State<T> GetInitialState();

        State<T> GetGoalState();

        List<State<T>> GetAllPossibleStates(State<T> s);

    }

}
