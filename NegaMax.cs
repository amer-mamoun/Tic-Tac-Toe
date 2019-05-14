using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class NegaMax
    {
        const int maxDepth = 3;
        GraphNode currentNode;
        GraphNode proposedNode;

        public NegaMax()
        {
            currentNode = new GraphNode(new TicTacToeState(), null, null, 0);
        }

        /// <summary>
        /// Method that returns: which way the  current player should go next.
        /// </summary>
        /// <returns></returns>
        public GraphNode recommend()
        {
            Expand(currentNode, 0);
            return proposedNode;

        }

        /// <summary>
        /// Method for recursively expand a graphnode.
        /// </summary>
        /// <param name="node">the nood to expand</param>
        /// <param name="depth">how deep we are in the subtree, in our recursive call</param>
        private void Expand(GraphNode node, int depth)
        {
            if (depth >= maxDepth || node.currentState.isGoal() != 0)
            {
                node.weight = node.currentState.Heuristics;
            }
            else
            {
                double maxWeight = double.MinValue; // the max weight of the current child nodes.

                foreach (PutOperator cuurOperator in PutOperator.operatorList)
                {
                    {
                        if (cuurOperator.Precondition(node.currentState))
                        {
                            TicTacToeState newState = cuurOperator.Apply(node.currentState);
                            GraphNode newNode = new GraphNode(newState, cuurOperator, node, 0);
                            Expand(newNode, depth + 1);
                            if (newNode.currentState.player != node.currentState.player)
                                newNode.weight = -newNode.weight;
                            if(newNode.weight > maxWeight)
                            {
                                maxWeight = newNode.weight;
                                if (depth == 0) proposedNode = newNode;
                            }
                        }
                    }
                }
                node.weight = maxWeight;
            }
        }
    }
}
