using System;
using System.Windows.Forms;

using Tetris.Controller;

namespace Tetris
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TetrisController gameController = new TetrisController();
            gameController.StartGame();
        }
    }
}
