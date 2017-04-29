using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai.Model
{
    class AlgoritmicPlayer : Player
    {
        private double[] scores;
        private int playerNum;
        private int maxDepth;
        private string resultsPath;

        public AlgoritmicPlayer(int maxDepth, string resultsPath)
        {
            this.maxDepth = maxDepth;
            this.resultsPath = resultsPath;
            playerNum = 1;
        }

        public AlgoritmicPlayer(int maxDepth) : this(maxDepth,"") {}

        public int getPlayerNum()
        {
            return playerNum;
        }

        public void setPlayerNum(int playerNum)
        {
            this.playerNum = playerNum;
        }

        public virtual int getSelectedCol(Board board)
        {
            Console.Write("Pensando...");
            scores = new double[board.columns];
            for(var i=0; i< scores.Length; i++) { scores[i] = 0; }
            rateColumns(board);
            int selectedCol = getBestRatedCol();
            if (resultsPath != "")
            {
                saveResult(board, selectedCol);
            }
            return selectedCol;
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

        private void saveResult(Board board, int selectedCol)
        {
            using (var w = new StreamWriter(resultsPath, true))
            {
                string line = board.getCSV(this) + "," + selectedCol;
                w.WriteLine(line);
                w.Flush();
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
