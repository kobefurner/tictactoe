using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    /// <summary>
    /// Tic tac toe class that keeps track of all the business logic so it's not all behind the UI.
    /// </summary>
    internal class clsTicTacToe
    {
        #region Attributes
        //2D array for the board
        private string[,] saBoard;

        //Player 1 wins
        private int iPlayer1Wins;

        //Player 2 wins
        private int iPlayer2Wins;

        //Number of ties
        private int iTies;

        //Attribute to be used for the winning move enumeration
        private WinningMove eWinningMove;

        #endregion

        #region Methods
        /// <summary>
        /// An enumeration that keeps track of each winning move
        /// </summary>
        public enum WinningMove
        {
            Row1,
            Row2,
            Row3,
            Col1,
            Col2,
            Col3,
            Diag1,
            Diag2
        }

        /// <summary>
        /// Default constructor. Sets the board to an empty array.
        /// </summary>
        public clsTicTacToe()
        {
            saBoard = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    saBoard[i, j] = "";
                }
            }
        }

        /// <summary>
        /// Board property that will return the saBoard array and allow for the board to be cleared
        /// when needed
        /// </summary>
        public string[,] Board
        {
            get
            {
                return saBoard;
            }
            set
            {
                saBoard = value;
            }

        }

        /// <summary>
        /// Player1Wins property that allows the iPlayer1Wins attribute to be called and set outside of 
        /// this class.
        /// </summary>
        public int Player1Wins
        {
            get
            {
                return iPlayer1Wins;
            }
            set
            {
                iPlayer1Wins = value;
            }
        }

        /// <summary>
        /// Player2Wins property that allows the iPlayer2Wins attribute to be called and set outside of 
        /// this class.
        /// </summary>
        public int Player2Wins
        {
            get
            {
                return iPlayer2Wins;
            }
            set
            {
                iPlayer2Wins = value;
            }
        }

        /// <summary>
        /// Ties property that allows the iTies attribute to be called and set outside of this class.
        /// </summary>
        public int Ties
        {
            get
            {
                return iTies;
            }
            set
            {
                iTies = value;
            }
        }

        /// <summary>
        /// A method to be used outside of this class so mainWindow code can know what the winning move
        /// was.
        /// </summary>
        public WinningMove? LastWinningMove
        {
            get { return eWinningMove; }
        }

        /// <summary>
        /// Calls three different methods and returns true if any of them were a winning move.
        /// </summary>
        /// <returns></returns>
        public bool isWinningMove()
        {
            return HorizontalWin() || VerticalWin() || DiagonalWin();
        }

        /// <summary>
        /// Loops through the rows in the array to check if they match correctly. Also checks
        /// that the array doesn't equal an empty string.
        /// </summary>
        /// <returns></returns>
        private bool HorizontalWin()
        {
            for (int row = 0; row < 3; row++)
            {
                if (Board[row, 0] != "" && Board[row, 0] == Board[row, 1] && Board[row, 1] == Board[row, 2])
                {
                    switch (row)
                    {
                        case 0:
                            eWinningMove = WinningMove.Row1;
                            break;
                        case 1:
                            eWinningMove = WinningMove.Row2;
                            break;
                        case 2:
                            eWinningMove = WinningMove.Row3;
                            break;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Loops through the columns in the array checking if there is a match. Won't allow a match if
        /// the array holds an empty string.
        /// </summary>
        /// <returns></returns>
        private bool VerticalWin()
        {
            for (int col = 0; col < 3; col++)
            {
                if (Board[0, col] != "" && Board[0, col] == Board[1, col] && Board[1, col] == Board[2, col])
                {
                    switch (col)
                    {
                        case 0:
                            eWinningMove = WinningMove.Col1;
                            break;
                        case 1:
                            eWinningMove = WinningMove.Col2;
                            break;
                        case 2:
                            eWinningMove = WinningMove.Col3;
                            break;
                    }
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Diagonal win returns true if the content in the array is matching and is not an empty string
        /// </summary>
        /// <returns></returns>
        private bool DiagonalWin()
        {
            if (Board[0, 0] != "" && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            {
                eWinningMove = WinningMove.Diag1;
                return true;
            }

            if (Board[0, 2] != "" && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
            {
                eWinningMove = WinningMove.Diag2;
                return true;
            }

            return false;
        }

        /// <summary>
        /// If all the spots in the array are filled and they are not an empty string, isTie returns true
        /// </summary>
        /// <returns></returns>
        public bool isTie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] == "")
                    {
                        return false;
                    }
                }
            }
            //Check that there is not a winning move
            return !isWinningMove();
        }

        #endregion
    }
}
