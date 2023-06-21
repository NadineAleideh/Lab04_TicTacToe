using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Lab04_TicTacToe.Classes
{
	public class Game
	{
		public Player PlayerOne { get; set; }
		public Player PlayerTwo { get; set; }
		public Player Winner { get; set; }
        public Player CurrentPlayer { get; set; }

        public Board Board { get; set; }


		/// <summary>
		/// Require 2 players and a board to start a game. 
		/// </summary>
		/// <param name="p1">Player 1</param>
		/// <param name="p2">Player 2</param>
		public Game(Player p1, Player p2)
		{
			PlayerOne = p1;
			PlayerTwo = p2;
			Board = new Board();
            CurrentPlayer = p1;

        }

        
         
        /// <summary>
        /// Activate the Play of the game
        /// </summary>
        /// <returns>Winner player or null if there is a draw</returns>
        public Player Play()
		{
           

            int turns = 0;
            

            while (turns < 9)
			{
                Board.DisplayBoard();
                CurrentPlayer.TakeTurn(Board);
                SwitchPlayer();
                turns++;

                if (CheckForWinner(Board))
                {
                    Winner = CurrentPlayer;
                    break;
                }

				if (turns==9 && !CheckForWinner(Board)) { Winner = null; }

                CurrentPlayer = NextPlayer();
            }

            Board.DisplayBoard();
            return Winner;
        }


        /// <summary>
        /// Check if winner exists on the current game board
        /// </summary>
        /// <param name="board">current state of the board</param>
        /// <returns>true if winner exists, otherwise false</returns>
        public bool CheckForWinner(Board board)
		{
			int[][] winners = new int[][]
			{
				new[] {1,2,3},
				new[] {4,5,6},
				new[] {7,8,9},

				new[] {1,4,7},
				new[] {2,5,8},
				new[] {3,6,9},

				new[] {1,5,9},
				new[] {3,5,7}
			};

			// Given all the winning conditions, Determine the winning logic. 
			for (int i = 0; i < winners.Length; i++)
			{
				Position p1 = CurrentPlayer.PositionForNumber(winners[i][0]);
				Position p2 = CurrentPlayer.PositionForNumber(winners[i][1]);
				Position p3 = CurrentPlayer.PositionForNumber(winners[i][2]);

				string a = Board.GameBoard[p1.Row, p1.Column];
				string b = Board.GameBoard[p2.Row, p2.Column];
				string c = Board.GameBoard[p3.Row, p3.Column];

                // TODO:  Determine a winner has been reached. 
                // return true if a winner has been reached. 

                if (a == b && b == c && a == c) // the three markers should be equal to each other in any row , column , diagonal to exist a winner
                {
                    return true;
					
                }
            }

			return false;
		}


		/// <summary>
		/// Determine next player to take a turn in the play
		/// </summary>
		/// <returns>next player</returns>
		public Player NextPlayer()
		{
			return (PlayerOne.IsTurn) ? PlayerOne : PlayerTwo;
		}

		/// <summary>
		/// End one players turn (the current player) and activate the other player turn
		/// </summary>
		public void SwitchPlayer()
		{
			if (PlayerOne.IsTurn)
			{
              
				PlayerOne.IsTurn = false;

              
				PlayerTwo.IsTurn = true;
			}
			else
			{
				PlayerOne.IsTurn = true;
				PlayerTwo.IsTurn = false;
			}
		}


	}
}
