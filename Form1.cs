using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            NegaMax newGame = new NegaMax();

            //GraphNode newState = PutOperator.operatorList[2].Apply (new TicTacToeState());

            //GraphNode newState = newGame.recommend();
            //drawState(newState);
            GraphNode newState2 = newGame.recommend();
            drawState(newState2);
        }
        private void drawState(GraphNode currNode)
        {
            boardLbl.Text = "";
            string boardstr = "";
            for (int i = 0; i < TicTacToeState.BOARDSIZE; i++)
            {
                for (int j = 0; j < TicTacToeState.BOARDSIZE; j++)
                {
                    if (currNode.currentState.board[i, j] == 0)
                        boardstr += "_";
                    else if (currNode.currentState.board[i, j] == -1)
                        boardstr += "X";
                    else if (currNode.currentState.board[i, j] == 1)
                        boardstr += "O";

                }
                boardstr += "\n";
            }
            //boardLbl.TabIndex = boardstr;
        }
    }
}
