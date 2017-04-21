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
    public partial class Promotion : Form
    {
        public string chessPiece { get; private set; }
        /// <summary>
        /// Variabelen die gebruik worden in AddGuiElements()
        /// </summary>
        #region GUI objects
        PictureBox PromotionKnightPictureBox = new PictureBox();
        PictureBox PromotionQueenPictureBox = new PictureBox();
        PictureBox PromotionBishopPictureBox = new PictureBox();
        PictureBox PromotionRookPictureBox = new PictureBox();
        PictureBox GUIBitmapPictureBox = new PictureBox();
        Bitmap GUIBitmap = new Bitmap(150, 150);
        #endregion

        // Add all the GUI elements to the Promotion screen
        private void AddGuiElements()
        {
            PromotionKnightPictureBox.Location = new Point(10, 10);
            PromotionKnightPictureBox.Size = new Size(50, 60);
            PromotionKnightPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PromotionKnightPictureBox.BackColor = Color.Transparent;
            PromotionKnightPictureBox.Image = Image.FromFile(@"..\..\..\ChessGame\Images\piece_white_knight.png");
            Controls.Add(PromotionKnightPictureBox);
            PromotionKnightPictureBox.Parent = GUIBitmapPictureBox;
            PromotionKnightPictureBox.MouseClick += PromotionKnightButton_MouseClick;

            PromotionQueenPictureBox.Location = new Point(10, 80);
            PromotionQueenPictureBox.Size = new Size(50, 60);
            PromotionQueenPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PromotionQueenPictureBox.BackColor = Color.Transparent;
            PromotionQueenPictureBox.Image = Image.FromFile(@"..\..\..\ChessGame\Images\piece_white_queen.png");
            Controls.Add(PromotionQueenPictureBox);
            PromotionQueenPictureBox.Parent = GUIBitmapPictureBox;
            PromotionQueenPictureBox.MouseClick += PromotionQueenButton_MouseClick;

            PromotionBishopPictureBox.Location = new Point(80, 10);
            PromotionBishopPictureBox.Size = new Size(50, 60);
            PromotionBishopPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PromotionBishopPictureBox.BackColor = Color.Transparent;
            PromotionBishopPictureBox.Image = Image.FromFile(@"..\..\..\ChessGame\Images\piece_white_bishop.png");
            Controls.Add(PromotionBishopPictureBox);
            PromotionBishopPictureBox.Parent = GUIBitmapPictureBox;
            PromotionBishopPictureBox.MouseClick += PromotionBishopButton_MouseClick;

            PromotionRookPictureBox.Location = new Point(80, 80);
            PromotionRookPictureBox.Size = new Size(50, 60);
            PromotionRookPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PromotionRookPictureBox.BackColor = Color.Transparent;
            PromotionRookPictureBox.Image = Image.FromFile(@"..\..\..\ChessGame\Images\piece_white_rook.png");
            Controls.Add(PromotionRookPictureBox);
            PromotionRookPictureBox.Parent = GUIBitmapPictureBox;
            PromotionRookPictureBox.MouseClick += PromotionRookButton_MouseClick;
            

            using (Graphics graphics = Graphics.FromImage(GUIBitmap))
            {
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\ChessBackground.jpg"), 0, 0, 150, 150);
            }

            GUIBitmapPictureBox.Location = new Point(0, 0);
            GUIBitmapPictureBox.Size = new Size(150, 150);
            GUIBitmapPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            GUIBitmapPictureBox.Image = GUIBitmap;
            Controls.Add(GUIBitmapPictureBox);
        }
        // Slaat de keuze op die je hebt gemaakt
        
        public Promotion()
        {
            AddGuiElements();
            InitializeComponent();
        }
        // Slaat de keuze op die je hebt gemaakt als je hierop klikt
        private void PromotionKnightButton_MouseClick(object sender, EventArgs e)
        {
            chessPiece = "knight";
            DialogResult = DialogResult.OK;
        }
        // Slaat de keuze op die je hebt gemaakt als je hierop klikt
        private void PromotionQueenButton_MouseClick(object sender, EventArgs e)
        {
            chessPiece = "queen";
            DialogResult = DialogResult.OK;
        }
        // Slaat de keuze op die je hebt gemaakt als je hierop klikt
        private void PromotionBishopButton_MouseClick(object sender, EventArgs e)
        {
            chessPiece = "bishop";
            DialogResult = DialogResult.OK;
        }
        // Slaat de keuze op die je hebt gemaakt als je hierop klikt
        private void PromotionRookButton_MouseClick(object sender, EventArgs e)
        {
            chessPiece = "rook";
            DialogResult = DialogResult.OK;
        }
    }
}
