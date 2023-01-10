using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe_ALDIL1.View;
using TicTacToe_ALDIL1.Controller;
using TicTacToe_ALDIL1.Model;

namespace TicTacToe_ALDIL1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            GameController game = new GameController();
            ViewController view = new ViewController();
            MainController mainController= new MainController(game,view);
        }
    }
}
