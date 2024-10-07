using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes
        //Creates an object for clsTicTacToe to be called later
        clsTicTacToe clsTicTacToe;

        //Has the game started?
        bool HasGameStarted;

        //Player 1's turn?
        bool Player1Turn;

        //Player 2's turn?
        bool Player2Turn;
        #endregion

        /// <summary>
        /// Initialize the window and also instantiate the clsTicTacToe object
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            clsTicTacToe = new clsTicTacToe();
        }

        /// <summary>
        /// Once the user has clicked the start button, the has game started variable is set to true,
        /// calls the reset method, calls the enabled method, turns off the start button, and ensures
        /// that the game status tells the user that it is player 1's turn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            HasGameStarted = true;
            Reset();
            Enabled();
            btnStart.IsEnabled = false;
            lblGameStatus.Content = "Player 1's turn";
        }

        /// <summary>
        /// Enables of of the labels on the board
        /// </summary>
        private void Enabled()
        {
            lbl101.IsEnabled = true;
            lbl102.IsEnabled = true;
            lbl103.IsEnabled = true;
            lbl201.IsEnabled = true;
            lbl202.IsEnabled = true;
            lbl203.IsEnabled = true;
            lbl301.IsEnabled = true;
            lbl302.IsEnabled = true;
            lbl303.IsEnabled = true;
        }

        /// <summary>
        /// Disables all the labels on the board
        /// </summary>
        private void Disabled()
        {
            lbl101.IsEnabled = false;
            lbl102.IsEnabled = false;
            lbl103.IsEnabled = false;
            lbl201.IsEnabled = false;
            lbl202.IsEnabled = false;
            lbl203.IsEnabled = false;
            lbl301.IsEnabled = false;
            lbl302.IsEnabled = false;
            lbl303.IsEnabled = false;
        }

        /// <summary>
        /// Sets the array back to empty and returns the labels colors and content back to their original
        /// states
        /// </summary>
        private void Reset()
        {
            clsTicTacToe.Board = new string[3, 3];

            lbl101.Content = "";
            lbl101.Background = new SolidColorBrush(Colors.LightPink);

            lbl102.Content = "";
            lbl102.Background = new SolidColorBrush(Colors.LightPink);

            lbl103.Content = "";
            lbl103.Background = new SolidColorBrush(Colors.LightPink);

            lbl201.Content = "";
            lbl201.Background = new SolidColorBrush(Colors.LightPink);

            lbl202.Content = "";
            lbl202.Background = new SolidColorBrush(Colors.LightPink);

            lbl203.Content = "";
            lbl203.Background = new SolidColorBrush(Colors.LightPink);

            lbl301.Content = "";
            lbl301.Background = new SolidColorBrush(Colors.LightPink);

            lbl302.Content = "";
            lbl302.Background = new SolidColorBrush(Colors.LightPink);

            lbl303.Content = "";
            lbl303.Background = new SolidColorBrush(Colors.LightPink);
            Player1Turn = true;
            Player2Turn = false;
        }

        /// <summary>
        /// When the user makes a move, this method will make sure that the space is empty and then set
        /// the label's content to either an X or an O depending on whose turn it is. It will then call
        /// isWinningMove and isTie to check if either return true.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayerMoveClick(object sender, MouseButtonEventArgs e)
        {
            if (HasGameStarted)
            {
                //Attribute used to be able to check the content of the label the user clicked
                Label clickedLabel = sender as Label;

                if (clickedLabel.Content == "")
                {
                    if (Player1Turn)
                    {
                        clickedLabel.Content = "X";
                        Player1Turn = false;
                        Player2Turn = true;
                        lblGameStatus.Content = "Player 2's turn";
                    }
                    else
                    {
                        clickedLabel.Content = "O";
                        Player1Turn = true;
                        Player2Turn = false;
                        lblGameStatus.Content = "Player 1's turn";
                    }
                }
                //Refresh the board
                LoadBoard();

                if (clsTicTacToe.isWinningMove())
                {
                    HighlightWinningMove();
                    UpdateStats();
                    HasGameStarted = false;
                    if (Player2Turn)
                    {
                        lblGameStatus.Content = "Player 1 Wins!";

                    }
                    else
                    {
                        lblGameStatus.Content = "Player 2 Wins!";
                    }
                    btnStart.IsEnabled = true;
                }

                else if (clsTicTacToe.isTie())
                {
                    //update tie attribute
                    clsTicTacToe.Ties++;
                    HasGameStarted = false;
                    lblGameStatus.Content = "It's a Tie!";
                    btnStart.IsEnabled = true;
                    lblP1Wins.Content = "Player 1 Wins: " + clsTicTacToe.Player1Wins.ToString();
                    lblP2Wins.Content = "Player 2 Wins: " + clsTicTacToe.Player2Wins.ToString();
                    lblTies.Content = "Ties : " + clsTicTacToe.Ties.ToString();
                }
            }
        }

        /// <summary>
        /// Increase the wins based on whose turn it was
        /// </summary>
        private void UpdateStats()
        {
            if (Player2Turn)
            {
                clsTicTacToe.Player1Wins++;
            }
            else
            {
                clsTicTacToe.Player2Wins++;
            }
            //update labels for the statistics group box
            lblP1Wins.Content = "Player 1 Wins: " + clsTicTacToe.Player1Wins.ToString();
            lblP2Wins.Content = "Player 2 Wins: " + clsTicTacToe.Player2Wins.ToString();
            lblTies.Content = "Ties : " + clsTicTacToe.Ties.ToString();
        }

        /// <summary>
        /// Returns the values at each position in the array
        /// </summary>
        private void LoadBoard()
        {
            clsTicTacToe.Board[0, 0] = lbl101.Content.ToString();
            clsTicTacToe.Board[0, 1] = lbl102.Content.ToString();
            clsTicTacToe.Board[0, 2] = lbl103.Content.ToString();
            clsTicTacToe.Board[1, 0] = lbl201.Content.ToString();
            clsTicTacToe.Board[1, 1] = lbl202.Content.ToString();
            clsTicTacToe.Board[1, 2] = lbl203.Content.ToString();
            clsTicTacToe.Board[2, 0] = lbl301.Content.ToString();
            clsTicTacToe.Board[2, 1] = lbl302.Content.ToString();
            clsTicTacToe.Board[2, 2] = lbl303.Content.ToString();
        }

        /// <summary>
        /// Checks the lastWinningMove method from the tictactoe class and if it has a value, it will
        /// highlight the winning move based on where the winning move came from
        /// </summary>
        private void HighlightWinningMove()
        {
            if (clsTicTacToe.LastWinningMove.HasValue)
            {
                switch (clsTicTacToe.LastWinningMove.Value)
                {
                    case clsTicTacToe.WinningMove.Row1:
                        lbl101.Background = new SolidColorBrush(Colors.Green);
                        lbl102.Background = new SolidColorBrush(Colors.Green);
                        lbl103.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case clsTicTacToe.WinningMove.Row2:
                        lbl201.Background = new SolidColorBrush(Colors.Green);
                        lbl202.Background = new SolidColorBrush(Colors.Green);
                        lbl203.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case clsTicTacToe.WinningMove.Row3:
                        lbl301.Background = new SolidColorBrush(Colors.Green);
                        lbl302.Background = new SolidColorBrush(Colors.Green);
                        lbl303.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case clsTicTacToe.WinningMove.Col1:
                        lbl101.Background = new SolidColorBrush(Colors.Green);
                        lbl201.Background = new SolidColorBrush(Colors.Green);
                        lbl301.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case clsTicTacToe.WinningMove.Col2:
                        lbl102.Background = new SolidColorBrush(Colors.Green);
                        lbl202.Background = new SolidColorBrush(Colors.Green);
                        lbl302.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case clsTicTacToe.WinningMove.Col3:
                        lbl103.Background = new SolidColorBrush(Colors.Green);
                        lbl203.Background = new SolidColorBrush(Colors.Green);
                        lbl303.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case clsTicTacToe.WinningMove.Diag1:
                        lbl101.Background = new SolidColorBrush(Colors.Green);
                        lbl202.Background = new SolidColorBrush(Colors.Green);
                        lbl303.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case clsTicTacToe.WinningMove.Diag2:
                        lbl103.Background = new SolidColorBrush(Colors.Green);
                        lbl202.Background = new SolidColorBrush(Colors.Green);
                        lbl301.Background = new SolidColorBrush(Colors.Green);
                        break;
                }
            }
        }
    }
}