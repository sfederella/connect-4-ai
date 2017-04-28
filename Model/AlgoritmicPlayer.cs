using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai.Model
{
    class AlgoritmicPlayer : Player
    {
        double[] scores;
        int playerNum;
        int maxDepth;

        public AlgoritmicPlayer(int maxDepth)
        {
            this.maxDepth = maxDepth;
        }

        public int getPlayerNum()
        {
            return playerNum;
        }

        public void setPlayerNum(int playerNum)
        {
            this.playerNum = playerNum;
        }

        public int getSelectedCol(Board board)
        {
            Console.Write("Pensando...");
            scores = new double[board.columns];
            for(var i=0; i< scores.Length; i++) { scores[i] = 0; }
            rateColumns(board);
            return getBestRatedCol();
        }

        private int getBestRatedCol()
        {
            double maxValue = scores.Max();
            List<int> maxIndexes = new List<int>();
            for (int i=0; i < scores.Length; i++)
            {
                if (scores[i]==maxValue)
                {
                    maxIndexes.Add(i);
                }
            }
            if(maxIndexes.Count == 1)
            {
                return maxIndexes[0];
            } else
            {
                return maxIndexes[new Random().Next(0, maxIndexes.Count)];
            }
        }

        private void rateColumns(Board board)
        {
            for (int col = 0; col < board.columns; col++)
            {
                if (board.colHasSpace(col))
                {
                    rateColumn(col, board.clone(), playerNum, col, 1, maxDepth);
                }
                else
                {
                    scores[col] = double.MinValue;
                } 
            }
        }

        private void rateColumn(int col, Board board, int nroPlayerTurn, int colReference, int level, int maxDepth)
        {
            board.selectColumn(col, nroPlayerTurn);
            int winner = board.getStatus();
            if(winner == 0)
            {
                if (level < maxDepth)
                {
                    for (int subcol = 0; subcol < board.columns; subcol++)
                    {
                        if (board.colHasSpace(subcol))
                        {
                            rateColumn(subcol, board.clone(), nroPlayerTurn * -1, colReference, level + 1, maxDepth);
                        }
                    }
                }
            }
            else if (winner == playerNum)
            {
                if (level == 1)
                {
                    scores[colReference] = double.MaxValue;
                }

            }
            else
            {
                if (level == 2)
                {
                    if (col != colReference)
                    {
                        scores[col] += double.MaxValue / board.columns;
                    }
                    else
                    {
                        scores[colReference] += -1 * double.MaxValue / board.columns;
                    }
                }
                scores[colReference] += (-1.0 / Math.Pow(level, 2));
            }
        }

    }
}
