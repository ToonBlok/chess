using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    static class ChessApp
    {
        static void Main()
        {
            // Uncomment om het hele spel te starten
            #region Normale start
            StartScreen StartScreen = new StartScreen();
            StartScreen.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(StartScreen);

            if (StartScreen.startButtonPushed == true)
            {
                Chessboard Chessboard = new Chessboard(StartScreen.playerNameOne, StartScreen.playerNameTwo);
                Chessboard.StartPosition = FormStartPosition.CenterScreen;
                Application.Run(Chessboard);
            }
            #endregion

            // Uncomment om alleen specifieke delen van het spel te starten, comment region Normal Start hierboven
            #region Quick start
            //Chessboard chessboard = new Chessboard("Toon", "Andre");
            //chessboard.StartPosition = FormStartPosition.CenterScreen;
            //Application.Run(chessboard);
            #endregion
        }
    }
}
