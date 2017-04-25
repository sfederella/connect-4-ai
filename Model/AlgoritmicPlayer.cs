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

        public AlgoritmicPlayer() { }

        public int getSelectedCol(Board board)
        {
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
            int maxDepth = 8;
            for (int col = 0; col < board.columns; col++)
            {
                if (board.colHasSpace(col))
                {
                    rateColumn(col, board.clone(), 1, col, 1, maxDepth);
                }
                else
                {
                    scores[col] = double.MinValue;
                } 
            }
        }

        private void rateColumn(int col, Board board, int player, int colReference, int level, int maxDepth)
        {
            board.selectColumn(col, player);
            int winner = GameRules.connect4Done(board);
            switch (winner)
            {
                case 1:
                    if (level == 1)
                    {
                        scores[colReference] = double.MaxValue;
                    }
                    break;
                case -1:
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
                    scores[colReference] += (-1.0 / Math.Pow(level,2));
                    break;
                default:
                    if (level < maxDepth)
                    {
                        for (int subcol = 0; subcol < board.columns; subcol++)
                        {
                            if (board.colHasSpace(subcol))
                            {
                                rateColumn(subcol, board.clone(), player * -1, colReference, level + 1, maxDepth);
                            }
                        }
                    }
                    break;
            }
        }

    }
}
