using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumericalTicTacToe
{
    public partial class Form1 : Form
    {

        int[,] board = new int[3, 3]; //0 is no number, any other number is the corresponding number
        int turn = 1; //odd number is yellow's turn (player), even number is orange's turn (AI)
        int numberClicked = 0;
        bool AImode = false;
        bool isPlayer = true;
        bool gameEnded = false;
        Logic logic;

        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            rules.Text = ("- The numbers 1 to 9 are used in this game" + "\n" + "- The first player plays with the odd numbers" + "\n" + "- The second player plays with the even numbers" + "\n" + "- All numbers can be used only once" + "\n" + "- The player who puts down 15 points in a line wins");
            for (int i = 1; i <= 9; i++)
            {
                Button b = new Button();
                b.Name = "outside" + i;
                b.Size = new Size(100, 100);
                int x = 20 + (i % 2) * 760;
                int y = 20 + ((i - 1) / 2) * 150;
                b.Location = new Point(x, y);
                b.Cursor = Cursors.Hand;
                b.Text = i.ToString();
                b.Font = new Font("Futura XBlkIt BT", 26F, FontStyle.Bold);
                b.Visible = false;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 2;
                b.ForeColor = Color.Black;
                if (i % 2 == 0)
                    b.BackColor = Color.FromArgb(255, 128, 0);
                else
                    b.BackColor = Color.Gold;
                b.Click += new EventHandler(outside_Click);
                Controls.Add(b);
            }
            for(int i=0; i<3; i++)
                for(int j=0; j<3; j++)
                {
                    Button b = new Button();
                    b.Name = "slot" + i + j;
                    b.Size = new Size(150, 150);
                    int x = 215 + (155 * j);
                    int y = 80 + (155 * i);
                    b.Location = new Point(x, y);
                    b.Cursor = Cursors.Hand;
                    b.Font = new Font("Futura XBlkIt BT", 26F, FontStyle.Bold);
                    b.Visible = false;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 2;
                    b.FlatAppearance.BorderColor = Color.White;
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 255, 255, 255);
                    b.ForeColor = Color.Black;
                    b.BackColor = Color.Transparent;
                    b.Click += new EventHandler(slot_Click);
                    Controls.Add(b);
                }
            setBoard();
            logic = new Logic(board);
        }

        private void setBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = 0;
        }

        private Button findOutside(int i)
        {
            foreach(Control c in Controls)
                if(c.GetType().Name == "Button")
                {
                    Button b = (Button)c;
                    if (b.Name == "outside" + i)
                        return b;
                }
            return null;
        }

        private Button findSlot(int i, int j)
        {
            foreach (Control c in Controls)
                if (c.GetType().Name == "Button")
                {
                    Button b = (Button)c;
                    if (b.Name == "slot" + i + j)
                        return b;
                }
            return null;
        }

        private void changeBackColors(Color myColor)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    Button slot = findSlot(i, j);
                    if (slot.Text == "")
                        slot.FlatAppearance.MouseOverBackColor = myColor;
                }
        }

        private void setTurnCounter()
        {
            if(turn%2==1)
            {
                turnCounter.Text = "Yellow's Turn";
                turnCounter.Location = new Point(344, turnCounter.Location.Y);
            }
            else
            {
                turnCounter.Text = "Orange's Turn";
                turnCounter.Location = new Point(337, turnCounter.Location.Y);
            }
        }

        private void mode_Click(object sender, EventArgs e)
        {
            PlayClick();
            Button b = (Button)sender;
            pvpButton.Visible = false;
            pveButton.Visible = false;
            menuLabel.Visible = false;
            chunkyRunky.Visible = false;
            rules.Visible = false;
            if(b.Name == "pvpButton")
                setTurnCounter();
            else
            {
                AImode = true;
                turnCounter.Text = "~3~ seconds";
                turnCounter.Location = new Point(342, turnCounter.Location.Y);
            }
            for (int i = 1; i <= 9; i++)
            {
                findOutside(i).Visible = true;
                findSlot((i - 1) / 3, (i - 1) % 3).Visible = true;
            }
        }

        private void outside_Click(object sender, EventArgs e)
        {
            if (!isPlayer)
                return;
            PlaySelect();
            Button b = (Button)sender;
            int n = int.Parse(b.Text);
            if(turn%2 != n%2)
            {
                MessageBox.Show("Not your numbers!");
                return;
            }
            if (numberClicked != 0)
                if(numberClicked == n)
                {
                    b.FlatAppearance.BorderColor = Color.Black;
                    numberClicked = 0;
                    changeBackColors(Color.FromArgb(150,255,255,255));
                    return;
                }
                else
                    findOutside(numberClicked).FlatAppearance.BorderColor = Color.Black;
            findOutside(n).FlatAppearance.BorderColor = Color.White;
            numberClicked = n;
            Color myColor = (turn % 2 == 0) ? Color.FromArgb(190, 255, 128, 0) : Color.FromArgb(190, 252, 212, 4);
            changeBackColors(myColor);
        }

        private void slot_Click(object sender, EventArgs e)
        {
            if (!isPlayer || gameEnded)
                return;
            PlayTic();
            if (numberClicked == 0)
            {
                MessageBox.Show("Didn't pick a number!");
                return;
            }
            Button b = (Button)sender;
            if(b.BackColor != Color.Transparent)
            {
                MessageBox.Show("Slot already picked!");
                return;
            }
            int i = int.Parse(b.Name[4].ToString());
            int j = int.Parse(b.Name[5].ToString());
            board[i, j] = numberClicked;
            b.Text = numberClicked.ToString();
            if (numberClicked % 2 == 0)
                b.BackColor = Color.FromArgb(255, 128, 0);
            else
                b.BackColor = Color.Gold;
            findOutside(numberClicked).Visible = false;
            changeBackColors(Color.FromArgb(150, 255, 255, 255));
            logic.setBoard(board);
            String winner = logic.checkWinner(turn, i, j);
            switch (winner)
            {
                case "no":
                    break;
                case "tie":
                    turnCounter.Text = "Tie Game!";
                    turnCounter.Location = new Point(367, turnCounter.Location.Y);
                    endGame(winner);
                    return;
                default:
                    if(turn%2==0)
                    {
                        turnCounter.Text = "Orange Wins!";
                        turnCounter.Location = new Point(340, turnCounter.Location.Y);
                    }
                    else
                    {
                        turnCounter.Text = "Yellow Wins!";
                        turnCounter.Location = new Point(347, turnCounter.Location.Y);
                    }
                    endGame(winner);
                    return;
            }
            turn++;
            numberClicked = 0;
            if(!AImode)
            {
                setTurnCounter();
                return;
            }
            isPlayer = !isPlayer;
            AIPerformMove();
            PlayTic();
        }

        private void AIPerformMove()
        {
            int[] move = logic.AIPerformMove(turn);
            int bestI = move[0], bestJ = move[1], bestN = move[2];
            board[bestI, bestJ] = bestN;
            Button slot = findSlot(bestI, bestJ);
            slot.Text = bestN.ToString();
            slot.BackColor = Color.FromArgb(255, 128, 0);
            slot.FlatAppearance.MouseOverBackColor = Color.FromArgb(190, 255, 128, 0);
            findOutside(bestN).Visible = false;
            changeBackColors(Color.FromArgb(150, 255, 255, 255));
            logic.setBoard(board);
            String winner = logic.checkWinner(turn, bestI, bestJ);
            switch (winner)
            {
                case "no":
                    turnCounter.Text = "";
                    break;
                case "tie":
                    turnCounter.Text = "Tie Game!";
                    turnCounter.Location = new Point(367, turnCounter.Location.Y);
                    endGame(winner);
                    return;
                default:
                    if (turn % 2 == 0)
                    {
                        turnCounter.Text = "Orange Wins!";
                        turnCounter.Location = new Point(340, turnCounter.Location.Y);
                    }
                    else
                    {
                        turnCounter.Text = "Yellow Wins!";
                        turnCounter.Location = new Point(347, turnCounter.Location.Y);
                    }
                    endGame(winner);
                    return;
            }
            turn++;
            isPlayer = !isPlayer;
        }

        private void endGame(String winner)
        {
            gameEnded = true;
            for (int i = 1; i <= 9; i++)
            {
                findOutside(i).Visible = false;
                findSlot((i - 1) / 3, (i - 1) % 3).Enabled = false;
            }
            if (winner == "tie")
                restartButton.BackColor = Color.FromArgb(254, 170, 2);
            else if (turn % 2 == 1)
                restartButton.BackColor = Color.Gold;
            else
                restartButton.BackColor = Color.FromArgb(255, 128, 0);
            restartButton.Visible = true;
            if (winner == "tie")
                return;
            for (int x = 0; x < winner.Length; x += 2)
            {
                int i = int.Parse(winner[x].ToString());
                int j = int.Parse(winner[x + 1].ToString());
                findSlot(i, j).Enabled = true;
                findSlot(i, j).FlatAppearance.BorderColor = Color.Black;
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            PlayClick();
            setBoard();
            turn = 1;
            numberClicked = 0;
            AImode = false;
            isPlayer = true;
            gameEnded = false;
            for (int i = 1; i <= 9; i++)
            {
                findOutside(i).FlatAppearance.BorderColor = Color.Black;
                Button slot = findSlot((i - 1) / 3, (i - 1) % 3);
                slot.Visible = false;
                slot.Text = "";
                slot.BackColor = Color.Transparent;
                slot.Enabled = true;
                slot.FlatAppearance.BorderColor = Color.White;
            }
            changeBackColors(Color.FromArgb(150, 255, 255, 255));
            restartButton.Visible = false;
            turnCounter.Text = "";
            menuLabel.Visible = true;
            pvpButton.Visible = true;
            pveButton.Visible = true;
            chunkyRunky.Visible = true;
            rules.Visible = true;
        }

        private void PlayClick()
        {
            System.IO.Stream sound = Properties.Resources.click;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(sound);
            snd.Play();
        }

        private void PlaySelect()
        {
            System.IO.Stream sound = Properties.Resources.select;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(sound);
            snd.Play();
        }

        private void PlayTic()
        {
            System.IO.Stream sound = Properties.Resources.tic;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(sound);
            snd.Play();
        }
    }
}