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
    partial class Chessboard : Form
    {
        private string playerNameOne { get; set; }
        private string playerNameTwo { get; set; }

        public Tile[,] ChessboardTileArray = new Tile[8, 8];

        // De Bitmap waar het schaakbord in staat (niet de GUI)
        private Bitmap ChessboardBitmap = new Bitmap(400, 400);
        // De PictureBox die BitmapChessboard als achtergrond heeft
        private PictureBox ChessboardBitmapPictureBox = new PictureBox();

        /// <summary>
        /// Variabelen die gebruik worden in AddGuiElements()
        /// </summary>
        #region GUI variables
        Button ChessGameRestartButton = new Button();
        Button ChessGameQuitButton = new Button();
        Label ChessPlayer01Label = new Label();
        Label ChessPlayer02Label = new Label();
        PictureBox GUIBitmapPictureBox = new PictureBox();
        Bitmap GUIBitmap = new Bitmap(1000, 600);
        #endregion

        /// <summary>
        /// Tekent alle GUI objecten (behalve het schaakbord) naar een Bitmap, deze Bitmap wordt als achtergrond gezet voor een PictureBox waarna de PictureBox getoond wordt.
        /// </summary>
        private void AddGuiElements()
        {
            // The restart button
            ChessGameRestartButton.Location = new Point(906, 546);
            ChessGameRestartButton.Size = new Size(55, 20);
            ChessGameRestartButton.Visible = true;
            ChessGameRestartButton.Font = new Font("Arial", 8, FontStyle.Bold);
            ChessGameRestartButton.Text = "Restart";
            Controls.Add(ChessGameRestartButton);
            ChessGameRestartButton.Click -= ChessGameRestart_Click;
            ChessGameRestartButton.Click += ChessGameRestart_Click;

            // Quit button
            ChessGameQuitButton.Location = new Point(906, 568);
            ChessGameQuitButton.Size = new Size(55, 20);
            ChessGameQuitButton.Visible = true;
            ChessGameQuitButton.Font = new Font("Arial", 8, FontStyle.Bold);
            ChessGameQuitButton.Text = "Quit";
            Controls.Add(ChessGameQuitButton);
            ChessGameQuitButton.MouseClick += ChessGameQuitButton_MouseClick;

            // Label inside nameplate player 1
            ChessPlayer01Label.Text = playerNameOne;
            ChessPlayer01Label.Location = new Point(90, 34);  // (44, 25); and then (84, 25);
            ChessPlayer01Label.Size = new Size(200, 40);
            ChessPlayer01Label.Visible = true;
            ChessPlayer01Label.BackColor = Color.Transparent;
            ChessPlayer01Label.Font = new Font("Arial", 12);
            ChessPlayer01Label.ForeColor = Color.White;
            this.Controls.Add(ChessPlayer01Label);
            ChessPlayer01Label.Parent = GUIBitmapPictureBox;

            // Label inside nameplate player 2
            ChessPlayer02Label.Text = playerNameTwo;
            ChessPlayer02Label.Location = new Point(799, 34); // (755, 25);
            ChessPlayer02Label.Size = new Size(200, 40);
            ChessPlayer02Label.Visible = true;
            ChessPlayer02Label.BackColor = Color.Transparent;
            ChessPlayer02Label.Font = new Font("Arial", 12);
            ChessPlayer02Label.ForeColor = Color.White;
            this.Controls.Add(ChessPlayer02Label);
            ChessPlayer02Label.Parent = GUIBitmapPictureBox;

            using (Graphics graphics = Graphics.FromImage(GUIBitmap))
            {
                // Het houten achtergrond plaatje
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\ChessBackground.jpg"), 0, 0, 1000, 600);
                // Zwart vakje om het schaakbord heen
                graphics.DrawImage(Image.FromFile(@"..\..\..\chessgame\images\chessboxbackground.png"), 265, 60, 470, 470);
                // Wanneer een speler aan de beurt is wordt de nameplate van de speler groen
                if (WhiteRound == true)
                {
                    graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\PlayerNameBoxSelected.png"), 42, 20, 211, 51);
                    graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\PlayerNameBox.png"), 750, 20, 211, 51);
                }
                else
                {
                    graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\PlayerNameBox.png"), 42, 20, 211, 51);
                    graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\PlayerNameBoxSelected.png"), 750, 20, 211, 51);
                }
                // Verschillende andere GUI elementen
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\ResetBox.png"), 922, 564, 63, 28);
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\ResetBox.png"), 922, 540, 63, 28);
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\piece_white_rook.png"), 42, 18, 50, 50);
                graphics.DrawImage(Image.FromFile(@"..\..\..\ChessGame\Images\piece_black_rook.png"), 750, 18, 50, 50);

            }
            // De PictureBox die de Bitmap met de GUI elementen (niet het schaakbord) als achtergrond heeft
            GUIBitmapPictureBox.Location = new Point(-20, 0);
            GUIBitmapPictureBox.Size = new Size(1000, 600);
            GUIBitmapPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            GUIBitmapPictureBox.Image = GUIBitmap;
            Controls.Add(GUIBitmapPictureBox);
        }
        /// <summary>
        /// De quit knop 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChessGameQuitButton_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Variablen die alleen gebruikt worden binnen de methode BitmapPictureBox_MouseClick
        /// </summary>
        #region MouseClick variables
        int CurrentColumn = 0;
        int CurrentRow = 0;
        int PreviousColumn = 0;
        int PreviousRow = 3;
        bool FirstSelect = false;
        bool WhiteRound = true;
        #endregion
        /// <summary>
        /// Deze method behandelt de muis klik van de speler. The speler kan een Tile selecteren met een schaakstuk, een Tile met een schaakstuk deselecteren en kan een bestemming kiezen voor een Tile met schaakstuk wanneer deze geselecteerd is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BitmapPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Bereken welk vakje je wilt selecteren
            if (e.Button == MouseButtons.Left)
            {
                CurrentColumn = e.Location.Y / 50;
                CurrentRow = e.Location.X / 50;
            }
            // Als de eerste en tweede klik op hetzelfde vakje gedaan zijn, deselecteer het vakje dan
            if ((PreviousColumn == CurrentColumn) && (PreviousRow == CurrentRow) && (FirstSelect == true))
            {
                ChessboardTileArray[PreviousColumn, PreviousRow].Deselect();
                PreviousColumn = 0;
                PreviousRow = 0;
                FirstSelect = false;
            }
            else
            {
                // Deselecteer het eerste geselecteerde vakje wanneer een zet gemaakt is
                ChessboardTileArray[PreviousColumn, PreviousRow].Deselect();
                // Voert uit bij tweede klik
                #region (FirstSelect == true)
                if (FirstSelect == true)
                {
                    ChessboardTileArray[PreviousColumn, PreviousRow].Move(ChessboardTileArray[CurrentColumn, CurrentRow]);
                    if (ChessboardTileArray[PreviousColumn, PreviousRow].legalMove == true)
                    {
                        if (WhiteRound == true)
                        {
                            WhiteRound = false;
                        }
                        else
                        {
                            WhiteRound = true;
                        }
                        ChessboardTileArray[PreviousColumn, PreviousRow].legalMove = false;
                        AddGuiElements();
                    }
                    FirstSelect = false;
                }
                #endregion
                else if (ChessboardTileArray[CurrentColumn, CurrentRow].MyChesspiece != null)
                {
                    // Als wit aan de beurt is
                    if (WhiteRound == true && ChessboardTileArray[CurrentColumn, CurrentRow].MyChesspiece.ChessPieceColor == "white")
                    {
                        // Laat het vakje een andere kleur krijgen om aan te geven dat het geselecteerd is
                        ChessboardTileArray[CurrentColumn, CurrentRow].Select();
                        PreviousColumn = CurrentColumn;
                        PreviousRow = CurrentRow;
                        // Het programma weet door FirstSelect = true nu dat een eerste selectie gemaakt is
                        FirstSelect = true;
                    }

                    // Als zwart aan de beurt is
                    else if (WhiteRound == false && ChessboardTileArray[CurrentColumn, CurrentRow].MyChesspiece.ChessPieceColor == "black")
                    {
                        // Laat het vakje een andere kleur krijgen om aan te geven dat het geselecteerd is
                        ChessboardTileArray[CurrentColumn, CurrentRow].Select();
                        PreviousColumn = CurrentColumn;
                        PreviousRow = CurrentRow;
                        // Het programma weet door FirstSelect = true nu dat een eerste selectie gemaakt is
                        FirstSelect = true;
                    }
                }
            }
            // Wanneer er een klik uitgevoerd is, teken dan opnieuw de vakjes
            FillBitmapTiles(ChessboardTileArray, ChessboardBitmap);
            // Wanneer er een klik uitgevoerd is, teken dan na de vakjes opnieuw de schaakstukken
            FillBitmapChesspieces(ChessboardTileArray, ChessboardBitmap);
            // Laat uiteindelijk de Bitmap opnieuw zien
            DisplayBitmap();
        }

        /// <summary>
        /// Herstart het spel. Alle posities in de TileArray (die vakjes met daarop schaakstukken vasthoudt) worden verwijdert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChessGameRestart_Click(object sender, EventArgs e)
        {
            ChessboardTileArray = new Tile[8, 8];
            GC.Collect();
            GC.WaitForPendingFinalizers();
            MessageBox.Show("Chess is restarted", "Error", MessageBoxButtons.OK);

            ChessGame chessGame = new ChessGame();
            chessGame.FillArrayTiles(ref ChessboardTileArray);
            chessGame.FillArrayChesspieces(ref ChessboardTileArray);
            chessGame.DetermineNeighbours(ref ChessboardTileArray);
            FillBitmapTiles(ChessboardTileArray, ChessboardBitmap);
            FillBitmapChesspieces(ChessboardTileArray, ChessboardBitmap);
            DisplayBitmap();
            WhiteRound = true;
            FirstSelect = false;
            AddGuiElements();
        }

        /// <summary>
        /// Teken de vakjes opnieuw naar een Bitmap
        /// </summary>
        /// <param name="ChessboardTileArray">Gebruik hierbij de TileArray</param>
        /// <param name="Bitmap">Gebruik hierbij al de bestaande Bitmap</param>
        private void FillBitmapTiles(Tile[,] ChessboardTileArray, Bitmap ChessboardBitmap)
        {
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    ChessboardTileArray[column, row].AddTileToBitmap(row * 50, column * 50, ChessboardBitmap);
                }
            }
        }

        /// <summary>
        /// Teken de schaakstukken bovenop de vakjes
        /// </summary>
        /// <param name="ChessboardTileArray">Gebruik hierbij de TileArray</param>
        /// <param name="Bitmap">Gebruik hierbij al de bestaande Bitmap</param>
        private void FillBitmapChesspieces(Tile[,] tileArray, Bitmap ChessboardBitmap)
        {
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    if (ChessboardTileArray[column, row].MyChesspiece != null)
                    {
                        tileArray[column, row].AddChessPieceToBitmap(row * 50, column * 50, ChessboardBitmap);
                    }
                }
            }
        }

        /// <summary>
        /// Laat de Bitmap zien door het als achtergrond in een PictureBox te tekenen
        /// </summary>
        private void DisplayBitmap()
        {
            ChessboardBitmapPictureBox.Size = new Size(400, 400);
            ChessboardBitmapPictureBox.Location = new Point(299, 94);
            ChessboardBitmapPictureBox.BackgroundImage = ChessboardBitmap;
            Controls.Add(ChessboardBitmapPictureBox);
            ChessboardBitmapPictureBox.Parent = GUIBitmapPictureBox;
            ChessboardBitmapPictureBox.MouseClick -= BitmapPictureBox_MouseClick;
            ChessboardBitmapPictureBox.MouseClick += BitmapPictureBox_MouseClick;
        }

        /// <summary>
        /// Ontvangt speler namen vanuit ChessApp en zet deze gelijk aan variabelen in deze class 
        /// </summary>
        /// <param name="_playerNameOne"></param>
        /// <param name="_playerNameTwo"></param>
        public Chessboard(string _playerNameOne,  string _playerNameTwo)
        {
            playerNameOne = _playerNameOne;
            playerNameTwo = _playerNameTwo;
            InitializeComponent();
            AddGuiElements();

            ChessGame chessGame = new ChessGame();
            chessGame.FillArrayTiles(ref ChessboardTileArray);
            chessGame.FillArrayChesspieces(ref ChessboardTileArray);
            chessGame.DetermineNeighbours(ref ChessboardTileArray);

            FillBitmapTiles(ChessboardTileArray, ChessboardBitmap);
            FillBitmapChesspieces(ChessboardTileArray, ChessboardBitmap);
            DisplayBitmap();
        }
    }
}