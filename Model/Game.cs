using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai.Model
{
    class Game
    {
        Board board;
        Players players;
        string resultsPath;

        public Game(Board board, Players players)
        {
            this.board = board;
            this.players = players;
            resultsPath = "";
        }

        public void play() { play(1); }

        public void play(int times)
        {
            for(int i=0; i< times; i++)
            {
                Board gameBoard = board.clone();
                Player turnPlayer;
                int winner = 0;
                int selectedCol;

                while (winner == 0 && gameBoard.hasSpace())
                {
                    turnPlayer = players.next();

                    Console.Clear();
                    Console.WriteLine("Partida nro " + (i + 1) + "\n");
                    Console.WriteLine(gameBoard.getStringBoard());
                    selectedCol = turnPlayer.getSelectedCol(gameBoard);
                    if (resultsPath != "")
                    {
                        saveResult(gameBoard, selectedCol, turnPlayer);
                    }
                    gameBoard.selectColumn(selectedCol, turnPlayer.getPlayerNum());
                    winner = gameBoard.getStatus();
                }
                Console.Clear();
                Console.WriteLine("Partida nro " + (i + 1) + "\n");
                Console.WriteLine(gameBoard.getStringBoard());
            }
        }

        public void setResultsPath(string path)
        {
            resultsPath = path;
        }

        private void saveResult(Board board, int selecteCol, Player player)
        {
            using (var w = new StreamWriter(resultsPath, true))
            {
                string line = board.getCSV(player) + "," + selecteCol;
                w.WriteLine(line);
                w.Flush();
            }
        }
    }
}
