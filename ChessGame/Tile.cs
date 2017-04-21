using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    class Tile
    {
        // Elk vakje heeft een schaakstuk
        public ChessPiece MyChesspiece { get; set; }
        // Elk vakje heeft een kleur
        private string Color;
        // Image van een vakje (zwart of wit)
        private Image NewTile;
        // Hiermee wordt gekeken wanneer een beurt voorbij is doordat de beweging wel of niet correct is
        public bool legalMove = false;

        public Tile TileNorth { get; private set; }
        public Tile TileNorthEast { get; private set; }
        public Tile TileEast { get; private set; }
        public Tile TileSouthEast { get; private set; }
        public Tile TileSouth { get; private set; }
        public Tile TileSouthWest { get; private set; }
        public Tile TileWest { get; private set; }
        public Tile TileNorthWest { get; private set; }

        /// <summary>
        /// .Move ontvangt het tweede geselecteerde vakje
        /// .Move receives the second selected Tile, it tries to match this tile with a neighbour
        /// </summary>
        /// <param name="ReceivedTile"></param>
        public void Move(Tile ReceivedTile)
        {
            MyChesspiece.MoveStyle(ReceivedTile, this);
        }
        /// <summary>
        /// Receives the tiles that were determined to be a neighbour in ChessGame
        /// </summary>
        /// <param name="_TileNorth"></param>
        /// <param name="_TileNorthEast"></param>
        /// <param name="_TileEast"></param>
        /// <param name="_TileSouthEast"></param>
        /// <param name="_TileSouth"></param>
        /// <param name="_TileSouthWest"></param>
        /// <param name="_TileWest"></param>
        /// <param name="_TileNorthWest"></param>
        public void ReceiveNeighbours(Tile _TileNorth, Tile _TileNorthEast, Tile _TileEast, Tile _TileSouthEast, Tile _TileSouth, Tile _TileSouthWest, Tile _TileWest, Tile _TileNorthWest)
        {
            TileNorth = _TileNorth;
            TileNorthEast = _TileNorthEast;
            TileEast = _TileEast;
            TileSouthEast = _TileSouthEast;
            TileSouth = _TileSouth;
            TileSouthWest = _TileSouthWest;
            TileWest = _TileWest;
            TileNorthWest = _TileNorthWest;
        }

        /// <summary>
        /// Wordt aangeroepen wanneer er op een vakje met een schaakstuk wordt geklikt
        /// </summary>
        public void Select()
        {
            NewTile = Image.FromFile(@"..\..\..\ChessGame\Images\SelectedTile.png");
        }

        /// <summary>
        /// Wordt aangeroepen wanneer de eerste en tweede klik allebei op hetzelfde vakje zijn. 
        /// </summary>
        public void Deselect()
        {
            if (Color == "white")
            {
                NewTile = Image.FromFile(@"..\..\..\ChessGame\Images\WhiteTile.jpg");
            }
            else
            {
                NewTile = Image.FromFile(@"..\..\..\ChessGame\Images\BlackTile.jpg");
            }
        }

        /// <summary>
        /// Teken opnieuw het vakje van dit vakje object
        /// </summary>
        /// <param name="positionX">Waar horizontaal het vakje terecht komt</param>
        /// <param name="positionY">Waar verticaal het vakje terecht komt</param>
        /// <param name="ChessboardBitmap">De Bitmap vanuit Chessboard</param>
        public void AddTileToBitmap(int positionX, int positionY, Bitmap ChessboardBitmap)
        {
            using (Graphics graphics = Graphics.FromImage(ChessboardBitmap))
            {
                graphics.DrawImage(NewTile, positionX, positionY, 50, 50);
            }
        }

        /// <summary>
        /// Teken opnieuw het schaakstuk van dit vakje object bovenop het vakje 
        /// </summary>
        /// <param name="positionX">Waar horizontaal het schaakstuk terecht komt</param>
        /// <param name="positionY">Waar verticaal het schaakstuk terecht komt</param>
        /// <param name="ChessboardBitmap">De Bitmap vanuit Chessboard</param>
        public void AddChessPieceToBitmap(int positionX, int positionY, Bitmap ChessboardBitmap)
        {
            using (Graphics graphics = Graphics.FromImage(ChessboardBitmap))
            {
                 graphics.DrawImage(MyChesspiece.ChessPieceImage, positionX, positionY, 50, 50);
            }
        }

        /// <summary>
        /// Wanneer een vakje gemaakt wordt wordt gekeken of deze zwart of wit moet zijn. Tegelijkertijd wordt een ID (Color) aangewezen
        /// </summary>
        /// <param name="TileColor"></param>
        public Tile(ChessColor TileColor)
        {
            if (TileColor == ChessColor.white)
            {
                NewTile = Image.FromFile(@"..\..\..\ChessGame\Images\WhiteTile.jpg");
                Color = "white";
            }
            else
            {
                NewTile = Image.FromFile(@"..\..\..\ChessGame\Images\BlackTile.jpg");
                Color = "black";
            }
        }
    }
}
