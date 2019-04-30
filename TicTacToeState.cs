using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class TicTacToeState : IState
    {
        int player = 1; // 1 or -1
        int[,] board = new int[10, 10]; // game board
        int x, y = 0; // postion of the last step
        public bool isGoal()
        {
            throw new NotImplementedException();
        }

        public bool isValid()
        {
            throw new NotImplementedException();
        }
        public int Heuristics
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
