using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
    public class Board
    {
		/// <summary>
		/// Tic Tac Toe Gameboard states
		/// </summary>
		public string[,] GameBoard = new string[,]
		{
			{"1", "2", "3"},
			{"4", "5", "6"},
			{"7", "8", "9"},
		};


        /// <summary>
        /// Displays the current state of the game board. It used in Play methd.
        /// </summary>
        public void DisplayBoard()
		{
            //TODO: Output the board to the console
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t\t\t\t");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("\t\t\t");
                    Console.Write($"\t|{GameBoard[i, j]}|");
                }
                
                Console.WriteLine();
            }
            Console.WriteLine();

        }
	}
}
