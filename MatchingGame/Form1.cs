using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        string rightly = "D:\\work\\sounds\\pravilno.wav";
        string wrongly = "D:\\work\\sounds\\no.wav";
        bool enable = false;
        int timeleft;
        Label firstClicked = null;
        Label secondClicked = null;
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "K", "K",
            "b", "b", "v", "v", "w", "w", "z", "z",
            "j", "j", "k", "k", "o", "o", "@", "@",
            "L", "L", "h", "h", "B", "B", "~", "~",
            "-", "-", "%", "%"
        };

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumer = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumer];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumer);
                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (enable == true)
            {
                Label clickLabel = sender as Label;
                if (clickLabel != null)
                {
                    if (clickLabel.ForeColor == Color.Black)
                        return;

                    if (firstClicked == null)
                    {
                        firstClicked = clickLabel;
                        firstClicked.ForeColor = Color.Black;
                        return;
                    }

                    if (secondClicked == null)
                    {
                        secondClicked = clickLabel;
                        secondClicked.ForeColor = Color.Black;
                    }

                    CheckForWinner();

                    if (firstClicked.Text == secondClicked.Text)
                    {
                        SoundPlayer player = new SoundPlayer(rightly);
                        player.Play();
                        firstClicked = null;
                        secondClicked = null;
                        return;
                    }

                    else
                    {
                        SoundPlayer player = new SoundPlayer(wrongly);
                        player.Play(); 
                        timer1.Start();
                    }
              
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            timeleft = 300;
            timer2.Start();
            StartButton.Enabled = false;
            enable = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeleft > 0)
            {
                timeleft--;
                label37.Text = timeleft + " Seconds";
                checkForLoss();
            }
        }

        private void checkForLoss()
        {
            if(timeleft == 0)
            {
                timer2.Stop();
                tableLayoutPanel1.Enabled = false;
                MessageBox.Show("Time is up!!!", "Ooops"); 
                Close();
            }
        }

        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            timer2.Stop();
            MessageBox.Show("You match all icons!", "Congratulations");
            Close();
        }
    }
}