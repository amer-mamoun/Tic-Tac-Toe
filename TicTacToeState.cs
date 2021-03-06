﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToeState : IState, ICloneable
    {
        public const byte BOARDSIZE = 10;
        const byte winnerCount = 5;

        public int player = 1; // 1 or -1
        public int[,] board = new int[BOARDSIZE, BOARDSIZE]; // game board
        public int x, y = 0; // the position of the last step

        public TicTacToeState()
        {
            player = 0;
            board = new int[BOARDSIZE, BOARDSIZE];
        }




        /// <summary>
        /// 0 - not a goal
        /// -1/1 - player won
        /// 2 - even
        /// </summary>
        /// <returns></returns>
        public int isGoal()
        {
            // check if a player won
            byte counter = 0;

            // horizontal
            for (int i = x; i > -1; i--)
            {
                if (player != board[i, y]) break;
                counter++;
            }
            for (int i = x; i < BOARDSIZE; i++)
            {
                if (player != board[i, y]) break;
                counter++;
            }
            if (counter >= winnerCount) return player;
            counter = 0;

            // vertical
            for (int i = y; i > -1; i--)
            {
                if (player != board[x, i]) break;
                counter++;
            }
            for (int i = y; i < BOARDSIZE; i++)
            {
                if (player != board[x, i]) break;
                counter++;
            }
            if (counter >= winnerCount) return player;
            counter = 0;

            // first diagonal
            for (int i = 0; i <= winnerCount; i++)
            {
                if (x - i < 0 || y - i < 0)
                    break;

                if (player != board[x - i, y - i])
                    break;
                counter++;

            }

            for (int i = 0; i <= winnerCount; i++)
            {
                if (x + i > BOARDSIZE || y + i > BOARDSIZE)
                    break;

                if (player != board[x + i, y + i])
                    break;
                counter++;

            }
            if (counter >= winnerCount) return player;
            counter = 0;

            // seconed diagonal
            for (int i = 0; i <= winnerCount; i++)
            {
                if (x + i > BOARDSIZE || y - i < 0)
                    break;

                if (player != board[x + i, y - i])
                    break;
                counter++;
            }

            for (int i = 0; i <= winnerCount; i++)
            {
                if (x - i < 0 || y + i > BOARDSIZE)
                    break;

                if (player != board[x - i, y + i])
                    break;
                counter++;
            }
            if (counter >= winnerCount) return player;

            // check if it's a tie

            for (int i = 0; i < BOARDSIZE; i++)
            {
                for (int j = 0; j < BOARDSIZE; j++)
                {
                    if (board[i, j] == 0) return 2;
                }
            }
            return 0;

        }

        public bool isValid()
        {
            int count1 = 0;
            int count2 = 0;
            // x,y are inside the board
            if (!((x >= 0 && x < BOARDSIZE) && (y >= 0 && y < BOARDSIZE)))
                return false;
            // the board only contains -1, 1, 0
            for (int i = 0; i < BOARDSIZE; i++)
            {
                for (int j = 0; j < BOARDSIZE; j++)
                {
                    if (board[i, j] < -1 && board[i, j] > 1)
                        return false;
                    if (board[i, j] == -1)
                        count1++;
                    else if (board[i, j] == 1)
                        count2++;
                }
            }
            // difference between -1 and 1 count
            if (Math.Abs(count1 - count2) > 1)
                return false;

            return true;
        }

        public double Heuristics
        {
            get
            {
                double h = 0;
                // horizontal
                for (int i = x; i > -1; i--)
                {
                    if (player == board[i, y])
                    {
                        h += 2;
                    }else if(board[i, y] == 0)
                    {
                        h++;
                    }
                }
                for (int i = x; i < BOARDSIZE; i++)
                {
                    if (player != board[i, y])
                    {
                        if (player == board[i, y])
                        {
                            h += 2;
                        }
                        else if (board[i, y] == 0)
                        {
                            h++;
                        }
                    }
                }

                // vertical
                for (int i = y; i > -1; i--)
                {
                    if (player == board[i, y])
                    {
                        h += 2;
                    }
                    else if (board[i, y] == 0)
                    {
                        h++;
                    }
                }
                for (int i = y; i < BOARDSIZE; i++)
                {
                    if (player == board[i, y])
                    {
                        h += 2;
                    }
                    else if (board[i, y] == 0)
                    {
                        h++;
                    }
                }
     

                // first diagonal
                for (int i = 0; i <= winnerCount; i++)
                {
                    if (x - i < 0 || y - i < 0)
                        break;
                    if (player == board[x - i, y - i])
                    {
                        h += 2;
                    }
                    else if (board[x - i, y - i] == 0)
                    {
                        h++;
                    }
                }

                for (int i = 0; i <= winnerCount; i++)
                {
                    if (x + i >= BOARDSIZE || y + i >= BOARDSIZE)
                        break;

                    if (player == board[x + i, y + i])
                    {
                        h += 2;
                    }
                    else if (board[x + i, y + i] == 0)
                    {
                        h++;
                    }

                

                }

                // seconed diagonal
                for (int i = 0; i <= winnerCount; i++)
                {
                    if (x + i >= BOARDSIZE || y - i < 0)
                        break;
                    if (player == board[x + i, y - i])
                    {
                        h += 2;
                    }
                    else if (board[x + i, y - i] == 0)
                    {
                        h++;
                    }
                }

                for (int i = 0; i <= winnerCount; i++)
                {
                    if (x - i < 0 || y + i >= BOARDSIZE)
                        break;

                    if (player == board[x - i, y + i])
                    {
                        h += 2;
                    }
                    else if (board[x - i, y + i] == 0)
                    {
                        h++;
                    }
                }
                return h;
            }
        }

        public override bool Equals(object obj)
        {
            TicTacToeState otherState = (obj as TicTacToeState);
            if (player != otherState.player) return false;
            if (x != otherState.x || y != otherState.y) return false;

            for (int i = 0; i < BOARDSIZE; i++)
            {
                for (int j = 0; j < BOARDSIZE; j++)
                {
                    if (board[i, j] != otherState.board[i, j])
                        return false;
                }
            }
            return true;
        }

        public object Clone()
        {
            TicTacToeState newState = new TicTacToeState();
            newState.player = player;
            newState.x = x;
            newState.y = y;

            for (int i = 0; i < BOARDSIZE; i++)
            {
                for (int j = 0; j < BOARDSIZE; j++)
                {
                    newState.board[i, j] = board[i, j];
                }
            }
            return newState;
        }
    }
}
