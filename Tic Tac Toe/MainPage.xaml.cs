using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tic_Tac_Toe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        bool turn = true; //players turn swap
        int turnCount = 0;
        int p2Score = 0;
        int p1Score = 0;

        public MainPage()
        {
            this.InitializeComponent();
            enableButton();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;

            //if turn is true then is player1's turn else is player2's turn
            if (turn == true)
            {
                b.Content = "X";
                TurnLabel.Text = "Player 2";

            }
            else
            {
                b.Content = "O";
                TurnLabel.Text = "Player 1";
            }
            //make sure turn is not equal to the same value after one player has pressed a button
            turn = !turn;
            //after pressed a button we have to disable it so play can not pressed that button again
            turnCount++;
            b.IsEnabled = false;
            
            checkit();
        }


        //check if any one wins
        public void checkit()
        {

            bool winnerAppears = false;
            try
            {
                //if any 3 horizontal check 
                if (button1.Content.ToString() == button2.Content.ToString() &&
                    button2.Content.ToString() == button3.Content.ToString() &&
                    (!button1.IsEnabled))
                {
                    winnerAppears = true;
                }
                else if (button4.Content.ToString() == button5.Content.ToString() &&
                    button5.Content.ToString() == button6.Content.ToString() &&
                    (!button4.IsEnabled))
                {
                    winnerAppears = true;
                }
                else if (button7.Content.ToString() == button8.Content.ToString() &&
                    button8.Content.ToString() == button9.Content.ToString() &&
                    (!button7.IsEnabled))
                {
                    winnerAppears = true;
                }

                //vertical checks
                if (button1.Content.ToString() == button4.Content.ToString() &&
                   button4.Content.ToString() == button7.Content.ToString() &&
                   (!button1.IsEnabled))
                {
                    winnerAppears = true;
                }
                else if (button2.Content.ToString() == button5.Content.ToString() &&
                    button5.Content.ToString() == button8.Content.ToString() &&
                    (!button2.IsEnabled))
                {
                    winnerAppears = true;
                }
                else if (button3.Content.ToString() == button6.Content.ToString() &&
                    button6.Content.ToString() == button9.Content.ToString() &&
                    (!button3.IsEnabled))
                {
                    winnerAppears = true;
                }


                //diagonal checks
                if (button1.Content.ToString() == button5.Content.ToString() &&
                  button5.Content.ToString() == button9.Content.ToString() &&
                  (!button1.IsEnabled))
                {
                    winnerAppears = true;
                }
                else if (button3.Content.ToString() == button5.Content.ToString() &&
                    button5.Content.ToString() == button7.Content.ToString() &&
                    (!button3.IsEnabled))
                {
                    winnerAppears = true;
                }
            }
            catch { }


            //if there is a winner 
            if (winnerAppears == true)
            {

                //disable all the button and ouput a winner player
                disableButton();

                string winnerIs = "";

                if (turn)
                {
                    p2Score++;
                    winnerIs = "Player2";
                    player2Label.Text = p2Score.ToString();
                }
                else
                {
                    p1Score++;
                    winnerIs = "Player1";
                    player1Label.Text = p1Score.ToString();
                }

                WinneLabel.Text = winnerIs + " Win!";

            }
            //if the turn count is 9 then we know there is a draw there is a draw
            else
            {
                if (turnCount == 9)
                {
                    WinneLabel.Text = "Draw!";
                }
            }

        }

        //disable all the button
        private void disableButton()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
        }

        //reset all buttons
        private void enableButton()
        {
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled = true;
            button9.IsEnabled = true;
            button1.Content = "";
            button2.Content = "";
            button3.Content = "";
            button4.Content = "";
            button5.Content = "";
            button6.Content = "";
            button7.Content = "";
            button8.Content = "";
            button9.Content = "";
        }

        //create a new game
        private void New_Game_Click(object sender, RoutedEventArgs e)
        {
            turn = true;
            turnCount = 0;
            enableButton();
            WinneLabel.Text = "";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            p1Score = 0;
            p2Score = 0;
            player1Label.Text = "";
            player2Label.Text = "";
            turn = true;
            turnCount = 0;
            enableButton();
            WinneLabel.Text = "";
            TurnLabel.Text = "";
        }
    }
}
