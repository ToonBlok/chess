using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class StartScreen : Form
    {
        public string playerNameOne { get; private set; }
        public string playerNameTwo { get; private set; }
        public bool startButtonPushed = false;
        /// <summary>
        /// Variabelen die gebruik worden in AddGuiElements()
        /// </summary>
        #region GUI objects
        Button ChessGameStartButton = new Button();
        Button ChessGameQuitButton = new Button();
        Label ChessPlayer01Label = new Label();
        Label ChessPlayer02Label = new Label();
        TextBox ChessPlayer01TextBox = new TextBox();
        TextBox ChessPlayer02TextBox = new TextBox();
        PictureBox GUIBitmapPictureBox = new PictureBox();
        Bitmap GUIBitmap = new Bitmap(1000, 600);
        #endregion

        // Adds the start screen GUI elements
        private void AddGuiElements()
        {
            // Input name box of player 1
            ChessPlayer01TextBox.Location = new Point(400, 248);
            ChessPlayer01TextBox.Size = new Size(140, 20);
            ChessPlayer01TextBox.Visible = true;
            ChessPlayer01TextBox.Text = "";
            Controls.Add(ChessPlayer01TextBox);

            // Input name box of player 2
            ChessPlayer02TextBox.Location = new Point(400, 320);
            ChessPlayer02TextBox.Size = new Size(140, 20);
            ChessPlayer02TextBox.Visible = true;
            ChessPlayer02TextBox.Text = "";
            Controls.Add(ChessPlayer02TextBox);

            // The start button
            ChessGameStartButton.Location = new Point(400, 364);
            ChessGameStartButton.Size = new Size(140, 46);
            ChessGameStartButton.Visible = true;
            ChessGameStartButton.Font = new Font("Arial", 12, FontStyle.Bold);
            ChessGameStartButton.Text = "Start";
            Controls.Add(ChessGameStartButton);
            ChessGameStartButton.Click += ChessGameStart_Click;

            // Quit button
            ChessGameQuitButton.Location = new Point(906, 568);
            ChessGameQuitButton.Size = new Size(55, 20);
            ChessGameQuitButton.Visible = true;
            ChessGameQuitButton.Font = new Font("Arial", 8, FontStyle.Bold);
            ChessGameQuitButton.Text = "Quit";
            Controls.Add(ChessGameQuitButton);
            ChessGameQuitButton.MouseClick += ChessGameQuitButton_MouseClick;

            // Text above input name box of player 1
            ChessPlayer01Label.Location = new Point(433, 222);
            ChessPlayer01Label.Size = new Size(113, 20);
            ChessPlayer01Label.Visible = true;
            ChessPlayer01Label.BackColor = Color.Transparent;
            ChessPlayer01Label.Font = new Font("Arial", 12);
            ChessPlayer01Label.ForeColor = Color.White;
            ChessPlayer01Label.Text = "Player white";
            this.Controls.Add(ChessPlayer01Label);
            ChessPlayer01Label.Parent = GUIBitmapPictureBox;

            // Text above input name box of player 2
            ChessPlayer02Label.Location = new Point(433, 294);
            ChessPlayer02Label.Size = new Size(113, 20);
            ChessPlayer02Label.Visible = true;
            ChessPlayer02Label.BackColor = Color.Transparent;
            ChessPlayer02Label.Font = new Font("Arial", 12);
            ChessPlayer02Label.ForeColor = Color.White;
            ChessPlayer02Label.Text = "Player black";
            this.Controls.Add(ChessPlayer02Label);
            ChessPlayer02Label.Parent = GUIBitmapPictureBox;

            using (Graphics graphics = Graphics.FromImage(GUIBitmap))
            {
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\ChessBackground.jpg"), 0, 0, 1000, 600);
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\ResetBox.png"), 922, 563, 63, 28);
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\WelcomeBox.png"), 316, 213, 348, 62);
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\WelcomeBox.png"), 316, 285, 348, 62);
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\WelcomeBox.png"), 316, 357, 348, 62);
            }

            GUIBitmapPictureBox.Location = new Point(-20, 0);
            GUIBitmapPictureBox.Size = new Size(1000, 600);
            GUIBitmapPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            GUIBitmapPictureBox.Image = GUIBitmap;
            Controls.Add(GUIBitmapPictureBox);
        }
        private void ChessGameQuitButton_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
        private void ChessGameStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ChessPlayer01TextBox.Text) || String.IsNullOrEmpty(ChessPlayer02TextBox.Text))
            {
                MessageBox.Show("Please enter a name for both players", "Error", MessageBoxButtons.OK);
            }
            else if (ChessPlayer01TextBox.Text.Length > 18 || ChessPlayer02TextBox.Text.Length > 18)
            {
                MessageBox.Show("Name is too long", "Error", MessageBoxButtons.OK);
            }
            else
            {
                playerNameOne = ChessPlayer01TextBox.Text;
                playerNameTwo = ChessPlayer02TextBox.Text;
                startButtonPushed = true;
                this.Close();
            }   
        }

        public StartScreen()
        {
            InitializeComponent();
            AddGuiElements();
        }
    }
}
