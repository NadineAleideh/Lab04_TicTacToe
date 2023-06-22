
using Lab04_TicTacToe.Classes;
using Xunit;


namespace Test_Lab04_TicTacToe
{
    
    public class UnitTest1
    {

        [Fact]
        public static void TestForWinner()
        {
            // Given a game board, test for winners
            Player playerOne = new Player("Player1", "X");
            Player playerTwo = new Player("Player2", "O");
           
            Game game = new Game(playerOne, playerTwo);

            game.Board.GameBoard = new string[,]
           {
                   {"X", "X", "X"},
                   {"O", "O", "6"},
                   {"7", "8", "9"}
           };

            bool hasWinnerr = game.CheckForWinner(game.Board);
            bool expected = true;
            Assert.Equal(hasWinnerr, expected);
        }

        [Fact]
        public void TestSwitchPlayer()
        {
            //Test that there is a switch in players between turns
            Game game1 = new (new Player("Player1", "X"), new Player("Player2", "O"));
            Player currentPlayer = game1.NextPlayer();

            game1.SwitchPlayer();
            Player switchedPlayer = game1.NextPlayer();

            Assert.NotEqual(currentPlayer, switchedPlayer);
        }

        [Fact]
        public void TestPlayerGetPosition()
        {
            // Test to confirm that the position the player inputs correlates to the correct index of the array
            Board board1 = new Board();
            Player playerr = new Player("Player1", "X");

            // Simulate user input
            string input = "1";
            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                Position position = playerr.GetPosition(board1);

                Assert.Equal(0, position.Row);
                Assert.Equal(0, position.Column);
            }
        }

        [Fact]
        public static void TestGamePlayReturnsNullWhenGameEndsInADraw()
        {// when game ends in draw
            Player player1 = new Player("Player1", "X");
            Player player2 = new Player("Player2", "O");
            Game game3 = new( player1, player2);
            game3.Board.GameBoard = new string[,]
            {
                   {"X", "O", "X"},
                   {"X", "O", "O"},
                   {"O", "X", "X"}
            };

            int boardSize = game3.Board.GameBoard.GetLength(0);
            int[,] parsedGameBoard = new int[boardSize, boardSize];
            bool s = false;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (int.TryParse(game3.Board.GameBoard[row, col], out int parsedValue))
                    {
                        parsedGameBoard[row, col] = parsedValue;
                        s = true;
                    }
                    else
                    {
                        s = false;
                    }
                  
                }
            }

           
           bool hasWinner = game3.CheckForWinner(game3.Board);
           
            Assert.False(s);
            Assert.False(hasWinner);

        }
    }
}
