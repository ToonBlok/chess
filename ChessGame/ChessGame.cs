using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public enum ChessColor
    {
        black,
        white
    };

    class ChessGame
    {
        /// <summary>
        /// Vul het schaakbord met zwarte en witte vakjes. Elke keer dat row 0 is (wanneer een nieuw rijtje schaakvakjes begint) wordt de int colorInt 
        /// omgedraaid waardoor er om de beurt een zwart of wit vakje ingeladen wordt.
        /// </summary>
        /// <param name="ChessboardTileArray">Array die vakjes bevat, in de constructor wordt de array bij het onstaan van deze class al gelijk gezet aan een
        /// soorgelijke array in de class Chessboard.
        /// </param>
        public void FillArrayTiles(ref Tile[,] ChessboardTileArray)
        {
            int colorInt = 1;
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    if (row == 0 && column > 0)
                    {
                        if (colorInt == 1)
                        {
                            colorInt = 0;
                        }
                        else
                        {
                            colorInt = 1;
                        }
                    }
                    if (colorInt == 1)
                    {
                        ChessboardTileArray[column, row] = new Tile(ChessColor.white);
                        colorInt = 0;
                    }
                    else
                    {
                        ChessboardTileArray[column, row] = new Tile(ChessColor.black);
                        colorInt = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Na het aanmaken van het schaakbord wordt op de juiste plekken een schaakstuk gezet
        /// </summary>
        /// <param name="ChessboardTileArray">Array die vakjes bevat, in de constructor wordt de array bij het onstaan van deze class al gelijk gezet aan een
        /// soorgelijke array in de class Chessboard.</param>
        public void FillArrayChesspieces(ref Tile[,] ChessboardTileArray)
        {
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    if ((row == 0 && column == 0) || (row == 7 && column == 0))
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new Rook(ChessColor.black);
                    }
                    else if ((row == 1 && column == 0) || (row == 6 && column == 0))
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new Knight(ChessColor.black);
                    }
                    else if ((row == 2 && column == 0) || (row == 5 && column == 0))
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new Bishop(ChessColor.black);
                    }
                    else if (row == 3 && column == 0)
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new Queen(ChessColor.black);
                    }
                    else if (row == 4 && column == 0)
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new King(ChessColor.black);
                    }
                    else if (column == 1)
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new Pawn(ChessColor.black);
                    }
                    else if ((row == 0 && column == 7) || (row == 7 && column == 7))
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new Rook(ChessColor.white);
                    }
                    else if ((row == 1 && column == 7) || (row == 6 && column == 7))
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new Knight(ChessColor.white);
                    }
                    else if ((row == 2 && column == 7) || (row == 5 && column == 7))
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new Bishop(ChessColor.white);
                    }
                    else if (row == 3 && column == 7)
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new Queen(ChessColor.white);
                    }
                    else if (row == 4 && column == 7)
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new King(ChessColor.white);
                    }
                    else if (column == 6)
                    {
                        ChessboardTileArray[column, row].MyChesspiece = new Pawn(ChessColor.white);
                    }
                }
            }
        }

        // Variabelen die alleen gebruikt worden in de DiscoverNeighbours methode
        #region DiscoverNeighbours variables
        private Tile TileNorth;
        private Tile TileNorthEast;
        private Tile TileEast;
        private Tile TileSouthEast;
        private Tile TileSouth;
        private Tile TileSouthWest;
        private Tile TileWest;
        private Tile TileNorthWest;
        private int myNeighbourNorth;
        private int myNeighbourEast;
        private int myNeighbourSouth;
        private int myNeighbourWest;
        #endregion
        /// <summary>
        /// Neemt een vakje in een positie uit de TileArray en bepaalt voordat vakje alle 8 buren. Aan het einde van de methode worden deze buren naar het vakje gestuurd.
        /// </summary>
        /// <param name="ChessboardTileArray">Array die vakjes bevat, in de constructor wordt de array bij het onstaan van deze class al gelijk gezet aan een
        /// soorgelijke array in de class Chessboard.</param>
        public void DetermineNeighbours(ref Tile[,] ChessboardTileArray)
        {
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    // North
                    myNeighbourNorth = column - 1;
                    if (myNeighbourNorth < 0)
                    {
                        TileNorth = null;
                    }
                    else
                    {
                        TileNorth = ChessboardTileArray[myNeighbourNorth, row];
                    }

                    // East
                    myNeighbourEast = row + 1;
                    if (myNeighbourEast > 7)
                    {
                        TileEast = null;
                    }
                    else
                    {
                        TileEast = ChessboardTileArray[column, myNeighbourEast];
                    }

                    // South
                    myNeighbourSouth = column + 1;
                    if (myNeighbourSouth > 7)
                    {
                        TileSouth = null;
                    }
                    else
                    {
                        TileSouth = ChessboardTileArray[myNeighbourSouth, row];
                    }

                    // West
                    myNeighbourWest = row - 1;
                    if (myNeighbourWest < 0)
                    {
                        TileWest = null;
                    }
                    else
                    {
                        TileWest = ChessboardTileArray[column, myNeighbourWest];
                    }

                    // North east
                    if (myNeighbourNorth < 0 || myNeighbourEast > 7)
                    {
                        TileNorthEast = null;
                    }
                    else
                    {
                        TileNorthEast = ChessboardTileArray[myNeighbourNorth, myNeighbourEast];
                    }

                    // South east
                    if (myNeighbourEast > 7 || myNeighbourSouth > 7)
                    {
                        TileSouthEast = null;
                    }
                    else
                    {
                        TileSouthEast = ChessboardTileArray[myNeighbourSouth, myNeighbourEast];
                    }

                    // South west
                    if (myNeighbourSouth > 7 || myNeighbourWest < 0)
                    {
                        TileSouthWest = null;
                    }
                    else
                    {
                        TileSouthWest = ChessboardTileArray[myNeighbourSouth, myNeighbourWest];
                    }

                    // North west
                    if (myNeighbourNorth < 0 || myNeighbourWest < 0)
                    {
                        TileNorthWest = null;
                    }
                    else
                    {
                        TileNorthWest = ChessboardTileArray[myNeighbourNorth, myNeighbourWest];
                    }

                    // Stuur de buur objecten naar het vakje
                    ChessboardTileArray[column, row].ReceiveNeighbours(TileNorth, TileNorthEast, TileEast, TileSouthEast, TileSouth, TileSouthWest, TileWest, TileNorthWest);
                }
            }

        }
        public ChessGame()
        {
            
        }
    }
}
