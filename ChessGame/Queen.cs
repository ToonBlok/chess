using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Queen : ChessPiece
    {
        // Checkt of hij langs een tegel is gekomen waardoor de zet niet meer mogelijk is
        private bool checkTilePossible;
        // Houdt bij welke tiles hij al heeft doorlopen
        private Tile CheckTile;
        public Queen(ChessColor Color)
        {
            if (Color == ChessColor.white)
            {
                ChessPieceImage = Image.FromFile(@"..\..\..\ChessGame\Images\piece_white_queen.png");
                ChessPieceColor = "white";
            }
            else
            {
                ChessPieceImage = Image.FromFile(@"..\..\..\ChessGame\Images\piece_black_queen.png");
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
            #region Queen
            // Als het schaakstuk van het eerste geklikte vakje niet hetzelfde kleur heeft als het schaakstuk van het tweede vakje
            if (_Current.MyChesspiece.ChessPieceColor != _ReceivedTile.MyChesspiece?.ChessPieceColor)
            {
                checkTilePossible = true;
                CheckTile = _Current;
                // Hj gaat telkens een verder Noord totdat hij alle tegels heeft afgewerkt en hij bekijkt of hij daarbij de juiste tegel tegenkomt die hij ook kan slaan
                while (CheckTile.TileNorth != null)
                {
                    CheckTile = CheckTile.TileNorth;
                    if (CheckTile.TileSouth.MyChesspiece != null && CheckTile.TileSouth != _Current)
                    {
                        checkTilePossible = false;
                    }
                    else if (_ReceivedTile == CheckTile && checkTilePossible == true)
                    {
                        MoveChesspiece(CheckTile, _Current);
                    }
                }
                checkTilePossible = true;
                CheckTile = _Current;
                // Hj gaat telkens een verder West totdat hij alle tegels heeft afgewerkt en hij bekijkt of hij daarbij de juiste tegel tegenkomt die hij ook kan slaan
                while (CheckTile.TileWest != null)
                {
                    CheckTile = CheckTile.TileWest;
                    if (CheckTile.TileEast.MyChesspiece != null && CheckTile.TileEast != _Current)
                    {
                        checkTilePossible = false;
                    }
                    else if (_ReceivedTile == CheckTile && checkTilePossible == true)
                    {
                        MoveChesspiece(CheckTile, _Current);
                    }
                }
                checkTilePossible = true;
                CheckTile = _Current;
                // Hj gaat telkens een verder Oost totdat hij alle tegels heeft afgewerkt en hij bekijkt of hij daarbij de juiste tegel tegenkomt die hij ook kan slaan
                while (CheckTile.TileEast != null)
                {
                    CheckTile = CheckTile.TileEast;
                    if (CheckTile.TileWest.MyChesspiece != null && CheckTile.TileWest != _Current)
                    {
                        checkTilePossible = false;
                    }
                    else if (_ReceivedTile == CheckTile && checkTilePossible == true)
                    {
                        MoveChesspiece(CheckTile, _Current);
                    }
                }
                checkTilePossible = true;
                CheckTile = _Current;
                // Hj gaat telkens een verder Zuid totdat hij alle tegels heeft afgewerkt en hij bekijkt of hij daarbij de juiste tegel tegenkomt die hij ook kan slaan
                while (CheckTile.TileSouth != null)
                {
                    CheckTile = CheckTile.TileSouth;
                    if (CheckTile.TileNorth.MyChesspiece != null && CheckTile.TileNorth != _Current)
                    {
                        checkTilePossible = false;
                    }
                    else if (_ReceivedTile == CheckTile && checkTilePossible == true)
                    {
                        MoveChesspiece(CheckTile, _Current);
                    }
                }
                checkTilePossible = true;
                CheckTile = _Current;
                // Hj gaat telkens een verder Noord oost totdat hij alle tegels heeft afgewerkt en hij bekijkt of hij daarbij de juiste tegel tegenkomt die hij ook kan slaan
                while (CheckTile.TileNorthEast != null)
                {
                    CheckTile = CheckTile.TileNorthEast;
                    if (CheckTile.TileSouthWest.MyChesspiece != null && CheckTile.TileSouthWest != _Current)
                    {
                        checkTilePossible = false;
                    }
                    else if (_ReceivedTile == CheckTile && checkTilePossible == true)
                    {
                        MoveChesspiece(CheckTile, _Current);
                    }
                }
                checkTilePossible = true;
                CheckTile = _Current;
                // Hj gaat telkens een verder Noord west totdat hij alle tegels heeft afgewerkt en hij bekijkt of hij daarbij de juiste tegel tegenkomt die hij ook kan slaan
                while (CheckTile.TileNorthWest != null)
                {
                    CheckTile = CheckTile.TileNorthWest;
                    if (CheckTile.TileSouthEast.MyChesspiece != null && CheckTile.TileSouthEast != _Current)
                    {
                        checkTilePossible = false;
                    }
                    else if (_ReceivedTile == CheckTile && checkTilePossible == true)
                    {
                        MoveChesspiece(CheckTile, _Current);
                    }
                }
                checkTilePossible = true;
                CheckTile = _Current;
                // Hj gaat telkens een verder Zuid oost totdat hij alle tegels heeft afgewerkt en hij bekijkt of hij daarbij de juiste tegel tegenkomt die hij ook kan slaan
                while (CheckTile.TileSouthEast != null)
                {
                    CheckTile = CheckTile.TileSouthEast;
                    if (CheckTile.TileNorthWest.MyChesspiece != null && CheckTile.TileNorthWest != _Current)
                    {
                        checkTilePossible = false;
                    }
                    else if (_ReceivedTile == CheckTile && checkTilePossible == true)
                    {
                        MoveChesspiece(CheckTile, _Current);
                    }
                }
                checkTilePossible = true;
                CheckTile = _Current;
                // Hj gaat telkens een verder Zuid west totdat hij alle tegels heeft afgewerkt en hij bekijkt of hij daarbij de juiste tegel tegenkomt die hij ook kan slaan
                while (CheckTile.TileSouthWest != null)
                {
                    CheckTile = CheckTile.TileSouthWest;
                    if (CheckTile.TileNorthEast.MyChesspiece != null && CheckTile.TileNorthEast != _Current)
                    {
                        checkTilePossible = false;
                    }
                    else if (_ReceivedTile == CheckTile && checkTilePossible == true)
                    {
                        MoveChesspiece(CheckTile, _Current);
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
            checkTilePossible = false;
        }
    }
}
