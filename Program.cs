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
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Board board = new Board(7, 6);
                Player player1 = new AlgoritmicPlayer(6);
                Player player2 = new AlgoritmicPlayer(6);
                Players players = new Players(player1, player2);
                Game game = new Game(board, players);

                Console.Clear();
                Console.WriteLine(board.getStringBoard());
                Console.Write("Ingrese cantidad de partidas: ");
                int times = Int32.Parse(Console.ReadKey().KeyChar.ToString());

                game.play(times);

                Console.Write("Desea jugar nuevamente (Y/N): ");
                exit = Console.ReadKey().KeyChar.ToString().ToUpper() != "Y";
            }
        }

    }
}
