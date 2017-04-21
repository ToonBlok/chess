using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    abstract class ChessPiece
    {
        // De kleur van het schaakstuk
        public string ChessPieceColor { get; protected set; }
        // Het plaatje van het schaakstuk
        public Image ChessPieceImage { get; protected set; }
        // De manier van bewegen van het schaakstuk (is uniek voor elk stuk) wordt hier bepaald
        public abstract void MoveStyle(Tile _ReceivedTile, Tile _Current);
        // Nadat de manier van bewegen van het schaakstuk bepaald is wordt deze methode aangeroepen
        protected abstract void MoveChesspiece(Tile _PieceToTile, Tile _Current);
        /// <summary>
        /// Kijkt of de tegel waar hij naar toe gaat een king bevat als de zet al mogelijk is. Als hij een king bevat herstart hij het programma en zegt hij dat je hebt gewonnen.
        /// </summary>
        /// <param name="_PieceToTile"></param>
        protected void CheckKingLose(Tile _PieceToTile)
        {
            if(_PieceToTile.MyChesspiece is King)
            {
                if (_PieceToTile.MyChesspiece.ChessPieceColor == "black")
                {
                    MessageBox.Show("Wit heeft gewonnen!", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Zwart heeft gewonnen!", "Error", MessageBoxButtons.OK);
                }
                Application.Restart();
            }
        }
    }
}
