using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class King : ChessPiece
    {
        public King(ChessColor Color)
        {
            if (Color == ChessColor.white)
            {
                ChessPieceImage = Image.FromFile(@"..\..\..\ChessGame\Images\piece_white_king.png");
                ChessPieceColor = "white";
            }
            else
            {
                ChessPieceImage = Image.FromFile(@"..\..\..\ChessGame\Images\piece_black_king.png");
                ChessPieceColor = "black";
            }
        }

        /// <summary>
        /// Controleer of je een schaakstuk een goede zet heeft gedaan zodat hij mag plaatvinden
        /// </summary>
        /// <param name="_ReceivedTile"></param>
        /// <param name="_Current"></param>
        public override void MoveStyle(Tile _ReceivedTile, Tile _Current)
        {
            #region King
            // Als het schaakstuk van het eerste geklikte vakje niet hetzelfde kleur heeft als het schaakstuk van het tweede vakje
            if (_Current.MyChesspiece.ChessPieceColor != _ReceivedTile.MyChesspiece?.ChessPieceColor)
            {
                // Move North
                if (_ReceivedTile == _Current.TileNorth)
                {
                    MoveChesspiece(_Current.TileNorth, _Current);
                }
                // Move South
                else if (_ReceivedTile == _Current.TileSouth)
                {
                    MoveChesspiece(_Current.TileSouth, _Current);
                }
                // Move West
                else if (_ReceivedTile == _Current.TileWest)
                {
                    MoveChesspiece(_Current.TileWest, _Current);
                }
                // Move East
                else if (_ReceivedTile == _Current.TileEast)
                {
                    MoveChesspiece(_Current.TileEast, _Current);
                }
                // Move South east
                else if (_ReceivedTile == _Current.TileSouthEast)
                {
                    MoveChesspiece(_Current.TileSouthEast, _Current);
                }
                // Move South west
                else if (_ReceivedTile == _Current.TileSouthWest)
                {
                    MoveChesspiece(_Current.TileSouthWest, _Current);
                }
                // Move North east
                else if (_ReceivedTile == _Current.TileNorthEast)
                {
                    MoveChesspiece(_Current.TileNorthEast, _Current);
                }
                // Move North west
                else if (_ReceivedTile == _Current.TileNorthWest)
                {
                    MoveChesspiece(_Current.TileNorthWest, _Current);
                }
            }
            #endregion
        }
        /// <summary>
        /// Zodra MoveStyle een pad gevonden heeft, laat deze methode de echte bewegingen plaatsvinden
        /// </summary>
        /// <param name="_PieceToTile"></param>
        /// <param name="_Current"></param>
        protected override void MoveChesspiece(Tile _PieceToTile, Tile _Current)
        {
            CheckKingLose(_PieceToTile);
            _PieceToTile.MyChesspiece = _Current.MyChesspiece;
            _Current.MyChesspiece = null;
            _Current.legalMove = true;
        }
    }
}
