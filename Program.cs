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
                Board[] lastBoards = new Board[2];
                lastBoards[0] = board.clone();
                string key;
                Player player = new AlgoritmicPlayer();
                bool hasError = false;
                int winner = 0;

                Console.Clear();
                while (winner == 0)
                {
                    lastBoards[1] = lastBoards[0];
                    lastBoards[0] = board.clone();
                    Console.WriteLine(board.getStringBoard());
                    key = getKey(hasError, true);
                    if(key.ToUpper() == "B")
                    {
                        board = lastBoards[1];
                        Console.Clear();
                        Console.WriteLine(board.getStringBoard());
                        key = getKey(hasError, false);
                    }
                    try
                    {
                        // Human Turn
                        board.selectColumn(Int32.Parse(key)-1,-1);
                        winner = GameRules.connect4Done(board);
                        if (winner != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Human Turn");
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
                            Console.Clear();
                            Console.WriteLine(board.getStringBoard());
                            Console.Write("Has perdido.\nDesea regresar un turno (Y/N): ");
                            if (Console.ReadKey().KeyChar.ToString().ToUpper() == "Y")
                            {
                                board = lastBoards[0];
                                winner = 0;
                            } else
                            {
                                Console.Clear();
                                Console.WriteLine("Player Turn");
                                exit = endGame(winner, board);
                                break;
                            }
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

        static private string getKey(bool hasError, bool getBackwards)
        {
            if (!hasError)
            {
                Console.Write("Ficha O - Ingrese " + (getBackwards ? "'B' para retroceder o indique " : "") + "columna: ");
            }
            else
            {
                Console.Write("No puede ingresar esa columna, ingrese " + (getBackwards ? "'B' para retroceder o indique " : "") + "columna nuevamente: ");
            }
            return Console.ReadKey().KeyChar.ToString();
        }

        static private bool endGame(int winner, Board board)
        {
            Console.WriteLine(board.getStringBoard());
            Console.Write((winner == 1 ? "Has perdido." : "Has ganado.") + "\nDesea jugar nuevamente (Y/N):");
            return Console.ReadKey().KeyChar.ToString().ToUpper() != "Y";
        }

    }
}
