using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai.Model
{
    class GameRules
    {
        static public int connect4Done(Board board)
        {
            int winner;

            winner = horizontalWin(board);
            if (winner != 0) { return winner; }

            winner = verticalWin(board);
            if (winner != 0) { return winner; }

            winner = oblicousAscWin(board);
            if (winner != 0) { return winner; }

            winner = oblicousDescWin(board);
            if (winner != 0) { return winner; }

            return 0;
        }

        static private int horizontalWin(Board board)
        {
            int countNext;
            int lastVal;
            for (int row=0; row < board.rows; row++)
            {
                countNext = 0;
                lastVal = board.getVal(0, row);
                for (int col = 1; col < board.columns; col++)
                {
                    if (lastVal == board.getVal(col, row) && lastVal != 0) { countNext++; }
                    else { countNext = 0; }
                    lastVal = board.getVal(col, row);
                    if (countNext == 3) return lastVal;
                }
            }
            return 0;
        }

        static private int verticalWin(Board board)
        {
            int countNext;
            int lastVal;
            for (int col = 0; col < board.columns; col++)
            {
                countNext = 0;
                lastVal = board.getVal(col, 0);
                for (int row = 1; row < board.rows; row++)
                {
                    if (lastVal == board.getVal(col, row) && lastVal != 0) { countNext++; }
                    else { countNext = 0; }
                    lastVal = board.getVal(col, row);
                    if (countNext == 3) return lastVal;
                }
            }
            return 0;
        }

        static private int oblicousAscWin(Board board)
        {
            int countNext = 0;
            int oblicousLines = board.columns + board.rows - 1;
            int repetitionMaxOffset = Math.Abs(board.columns-board.rows);
            int col, row, startRow = 0, startCol = 0, maxOffset = 0, indexRepetitionMax = 0;
            for (int line = 3; line < oblicousLines-3; line++)
            {
                if (line < board.rows) { startRow = line; }
                else { startCol++; }
                int lastVal = board.getVal(startCol, startRow);

                if (line < Math.Min(board.columns, board.rows)) { maxOffset = line; }
                else if (indexRepetitionMax < repetitionMaxOffset) { indexRepetitionMax++; }
                else { maxOffset--; }

                countNext = 0;
                for (int offset = 1; offset <= maxOffset; offset++)
                {
                    col = startCol + offset;
                    row = startRow - offset;
                    if (lastVal == board.getVal(col, row) && lastVal != 0) {
                        countNext++;
                    }
                    else { countNext = 0; }
                    lastVal = board.getVal(col, row);
                    if (countNext == 3) return lastVal;
                }
            }
            return 0;
        }

        static private int oblicousDescWin(Board board)
        {
            int countNext = 0;
            int oblicousLines = board.columns + board.rows - 1;
            int repetitionMaxOffset = Math.Abs(board.columns - board.rows);
            int col, row, startRow = board.rows-1, startCol = 0, maxOffset = 0, indexRepetitionMax = 0;
            for (int line = 3; line < oblicousLines - 3; line++)
            {
                if (line < board.columns) { startCol = line; }
                else { startRow--; }
                int lastVal = board.getVal(startCol, startRow);

                if (line < Math.Min(board.columns, board.rows)) { maxOffset = line; }
                else if (indexRepetitionMax < repetitionMaxOffset) { indexRepetitionMax++; }
                else { maxOffset--; }

                countNext = 0;
                for (int offset = 1; offset <= maxOffset; offset++)
                {
                    col = startCol - offset;
                    row = startRow - offset;
                    if (lastVal == board.getVal(col, row) && lastVal != 0) {
                        countNext++;
                    }
                    else { countNext = 0; }
                    lastVal = board.getVal(col, row);
                    if (countNext == 3) return lastVal;
                }
            }
            return 0;
        }
    }
}
