using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai.Model
{
    class StupidAlgoritmicPlayer : AlgoritmicPlayer
    {
        private double stupidity;

        public StupidAlgoritmicPlayer(int maxDepth, string resultsPath, double stupidity) : base(maxDepth, resultsPath)
        {
            this.stupidity = (stupidity > 1 ? 1 : (stupidity < 0 ? 0 : stupidity));
        }

        public override int getSelectedCol(Board board)
        {
            Random random = new Random();
            if (stupidity > random.NextDouble())
            {
                List<int> colsWithSpace = new List<int>();
                for (int col=0; col<board.columns; col++)
                {
                    if (board.colHasSpace(col))
                    {
                        colsWithSpace.Add(col);
                    }
                }
                return colsWithSpace[random.Next(0, colsWithSpace.Count)];
            }
            else
            {
                return base.getSelectedCol(board);
            }
        }

    }
}
