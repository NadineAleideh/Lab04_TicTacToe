using Lab04_TicTacToe.Classes;
using System;

namespace Lab04_TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t**********Welcome to Tic Tac Toe! Let's have fun!**********\n");

            StartGame();

            Console.WriteLine("Thank you for playing Tic Tac Toe!");
        }

        static void StartGame()
        {
            // TODO: Setup your game. Create a new method that creates your players and instantiates the game class. Call that method in your Main method.
            // You are requesting a Winner to be returned, Determine who the winner is output the celebratory message to the correct player. If it's a draw, tell them that there is no winner. 
            Console.WriteLine("\t\t\t\tPlayer 1 goes with X marker , Player 2 goes with O marker\n");
            Console.Write("Player 1 enter your name: ");
            string player1Name = Console.ReadLine();
            Console.WriteLine();
            Player player1 = new Player(player1Name, "X");

            Console.Write("Player 2 enter your name: ");
            string player2Name = Console.ReadLine();
            Console.WriteLine();
            Player player2 = new Player(player2Name, "O");

            Game game = new Game(player1, player2);
            Player winner = game.Play();

            if (winner != null)
            {
                Console.WriteLine($"Congratulations, {winner.Name}! You'er the WINNER!.");
            }
            else
            {
                Console.WriteLine("It's a draw! There is no winner.");
            }
        }
    }
}
