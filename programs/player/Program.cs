using connect_4_ai.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect_4_ai
{
    class Program
    {
        /* ---- Parameters ---- */

        // Board: Complete with 1 or -1 (player 1 always starts)
        static Board board = new Board(new int[,] {
            { 0, 0, 0, 0, 0, 0 }, //1
            { 0, 0, 0, 0, 0, 0 }, //2
            { 0, 0, 0, 0, 0, 0 }, //3
            { 0, 0, 0, 0, 0, 0 }, //4
            { 0, 0, 0, 0, 0, 0 }, //5
            { 0, 0, 0, 0, 0, 0 }, //6
            { 0, 0, 0, 0, 0, 0 }  //7
        });

        // Number of games that will be played
        static int numGames = 100;

        // Path of the CSV file where the results will be saved
        static string datasetPath = "C:/Users/Santi/UTN/Inteligecia Artificial/connect-4-ai/Datasets/dataset.csv";

        /* ---- Program ---- */
        static void Main(string[] args)
        {
            Player player1 = new StupidAlgoritmicPlayer(6, datasetPath, 0.25);
            Player player2 = new StupidAlgoritmicPlayer(6, datasetPath, 0.25);
            Players players = new Players(player1, player2);
            Game game = new Game(board, players);
            Console.WriteLine(board.getStringBoard());
            Console.Write("Partidas: " + numGames + " \nPresione una tecla para continuar...");
            Console.ReadKey();
            game.play(numGames);
            Console.Write("Juego finalizado. Presione una tecla para continuar...");
            Console.ReadKey();
        }

    }
}
