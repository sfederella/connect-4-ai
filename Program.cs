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
                Player player = new AlgoritmicPlayer();
                bool hasError = false;
                int winner = 0;

                Console.Clear();
                while (winner == 0)
                {
                    Console.WriteLine(board.getStringBoard());
                    Console.Write(getPrompt(hasError));
                    try
                    {
                        // Human Turn
                        board.selectColumn(Int32.Parse(Console.ReadKey().KeyChar.ToString())-1,-1);
                        winner = GameRules.connect4Done(board);
                        if (winner != 0)
                        {
                            exit = endGame(winner, board);
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine(board.getStringBoard());
                        Console.Write("Pensando...");

                        // Player Turn
                        board.selectColumn(player.getSelectedCol(board.clone()), 1);
                        winner = GameRules.connect4Done(board);
                        if (winner != 0)
                        {
                            exit = endGame(winner, board);
                            break;
                        }
                        hasError = false;
                    }
                    catch (Exception e)
                    {
                        hasError = true;
                    }
                    Console.Clear();
                }
            }
        }

        static private string getPrompt(bool hasError)
        {
            if (!hasError)
            {
                return "Ficha O - Ingrese columna: ";
            }
            else
            {
                return "No puede ingresar esa columna, ingrese columna nuevamente: ";
            }
        }

        static private bool endGame(int winner, Board board)
        {
            Console.Clear();
            Console.WriteLine(board.getStringBoard());
            Console.Write((winner == 1 ? "Has perdido." : "Has ganado.") + "\nDesea jugar nuevamente (Y/N):");
            return Console.ReadKey().KeyChar.ToString().ToUpper() != "Y";
        }
    }
}
