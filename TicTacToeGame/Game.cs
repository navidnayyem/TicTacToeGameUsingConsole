using System;

namespace TicTacToe
{
    class Game
    {
        //create a 3 x 3 table
        char[,] gameBoard = new char[3, 3] {
                { '1','2','3' },
                { '4','5','6' },
                { '7','8','9' }
            };

        int playerCount = 1; //used for to take count of players turn
        int playerPos; //position of the marker
        char playerChoice; //players choice
        int score1 = 0; //show player 1 scores
        int score2 = 0;//show player 2 scores

        public void showBoard() //showBoard function
        {
            playerCount = 1; //reset playercount to 1 by default
            bool endgame = false;
            char[] positionArr = { gameBoard[0, 0], gameBoard[0, 1], gameBoard[0, 2], gameBoard[1, 0], gameBoard[1, 1], gameBoard[1, 2], gameBoard[2, 0], gameBoard[2, 1], gameBoard[2, 2] };//map 2d array into 1d
            Console.WriteLine("***TicTacToe Game***\n");
            Console.WriteLine("Enter marker at positions\n");
            Console.WriteLine("X for Player 1 & O for Player 2\n");

            while (endgame == false) //infinite loop
            {
                Console.WriteLine("  -------------------------");
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[0], positionArr[1], positionArr[2]);
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  -------------------------");
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[3], positionArr[4], positionArr[5]);
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  -------------------------");
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[6], positionArr[7], positionArr[8]);
                Console.WriteLine("  |       |       |       |");
                Console.WriteLine("  -------------------------");

                playerTurn(positionArr);
                playerCount++; //counter

                if (checkWin(positionArr) == true && playerCount % 2 == 0)
                {
                    score1++;
                    Console.WriteLine("PLayer 1 Wins, Score: {0} - {1}", score1, score2);
                    Console.WriteLine("  -------------------------");
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[0], positionArr[1], positionArr[2]);
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  -------------------------");
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[3], positionArr[4], positionArr[5]);
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  -------------------------");
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[6], positionArr[7], positionArr[8]);
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  -------------------------");
                    endgame = true;               
                }
                else if (checkWin(positionArr) == true && playerCount % 2 != 0)
                {
                    score2++;
                    Console.WriteLine("PLayer 2 Wins, Score: {0} - {1}", score1, score2);
                    Console.WriteLine("  -------------------------");
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[0], positionArr[1], positionArr[2]);
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  -------------------------");
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[3], positionArr[4], positionArr[5]);
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  -------------------------");
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[6], positionArr[7], positionArr[8]);
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  -------------------------");
                    endgame = true;
                }
                if(playerCount > 9)
                {
                    Console.WriteLine("  -------------------------");
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[0], positionArr[1], positionArr[2]);
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  -------------------------");
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[3], positionArr[4], positionArr[5]);
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  -------------------------");
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  |   {0}   |   {1}   |   {2}   |", positionArr[6], positionArr[7], positionArr[8]);
                    Console.WriteLine("  |       |       |       |");
                    Console.WriteLine("  -------------------------");
                    Console.WriteLine("Draw");
                    endgame = true;
                }
            }

            Console.Write("\nDo you want to play again? Enter Y for Yes, N for NO: ");
            playerChoice = Convert.ToChar(Console.ReadLine());

            if (playerChoice == 'Y' || playerChoice == 'y')
            {
                Console.WriteLine();
                showBoard();
            } 
            else if (playerChoice == 'N' || playerChoice == 'n')
            {
                Console.WriteLine("\nGAME EXITED");
            }
        }//end of showBoard

        public void playerTurn(char[] board) //checks who's turn it is
        { 
            if (playerCount % 2 == 0)
            {
            again:
                Console.Write("\nPlayer 2 Turn: ");
                playerPos = Convert.ToInt32(Console.ReadLine());
                playerPos--;
                if (board[playerPos] == 'o' || board[playerPos] == 'x')
                {
                    Console.WriteLine("This position has already been entered");
                    goto again;
                }
                else
                {
                    board[playerPos] = 'o';
                }

            }
            else
            {
            againPLayer:
                Console.Write("\nPlayer 1 Turn: ");
                playerPos = Convert.ToInt32(Console.ReadLine());
                playerPos--;
                if (board[playerPos] == 'x' || board[playerPos] == 'o')
                {
                    Console.WriteLine("This position has already been entered");
                    goto againPLayer;
                }
                else
                {
                    board[playerPos] = 'x';
                }
            }
        }
        public bool checkWin(char[] board)
        {
            if ((board[0] != ' ') && (board[0] == board[1] && board[1] == board[2]))
            {
                return true;
            }
            else if ((board[3] != ' ') && (board[3] == board[4] && board[4] == board[5]))
            {
                return true;
            }
            else if ((board[6] != ' ') && (board[6] == board[7] && board[7] == board[8]))
            {
                return true;
            }
            else if ((board[0] != ' ') && (board[0] == board[3] && board[3] == board[6]))
            {
                return true;
            }
            else if ((board[1] != ' ') && (board[1] == board[4] && board[4] == board[7]))
            {
                return true;
            }
            else if ((board[2] != ' ') && (board[2] == board[5] && board[5] == board[8]))
            {
                return true;
            }
            else if ((board[0] != ' ') && (board[0] == board[4] && board[4] == board[8]))
            {
                return true;
            }
            else if ((board[2] != ' ') && (board[2] == board[4] && board[4] == board[6]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            /*Background Color of Console*/
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();

            /*Color of Text*/
            Console.ForegroundColor = ConsoleColor.Black;
            Game firstGame = new Game();
            firstGame.showBoard();
            Console.ReadLine();
        }
    }
}