using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Knight : ChessPiece
    {
        public Knight(ChessColor Color)
        {
            if (Color == ChessColor.white)
            {
                ChessPieceImage = Image.FromFile(@"..\..\..\ChessGame\Images\piece_white_knight.png");
                ChessPieceColor = "white";
            }
            else
            {
                ChessPieceImage = Image.FromFile(@"..\..\..\ChessGame\Images\piece_black_knight.png");
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
            #region Knight
            // Als het schaakstuk van het eerste geklikte vakje niet hetzelfde kleur heeft als het schaakstuk van het tweede vakje
            if (_Current.MyChesspiece.ChessPieceColor != _ReceivedTile.MyChesspiece?.ChessPieceColor)
            {
                // Checkt of er een Oost vakje aanwezig is
                if (_Current.TileEast != null)
                {
                    // Laat als de tegel overeenkomt hem 1x Oost en daarna Zuid oost bewegen
                    if (_ReceivedTile == _Current.TileEast.TileSouthEast)
                    {
                        MoveChesspiece(_Current.TileEast.TileSouthEast, _Current);
                    }
                    // Laat als de tegel overeenkomt hem 1x Oost en daarna Noord oost bewegen
                    else if (_ReceivedTile == _Current.TileEast.TileNorthEast)
                    {
                        MoveChesspiece(_Current.TileEast.TileNorthEast, _Current);
                    }
                }
                // Checkt of er een Zuid vakje aanwezig is
                if (_Current.TileSouth != null)
                {
                    // Laat als de tegel overeenkomt hem 1x Zuid en daarna Zuid west bewegen
                    if (_ReceivedTile == _Current.TileSouth.TileSouthWest)
                    {
                        MoveChesspiece(_Current.TileSouth.TileSouthWest, _Current);
                    }
                    // Laat als de tegel overeenkomt hem 1x Zuid en daarna Zuid oost bewegen
                    else if (_ReceivedTile == _Current.TileSouth.TileSouthEast)
                    {
                        MoveChesspiece(_Current.TileSouth.TileSouthEast, _Current);
                    }
                }
                // Checkt of er een West vakje aanwezig is
                if (_Current.TileWest != null)
                {
                    // Laat als de tegel overeenkomt hem 1x West en daarna Zuid west bewegen
                    if (_ReceivedTile == _Current.TileWest.TileSouthWest)
                    {
                        MoveChesspiece(_Current.TileWest.TileSouthWest, _Current);
                    }
                    // Laat als de tegel overeenkomt hem 1x West en daarna Noord west bewegen
                    else if (_ReceivedTile == _Current.TileWest.TileNorthWest)
                    {
                        MoveChesspiece(_Current.TileWest.TileNorthWest, _Current);
                    }
                }
                // Checkt of er een Noord vakje aanwezig is
                if (_Current.TileNorth != null)
                {
                    // Laat als de tegel overeenkomt hem 1x Noord en daarna Noord west bewegen
                    if (_ReceivedTile == _Current.TileNorth.TileNorthWest)
                    {
                        MoveChesspiece(_Current.TileNorth.TileNorthWest, _Current);
                    }
                    // Laat als de tegel overeenkomt hem 1x Noord en daarna Noord oost bewegen
                    if (_ReceivedTile == _Current.TileNorth.TileNorthEast)
                    {
                        MoveChesspiece(_Current.TileNorth.TileNorthEast, _Current);
                    }
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