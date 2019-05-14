using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class GraphNode
    {
        public TicTacToeState currentState;
        PutOperator currentOperator;
        GraphNode parentNode;
        public double weight = 0;

        public GraphNode(TicTacToeState newState, PutOperator newOperator, GraphNode parentNode, double newWeight)
        {
            currentState = newState;
            currentOperator = newOperator;
            this.parentNode = parentNode;
            weight = newWeight;
        }
    }
}
