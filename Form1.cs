using System.Windows.Forms;

namespace TicTacToeApp
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        String[] gameBoard = new string[9];
        int currentTurn = 0;
        int playerOneWin = 0;
        int playerTwoWin = 0;
        int draws = 0;

        public String returnSymbol(int turn)
        {
            if (turn % 2 == 0)
            {
                return "0";
            }
            else
            {
                return "X";
            }
        }


        public void checkTheWinner()
        {
            for (int i = 0; i < 8; i++)
            {
                string combination = "";
                switch (i)
                {
                    case 0:
                        combination = gameBoard[0] + gameBoard[1] + gameBoard[2];
                        break;
                    case 1:
                        combination = gameBoard[3] + gameBoard[4] + gameBoard[5];
                        break;
                    case 2:
                        combination = gameBoard[6] + gameBoard[7] + gameBoard[8];
                        break;
                    case 3:
                        combination = gameBoard[0] + gameBoard[3] + gameBoard[6];
                        break;
                    case 4:
                        combination = gameBoard[1] + gameBoard[4] + gameBoard[7];
                        break;
                    case 5:
                        combination = gameBoard[2] + gameBoard[5] + gameBoard[8];
                        break;
                    case 6:
                        combination = gameBoard[0] + gameBoard[4] + gameBoard[8];
                        break;
                    case 7:
                        combination = gameBoard[2] + gameBoard[4] + gameBoard[6];
                        break;
                }
                if (combination.Equals("000"))
                {
                    Reset();
                    MessageBox.Show("0 has won the game!", "We have a winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    playerTwoWin++;
                    updateScore();
                }
                else if (combination.Equals("XXX"))
                {
                    Reset();
                    MessageBox.Show("X has won the game!", "We have a winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    playerOneWin++;
                    updateScore();
                }

                CheckIfDraw();

            }
        }
        private void Reset()
        {
            button1.Text = " ";
            button2.Text = " ";
            button3.Text = " ";
            button4.Text = " ";
            button5.Text = " ";
            button6.Text = " ";
            button7.Text = " ";
            button8.Text = " ";
            button9.Text = " ";
            currentTurn = 0;
            gameBoard = new string[9];
            time = 6;

        }
        private void CheckIfDraw()
        {


            int counter = 0;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                if (gameBoard[i] != null)
                {
                    counter++;
                }
            }

            if (counter == 9)
            {
                draws++;
                updateScore();
                Reset();
                MessageBox.Show("That's a draw!", "Nobody won the game!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        int time;


        private void updateScore()
        {
            label1.Text = "Player 1: " + playerOneWin.ToString();
            label2.Text = "Player 2: " + playerTwoWin.ToString();
            label3.Text = "Draws: " + draws.ToString();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            time--;
            if (time > 0)
                label4.Text = "Time Left: " + time.ToString();
            else if (time == 0)
            {
                if (currentTurn % 2 == 0)
                {
                    playerOneWin++;
                    MessageBox.Show("Run out of time. Player One wins.");
                    Reset();
                    updateScore();
                }
                else if (currentTurn % 2 == 1)
                {

                    playerTwoWin++;
                    MessageBox.Show("Run out of time. Player Two wins.");
                    Reset();
                    updateScore();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gameBoard[0] == null) { 
            currentTurn++;
            gameBoard[0] = returnSymbol(currentTurn);
            button1.Text = gameBoard[0];
            checkTheWinner();
            time = 6;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gameBoard[1] == null)
            currentTurn++;
            gameBoard[1] = returnSymbol(currentTurn);
            button2.Text = gameBoard[1];
            checkTheWinner();
            time = 6;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (gameBoard[2] == null)
            currentTurn++;
            gameBoard[2] = returnSymbol(currentTurn);
            button3.Text = gameBoard[2];
            checkTheWinner();
            time = 6;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (gameBoard[3] == null)   
            currentTurn++;
            gameBoard[3] = returnSymbol(currentTurn);
            button4.Text = gameBoard[3];
            checkTheWinner();
            time = 6;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (gameBoard[4] == null)
            currentTurn++;
            gameBoard[4] = returnSymbol(currentTurn);
            button5.Text = gameBoard[4];
            checkTheWinner();
            time = 6;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (gameBoard[5] == null)   
            currentTurn++;
            gameBoard[5] = returnSymbol(currentTurn);
            button6.Text = gameBoard[5];
            checkTheWinner();
            time = 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (gameBoard[6] == null)
            currentTurn++;
            gameBoard[6] = returnSymbol(currentTurn);
            button7.Text = gameBoard[6];
            checkTheWinner();
            time = 6;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (gameBoard[7] == null)   
            currentTurn++;
            gameBoard[7] = returnSymbol(currentTurn);
            button8.Text = gameBoard[7];
            checkTheWinner();
            time = 5;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (gameBoard[8] == null)   
            currentTurn++;
            gameBoard[8] = returnSymbol(currentTurn);
            button9.Text = gameBoard[8];
            checkTheWinner();
            time = 6;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            this.Hide();
            time = 10000;
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }   
    }
}
