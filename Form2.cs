using System;
using System.Reflection;

namespace TicTacToeApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        String[] gameBoard = new string[9];
        int currentTurn = 0;
        int playerOneWin = 0;
        int CPU = 0;
        int draws = 0;

        private int Evaluate(string[] board)
        {
            int[,] winPositions = new int[,]
            {
        {0,1,2}, {3,4,5}, {6,7,8}, // linii
        {0,3,6}, {1,4,7}, {2,5,8}, // coloane
        {0,4,8}, {2,4,6}           // diagonale
            };

            for (int i = 0; i < winPositions.GetLength(0); i++)
            {
                string a = board[winPositions[i, 0]];
                string b = board[winPositions[i, 1]];
                string c = board[winPositions[i, 2]];

                if (a != null && a == b && b == c)
                {
                    if (a == "X") return +10;  // jucătorul
                    if (a == "0") return -10;  // CPU
                }
            }
            return 0; // nimeni nu a câștigat
        }

        private bool IsMovesLeft(string[] board)
        {
            return board.Any(cell => cell == null);
        }
        private int Minimax(string[] board, int depth, bool isMax)
        {
            int score = Evaluate(board);

            if (score == 10) return score - depth;   // X câștigă
            if (score == -10) return score + depth;  // 0 câștigă
            if (!IsMovesLeft(board)) return 0;       // remiză

            if (isMax) // jucătorul X
            {
                int best = int.MinValue;
                for (int i = 0; i < 9; i++)
                {
                    if (board[i] == null)
                    {
                        board[i] = "X";
                        best = Math.Max(best, Minimax(board, depth + 1, false));
                        board[i] = null;
                    }
                }
                return best;
            }
            else // CPU (joacă cu "0")
            {
                int best = int.MaxValue;
                for (int i = 0; i < 9; i++)
                {
                    if (board[i] == null)
                    {
                        board[i] = "0";
                        best = Math.Min(best, Minimax(board, depth + 1, true));
                        board[i] = null;
                    }
                }
                return best;
            }
        }
        private int FindBestMove(string[] board)
        {
            int bestVal = int.MaxValue;
            int bestMove = -1;

            for (int i = 0; i < 9; i++)
            {
                if (board[i] == null)
                {
                    board[i] = "0";
                    int moveVal = Minimax(board, 0, true);
                    board[i] = null;

                    if (moveVal < bestVal)
                    {
                        bestMove = i;
                        bestVal = moveVal;
                    }
                }
            }
            return bestMove;
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
                if (combination == "000")
                {
                    CPU++;
                    updateScore();
                    MessageBox.Show("0 has won the game!", "We have a winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Reset();
                }
                else if (combination == "XXX")
                {
                    playerOneWin++;
                    updateScore();
                    MessageBox.Show("X has won the game!", "We have a winner!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Reset();
                }

                CheckIfDraw();
            }
        }
        private void Reset()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            currentTurn = 0;
            gameBoard = new string[9]; // toate revin la null
        }

        private void cpuMove()
        {
            if (gameBoard.Any(cell => cell == null))
            {
                int move = FindBestMove(gameBoard);

                if (move != -1)
                {
                    gameBoard[move] = "0";   // CPU e mereu 0
                    UpdateButton(move);
                    checkTheWinner();
                    currentTurn++;
                }
            }
            else
            {
                Reset();
            }
        }




        private void UpdateButton(int index)
        {
            switch (index)
            {
                case 0:
                    button1.Text = gameBoard[0];
                    break;
                case 1:
                    button2.Text = gameBoard[1];
                    break;
                case 2:
                    button3.Text = gameBoard[2];
                    break;
                case 3:
                    button4.Text = gameBoard[3];
                    break;
                case 4:
                    button5.Text = gameBoard[4];
                    break;
                case 5:
                    button6.Text = gameBoard[5];
                    break;
                case 6:
                    button7.Text = gameBoard[6];
                    break;
                case 7:
                    button8.Text = gameBoard[7];
                    break;
                case 8:
                    button9.Text = gameBoard[8];
                    break;
            }
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
        private void MakeMove(int index)
        {
            if (gameBoard[index] == null)
            {
                gameBoard[index] = "X";   // jucătorul e mereu X
                UpdateButton(index);
                checkTheWinner();
                currentTurn++;

                if (IsMovesLeft(gameBoard))
                {
                    cpuMove();
                }
            }
        }

        private void updateScore()
        {
            label1.Text = "Player 1: " + playerOneWin.ToString();
            label2.Text = "CPU: " + CPU.ToString();
            label3.Text = "Draws: " + draws.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MakeMove(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MakeMove(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MakeMove(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MakeMove(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MakeMove(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MakeMove(5);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            MakeMove(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MakeMove(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MakeMove(8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
