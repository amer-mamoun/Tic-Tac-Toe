using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interface to access the state level functions
    /// </summary>
    interface IState
    {
        /// <summary>
        /// Checking if the current state is a goal state or not.
        /// </summary>
        /// <returns>Bool value that indicates if it is a goal state or not.</returns>
        int isGoal();

        /// <summary>
        /// Checking if the current state is valid
        /// </summary>
        /// <returns>Bool value that indicate that the state is valid or not.</returns>
        bool isValid();
        int Heuristics
        {
            get;
        }
    }
}
