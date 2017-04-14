using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai.Model
{
    class Board
    {
        public int columns;
        public int rows;
        private int[,] boardMatrix;

        public Board(int columns, int rows)
        {
            this.columns = columns;
            this.rows = rows;
            boardMatrix = new int[columns, rows];
            for (int col=0; col<columns; col++)
            {
                for(int row=0; row<rows; row++)
                {
                    boardMatrix[col,row] = 0;
                }
            }
        }

        public Board(int columns, int rows, int[,] boardMatrix)
        {
            this.columns = columns;
            this.rows = rows;
            this.boardMatrix = (int[,]) boardMatrix.Clone();
        }

        public int getVal(int col, int row)
        {
            return boardMatrix[col, row];
        }

        public string getStringBoard()
        {
            string boardStr = "";
            for (int row = 0; row < rows; row++)
            {
                boardStr += "| ";
                for (int col = 0; col < columns; col++)
                {
                    switch (boardMatrix[col, row])
                    {
                        case 1:
                            boardStr += "X | ";
                            break;
                        case -1:
                            boardStr += "O | ";
                            break;
                        default:
                            boardStr += "  | ";
                            break;
                    }
                }
                boardStr += "\n";
            }
            for (int col = 1; col <= columns; col++)
            {
                boardStr += "  "+ col + " ";
            }
            boardStr += "\n";
            return boardStr;
        }

        public void selectColumn(int col, int player)
        {
            for (int row = rows-1; row >= 0; row--) {
                if(boardMatrix[col,row] == 0)
                {
                    boardMatrix[col, row] = player;
                    break;
                }
                if (row == 0)
                {
                   throw new ArgumentException();
                }
            }
        }

        public bool colHasSpace(int col)
        {
            for (int row = rows - 1; row >= 0; row--)
            {
                if (boardMatrix[col, row] == 0) { return true; }
            }
            return false;
        }

        public Board clone()
        {
            return new Board(columns, rows, boardMatrix);
        }

    }
}
