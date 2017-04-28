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

        public Board(int[,] boardMatrix)
        {
            this.boardMatrix = (int[,]) boardMatrix.Clone();
            columns = boardMatrix.GetLength(0);
            rows = boardMatrix.GetLength(1);
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

        public string getCSV(Player player)
        {
            int playerNum = player.getPlayerNum();
            string csv = "";
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    csv += "," + (boardMatrix[col, row] * playerNum);
                }
            }
            return csv.Substring(1);
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

        public bool hasSpace()
        {
            for (int col=0; col<columns; col++)
            {
                if (boardMatrix[col, 0] == 0) { return true; }
            }
            return false;
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
            return new Board(boardMatrix);
        }


        //Board Status
        public int getStatus()
        {
            int winner;

            winner = horizontalWin();
            if (winner != 0) { return winner; }

            winner = verticalWin();
            if (winner != 0) { return winner; }

            winner = oblicousAscWin();
            if (winner != 0) { return winner; }

            winner = oblicousDescWin();
            if (winner != 0) { return winner; }

            return 0;
        }

        private int horizontalWin()
        {
            int countNext;
            int lastVal;
            for (int row = 0; row < rows; row++)
            {
                countNext = 0;
                lastVal = getVal(0, row);
                for (int col = 1; col < columns; col++)
                {
                    if (lastVal == getVal(col, row) && lastVal != 0) { countNext++; }
                    else { countNext = 0; }
                    lastVal = getVal(col, row);
                    if (countNext == 3) return lastVal;
                }
            }
            return 0;
        }

        private int verticalWin()
        {
            int countNext;
            int lastVal;
            for (int col = 0; col < columns; col++)
            {
                countNext = 0;
                lastVal = getVal(col, 0);
                for (int row = 1; row < rows; row++)
                {
                    if (lastVal == getVal(col, row) && lastVal != 0) { countNext++; }
                    else { countNext = 0; }
                    lastVal = getVal(col, row);
                    if (countNext == 3) return lastVal;
                }
            }
            return 0;
        }

        private int oblicousAscWin()
        {
            int countNext = 0;
            int oblicousLines = columns + rows - 1;
            int repetitionMaxOffset = Math.Abs(columns - rows);
            int col, row, startRow = 0, startCol = 0, maxOffset = 0, indexRepetitionMax = 0;
            for (int line = 3; line < oblicousLines - 3; line++)
            {
                if (line < rows) { startRow = line; }
                else { startCol++; }
                int lastVal = getVal(startCol, startRow);

                if (line < Math.Min(columns, rows)) { maxOffset = line; }
                else if (indexRepetitionMax < repetitionMaxOffset) { indexRepetitionMax++; }
                else { maxOffset--; }

                countNext = 0;
                for (int offset = 1; offset <= maxOffset; offset++)
                {
                    col = startCol + offset;
                    row = startRow - offset;
                    if (lastVal == getVal(col, row) && lastVal != 0)
                    {
                        countNext++;
                    }
                    else { countNext = 0; }
                    lastVal = getVal(col, row);
                    if (countNext == 3) return lastVal;
                }
            }
            return 0;
        }

        private int oblicousDescWin()
        {
            int countNext = 0;
            int oblicousLines = columns + rows - 1;
            int repetitionMaxOffset = Math.Abs(columns - rows);
            int col, row, startRow = rows - 1, startCol = 0, maxOffset = 0, indexRepetitionMax = 0;
            for (int line = 3; line < oblicousLines - 3; line++)
            {
                if (line < columns) { startCol = line; }
                else { startRow--; }
                int lastVal = getVal(startCol, startRow);

                if (line < Math.Min(columns, rows)) { maxOffset = line; }
                else if (indexRepetitionMax < repetitionMaxOffset) { indexRepetitionMax++; }
                else { maxOffset--; }

                countNext = 0;
                for (int offset = 1; offset <= maxOffset; offset++)
                {
                    col = startCol - offset;
                    row = startRow - offset;
                    if (lastVal == getVal(col, row) && lastVal != 0)
                    {
                        countNext++;
                    }
                    else { countNext = 0; }
                    lastVal = getVal(col, row);
                    if (countNext == 3) return lastVal;
                }
            }
            return 0;
        }

    }
}
