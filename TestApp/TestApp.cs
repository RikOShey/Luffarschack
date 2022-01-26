using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class TestApp : Form
    {
        private List<PictureBox> boxes = new List<PictureBox>();
        string player;

        public TestApp()
        {
            InitializeComponent();
        }

        private void TestApp_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                PictureBox newPB = new PictureBox();
                newPB.Name = "PicBox" + i.ToString();
                newPB.SizeMode = PictureBoxSizeMode.StretchImage;
                newPB.Image = null;
                newPB.Size = new Size(100, 100);
                newPB.BorderStyle = BorderStyle.Fixed3D;
                newPB.Enabled = false;
                newPB.Click += new EventHandler(pb_Click);
                newPB.Cursor = Cursors.Hand;

                if (i == 0) newPB.Location = new Point(12, 12);
                if (i == 1) newPB.Location = new Point(117, 12);
                if (i == 2) newPB.Location = new Point(222, 12);
                if (i == 3) newPB.Location = new Point(12, 117);
                if (i == 4) newPB.Location = new Point(117, 117);
                if (i == 5) newPB.Location = new Point(222, 117);
                if (i == 6) newPB.Location = new Point(12, 222);
                if (i == 7) newPB.Location = new Point(117, 222);
                if (i == 8) newPB.Location = new Point(222, 222);

                boxes.Add(newPB);
                this.Controls.Add(newPB);
            }
            pictureBox1.Location = new Point(339, 100);
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        void pb_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if (player == Player1.Text)
            {
                clickedPictureBox.Image = Properties.Resources.GreenButton;
                clickedPictureBox.Tag = 1;
                clickedPictureBox.Enabled = false;
                CheckBoxes();
                player = Player2.Text;
                label3.Text = "Spelare: " + player;
            }
            else
            {
                clickedPictureBox.Image = Properties.Resources.RedButton;
                clickedPictureBox.Tag = 2;
                clickedPictureBox.Enabled = false;
                CheckBoxes();
                player = Player1.Text;
                label3.Text = "Spelare: " + player;
            }
        }

        private void CheckBoxes()
        {
            if (boxes[0].Tag != null && boxes[1].Tag != null && boxes[2].Tag != null)
            {
                if (boxes[0].Tag.ToString() == boxes[1].Tag.ToString() && boxes[1].Tag.ToString() == boxes[2].Tag.ToString())
                {
                    PlayAgain("win");
                }
            }

            if (boxes[3].Tag != null && boxes[4].Tag != null && boxes[5].Tag != null)
            {
                if (boxes[3].Tag.ToString() == boxes[4].Tag.ToString() && boxes[4].Tag.ToString() == boxes[5].Tag.ToString())
                {
                    PlayAgain("win");
                }
            }

            if (boxes[6].Tag != null && boxes[7].Tag != null && boxes[8].Tag != null)
            {
                if (boxes[6].Tag.ToString() == boxes[7].Tag.ToString() && boxes[7].Tag.ToString() == boxes[8].Tag.ToString())
                {
                    PlayAgain("win");
                }
            }

            if (boxes[0].Tag != null && boxes[3].Tag != null && boxes[6].Tag != null)
            {
                if (boxes[0].Tag.ToString() == boxes[3].Tag.ToString() && boxes[3].Tag.ToString() == boxes[6].Tag.ToString())
                {
                    PlayAgain("win");
                }
            }

            if (boxes[1].Tag != null && boxes[4].Tag != null && boxes[7].Tag != null)
            {
                if (boxes[1].Tag.ToString() == boxes[4].Tag.ToString() && boxes[4].Tag.ToString() == boxes[7].Tag.ToString())
                {
                    PlayAgain("win");
                }
            }

            if (boxes[2].Tag != null && boxes[5].Tag != null && boxes[8].Tag != null)
            {
                if (boxes[2].Tag.ToString() == boxes[5].Tag.ToString() && boxes[5].Tag.ToString() == boxes[8].Tag.ToString())
                {
                    PlayAgain("win");
                }
            }

            if (boxes[0].Tag != null && boxes[4].Tag != null && boxes[8].Tag != null)
            {
                if (boxes[0].Tag.ToString() == boxes[4].Tag.ToString() && boxes[4].Tag.ToString() == boxes[8].Tag.ToString())
                {
                    PlayAgain("win");
                }
            }

            if (boxes[2].Tag != null && boxes[4].Tag != null && boxes[6].Tag != null)
            {
                if (boxes[2].Tag.ToString() == boxes[4].Tag.ToString() && boxes[4].Tag.ToString() == boxes[6].Tag.ToString())
                {
                    PlayAgain("win");
                }
            }
            
            if (boxes[0].Tag != null && boxes[1].Tag != null && boxes[2].Tag != null && boxes[3].Tag != null && boxes[4].Tag != null && boxes[5].Tag != null && boxes[6].Tag != null && boxes[7].Tag != null && boxes[8].Tag != null)
            {
                PlayAgain("tie");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Player1.Text == "" || Player2.Text == "")
            {
                MessageBox.Show ("Man måste ange namn i båda fälten!", "Ange namn...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                player = Player1.Text;
                button1.Enabled = false;
            }

            foreach (Control child in this.Controls)
            {
                if (child is PictureBox)
                {
                    ((PictureBox)child).Image = null;
                    ((PictureBox)child).Tag = null;
                    ((PictureBox)child).Enabled = true;
                }
            }
            label3.Text = "Spelare: " + player;
        }

        private void PlayAgain(string result)
        {
            if (result == "win")
            {
                label3.Text = "Vinnare: " + player;
                pictureBox1.Image = Properties.Resources.Winner;
                DialogResult dialogResult = MessageBox.Show("Vinnare: " + player + "\nVill ni spela igen?", "Fråga...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    button1_Click(this, null);
                }
                else if (dialogResult == DialogResult.No)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                label3.Text = "Oavgjort!";
                pictureBox1.Image = Properties.Resources.TiedGame;
                DialogResult dialogResult = MessageBox.Show("Oavgjort!\nVill ni spela igen?", "Fråga...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    button1_Click(this, null);
                }
                else if (dialogResult == DialogResult.No)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
