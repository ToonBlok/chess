using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame 
{
    class Pawn : ChessPiece
    {
        // Check if the pawn has already done a first move
        private bool firstMove;
        public Pawn(ChessColor Color)
        {
            if (Color == ChessColor.white)
            {
                ChessPieceImage = Image.FromFile(@"..\..\..\ChessGame\Images\piece_white_pawn.png");
                ChessPieceColor = "white";
            }
            else
            {
                ChessPieceImage = Image.FromFile(@"..\..\..\ChessGame\Images\piece_black_pawn.png");
                ChessPieceColor = "black";
            }
        }

        /// <summary>
        /// Controleer of je een schaakstuk een of twee vakjes kan laten bewegen (als de pawn wit is alleen naar noorden, en als de pawn zwart is alleen naar zuiden)
        /// </summary>
        /// <param name="_ReceivedTile"></param>
        /// <param name="_Current"></param>
        public override void MoveStyle(Tile _ReceivedTile, Tile _Current)
        {
            #region Pawn
            // Als het schaakstuk van het eerste geklikte vakje niet hetzelfde kleur heeft als het schaakstuk van het tweede vakje
            if (_Current.MyChesspiece.ChessPieceColor != _ReceivedTile.MyChesspiece?.ChessPieceColor)
            {
                // Als het schaakstuk van het eerste geklikte vakje wit is (dan mag hij alleen naar het noorden bewegen)
                if (_Current.MyChesspiece.ChessPieceColor == "white")
                {
                    // Move north x1
                    if (_ReceivedTile == _Current.TileNorth && _Current.TileNorth.MyChesspiece == null)
                    {
                        MoveChesspiece(_Current.TileNorth, _Current);
                    }
                    // Move north x2
                    else if (_ReceivedTile == _Current.TileNorth.TileNorth && firstMove == false && _Current.TileNorth.MyChesspiece == null && _Current.TileNorth.TileNorth.MyChesspiece == null)
                    {
                        MoveChesspiece(_Current.TileNorth.TileNorth, _Current);
                    }
                    // Capture north east (can only move diagonally when capturing)
                    else if (_ReceivedTile == _Current.TileNorthEast && _Current.TileNorthEast.MyChesspiece != null)
                    {
                        MoveChesspiece(_Current.TileNorthEast, _Current);
                    }
                    // Capture north west (can only move diagonally when capturing)
                    else if (_ReceivedTile == _Current.TileNorthWest && _Current.TileNorthWest.MyChesspiece != null)
                    {
                        MoveChesspiece(_Current.TileNorthWest, _Current);
                    }
                }
                // Als het schaakstuk van het eerste geklikte vakje zwart is (dan mag hij alleen naar het zuiden bewegen)
                else
                {
                    // Move south x1
                    if (_ReceivedTile == _Current.TileSouth && _Current.TileSouth.MyChesspiece == null)
                    {
                        MoveChesspiece(_Current.TileSouth, _Current);
                    }
                    // Move south x2
                    else if (_ReceivedTile == _Current.TileSouth.TileSouth && firstMove == false && _Current.TileSouth.MyChesspiece == null && _Current.TileSouth.TileSouth.MyChesspiece == null)
                    {
                        MoveChesspiece(_Current.TileSouth.TileSouth, _Current);
                    }
                    // Capture south east (can only move diagonally when capturing)
                    else if (_ReceivedTile == _Current.TileSouthEast && _Current.TileSouthEast.MyChesspiece != null)
                    {
                        MoveChesspiece(_Current.TileSouthEast, _Current);
                    }
                    // Capture south west (can only move diagonally when capturing)
                    else if (_ReceivedTile == _Current.TileSouthWest && _Current.TileSouthWest.MyChesspiece != null)
                    {
                        MoveChesspiece(_Current.TileSouthWest, _Current);
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
            firstMove = true;
            _PieceToTile.MyChesspiece = _Current.MyChesspiece;
            _Current.legalMove = true;
            // Als het vakje noord x2 null is, start dan promotie op
            if (_Current.MyChesspiece?.ChessPieceColor == "white" && _Current.TileNorth.TileNorth == null)
            {
                Promotion(ChessColor.white, _PieceToTile);
            }
            // Als het vakje zuid x2 null is, start dan promotie op
            else if (_Current.MyChesspiece?.ChessPieceColor == "black" && _Current.TileSouth.TileSouth == null)
            {
                Promotion(ChessColor.black, _PieceToTile);
            }
            _Current.MyChesspiece = null;
        }

        /// <summary>
        /// Promote de schaakstuk op het vakje dat binnenkomt
        /// </summary>
        /// <param name="Color"></param>
        /// <param name="PromotionLocation"></param>
        private void Promotion(ChessColor Color, Tile PromotionLocation)
        {
            Promotion PawnPromotion = new Promotion();
            PawnPromotion.ShowDialog();
            // Switch de Pawn voor de gekozen schaakstuk
            if (PawnPromotion.chessPiece == "knight")
            {
                PromotionLocation.MyChesspiece = new Knight(Color);
            }
            else if (PawnPromotion.chessPiece == "queen")
            {
                PromotionLocation.MyChesspiece = new Queen(Color);
            }
            else if (PawnPromotion.chessPiece == "bishop")
            {
                PromotionLocation.MyChesspiece = new Bishop(Color);
            }
            else
            {
                PromotionLocation.MyChesspiece = new Rook(Color);
            }
        }
    }
}