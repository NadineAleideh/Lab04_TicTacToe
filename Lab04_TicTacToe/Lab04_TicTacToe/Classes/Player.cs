using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
     public class Player
    {
		public string Name { get; set; }
		/// <summary>
		/// P1 is X and P2 will be O
		/// </summary>
		public string Marker { get; set; }

		/// <summary>
		/// Flag to determine if it is the user's turn
		/// </summary>
		public bool IsTurn { get; set; }


        /// <summary>
        /// Initializes a new instance of the Player class with the specified name and marker.
        /// </summary>
        /// <param name="name">The player's name</param>
        /// <param name="marker">The player's marker (X or O)</param>
        public Player(string name, string marker)
        {
            Name = name;
            Marker = marker;
        }



        /// <summary>
        /// Retrieves the position chosen by the player on the game board. and used in TakeTurn method.
        /// </summary>
        /// <param name="board">The current game board</param>
        /// <returns>The chosen position on the board</returns>
        public Position GetPosition(Board board)
		{
			Position desiredCoordinate = null;
			while (desiredCoordinate is null)
			{
				Console.Write("...Please select a location:");
				Int32.TryParse(Console.ReadLine(), out int position);
                Console.WriteLine();
                desiredCoordinate = PositionForNumber(position);
			}
			return desiredCoordinate;

		}



        /// <summary>
        /// Converts the selected number representation of a position to the corresponding row and column on the game board.and used in GetPosition method.
        /// </summary>
        /// <param name="position">The number representation of a position on the game board</param>
        /// <returns>The corresponding position on the game board</returns>

        public  Position PositionForNumber(int position)
		{
			switch (position)
			{
				case 1: return new Position(0, 0); // Top Left
				case 2: return new Position(0, 1); // Top Middle
				case 3: return new Position(0, 2); // Top Right
				case 4: return new Position(1, 0); // Middle Left
				case 5: return new Position(1, 1); // Middle Middle
				case 6: return new Position(1, 2); // Middle Right
				case 7: return new Position(2, 0); // Bottom Left
				case 8: return new Position(2, 1); // Bottom Middle 
				case 9: return new Position(2, 2); // Bottom Right

				default: return null;
			}
		}

        /// <summary>
        /// Allows the current player to take their turn by selecting a locatin on the game board. and it filps the player turns flag this helps switching btween players. and it is used in play method.
        /// </summary>
        /// <param name="board">The current game board</param>
        public void TakeTurn(Board board)
		{
			IsTurn = true;

			Console.Write($"\n{Name} it is your turn");

			Position position = GetPosition(board);

			if (Int32.TryParse(board.GameBoard[position.Row, position.Column], out int _)) //if this selected position still a number(avalabile)
			{
				board.GameBoard[position.Row, position.Column] = Marker; //assign the current player marker to it 
			}
			else
			{
				Console.Write("This space is already occupied..try again");
                 position = GetPosition(board); //i think this line of code should be here to allow the current player to pick an avalabile location otherwise without playing and picking a location and that's not fair
            }
        }
	}
}
