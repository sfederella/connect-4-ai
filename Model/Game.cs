using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai.Model
{
    class Game
    {
        Board board;
        Players players;

        public Game(Board board, Players players)
        {
            this.board = board;
            this.players = players;
        }

        public void play() { play(1); }

        public void play(int times)
        {
            for(int i=0; i< times; i++)
            {
                Board gameBoard = board.clone();
                Player turnPlayer;
                int winner = 0;

                while (winner == 0 && gameBoard.hasSpace())
                {
                    turnPlayer = players.next();

                    Console.Clear();
                    Console.WriteLine("Partida nro "+(i+1)+"\n");
                    Console.WriteLine(gameBoard.getStringBoard());

                    gameBoard.selectColumn(turnPlayer.getSelectedCol(gameBoard), turnPlayer.getPlayerNum());
                    winner = gameBoard.getStatus();
                }
                Console.Clear();
                Console.WriteLine("Partida nro " + i + "\n");
                Console.WriteLine(gameBoard.getStringBoard());
            }
        }


    }
}
