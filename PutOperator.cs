using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class PutOperator
    {
        // coordinates
        int x, y;
        public static List<PutOperator> operatorList = new List<PutOperator>();

        public PutOperator(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        static PutOperator()
        {
            for (int i = 0; i < TicTacToeState.BOARDSIZE; i++)
            {
                for (int j = 0; j < TicTacToeState.BOARDSIZE; j++)
                {
                    operatorList.Add(new PutOperator(i, j));
                }
            }
        }

        public bool Precondition(TicTacToeState currentState)
        {
            if (!currentState.isValid())
            {
                return false;
            }
            if (x < 0 || y < 0 || x >= TicTacToeState.BOARDSIZE || y >= TicTacToeState.BOARDSIZE)
            {
                return false;
            }
            if (currentState.board[x, y] != 0)
            {
                return false;
            }
            return true;
        }

        public TicTacToeState Apply(TicTacToeState currentState)
        {
            TicTacToeState temp = (TicTacToeState)currentState.Clone();

            temp.board[x, y] = currentState.player;
            temp.player = currentState.player * -1;
            temp.x = x;
            temp.y = y;
            return temp;
        }
    }
}
